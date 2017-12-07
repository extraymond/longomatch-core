﻿//
//  Copyright (C) 2017 Andoni Morales Alastruey
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
using System.Collections.Generic;
using System.Linq;
using LongoMatch.Core.Hotkeys;
using LongoMatch.Core.ViewModel;
using LongoMatch.Services.State;
using VAS.Core.Common;
using VAS.Core.Events;
using VAS.Core.Hotkeys;
using VAS.Core.Interfaces.MVVMC;
using VAS.Core.MVVMC;
using VAS.Core.Store;
using VAS.Core.ViewModel;
using VAS.Services.Controller;
using Constants = VAS.Core.Common.Constants;

namespace LongoMatch.Services.Controller
{
	[Controller (ProjectAnalysisState.NAME)]
	[Controller (LiveProjectAnalysisState.NAME)]
	[Controller (FakeLiveProjectAnalysisState.NAME)]
	[Controller (LightLiveProjectState.NAME)]
	public class LMTaggingController : TaggingController
	{
		public override void SetViewModel (IViewModel viewModel)
		{
			base.SetViewModel (viewModel);
		}

		public override IEnumerable<KeyAction> GetDefaultKeyActions ()
		{
			List<KeyAction> keyActions = (List<KeyAction>)base.GetDefaultKeyActions ();

			KeyAction action = new KeyAction (
				App.Current.HotkeysService.GetByName (LMGeneralUIHotkeys.START_HOMETEAM_TAGGING),
				() => HandleTeamTagging (((LMProjectVM)project).HomeTeam, string.Empty));
			keyActions.Add (action);

			action = new KeyAction (
				App.Current.HotkeysService.GetByName (LMGeneralUIHotkeys.START_AWAYTEAM_TAGGING),
				() => HandleTeamTagging (((LMProjectVM)project).AwayTeam, string.Empty));
			keyActions.Add (action);

			return keyActions;
		}

		protected override TimelineEventVM CreateTimelineEventVM (EventType type, Time start, Time stop, Time eventTime, Image miniature)
		{
			var evt = project.Model.CreateEvent (type, start, stop, eventTime, miniature,
											  project.Model.EventsByType (type).Count + 1);

			return new TimelineEventVM () { Model = evt };
		}

		void HandleTeamTagging (LMTeamVM team, string taggedPlayer)
		{
			team.Tagged = true;
			// limitation to the number of temporal contexts that can be created
			int position = taggedPlayer.Length;
			if (position == 3) {
				HandleTaggedPlayer (team, taggedPlayer);
			}

			KeyTemporalContext tempContext = new KeyTemporalContext { };
			for (int i = 0; i < 10; i++) {
				string newTaggedPlayer = taggedPlayer + i;
				KeyAction action = new KeyAction (new KeyConfig {
					Name = taggedPlayer,
					Key = App.Current.Keyboard.ParseName (i.ToString ())
				}, () => HandleTeamTagging (team, newTaggedPlayer));
				tempContext.AddAction (action);
			}
			tempContext.Duration = Constants.TEMP_TAGGING_DURATION;
			tempContext.ExpiredTimeAction = () => HandleTaggedPlayer (team, taggedPlayer);

			App.Current.KeyContextManager.AddContext (tempContext);
		}

		void HandleTaggedPlayer (LMTeamVM team, string taggedPlayer)
		{
			if (taggedPlayer != string.Empty) {
				PlayerVM player = team.ViewModels.FirstOrDefault (x => ((LMPlayerVM)x).Number == Convert.ToInt32 (taggedPlayer));
				if (player != null) {
					App.Current.EventsBroker.Publish (new TagPlayerEvent {
						Player = player,
						Team = team,
						Modifier = ButtonModifier.None,
						Sender = player
					});
				}
			}
		}
	}
}
