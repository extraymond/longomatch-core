//
//  Copyright (C) 2010 Andoni Morales Alastruey
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
using Gtk;
using LongoMatch.Core.Events;
using LongoMatch.Core.Filters;
using LongoMatch.Core.Store;
using LongoMatch.Gui.Menus;
using VAS.Core.Common;
using VAS.Core.Events;
using VAS.Core.Store;
using VAS.Core.ViewModel;
using Color = Gdk.Color;
using Image = VAS.Core.Common.Image;
using LMCommon = LongoMatch.Core.Common;
using Point = VAS.Core.Common.Point;

namespace LongoMatch.Gui.Component
{
	public abstract class ListTreeViewBase:TreeView
	{
		protected bool editing;
		protected bool enableCategoryMove = false;
		protected SportsPlaysMenu playsMenu;
		protected TreeModelFilter modelFilter;
		protected TreeModelSort modelSort;
		protected TreeStore childModel;
		EventsFilter filter;

		public event EventHandler NewRenderingJob;

		public ListTreeViewBase ()
		{
			Selection.Mode = SelectionMode.Multiple;
			Selection.SelectFunction = SelectFunction;
			RowActivated += new RowActivatedHandler (OnTreeviewRowActivated);
			HeadersVisible = false;
			ShowExpanders = false;
			
			TreeViewColumn custColumn = new TreeViewColumn ();
			CellRenderer cr = new PlaysCellRenderer ();
			custColumn.PackStart (cr, true);
			custColumn.SetCellDataFunc (cr, RenderElement); 

			playsMenu = new SportsPlaysMenu ();
			playsMenu.EditPlayEvent += HandleEditPlayEvent;
			AppendColumn (custColumn);
		}

		public bool Colors {
			get;
			set;
		}

		public EventsFilter Filter {
			set {
				filter = value;
				filter.FilterUpdated += OnFilterUpdated;
				Refilter ();
			}
			get {
				return filter;
			}
		}

		public void Refilter ()
		{
			if (modelFilter != null)
				modelFilter.Refilter ();
		}

		public LMProject Project {
			set;
			protected get;
		}

		new public TreeStore Model {
			set {
				childModel = value;
				if (value != null) {
					modelFilter = new TreeModelFilter (value, null);
					modelFilter.VisibleFunc = new TreeModelFilterVisibleFunc (FilterFunction);
					modelSort = new TreeModelSort (modelFilter);
					modelSort.SetSortFunc (0, SortFunction);
					modelSort.SetSortColumnId (0, SortType.Ascending);
					// Assign the filter as our tree's model
					base.Model = modelSort;
				} else {
					base.Model = null;
				}
			}
			get {
				return childModel;
			}
		}

		protected LMTimelineEvent SelectedPlay {
			get {
				return GetValueFromPath (Selection.GetSelectedRows () [0]) as LMTimelineEvent;
			}
		}

		protected List<LMTimelineEvent> SelectedPlays {
			get {
				return Selection.GetSelectedRows ().Select (
					p => GetValueFromPath (p) as LMTimelineEvent).ToList ();
			}
		}

		protected void ShowMenu ()
		{
			IEnumerable<TimelineEventVM> eventVMs = SelectedPlays
				.Cast<TimelineEvent> ()
				.Select (evt => new TimelineEventVM () { Model = evt });

			playsMenu.ShowListMenu (Project, eventVMs);
		}

		protected object GetValueFromPath (TreePath path)
		{
			return modelSort.GetValue (path);
		}

		protected bool FilterFunction (TreeModel model, TreeIter iter)
		{
			if (Filter == null)
				return true;
			object o = model.GetValue (iter, 0);
			return Filter.IsVisible (o);
		}

		protected virtual void OnTreeviewRowActivated (object o, Gtk.RowActivatedArgs args)
		{
			object item = GetValueFromPath (args.Path);
			if (!(item is LMTimelineEvent))
				return;

			App.Current.EventsBroker.Publish<LoadEventEvent> (
				new LoadEventEvent {
					TimelineEvent = new TimelineEventVM () { Model = item as LMTimelineEvent }
				}
			);
		}

		void HandleEditPlayEvent (object sender, EventArgs e)
		{
			LMTimelineEvent selectedEvent = SelectedPlay;
			List<Player> players = selectedEvent.Players.ToList ();

			App.Current.EventsBroker.Publish<EditEventEvent> (
				new EditEventEvent {
					TimelineEvent = new TimelineEventVM () { Model = selectedEvent }
				});

			if (!players.SequenceEqual (selectedEvent.Players)) {
				App.Current.EventsBroker.Publish<TeamTagsChangedEvent> ();
			}

			modelSort.SetSortFunc (0, SortFunction);
			modelSort.SetSortColumnId (0, SortType.Ascending);
		}

		protected void OnFilterUpdated ()
		{
			Refilter ();
		}

		protected void RenderElement (TreeViewColumn column, CellRenderer cell, TreeModel model, TreeIter iter)
		{
			var item = model.GetValue (iter, 0);
			PlaysCellRenderer c = cell as PlaysCellRenderer;
			c.Item = item;
			c.Count = model.IterNChildren (iter);
			c.Project = Project;
		}

		protected abstract bool SelectFunction (TreeSelection selection, TreeModel model, TreePath path, bool selected);

		protected abstract int SortFunction (TreeModel model, TreeIter a, TreeIter b);
	}
}
