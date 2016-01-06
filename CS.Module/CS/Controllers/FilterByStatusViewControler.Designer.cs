// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports


namespace AdressenManagement.Module
{
	public partial class FilterByStatusViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public FilterByStatusViewControler(System.ComponentModel.IContainer Container) : this()
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
			this.FilterByStatus = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
			this.FilterByStatus.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.FilterByStatus_Execute);
			//
			//FilterByStatus
			//
			this.FilterByStatus.Caption = "Status:";
			this.FilterByStatus.Category = "View";
			this.FilterByStatus.ConfirmationMessage = null;
			this.FilterByStatus.Id = "FilterByStatus";
			this.FilterByStatus.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.FilterByStatus.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.FilterByStatus.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.FilterByStatus.ToolTip = null;
			this.FilterByStatus.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//FilterByStatusViewControler
			//
			this.Actions.Add(this.FilterByStatus);
			this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			
		}
		internal DevExpress.ExpressApp.Actions.SingleChoiceAction FilterByStatus;
		
	}
	
}
