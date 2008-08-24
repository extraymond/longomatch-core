// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.42
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using Gtk;
using Gdk;
using LongoMatch.DB;
using LongoMatch.Handlers;
using LongoMatch.TimeNodes;

namespace LongoMatch.Widgets.Component {
	
	
	public partial class TimeLineWidget : Gtk.Bin
	{
		
		public event TimeNodeChangedHandler TimeNodeChanged;
		public event TimeNodeSelectedHandler TimeNodeSelected;
		public event TimeNodeDeletedHandler TimeNodeDeleted;
		public event PlayListNodeAddedHandler PlayListNodeAdded;
		
		private TimeScale[] tsArray;
		private List<MediaTimeNode>[] tnArray;
		private Sections sections;
		private TimeReferenceWidget tr;
		private uint frames;
		private uint pixelRatio=1;
		private MediaTimeNode selected;
		private uint currentFrame;

		
		public TimeLineWidget()
		{
			this.Build();	
			
		}
		
		
		public MediaTimeNode SelectedTimeNode{
			get{return this.selected;}
			set{
				this.selected = value;
				if (tsArray != null && tnArray != null){
					foreach (TimeScale  ts in tsArray){
						ts.SelectedTimeNode = value;					
					}
				}
				this.QueueDraw();
			}
		}
		
		public uint CurrentFrame{
			get{return this.currentFrame;}
			set{
				this.currentFrame = value;
				
				if (tsArray != null && tnArray != null){
					
					foreach (TimeScale  ts in tsArray){
						ts.CurrentFrame = value;					
					}
					tr.CurrentFrame = value;
				}
				this.QueueDraw();

			}
		}
		
		public void AdjustPostion(uint currentframe){
			
		}
		
		
		public void SetPixelRatio(uint pixelRatio){
			
		
			if (tsArray != null && tnArray != null){
				this.pixelRatio = pixelRatio;
				this.tr.PixelRatio = pixelRatio;
				foreach (TimeScale  ts in tsArray){
					ts.PixelRatio = this.pixelRatio;
					
				}	
				tr.Size((int)(this.frames/pixelRatio),50);

				
			}
			
		}
		
		
		
		public Project Project{
			set{
				sections = value.Sections;
				tnArray = value.GetDataArray();
				tsArray = new TimeScale[20]; 
				this.pixelRatio=1;
				
				//Unrealize all children
				foreach (Widget w in vbox1.AllChildren){
					w.Unrealize();
					this.vbox1.Remove(w);
				}				
				
				this.frames = value.File.GetFrames();
				ushort fps = value.File.Fps;
				
				tr = new TimeReferenceWidget(frames,fps);
				tr.PixelRatio = 1;
				this.vbox1.PackStart(tr,false,false,0);
				tr.Show();
				for (int i=0; i<20; i++){
					TimeScale ts = new TimeScale(tnArray[i],frames,sections.GetColor(i));
					ts.PixelRatio = 1;
					tsArray[i]=ts;
					ts.TimeNodeChanged += new TimeNodeChangedHandler(OnTimeNodeChanged);
					ts.TimeNodeSelected += new TimeNodeSelectedHandler (OnTimeNodeSelected);
					ts.TimeNodeDeleted += new TimeNodeDeletedHandler(OnTimeNodeDeleted);
					this.vbox1.PackStart(ts,true,true,0);					
					if (value.Sections.GetVisibility(i)){
						ts.Show();
					}
				}
			}
			
		}
	
		protected virtual void OnTimeNodeChanged(TimeNode tn, object val){
			if (this.TimeNodeChanged != null)			
				this.TimeNodeChanged(tn,val);
		}
		
		protected virtual void OnTimeNodeSelected(MediaTimeNode tn){
			if (this.TimeNodeSelected != null)			
				this.TimeNodeSelected(tn);
		}
		protected virtual void OnTimeNodeDeleted(MediaTimeNode tn){
			if (this.TimeNodeDeleted != null)			
				this.TimeNodeDeleted(tn);
		}

		protected virtual void OnZoominbuttonClicked (object sender, System.EventArgs e)
		{
			if (this.pixelRatio > 2){
				this.pixelRatio--;
				this.pixelRatio--;
				this.SetPixelRatio(this.pixelRatio);
				this.QueueDraw();
			}
			
		}

		protected virtual void OnZoomoutbuttonClicked (object sender, System.EventArgs e)
		{
			if (this.pixelRatio <99){
				this.pixelRatio++;
				this.pixelRatio++;
				this.SetPixelRatio(this.pixelRatio);
				this.QueueDraw();
			}
			
		}
		
		

	}
}
