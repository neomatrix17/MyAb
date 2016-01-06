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
	public partial class EmpfehlungHinzufügen
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public EmpfehlungHinzufügen(System.ComponentModel.IContainer Container) : this()
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
			this.NeueEmpfehlungerstellen = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.NeueEmpfehlungerstellen.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.NeueEmpfehlungerstellen_Execute);
			//
			//NeueEmpfehlungerstellen
			//
			this.NeueEmpfehlungerstellen.Caption = "Neue Empfehlung erstellen";
			this.NeueEmpfehlungerstellen.ConfirmationMessage = null;
			this.NeueEmpfehlungerstellen.Id = "NeueEmpfehlung erstellen";
			this.NeueEmpfehlungerstellen.ImageName = "BO_Address";
			this.NeueEmpfehlungerstellen.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.NeueEmpfehlungerstellen.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.NeueEmpfehlungerstellen.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.NeueEmpfehlungerstellen.ToolTip = null;
			this.NeueEmpfehlungerstellen.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			//
			//EmpfehlungHinzufügen
			//
			this.Actions.Add(this.NeueEmpfehlungerstellen);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction NeueEmpfehlungerstellen;
		
	}
	
}
