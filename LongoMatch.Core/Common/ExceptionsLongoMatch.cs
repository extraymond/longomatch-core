﻿//
//  Copyright (C) 2013 Andoni Morales Alastruey
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
using LongoMatch.Core.Store.Templates;
using VAS.Core;
using VAS.Core.Interfaces;
using VAS.Core.Store.Templates;

namespace LongoMatch.Core.Common
{
	public class SubstitutionException: Exception
	{
		public SubstitutionException (string error) : base (error)
		{
		}
	}

	public class TemplateNotFoundException<T>: Exception where T: ITemplate
	{
		public TemplateNotFoundException (string name) :
			base (GenerateMessage (name))
		{
		}

		private static string GenerateMessage (string name)
		{
			if (typeof(T) == typeof(Team)) {
				return Catalog.GetString ("Team not found:\n") + name;
			} else if (typeof(T) == typeof(Dashboard)) {
				return Catalog.GetString ("Dashboard not found:\n") + name;
			} else {
				return Catalog.GetString ("Template not found:\n") + name;
			}
		}
	}
}