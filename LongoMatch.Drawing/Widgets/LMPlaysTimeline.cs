//
//  Copyright (C) 2014 Andoni Morales Alastruey
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
using LongoMatch.Core.ViewModel;
using LongoMatch.Drawing.CanvasObjects.Timeline;
using LongoMatch.Services.ViewModel;
using VAS.Core.Common;
using VAS.Core.Interfaces.Drawing;
using VAS.Core.MVVMC;
using VAS.Drawing.Widgets;
using VASDrawing = VAS.Drawing;

namespace LongoMatch.Drawing.Widgets
{
	/// <summary>
	/// A timeline that renders <see cref="TimelineEvent"/> objects.
	/// </summary>
	[View ("PlaysTimelineView")]
	public class LMPlaysTimeline : PlaysTimeline, ICanvasView<AnalysisVM>
	{
		public LMPlaysTimeline (IWidget widget) : base (widget)
		{
		}

		public LMPlaysTimeline ()
		{
		}

		public new AnalysisVM ViewModel {
			get {
				return base.ViewModel as AnalysisVM;
			}
			set {
				base.ViewModel = value;
				ClearObjects ();
				int i = 0;
				FillCanvas (ref i);
			}
		}

		public override void SetViewModel (object viewModel)
		{
			ViewModel = (AnalysisVM)viewModel;
		}

		protected override void FillCanvas (ref int line)
		{
			FillCanvasForPeriodsTimeline (ref line);
			base.FillCanvas (ref line);
		}

		void FillCanvasForPeriodsTimeline (ref int line)
		{
			var timeline = new PeriodsTimelineView {
				DraggingMode = NodeDraggingMode.All,
				Duration = ViewModel.Project.FileSet.Duration,
				Height = StyleConf.TimelineCategoryHeight,
				OffsetY = line * StyleConf.TimelineCategoryHeight,
				LineColor = App.Current.Style.PaletteBackgroundDark,
				BackgroundColor = VASDrawing.Utils.ColorForRow (line),
				ShowLine = false
			};
			timeline.SetViewModel ((ViewModel.Project as LMProjectVM).Periods);
			AddTimeline (timeline, timeline.ViewModel);
			line++;
		}
	}
}