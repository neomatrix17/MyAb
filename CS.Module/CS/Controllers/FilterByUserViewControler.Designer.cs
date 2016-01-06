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
	public partial class FilterByUserViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public FilterByUserViewControler(System.ComponentModel.IContainer Container) : this()
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
			this.FilterByUser = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
			this.FilterByUser.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.FilterByUser_Execute);
			//
			//FilterByUser
			//
			this.FilterByUser.Caption = "Benutzer:";
			this.FilterByUser.Category = "View";
			this.FilterByUser.ConfirmationMessage = null;
			this.FilterByUser.Id = "FilterByUser";
			this.FilterByUser.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.FilterByUser.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.FilterByUser.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.FilterByUser.ToolTip = null;
			this.FilterByUser.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//FilterByUserViewControler
			//
			this.Actions.Add(this.FilterByUser);
			this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			
		}
		internal DevExpress.ExpressApp.Actions.SingleChoiceAction FilterByUser;
		
	}
	
}
