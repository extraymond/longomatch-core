//
//  Copyright (C) 2015 jl
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
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using LongoMatch.Core.Interfaces;
using LongoMatch.Core.Common;

namespace LongoMatch.Services.Services
{
	public class FileStorage : IStorage
	{
		private string basePath;
		private bool deleteOnDestroy;

		public FileStorage (string basePath, bool deleteOnDestroy = false)
		{
			this.basePath = basePath;
			this.deleteOnDestroy = deleteOnDestroy;
			// Make sure to create the directory
			if (!Directory.Exists (basePath)) {
				Log.Information ("Creating directory " + basePath);
				Directory.CreateDirectory (basePath);
			}
		}

		~FileStorage ()
		{
			if (deleteOnDestroy)
				Reset ();
		}

		public string BasePath {
			get {
				return basePath;
			}
		}

		private string ResolvePath<T> ()
		{
			string typePath = Path.Combine (basePath, ResolveType (typeof(T)));

			if (!Directory.Exists (typePath)) {
				Log.Information ("Creating directory " + typePath);
				Directory.CreateDirectory (typePath);
			}
			return typePath;
		}

		// For a T being a Dashboard, the expected directory should be dashboards
		// What we have so far is this:
		// type -> dir -> extension
		// Dashboard -> analysis (Config.AnalysisDir) -> lct (Constants.CAT_TEMPLATE_EXT)
		// Team -> teams (Config.TeamsDir) -> ltt (Constants.TEAMS_TEMPLATE_EXT)
		static private string ResolveType (Type t)
		{
			// For a type like TestTempltesService.MyService.Template split it by . to only
			// use the last part
			string[] parts = t.ToString ().Split ('.');
			string part = parts [parts.Length - 1];
			// Make it lowercase so we end into something like this: baseDir/template
			return part.ToLower ();
		}

		static private string GetExtension (Type t)
		{
			string sType = ResolveType (t);

			// Add the different cases of t
			if (sType == "dashboard") {
				return Constants.CAT_TEMPLATE_EXT;
			} else if (sType == "team") {
				return Constants.TEAMS_TEMPLATE_EXT;
			} else {
				return ".json";
			}
		}

		#region IStorage implementation

		public T Retrieve<T> (Guid id) where T : IStorable
		{
			string typePath = ResolvePath<T> ();
			string path = Path.Combine (typePath, id.ToString () + GetExtension (typeof(T)));

			if (File.Exists (path)) {
				T t = Serializer.LoadSafe<T> (path);
				Log.Information ("Retrieving " + path);
				return t;
			}
			return default (T);
		}

		public List<T> RetrieveAll<T> () where T : IStorable
		{
			List<T> l = new List<T> ();
			string typePath = ResolvePath<T> ();
			string extension = GetExtension (typeof(T));

			// Get the name of the class and look for a folder on the
			// basePath with the same name
			foreach (string path in Directory.GetFiles (typePath, "*" + extension)) {
				T t = (T)Serializer.LoadSafe<T> (path);
				Log.Information ("Retrieving " + path);
				l.Add (t);
			}
			return l;
		}

		public List<T> Retrieve<T> (Dictionary<string,object> dict) where T : IStorable
		{
			List<T> l = new List<T> ();
			string typePath = ResolvePath<T> ();
			string extension = GetExtension (typeof(T));

			if (dict == null)
				return RetrieveAll<T> ();

			// Get the name of the class and look for a folder on the
			// basePath with the same name
			foreach (string path in Directory.GetFiles (typePath, "*" + extension)) {
				T t = (T)Serializer.LoadSafe<T> (path);
				bool matches = true;

				foreach (KeyValuePair<string, object> entry in dict) {
					FieldInfo finfo = t.GetType ().GetField (entry.Key);
					PropertyInfo pinfo = t.GetType ().GetProperty (entry.Key);
					object ret = null;

					if (pinfo == null && finfo == null) {
						Log.Warning ("Property/Field does not exist " + entry.Key);
						matches = false;
						break;
					}

					if (pinfo != null)
						ret = pinfo.GetValue (t, null);
					else
						ret = finfo.GetValue (t);

					if (ret == null && entry.Value != null) {
						matches = false;
						break;
					}

					if (ret != null && entry.Value == null) {
						matches = false;
						break;
					}

					if (ret.GetType () == entry.Value.GetType ()) {
						if (!Object.Equals (ret, entry.Value)) {
							matches = false;
						}
					}
				}

				if (matches) {
					Log.Information ("Retrieving " + path);
					l.Add (t);
				}
			}
			return l;
		}


		public void Store<T> (T t) where T : IStorable
		{
			string typePath = ResolvePath<T> ();
			string extension = GetExtension (typeof(T));

			// Save the object as a file on disk
			string path = Path.Combine (typePath, t.ID.ToString ()) + extension;
			Log.Information ("Storing " + path);
			Serializer.Save<T> (t, path);
		}

		public void Delete<T> (T t) where T : IStorable
		{
			string typePath = ResolvePath<T> ();
			string extension = GetExtension (typeof(T));

			try {
				string path = Path.Combine (typePath, t.ID.ToString ()) + extension; 
				Log.Information ("Deleting " + path);
				File.Delete (path);
			} catch (Exception ex) {
				Log.Exception (ex);
			}
		}

		public void Reset ()
		{
			if (File.Exists (basePath)) {
				Log.Information ("Deleting " + basePath + " recursively");
				Directory.Delete (basePath, true);
			}
		}

		#endregion

		/// <summary>
		/// Retrieves an object of type T from a file path
		/// </summary>
		/// <returns>The object found.</returns>
		/// <param name="from">The file path to retrieve the object from</param>
		/// <typeparam name="T">The type of the object.</typeparam>
		public static T RetrieveFrom<T> (string from) where T : IStorable
		{
			T t;

			Log.Information ("Loading " + from);
			t = (T)Serializer.LoadSafe<T> (from);
			return t;
		}

		/// <summary>
		/// Stores an object of type T at file at
		/// </summary>
		/// <param name="t">The object to store</param>
		/// <param name="at">The filename to store the object</param>
		/// <typeparam name="T">The type of the object.</typeparam>
		public static void StoreAt<T> (T t, string at) where T : IStorable
		{
			Log.Information ("Saving " + t.ID.ToString () + " to " + at);

			if (File.Exists (at)) {
				throw new Exception ("A file already exists at " + at);
			}

			if (!Directory.Exists (Path.GetDirectoryName (at))) {
				Directory.CreateDirectory (Path.GetDirectoryName (at));
			}

			/* Don't cach the Exception here to chain it up */
			Serializer.Save<T> ((T)t, at);
		}
	}
}
