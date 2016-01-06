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
	public partial class ExportAppointmentsControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public ExportAppointmentsControler(System.ComponentModel.IContainer Container) : this()
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
			this.AlsPdfExportieren = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.AlsPdfExportieren.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.AlsPdfExportieren_Execute);
			//
			//AlsPdfExportieren
			//
			this.AlsPdfExportieren.Caption = "Tageskalender";
			this.AlsPdfExportieren.Category = "View";
			this.AlsPdfExportieren.ConfirmationMessage = null;
			this.AlsPdfExportieren.Id = "AlsPdfExportieren";
			this.AlsPdfExportieren.ImageName = "Action_Export_ToPDF";
			this.AlsPdfExportieren.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.AlsPdfExportieren.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.AlsPdfExportieren.ToolTip = null;
			this.AlsPdfExportieren.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//ExportAppointmentsControler
			//
			this.Actions.Add(this.AlsPdfExportieren);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction AlsPdfExportieren;
		
	}
	
}
