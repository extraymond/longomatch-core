﻿//
//  Copyright (C) 2015 Fluendo S.A.
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LongoMatch.Core.Common;
using LongoMatch.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LongoMatch.Core.Serialization
{
	/// <summary>
	/// Parses <see cref="IStorable"/> objects traversing all its children objects
	/// looking for changes using the IsChanged property.
	/// This can be used before storing an <see cref="IStorable"/> in the database to
	/// know which updates are really needed to persist the object and its children.
	/// </summary>
	public class ObjectChangedParser
	{

		List<StorableStackObject> stack;
		List<IStorable> changedStorables; 
		List<IStorable> childrenStorables; 
		internal List<object> parsed;
		StorableStackObject current;
		IContractResolver resolver;
		JsonSerializerSettings settings;
		bool reset;

		public ObjectChangedParser ()
		{
		}

		/// <summary>
		/// Parse an <see cref="IStorable"/> listing all its children
		/// and the ones that changed.
		/// </summary>
		/// <param name="children">List of children.</param>
		/// <param name="changedStorables">List of storables with changes.</param>
		/// <param name="storable">The storable object to parse.</param>
		/// <param name="settings">The serialization settings.</param>
		/// <param name="reset">If set to <c>true</c> reset the IsChanged flag.</param>
		public bool Parse(out List<IStorable> children, out List<IStorable> changedStorables,
			IStorable storable, JsonSerializerSettings settings, bool reset = true)
		{
			bool ret = ParseInternal (out children , out changedStorables, storable, settings, reset);
			if (ret && stack.Count != 0) {
				Log.Error ("Stack should be empty");
				return false;
			}
			stack.Clear ();
			parsed.Clear ();
			return ret;
		}

		internal bool ParseInternal(out List<IStorable> children, out List<IStorable> changedStorables,
			IStorable value, JsonSerializerSettings settings, bool reset = true)
		{
			stack = new List<StorableStackObject> ();
			parsed = new List<object> ();
			this.changedStorables = changedStorables = new List<IStorable> ();
			children = childrenStorables = new List<IStorable> ();
			resolver = settings.ContractResolver ?? new DefaultContractResolver ();
			this.settings = settings;
			this.reset = reset;
			try {
				CheckValue (value);
				return true;
			} catch (Exception ex) {
				Log.Exception (ex);
				children = null;
				changedStorables = null;
				return false;
			}
		}

		void CheckValue (object value)
		{
			IStorable storable;

			if (value == null) {
				return;
			} else if (parsed.Any (v => Object.ReferenceEquals (v, value))) {
				// Value already parsed, return to avoid dependency cycles.
				return;
			}

			storable = value as IStorable;

			if (storable != null) {
				current = new StorableStackObject (storable);
				stack.Add (current);
				if (storable != stack[0].storable) {
					childrenStorables.Add (storable);
				}
			}

			JsonContract valueContract = resolver.ResolveContract(value.GetType());

			if (valueContract is JsonObjectContract) {
				CheckObject (value, valueContract as JsonObjectContract);
			} else if (valueContract is JsonArrayContract) {
				CheckEnumerable (value as IEnumerable, valueContract as JsonArrayContract);
			} else if (valueContract is JsonDictionaryContract) {
				CheckEnumerable ((value as IDictionary).Values, valueContract as JsonArrayContract);
			} else {
				// Skip primitive value
			}

			if (storable != null) {
				stack.Remove (current);
				if (stack.Count > 0) {
					current = stack [stack.Count - 1];
				} else {
					current = null;
				}
			}
		}

		void CheckObject (object value, JsonObjectContract contract) {
			parsed.Add (value);


			for (int index = 0; index < contract.Properties.Count; index++)
			{
				JsonProperty property = contract.Properties[index];
				try
				{
					object memberValue;

					if (property.PropertyName == "IsChanged") {
						IValueProvider provider = property.ValueProvider;
						bool changed = (bool) provider.GetValue(value);
						if (changed) {
							if (!current.addedToChangedList) {
								changedStorables.Add (current.storable);
								current.addedToChangedList = true;
							}
							if (reset) {
								provider.SetValue (value, false);
							}
						}
					} else {
						if (!CalculatePropertyValues(value, property, out memberValue))
							continue;
						CheckValue(memberValue);
					}
				}
				catch (Exception ex)
				{
				}
			}
		}

		void CheckEnumerable (IEnumerable values, JsonArrayContract contract) {
			foreach (object value in values)
			{
				CheckValue (value);
			}
		}

		bool CalculatePropertyValues(object value, JsonProperty property, out object memberValue)
		{
			if (!property.Ignored && property.Readable)
			{
				memberValue = property.ValueProvider.GetValue(value);
				return true;
			} else {
				memberValue = null;
				return false;
			}
		}
	}

	class StorableStackObject {
		public IStorable storable;
		public bool addedToChangedList;

		public StorableStackObject (IStorable storable) {
			this.storable = storable;
			addedToChangedList = false;
		}
	}
}
