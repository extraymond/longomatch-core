
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Component
{
	public partial class PlaysPositionViewer
	{
		private global::Gtk.HBox hbox1;

		private global::LongoMatch.Gui.Component.CoordinatesTagger field;

		private global::Gtk.VBox vbox2;

		private global::LongoMatch.Gui.Component.CoordinatesTagger hfield;

		private global::LongoMatch.Gui.Component.CoordinatesTagger goal;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget LongoMatch.Gui.Component.PlaysPositionViewer
			global::Stetic.BinContainer.Attach(this);
			this.Name = "LongoMatch.Gui.Component.PlaysPositionViewer";
			// Container child LongoMatch.Gui.Component.PlaysPositionViewer.Gtk.Container+ContainerChild
			this.hbox1 = new global::Gtk.HBox();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.field = new global::LongoMatch.Gui.Component.CoordinatesTagger();
			this.field.Events = ((global::Gdk.EventMask)(256));
			this.field.Name = "field";
			this.hbox1.Add(this.field);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.field]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hfield = new global::LongoMatch.Gui.Component.CoordinatesTagger();
			this.hfield.Events = ((global::Gdk.EventMask)(256));
			this.hfield.Name = "hfield";
			this.vbox2.Add(this.hfield);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.hfield]));
			w2.Position = 0;
			// Container child vbox2.Gtk.Box+BoxChild
			this.goal = new global::LongoMatch.Gui.Component.CoordinatesTagger();
			this.goal.Events = ((global::Gdk.EventMask)(256));
			this.goal.Name = "goal";
			this.vbox2.Add(this.goal);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2[this.goal]));
			w3.Position = 1;
			this.hbox1.Add(this.vbox2);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1[this.vbox2]));
			w4.Position = 1;
			this.Add(this.hbox1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
