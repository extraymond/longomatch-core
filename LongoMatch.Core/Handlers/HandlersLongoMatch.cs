﻿// Handlers.cs
//
//  Copyright (C) 2007-2009 Andoni Morales Alastruey
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA 02110-1301, USA.
//
//
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using LongoMatch.Core.Common;
using LongoMatch.Core.Filters;
using LongoMatch.Core.Interfaces;
using LongoMatch.Core.Interfaces.GUI;
using LongoMatch.Core.Store;
using LongoMatch.Core.Store.Templates;
using VAS.Core.Common;
using VAS.Core.Interfaces;
using VAS.Core.Interfaces.Drawing;
using VAS.Core.Store;
using VAS.Core.Store.Playlists;

namespace LongoMatch.Core.Handlers
{
	/* An events needs to be loaded */
	public delegate void LoadEventHandler (TimelineEventLongoMatch evt);
	/* An event was loaded */
	public delegate void EventLoadedHandler (TimelineEventLongoMatch evt);
	/* An event has been created */
	public delegate void EventCreatedHandler (TimelineEventLongoMatch evt);
	/* A new play needs to be created for a specific category at the current play time */
	public delegate void NewEventHandler (EventType eventType,List<PlayerLongoMatch> players,ObservableCollection<Team> team,
		List<Tag> tags,Time start,Time stop,Time EventTime,DashboardButton btn);
	/* Add a new play to the current project from Dashboard */
	public delegate void NewDashboardEventHandler (TimelineEventLongoMatch evt,DashboardButton btn,bool edit,
		List<DashboardButton> from);
	/* An event was edited */
	public delegate void TimeNodeChangedHandler (TimeNode tNode,Time time);
	/* Edit EventType properties */
	public delegate void EditEventTypeHandler (EventType cat);
	/* A list of plays needs to be deleted */
	public delegate void DeleteEventsHandler (List<TimelineEventLongoMatch> events);
	/* Change the Play's category */
	public delegate void MoveEventHandler (TimelineEventLongoMatch play,EventType eventType);
	/* An event was edited */
	public delegate void EventEditedHandler (TimelineEventLongoMatch play);
	/* Duplicate play */
	public delegate void DuplicateEventsHandler (List<TimelineEventLongoMatch> events);
	/* Emited when the dashboard is edited and might have new EventTypes */
	public delegate void DashboardEditedHandler ();

	/* Dashboard buttons selected */
	public delegate void ButtonsSelectedHandler (List<DashboardButton> taggerbuttons);
	public delegate void ButtonSelectedHandler (DashboardButton taggerbutton);

	/* Dashboard link selected */
	public delegate void ActionLinksSelectedHandler (List<ActionLink> actionLink);

	/* Dashboard link crated */
	public delegate void ActionLinkCreatedHandler (ActionLink actionLink);

	/* Show dashboard menu */
	public delegate void ShowDashboardMenuHandler (List<DashboardButton> selectedButtons,List<ActionLink> selectedLinks);

	/* The players tagged in an event have changed */
	public delegate void TeamsTagsChangedHandler ();
	/* Project Events */
	public delegate void SaveProjectHandler (ProjectLongoMatch project,ProjectType projectType);
	public delegate void OpenedProjectChangedHandler (ProjectLongoMatch project,ProjectType projectType,EventsFilter filter,
		IAnalysisWindow analysisWindow);
	public delegate void OpenedPresentationChangedHandler (Playlist presentation,IPlayerController player);
	public delegate void OpenProjectIDHandler (Guid project_id,ProjectLongoMatch project);
	public delegate void OpenProjectHandler ();
	public delegate bool CloseOpenendProjectHandler ();
	public delegate void NewProjectHandler (ProjectLongoMatch project);
	public delegate void OpenNewProjectHandler (ProjectLongoMatch project,ProjectType projectType,CaptureSettings captureSettings);
	public delegate void ImportProjectHandler ();
	public delegate void ExportProjectHandler (ProjectLongoMatch project);
	public delegate void QuitApplicationHandler ();
	public delegate void CreateThumbnailsHandler (ProjectLongoMatch project);
	/* GUI */
	public delegate void ManageJobsHandler ();
	public delegate void ManageTeamsHandler ();
	public delegate void ManageDashboardsHandler ();
	public delegate void ManageProjects ();
	public delegate void ManageDatabases ();
	public delegate void EditPreferences ();
	public delegate void MigrateDBHandler ();
	/*Playlist Events*/
	/* Create a new playlist */
	public delegate Playlist NewPlaylistHandler (ProjectLongoMatch project);
	/* Add a new rendering job */
	public delegate void RenderPlaylistHandler (Playlist playlist);
	/* A play list element is selected */
	public delegate void PlaylistElementSelectedHandler (Playlist playlist,IPlaylistElement element,bool playing);
	/* Add a play to a playlist */
	public delegate void AddPlaylistElementHandler (Playlist playlist,List<IPlaylistElement> element);
	/* Play next playlist element */
	public delegate void NextPlaylistElementHandler (Playlist playlist);
	/* Play previous playlist element */
	public delegate void PreviousPlaylistElementHandler (Playlist playlist);
	/* Playlists have been edited */
	public delegate void PlaylistsChangedHandler (object sender);
	/* Create snapshots for a play */
	public delegate void SnapshotSeriesHandler (TimelineEventLongoMatch tNode);
	/* Convert a video file */
	public delegate void ConvertVideoFilesHandler (List<MediaFile> inputFiles,EncodingSettings encSettings);
	/* A date was selected */
	public delegate void DateSelectedHandler (DateTime selectedDate);
	/* A new version of the software exists */
	public delegate void NewVersionHandler (Version version,string URL);
	/* Edit player properties */
	public delegate void PlayerPropertiesHandler (PlayerLongoMatch player);
	public delegate void PlayersPropertiesHandler (List<PlayerLongoMatch> players);
	/* Players selection */
	public delegate void PlayersSubstitutionHandler (Team team,PlayerLongoMatch p1,PlayerLongoMatch p2,
		SubstitutionReason reason,Time time);
	public delegate void PlayersSelectionChangedHandler (List<PlayerLongoMatch> players);
	public delegate void TeamSelectionChangedHandler (ObservableCollection<Team> teams);
	/* A list of projects have been selected */
	public delegate void ProjectsSelectedHandler (List<ProjectLongoMatch> projects);
	public delegate void ProjectSelectedHandler (ProjectLongoMatch project);
	public delegate void KeyHandler (object sender,HotKey key);
	/* The plays filter was updated */
	public delegate void FilterUpdatedHandler ();
	public delegate void DetachPlayerHandler ();
	/* Show project stats */
	public delegate void ShowProjectStats (ProjectLongoMatch project);
	public delegate void ShowFullScreenHandler (bool fullscreen);
	public delegate void PlaylistVisibiltyHandler (bool visible);
	public delegate void AnalysisWidgetsVisibilityHandler (bool visible);
	public delegate void AnalysisModeChangedHandler (VideoAnalysisMode mode);
	public delegate void TagSubcategoriesChangedHandler (bool tagsubcategories);
	public delegate void ShowTimelineMenuHandler (List<TimelineEventLongoMatch> plays,EventType cat,Time time);
	public delegate void ShowTimersMenuHandler (List<TimeNode> timenodes);
	public delegate void ShowTimerMenuHandler (Timer timer,Time time);
	public delegate void ShowTaggerMenuHandler (List<TimelineEventLongoMatch> plays);
	public delegate void ShowDrawToolMenuHandler (IBlackboardObject drawable);
	public delegate void ConfigureDrawingObjectHandler (IBlackboardObject drawable,DrawTool tool);
	public delegate void DrawableChangedHandler (IBlackboardObject drawable);
	public delegate void BackEventHandle ();
	/* Camera dragging */
	public delegate void CameraDraggedHandler (MediaFile file,TimeNode timenode);
}