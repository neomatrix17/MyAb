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
	public partial class TerminÖffnenControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public TerminÖffnenControler(System.ComponentModel.IContainer Container) : this()
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
			this.TerminÖffnen = new DevExpress.ExpressApp.Actions.SimpleAction();
			this.TerminÖffnen.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TerminÖffnen_Execute);
			//
			//TerminÖffnen
			//
			this.TerminÖffnen.Caption = "Termin öffnen";
			this.TerminÖffnen.Category = "RecordEdit";
			this.TerminÖffnen.ConfirmationMessage = null;
			this.TerminÖffnen.Id = "TerminÖffnen";
			this.TerminÖffnen.ImageName = "Action_ShowItemOnDashboard";
			this.TerminÖffnen.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
			this.TerminÖffnen.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
			this.TerminÖffnen.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.TerminÖffnen.ToolTip = null;
			//
			//TerminÖffnenControler
			//
			this.Actions.Add(this.TerminÖffnen);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction TerminÖffnen;
		
	}
	
}
