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
	public partial class TerminBerichtÖffnen
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public TerminBerichtÖffnen(System.ComponentModel.IContainer Container) : this()
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
			this.TerminBerichtOeffnen2 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.TerminBerichtOeffnen2.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TerminBerichtOeffnen2_Execute);
			//
			//TerminBerichtOeffnen2
			//
			this.TerminBerichtOeffnen2.Caption = "Bericht öffnen";
			this.TerminBerichtOeffnen2.Category = "RecordEdit";
			this.TerminBerichtOeffnen2.ConfirmationMessage = null;
			this.TerminBerichtOeffnen2.Id = "TerminBerichtOeffnen2";
			this.TerminBerichtOeffnen2.ImageName = "BO_Report";
			this.TerminBerichtOeffnen2.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
			this.TerminBerichtOeffnen2.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
			this.TerminBerichtOeffnen2.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.TerminBerichtOeffnen2.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.TerminBerichtOeffnen2.ToolTip = null;
			//
			//TerminBerichtÖffnen
			//
			this.Actions.Add(this.TerminBerichtOeffnen2);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction TerminBerichtOeffnen2;
		
	}
	
}
