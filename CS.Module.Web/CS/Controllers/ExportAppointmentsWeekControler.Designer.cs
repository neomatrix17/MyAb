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
	public partial class ExportAppointmentsWeekControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public ExportAppointmentsWeekControler(System.ComponentModel.IContainer Container) : this()
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
			this.WeekPdfExport = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.WeekPdfExport.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WeekPdfExport_Execute);
			//
			//WeekPdfExport
			//
			this.WeekPdfExport.Caption = "Wochen/Monats Kalender";
			this.WeekPdfExport.Category = "View";
			this.WeekPdfExport.ConfirmationMessage = null;
			this.WeekPdfExport.Id = "WeekPdfExport";
			this.WeekPdfExport.ImageName = "Action_Export_ToPDF";
			this.WeekPdfExport.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.WeekPdfExport.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.WeekPdfExport.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.WeekPdfExport.ToolTip = null;
			this.WeekPdfExport.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//ExportAppointmentsWeekControler
			//
			this.Actions.Add(this.WeekPdfExport);
			
		}
		
		internal DevExpress.ExpressApp.Actions.SimpleAction WeekPdfExport;
		
	}
	
}
