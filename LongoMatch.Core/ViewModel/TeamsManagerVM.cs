﻿//
//  Copyright (C) 2016 Fluendo S.A.
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
using System.Collections.Generic;
using LongoMatch.Core.Interfaces;
using LongoMatch.Core.Store.Templates;
using VAS.Core;
using VAS.Core.Common;
using VAS.Core.Store;
using VAS.Core.Store.Templates;
using VAS.Core.ViewModel;

namespace LongoMatch.Core.ViewModel
{
	/// <summary>
	/// ViewModel for the teams manager.
	/// </summary>
	public class TeamsManagerVM : TemplatesManagerViewModel<Team, TeamVM, Player, PlayerVM>, ILMTeamTaggerDealer, ILMTeamEditorDealer
	{
		CountLimitationBarChartVM chartVM;

		public TeamsManagerVM ()
		{
			LoadedTemplate = new LMTeamVM ();
			NewCommand.Icon = App.Current.ResourcesLocator.LoadIcon ("vas-add", StyleConf.TemplatesIconSize);
			SaveCommand.Icon = App.Current.ResourcesLocator.LoadIcon ("vas-save", StyleConf.TemplatesIconSize);
			DeleteCommand.Icon = App.Current.ResourcesLocator.LoadIcon ("vas-delete", StyleConf.TemplatesIconSize);
			ExportCommand.Icon = App.Current.ResourcesLocator.LoadIcon ("lm-export", StyleConf.TemplatesIconSize);
			ImportCommand.Icon = App.Current.ResourcesLocator.LoadIcon ("vas-import", StyleConf.TemplatesIconSize);
			TeamTagger = new LMTeamTaggerVM ();
			TeamTagger.HomeTeam = (LMTeamVM)LoadedTemplate;
			TeamTagger.AwayTeam = null;
			TeamTagger.Background = App.Current.HHalfFieldBackground;
			TeamTagger.SelectionMode = MultiSelectionMode.MultipleWithModifier;
			TeamEditor = new LMTeamEditorVM ();
			TeamEditor.Team = (LMTeamVM)LoadedTemplate;
			TeamEditor.Team.TemplateEditorMode = true;
			if (LimitationChart != null) {
				LimitationChart.Dispose ();
				LimitationChart = null;
			}
			TeamMenu = CreateTeamMenu ();
		}

		/// <summary>
		/// Gets the team tagger.
		/// </summary>
		/// <value>The team tagger.</value>
		public LMTeamTaggerVM TeamTagger {
			get;
		}

		/// <summary>
		/// Gets the team tagger.
		/// </summary>
		/// <value>The team tagger.</value>
		public LMTeamEditorVM TeamEditor {
			get;
		}

		protected override TeamVM CreateInstance (Team model)
		{
			LMTeamVM lMTeamVM = new LMTeamVM { Model = (LMTeam)model };
			if (model.Static) {
				StaticViewModels.Add (lMTeamVM);
			}

			return lMTeamVM;
		}

		/// <summary>
		/// ViewModel for the Bar chart used to display count limitations in the Limitation Widget
		/// </summary>
		public CountLimitationBarChartVM LimitationChart {
			get { return chartVM; }
			set {
				chartVM = value;
				Limitation = chartVM?.Limitation;
			}
		}

		/// <summary>
		/// Gets the team menu.
		/// </summary>
		/// <value>The team menu.</value>
		public MenuVM TeamMenu { get; private set; }

		protected MenuVM CreateTeamMenu ()
		{
			DeleteCommand.IconName = "vas-delete";
			MenuVM menu = new MenuVM ();
			menu.ViewModels.AddRange (new List<MenuNodeVM> {
				new MenuNodeVM (DeleteCommand, null, Catalog.GetString("Delete")) { Color = App.Current.Style.ColorAccentError },
			});

			return menu;
		}

	}
}

