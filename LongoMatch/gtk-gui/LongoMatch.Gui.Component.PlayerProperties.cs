// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace LongoMatch.Gui.Component {
    
    
    public partial class PlayerProperties {
        
        private Gtk.Frame frame1;
        
        private Gtk.Alignment GtkAlignment;
        
        private Gtk.Table table1;
        
        private Gtk.HBox hbox1;
        
        private Gtk.Image image;
        
        private Gtk.Button openbutton;
        
        private Gtk.Label label1;
        
        private Gtk.Label label2;
        
        private Gtk.Label label3;
        
        private Gtk.Label label4;
        
        private Gtk.Entry nameentry;
        
        private Gtk.SpinButton numberspinbutton;
        
        private Gtk.Entry positionentry;
        
        private Gtk.Label titlelabel;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget LongoMatch.Gui.Component.PlayerProperties
            Stetic.BinContainer.Attach(this);
            this.Name = "LongoMatch.Gui.Component.PlayerProperties";
            // Container child LongoMatch.Gui.Component.PlayerProperties.Gtk.Container+ContainerChild
            this.frame1 = new Gtk.Frame();
            this.frame1.Name = "frame1";
            this.frame1.ShadowType = ((Gtk.ShadowType)(0));
            // Container child frame1.Gtk.Container+ContainerChild
            this.GtkAlignment = new Gtk.Alignment(0F, 0F, 1F, 1F);
            this.GtkAlignment.Name = "GtkAlignment";
            this.GtkAlignment.LeftPadding = ((uint)(12));
            // Container child GtkAlignment.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(4)), ((uint)(2)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.hbox1 = new Gtk.HBox();
            this.hbox1.Name = "hbox1";
            this.hbox1.Spacing = 6;
            // Container child hbox1.Gtk.Box+BoxChild
            this.image = new Gtk.Image();
            this.image.Name = "image";
            this.hbox1.Add(this.image);
            Gtk.Box.BoxChild w1 = ((Gtk.Box.BoxChild)(this.hbox1[this.image]));
            w1.Position = 0;
            // Container child hbox1.Gtk.Box+BoxChild
            this.openbutton = new Gtk.Button();
            this.openbutton.CanFocus = true;
            this.openbutton.Name = "openbutton";
            this.openbutton.UseStock = true;
            this.openbutton.UseUnderline = true;
            this.openbutton.Label = "gtk-open";
            this.hbox1.Add(this.openbutton);
            Gtk.Box.BoxChild w2 = ((Gtk.Box.BoxChild)(this.hbox1[this.openbutton]));
            w2.Position = 1;
            w2.Expand = false;
            w2.Fill = false;
            this.table1.Add(this.hbox1);
            Gtk.Table.TableChild w3 = ((Gtk.Table.TableChild)(this.table1[this.hbox1]));
            w3.TopAttach = ((uint)(3));
            w3.BottomAttach = ((uint)(4));
            w3.LeftAttach = ((uint)(1));
            w3.RightAttach = ((uint)(2));
            w3.XOptions = ((Gtk.AttachOptions)(4));
            w3.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label1 = new Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = Mono.Unix.Catalog.GetString("Name:");
            this.table1.Add(this.label1);
            Gtk.Table.TableChild w4 = ((Gtk.Table.TableChild)(this.table1[this.label1]));
            w4.XOptions = ((Gtk.AttachOptions)(4));
            w4.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label2 = new Gtk.Label();
            this.label2.Name = "label2";
            this.label2.LabelProp = Mono.Unix.Catalog.GetString("Position:");
            this.table1.Add(this.label2);
            Gtk.Table.TableChild w5 = ((Gtk.Table.TableChild)(this.table1[this.label2]));
            w5.TopAttach = ((uint)(1));
            w5.BottomAttach = ((uint)(2));
            w5.XOptions = ((Gtk.AttachOptions)(4));
            w5.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label3 = new Gtk.Label();
            this.label3.Name = "label3";
            this.label3.LabelProp = Mono.Unix.Catalog.GetString("Number:");
            this.table1.Add(this.label3);
            Gtk.Table.TableChild w6 = ((Gtk.Table.TableChild)(this.table1[this.label3]));
            w6.TopAttach = ((uint)(2));
            w6.BottomAttach = ((uint)(3));
            w6.XOptions = ((Gtk.AttachOptions)(4));
            w6.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.label4 = new Gtk.Label();
            this.label4.Name = "label4";
            this.label4.LabelProp = Mono.Unix.Catalog.GetString("Photo:");
            this.table1.Add(this.label4);
            Gtk.Table.TableChild w7 = ((Gtk.Table.TableChild)(this.table1[this.label4]));
            w7.TopAttach = ((uint)(3));
            w7.BottomAttach = ((uint)(4));
            w7.XOptions = ((Gtk.AttachOptions)(4));
            w7.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.nameentry = new Gtk.Entry();
            this.nameentry.CanFocus = true;
            this.nameentry.Name = "nameentry";
            this.nameentry.IsEditable = true;
            this.nameentry.InvisibleChar = '●';
            this.table1.Add(this.nameentry);
            Gtk.Table.TableChild w8 = ((Gtk.Table.TableChild)(this.table1[this.nameentry]));
            w8.LeftAttach = ((uint)(1));
            w8.RightAttach = ((uint)(2));
            w8.XOptions = ((Gtk.AttachOptions)(4));
            w8.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.numberspinbutton = new Gtk.SpinButton(0, 100, 1);
            this.numberspinbutton.CanFocus = true;
            this.numberspinbutton.Name = "numberspinbutton";
            this.numberspinbutton.Adjustment.PageIncrement = 10;
            this.numberspinbutton.ClimbRate = 1;
            this.numberspinbutton.Numeric = true;
            this.table1.Add(this.numberspinbutton);
            Gtk.Table.TableChild w9 = ((Gtk.Table.TableChild)(this.table1[this.numberspinbutton]));
            w9.TopAttach = ((uint)(2));
            w9.BottomAttach = ((uint)(3));
            w9.LeftAttach = ((uint)(1));
            w9.RightAttach = ((uint)(2));
            w9.YOptions = ((Gtk.AttachOptions)(4));
            // Container child table1.Gtk.Table+TableChild
            this.positionentry = new Gtk.Entry();
            this.positionentry.CanFocus = true;
            this.positionentry.Name = "positionentry";
            this.positionentry.IsEditable = true;
            this.positionentry.InvisibleChar = '●';
            this.table1.Add(this.positionentry);
            Gtk.Table.TableChild w10 = ((Gtk.Table.TableChild)(this.table1[this.positionentry]));
            w10.TopAttach = ((uint)(1));
            w10.BottomAttach = ((uint)(2));
            w10.LeftAttach = ((uint)(1));
            w10.RightAttach = ((uint)(2));
            w10.XOptions = ((Gtk.AttachOptions)(4));
            w10.YOptions = ((Gtk.AttachOptions)(4));
            this.GtkAlignment.Add(this.table1);
            this.frame1.Add(this.GtkAlignment);
            this.titlelabel = new Gtk.Label();
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.LabelProp = Mono.Unix.Catalog.GetString("<b>frame1</b>");
            this.titlelabel.UseMarkup = true;
            this.frame1.LabelWidget = this.titlelabel;
            this.Add(this.frame1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.Hide();
            this.openbutton.Clicked += new System.EventHandler(this.OnOpenbuttonClicked);
        }
    }
}
