
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Component
{
	public partial class CoordinatesTagger
	{
		private global::Gtk.DrawingArea drawingarea;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Gui.Component.CoordinatesTagger
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LongoMatch.Gui.Component.CoordinatesTagger";
			// Container child LongoMatch.Gui.Component.CoordinatesTagger.Gtk.Container+ContainerChild
			this.drawingarea = new global::Gtk.DrawingArea ();
			this.drawingarea.Events = ((global::Gdk.EventMask)(784));
			this.drawingarea.Name = "drawingarea";
			this.Add (this.drawingarea);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}
