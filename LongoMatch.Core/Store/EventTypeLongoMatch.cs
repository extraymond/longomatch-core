﻿//
//  Copyright (C) 2016 dfernandez
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
using VAS.Core.Store;

namespace LongoMatch.Core.Store
{
	[Serializable]
	public class EventTypeLongoMatch : EventType
	{
		[Serializable]
		public class PenaltyCardEventType: EventType
		{
			public override Color Color {
				get {
					return PenaltyCard != null ? PenaltyCard.Color : null;
				}
				set {
					if (PenaltyCard != null) {
						PenaltyCard.Color = value;
					}
				}
			}

			public override string Name {
				get {
					return PenaltyCard != null ? PenaltyCard.Name : null;
				}
				set {
					if (PenaltyCard != null) {
						PenaltyCard.Name = value;
					}
				}
			}

			public PenaltyCard PenaltyCard {
				get;
				set;
			}
		}

		[Serializable]
		public class ScoreEventType: EventType
		{
			public override string Name {
				get {
					return Score != null ? Score.Name : null;
				}
				set {
					if (Score != null) {
						Score.Name = value;
					}
				}
			}

			public Score Score {
				get;
				set;
			}
		}

		[Serializable]
		public class SubstitutionEventType: EventType
		{
			public SubstitutionEventType ()
			{
				ID = Constants.SubsID;
				Name = Catalog.GetString ("Substitution");
			}

			public override bool Equals (object obj)
			{
				SubstitutionEventType sc = obj as SubstitutionEventType;
				if (sc == null)
					return false;
				return sc.ID == ID;
			}

			public override int GetHashCode ()
			{
				return ID.GetHashCode ();
			}
		}
	}
}
