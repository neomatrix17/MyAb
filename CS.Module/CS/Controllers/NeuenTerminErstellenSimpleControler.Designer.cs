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
	public partial class NeuenTerminErstellenSimpleControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public NeuenTerminErstellenSimpleControler(System.ComponentModel.IContainer Container) : this()
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
			this.SimpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.SimpleAction1.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.SimpleAction1_Execute);
			//
			//SimpleAction1
			//
			this.SimpleAction1.Caption = "Neuer Termin";
			this.SimpleAction1.Category = "RecordEdit";
			this.SimpleAction1.ConfirmationMessage = null;
			this.SimpleAction1.Id = "NeuenTerminErstellenSimpleControler";
			this.SimpleAction1.ImageName = "BO_Appointment";
			this.SimpleAction1.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
			this.SimpleAction1.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.SimpleAction1.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.SimpleAction1.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.SimpleAction1.ToolTip = null;
			this.SimpleAction1.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			//
			//NeuenTerminErstellenSimpleControler
			//
			this.Actions.Add(this.SimpleAction1);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction SimpleAction1;
		
	}
	
}
