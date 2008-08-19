// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace LongoMatch {
    
    
    public partial class MainWindow {
        
        private Gtk.Action FileAction;
        
        private Gtk.Action NewPojectAction;
        
        private Gtk.Action OpenProjectAction;
        
        private Gtk.Action QuitAction;
        
        private Gtk.Action CloseProjectAction;
        
        private Gtk.Action ToolsAction;
        
        private Gtk.Action ProjectsManagerAction;
        
        private Gtk.Action TemplatesManagerAction;
        
        private Gtk.Action ViewAction;
        
        private Gtk.ToggleAction FullScreenAction;
        
        private Gtk.ToggleAction PlaylistAction;
        
        private Gtk.Action PlayerAction;
        
        private Gtk.RadioAction CaptureModeAction;
        
        private Gtk.RadioAction AnalyzeModeAction;
        
        private Gtk.Action SaveProjectAction;
        
        private Gtk.Action PlayAction;
        
        private Gtk.Action PauseAction;
        
        private Gtk.Action PreviousAction;
        
        private Gtk.Action NextAction;
        
        private Gtk.Action OpenPlaylistAction;
        
        private Gtk.VBox vbox1;
        
        private Gtk.VBox menubox;
        
        private Gtk.MenuBar menubar1;
        
        private Gtk.HPaned hpaned;
        
        private Gtk.VBox leftbox;
        
        private LongoMatch.Widgets.Component.TreeWidget treewidget1;
        
        private Gtk.HPaned hpaned1;
        
        private Gtk.VBox vbox5;
        
        private CesarPlayer.PlayerBin playerbin1;
        
        private LongoMatch.Widgets.Component.TimeLineWidget timelinewidget1;
        
        private LongoMatch.Widgets.Component.ButtonsWidget buttonswidget1;
        
        private LongoMatch.Widgets.Component.PlayListWidget playlistwidget2;
        
        private Gtk.Statusbar statusbar1;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget LongoMatch.MainWindow
            Gtk.UIManager w1 = new Gtk.UIManager();
            Gtk.ActionGroup w2 = new Gtk.ActionGroup("Default");
            this.FileAction = new Gtk.Action("FileAction", Mono.Unix.Catalog.GetString("_File"), null, null);
            this.FileAction.ShortLabel = Mono.Unix.Catalog.GetString("_File");
            w2.Add(this.FileAction, null);
            this.NewPojectAction = new Gtk.Action("NewPojectAction", Mono.Unix.Catalog.GetString("_New Poject"), null, "gtk-new");
            this.NewPojectAction.ShortLabel = Mono.Unix.Catalog.GetString("_New Poyect");
            w2.Add(this.NewPojectAction, null);
            this.OpenProjectAction = new Gtk.Action("OpenProjectAction", Mono.Unix.Catalog.GetString("_Open Project"), null, "gtk-open");
            this.OpenProjectAction.ShortLabel = Mono.Unix.Catalog.GetString("_Open Proyect");
            w2.Add(this.OpenProjectAction, null);
            this.QuitAction = new Gtk.Action("QuitAction", Mono.Unix.Catalog.GetString("_Quit"), null, "gtk-quit");
            this.QuitAction.ShortLabel = Mono.Unix.Catalog.GetString("_Quit");
            w2.Add(this.QuitAction, null);
            this.CloseProjectAction = new Gtk.Action("CloseProjectAction", Mono.Unix.Catalog.GetString("_Close Project"), null, "gtk-close");
            this.CloseProjectAction.Sensitive = false;
            this.CloseProjectAction.ShortLabel = Mono.Unix.Catalog.GetString("_Close Proyect");
            w2.Add(this.CloseProjectAction, null);
            this.ToolsAction = new Gtk.Action("ToolsAction", Mono.Unix.Catalog.GetString("_Tools"), null, null);
            this.ToolsAction.ShortLabel = Mono.Unix.Catalog.GetString("_Tools");
            w2.Add(this.ToolsAction, null);
            this.ProjectsManagerAction = new Gtk.Action("ProjectsManagerAction", Mono.Unix.Catalog.GetString("Projects Manager"), null, null);
            this.ProjectsManagerAction.ShortLabel = Mono.Unix.Catalog.GetString("Database Manager");
            w2.Add(this.ProjectsManagerAction, null);
            this.TemplatesManagerAction = new Gtk.Action("TemplatesManagerAction", Mono.Unix.Catalog.GetString("Templates Manager"), null, null);
            this.TemplatesManagerAction.ShortLabel = Mono.Unix.Catalog.GetString("Templates Manager");
            w2.Add(this.TemplatesManagerAction, null);
            this.ViewAction = new Gtk.Action("ViewAction", Mono.Unix.Catalog.GetString("_View"), null, null);
            this.ViewAction.ShortLabel = Mono.Unix.Catalog.GetString("_View");
            w2.Add(this.ViewAction, null);
            this.FullScreenAction = new Gtk.ToggleAction("FullScreenAction", Mono.Unix.Catalog.GetString("Full Screen"), null, "gtk-fullscreen");
            this.FullScreenAction.ShortLabel = Mono.Unix.Catalog.GetString("Full Screen");
            w2.Add(this.FullScreenAction, null);
            this.PlaylistAction = new Gtk.ToggleAction("PlaylistAction", Mono.Unix.Catalog.GetString("Playlist"), null, null);
            this.PlaylistAction.ShortLabel = Mono.Unix.Catalog.GetString("Playlist");
            w2.Add(this.PlaylistAction, null);
            this.PlayerAction = new Gtk.Action("PlayerAction", Mono.Unix.Catalog.GetString("_Player"), null, null);
            this.PlayerAction.Sensitive = false;
            this.PlayerAction.ShortLabel = Mono.Unix.Catalog.GetString("_Player");
            w2.Add(this.PlayerAction, null);
            this.CaptureModeAction = new Gtk.RadioAction("CaptureModeAction", Mono.Unix.Catalog.GetString("Capture Mode"), null, null, 0);
            this.CaptureModeAction.Group = new GLib.SList(System.IntPtr.Zero);
            this.CaptureModeAction.Sensitive = false;
            this.CaptureModeAction.ShortLabel = Mono.Unix.Catalog.GetString("Capture Mode");
            w2.Add(this.CaptureModeAction, null);
            this.AnalyzeModeAction = new Gtk.RadioAction("AnalyzeModeAction", Mono.Unix.Catalog.GetString("Analyze Mode"), null, null, 0);
            this.AnalyzeModeAction.Group = this.CaptureModeAction.Group;
            this.AnalyzeModeAction.Sensitive = false;
            this.AnalyzeModeAction.ShortLabel = Mono.Unix.Catalog.GetString("Analyze Mode");
            w2.Add(this.AnalyzeModeAction, null);
            this.SaveProjectAction = new Gtk.Action("SaveProjectAction", Mono.Unix.Catalog.GetString("_Save Project"), null, "gtk-save");
            this.SaveProjectAction.Sensitive = false;
            this.SaveProjectAction.ShortLabel = Mono.Unix.Catalog.GetString("_Save Project");
            w2.Add(this.SaveProjectAction, null);
            w1.InsertActionGroup(w2, 0);
            Gtk.ActionGroup w3 = new Gtk.ActionGroup("Player");
            this.PlayAction = new Gtk.Action("PlayAction", Mono.Unix.Catalog.GetString("_Play"), null, "gtk-media-play");
            this.PlayAction.ShortLabel = Mono.Unix.Catalog.GetString("dasdf");
            w3.Add(this.PlayAction, null);
            this.PauseAction = new Gtk.Action("PauseAction", Mono.Unix.Catalog.GetString("P_ause"), null, "gtk-media-pause");
            this.PauseAction.ShortLabel = Mono.Unix.Catalog.GetString("P_ause");
            w3.Add(this.PauseAction, null);
            this.PreviousAction = new Gtk.Action("PreviousAction", Mono.Unix.Catalog.GetString("P_revious"), null, "gtk-media-previous");
            this.PreviousAction.ShortLabel = Mono.Unix.Catalog.GetString("P_revious");
            w3.Add(this.PreviousAction, null);
            this.NextAction = new Gtk.Action("NextAction", Mono.Unix.Catalog.GetString("_Next"), null, "gtk-media-next");
            this.NextAction.ShortLabel = Mono.Unix.Catalog.GetString("_Next");
            w3.Add(this.NextAction, null);
            this.OpenPlaylistAction = new Gtk.Action("OpenPlaylistAction", Mono.Unix.Catalog.GetString("Open Playlist"), null, null);
            this.OpenPlaylistAction.ShortLabel = Mono.Unix.Catalog.GetString("Open Playlist");
            w3.Add(this.OpenPlaylistAction, null);
            w1.InsertActionGroup(w3, 1);
            this.AddAccelGroup(w1.AccelGroup);
            this.Name = "LongoMatch.MainWindow";
            this.Title = Mono.Unix.Catalog.GetString("LongoMatch");
            this.Icon = new Gdk.Pixbuf(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "./lgmlogo.png"));
            this.WindowPosition = ((Gtk.WindowPosition)(3));
            this.Gravity = ((Gdk.Gravity)(5));
            // Container child LongoMatch.MainWindow.Gtk.Container+ContainerChild
            this.vbox1 = new Gtk.VBox();
            this.vbox1.Name = "vbox1";
            this.vbox1.Spacing = 6;
            // Container child vbox1.Gtk.Box+BoxChild
            this.menubox = new Gtk.VBox();
            this.menubox.Name = "menubox";
            this.menubox.Spacing = 6;
            // Container child menubox.Gtk.Box+BoxChild
            w1.AddUiFromString("<ui><menubar name='menubar1'><menu action='FileAction'><menuitem action='NewPojectAction'/><menuitem action='OpenProjectAction'/><menuitem action='SaveProjectAction'/><menuitem action='CloseProjectAction'/><menuitem action='OpenPlaylistAction'/><separator/><menuitem action='QuitAction'/></menu><menu action='ToolsAction'><menuitem action='ProjectsManagerAction'/><menuitem action='TemplatesManagerAction'/></menu><menu action='ViewAction'><menuitem action='FullScreenAction'/><menuitem action='PlaylistAction'/><menuitem action='CaptureModeAction'/><menuitem action='AnalyzeModeAction'/></menu><menu action='PlayerAction'><menuitem action='PlayAction'/><menuitem action='PauseAction'/><menuitem action='NextAction'/><menuitem action='PreviousAction'/></menu></menubar></ui>");
            this.menubar1 = ((Gtk.MenuBar)(w1.GetWidget("/menubar1")));
            this.menubar1.Name = "menubar1";
            this.menubox.Add(this.menubar1);
            Gtk.Box.BoxChild w4 = ((Gtk.Box.BoxChild)(this.menubox[this.menubar1]));
            w4.Position = 0;
            w4.Expand = false;
            w4.Fill = false;
            this.vbox1.Add(this.menubox);
            Gtk.Box.BoxChild w5 = ((Gtk.Box.BoxChild)(this.vbox1[this.menubox]));
            w5.Position = 0;
            w5.Expand = false;
            w5.Fill = false;
            // Container child vbox1.Gtk.Box+BoxChild
            this.hpaned = new Gtk.HPaned();
            this.hpaned.CanFocus = true;
            this.hpaned.Name = "hpaned";
            this.hpaned.Position = 261;
            // Container child hpaned.Gtk.Paned+PanedChild
            this.leftbox = new Gtk.VBox();
            this.leftbox.Name = "leftbox";
            this.leftbox.Spacing = 6;
            // Container child leftbox.Gtk.Box+BoxChild
            this.treewidget1 = new LongoMatch.Widgets.Component.TreeWidget();
            this.treewidget1.Events = ((Gdk.EventMask)(256));
            this.treewidget1.Name = "treewidget1";
            this.leftbox.Add(this.treewidget1);
            Gtk.Box.BoxChild w6 = ((Gtk.Box.BoxChild)(this.leftbox[this.treewidget1]));
            w6.Position = 0;
            this.hpaned.Add(this.leftbox);
            Gtk.Paned.PanedChild w7 = ((Gtk.Paned.PanedChild)(this.hpaned[this.leftbox]));
            w7.Resize = false;
            // Container child hpaned.Gtk.Paned+PanedChild
            this.hpaned1 = new Gtk.HPaned();
            this.hpaned1.CanFocus = true;
            this.hpaned1.Name = "hpaned1";
            this.hpaned1.Position = 765;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.vbox5 = new Gtk.VBox();
            this.vbox5.WidthRequest = 320;
            this.vbox5.Name = "vbox5";
            this.vbox5.Spacing = 6;
            // Container child vbox5.Gtk.Box+BoxChild
            this.playerbin1 = new CesarPlayer.PlayerBin();
            this.playerbin1.Events = ((Gdk.EventMask)(256));
            this.playerbin1.Name = "playerbin1";
            this.playerbin1.LogoMode = false;
            this.vbox5.Add(this.playerbin1);
            Gtk.Box.BoxChild w8 = ((Gtk.Box.BoxChild)(this.vbox5[this.playerbin1]));
            w8.Position = 0;
            // Container child vbox5.Gtk.Box+BoxChild
            this.timelinewidget1 = new LongoMatch.Widgets.Component.TimeLineWidget();
            this.timelinewidget1.HeightRequest = 200;
            this.timelinewidget1.Events = ((Gdk.EventMask)(256));
            this.timelinewidget1.Name = "timelinewidget1";
            this.timelinewidget1.CurrentFrame = ((uint)(0));
            this.vbox5.Add(this.timelinewidget1);
            Gtk.Box.BoxChild w9 = ((Gtk.Box.BoxChild)(this.vbox5[this.timelinewidget1]));
            w9.Position = 1;
            // Container child vbox5.Gtk.Box+BoxChild
            this.buttonswidget1 = new LongoMatch.Widgets.Component.ButtonsWidget();
            this.buttonswidget1.Events = ((Gdk.EventMask)(256));
            this.buttonswidget1.Name = "buttonswidget1";
            this.vbox5.Add(this.buttonswidget1);
            Gtk.Box.BoxChild w10 = ((Gtk.Box.BoxChild)(this.vbox5[this.buttonswidget1]));
            w10.Position = 2;
            w10.Expand = false;
            w10.Fill = false;
            this.hpaned1.Add(this.vbox5);
            Gtk.Paned.PanedChild w11 = ((Gtk.Paned.PanedChild)(this.hpaned1[this.vbox5]));
            w11.Resize = false;
            w11.Shrink = false;
            // Container child hpaned1.Gtk.Paned+PanedChild
            this.playlistwidget2 = new LongoMatch.Widgets.Component.PlayListWidget();
            this.playlistwidget2.WidthRequest = 150;
            this.playlistwidget2.Events = ((Gdk.EventMask)(256));
            this.playlistwidget2.Name = "playlistwidget2";
            this.hpaned1.Add(this.playlistwidget2);
            Gtk.Paned.PanedChild w12 = ((Gtk.Paned.PanedChild)(this.hpaned1[this.playlistwidget2]));
            w12.Resize = false;
            w12.Shrink = false;
            this.hpaned.Add(this.hpaned1);
            this.vbox1.Add(this.hpaned);
            Gtk.Box.BoxChild w14 = ((Gtk.Box.BoxChild)(this.vbox1[this.hpaned]));
            w14.Position = 1;
            // Container child vbox1.Gtk.Box+BoxChild
            this.statusbar1 = new Gtk.Statusbar();
            this.statusbar1.Name = "statusbar1";
            this.statusbar1.Spacing = 6;
            this.vbox1.Add(this.statusbar1);
            Gtk.Box.BoxChild w15 = ((Gtk.Box.BoxChild)(this.vbox1[this.statusbar1]));
            w15.Position = 2;
            w15.Expand = false;
            w15.Fill = false;
            this.Add(this.vbox1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 1194;
            this.DefaultHeight = 569;
            this.leftbox.Hide();
            this.timelinewidget1.Hide();
            this.buttonswidget1.Hide();
            this.playlistwidget2.Hide();
            this.Show();
            this.DeleteEvent += new Gtk.DeleteEventHandler(this.OnDeleteEvent);
            this.NewPojectAction.Activated += new System.EventHandler(this.OnNewActivated);
            this.OpenProjectAction.Activated += new System.EventHandler(this.OnOpenActivated);
            this.QuitAction.Activated += new System.EventHandler(this.OnQuitActivated);
            this.CloseProjectAction.Activated += new System.EventHandler(this.OnCloseActivated);
            this.ProjectsManagerAction.Activated += new System.EventHandler(this.OnDatabaseManagerActivated);
            this.TemplatesManagerAction.Activated += new System.EventHandler(this.OnSectionsTemplatesManagerActivated);
            this.FullScreenAction.Toggled += new System.EventHandler(this.OnFullScreenActionToggled);
            this.PlaylistAction.Toggled += new System.EventHandler(this.OnPlaylistActionToggled);
            this.CaptureModeAction.Toggled += new System.EventHandler(this.OnCaptureModeActionToggled);
            this.SaveProjectAction.Activated += new System.EventHandler(this.OnSaveProjectActionActivated);
            this.OpenPlaylistAction.Activated += new System.EventHandler(this.OnOpenPlaylistActionActivated);
            this.playerbin1.Error += new CesarPlayer.ErrorHandler(this.OnPlayerbin1Error);
        }
    }
}
