
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Plugins.Stats
{
	public partial class PlayerCategoryViewer
	{
		private global::Gtk.VBox vbox1;
		private global::LongoMatch.Gui.Component.PlaysCoordinatesTagger tagger;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Plugins.Stats.PlayerCategoryViewer
			global::Stetic.BinContainer.Attach (this);
			this.Name = "LongoMatch.Plugins.Stats.PlayerCategoryViewer";
			// Container child LongoMatch.Plugins.Stats.PlayerCategoryViewer.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.tagger = new global::LongoMatch.Gui.Component.PlaysCoordinatesTagger ();
			this.tagger.Events = ((global::Gdk.EventMask)(256));
			this.tagger.Name = "tagger";
			this.vbox1.Add (this.tagger);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.tagger]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
		}
	}
}