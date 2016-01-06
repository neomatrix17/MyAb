// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports


namespace AdressenManagement.Module.Web
{
	public partial class HideCalenderViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public HideCalenderViewControler(System.ComponentModel.IContainer Container) : this()
		{
			
			//Required for Windows.Forms Class Composition Designer support
			Container.Add(this);
			
		}
		
		//Component overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		//Required by the Component Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Component Designer
		//It can be modified using the Component Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.ShowCalender = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.ShowCalender.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.ShowCalender_Execute);
			//
			//ShowCalender
			//
			this.ShowCalender.Caption = "Kalender anzeigen/ausblenden";
			this.ShowCalender.Category = "View";
			this.ShowCalender.ConfirmationMessage = null;
			this.ShowCalender.Id = "ShowCalender";
			this.ShowCalender.ImageName = "BO_Appointment";
			this.ShowCalender.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.ShowCalender.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.ShowCalender.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.ShowCalender.ToolTip = null;
			this.ShowCalender.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//HideCalenderViewControler
			//
			this.Actions.Add(this.ShowCalender);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction ShowCalender;
		
	}
	
}
