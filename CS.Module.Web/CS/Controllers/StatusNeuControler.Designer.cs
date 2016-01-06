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
	public partial class StatusNeuControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public StatusNeuControler(System.ComponentModel.IContainer Container) : this()
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
			this.NochNichtKontaktiertNeu = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.NochNichtKontaktiertNeu.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.NochNichtKontaktiertNeu_Execute);
			//
			//NochNichtKontaktiertNeu
			//
			this.NochNichtKontaktiertNeu.Caption = "Noch Nicht Kontaktiert";
			this.NochNichtKontaktiertNeu.Category = "NochNichtKontaktiertNeu";
			this.NochNichtKontaktiertNeu.ConfirmationMessage = null;
			this.NochNichtKontaktiertNeu.Id = "eac0d61f-f8d0-4f5f-b30e-f726d62d5615";
			this.NochNichtKontaktiertNeu.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.NochNichtKontaktiertNeu.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.NochNichtKontaktiertNeu.ToolTip = null;
			this.NochNichtKontaktiertNeu.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			//
			//StatusNeuControler
			//
			this.Actions.Add(this.NochNichtKontaktiertNeu);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction NochNichtKontaktiertNeu;
		
	}
	
}
