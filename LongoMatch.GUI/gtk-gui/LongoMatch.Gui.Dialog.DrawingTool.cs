
// This file has been generated by the GUI designer. Do not modify.
namespace LongoMatch.Gui.Dialog
{
	public partial class DrawingTool
	{
		private global::Gtk.HBox hbox1;
		private global::Gtk.VBox vbox2;
		private global::LongoMatch.Gui.Component.DrawingToolBox drawingtoolbox1;
		private global::Gtk.Button savetoprojectbutton;
		private global::Gtk.Button savebutton;
		private global::LongoMatch.Gui.Component.DrawingWidget drawingwidget1;
		private global::Gtk.Button button271;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget LongoMatch.Gui.Dialog.DrawingTool
			this.Name = "LongoMatch.Gui.Dialog.DrawingTool";
			this.Title = global::Mono.Unix.Catalog.GetString ("Drawing Tool");
			this.Icon = global::Gdk.Pixbuf.LoadFromResource ("logo.svg");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.Modal = true;
			this.Gravity = ((global::Gdk.Gravity)(5));
			this.SkipPagerHint = true;
			this.SkipTaskbarHint = true;
			// Internal child LongoMatch.Gui.Dialog.DrawingTool.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.drawingtoolbox1 = new global::LongoMatch.Gui.Component.DrawingToolBox ();
			this.drawingtoolbox1.Events = ((global::Gdk.EventMask)(256));
			this.drawingtoolbox1.Name = "drawingtoolbox1";
			this.vbox2.Add (this.drawingtoolbox1);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.drawingtoolbox1]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savetoprojectbutton = new global::Gtk.Button ();
			this.savetoprojectbutton.CanFocus = true;
			this.savetoprojectbutton.Name = "savetoprojectbutton";
			this.savetoprojectbutton.UseUnderline = true;
			// Container child savetoprojectbutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w3 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w4 = new global::Gtk.HBox ();
			w4.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w5 = new global::Gtk.Image ();
			w5.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			w4.Add (w5);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w7 = new global::Gtk.Label ();
			w7.LabelProp = global::Mono.Unix.Catalog.GetString ("Save to Project");
			w7.UseUnderline = true;
			w4.Add (w7);
			w3.Add (w4);
			this.savetoprojectbutton.Add (w3);
			this.vbox2.Add (this.savetoprojectbutton);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savetoprojectbutton]));
			w11.PackType = ((global::Gtk.PackType)(1));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.savebutton = new global::Gtk.Button ();
			this.savebutton.CanFocus = true;
			this.savebutton.Name = "savebutton";
			this.savebutton.UseUnderline = true;
			// Container child savebutton.Gtk.Container+ContainerChild
			global::Gtk.Alignment w12 = new global::Gtk.Alignment (0.5F, 0.5F, 0F, 0F);
			// Container child GtkAlignment.Gtk.Container+ContainerChild
			global::Gtk.HBox w13 = new global::Gtk.HBox ();
			w13.Spacing = 2;
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Image w14 = new global::Gtk.Image ();
			w14.Pixbuf = global::Stetic.IconLoader.LoadIcon (this, "gtk-save", global::Gtk.IconSize.Menu);
			w13.Add (w14);
			// Container child GtkHBox.Gtk.Container+ContainerChild
			global::Gtk.Label w16 = new global::Gtk.Label ();
			w16.LabelProp = global::Mono.Unix.Catalog.GetString ("Save to File");
			w16.UseUnderline = true;
			w13.Add (w16);
			w12.Add (w13);
			this.savebutton.Add (w12);
			this.vbox2.Add (this.savebutton);
			global::Gtk.Box.BoxChild w20 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.savebutton]));
			w20.PackType = ((global::Gtk.PackType)(1));
			w20.Position = 2;
			w20.Expand = false;
			w20.Fill = false;
			this.hbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w21 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vbox2]));
			w21.Position = 0;
			w21.Expand = false;
			w21.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.drawingwidget1 = new global::LongoMatch.Gui.Component.DrawingWidget ();
			this.drawingwidget1.Events = ((global::Gdk.EventMask)(256));
			this.drawingwidget1.Name = "drawingwidget1";
			this.hbox1.Add (this.drawingwidget1);
			global::Gtk.Box.BoxChild w22 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.drawingwidget1]));
			w22.Position = 1;
			w1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w23 = ((global::Gtk.Box.BoxChild)(w1 [this.hbox1]));
			w23.Position = 0;
			// Internal child LongoMatch.Gui.Dialog.DrawingTool.ActionArea
			global::Gtk.HButtonBox w24 = this.ActionArea;
			w24.Name = "dialog1_ActionArea";
			w24.Spacing = 6;
			w24.BorderWidth = ((uint)(5));
			w24.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.button271 = new global::Gtk.Button ();
			this.button271.CanFocus = true;
			this.button271.Name = "button271";
			this.button271.UseUnderline = true;
			this.button271.Label = "";
			this.AddActionWidget (this.button271, 0);
			global::Gtk.ButtonBox.ButtonBoxChild w25 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w24 [this.button271]));
			w25.Expand = false;
			w25.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 600;
			this.DefaultHeight = 579;
			this.savetoprojectbutton.Hide ();
			this.button271.Hide ();
			this.Show ();
			this.drawingtoolbox1.LineWidthChanged += new global::LongoMatch.Handlers.LineWidthChangedHandler (this.OnDrawingtoolbox1LineWidthChanged);
			this.drawingtoolbox1.ColorChanged += new global::LongoMatch.Handlers.ColorChangedHandler (this.OnDrawingtoolbox1ColorChanged);
			this.drawingtoolbox1.VisibilityChanged += new global::LongoMatch.Handlers.VisibilityChangedHandler (this.OnDrawingtoolbox1VisibilityChanged);
			this.drawingtoolbox1.ClearDrawing += new global::LongoMatch.Handlers.ClearDrawingHandler (this.OnDrawingtoolbox1ClearDrawing);
			this.savebutton.Clicked += new global::System.EventHandler (this.OnSavebuttonClicked);
			this.savetoprojectbutton.Clicked += new global::System.EventHandler (this.OnSavetoprojectbuttonClicked);
		}
	}
}
