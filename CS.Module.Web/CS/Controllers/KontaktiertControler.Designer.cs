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
	public partial class KontaktiertControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public KontaktiertControler(System.ComponentModel.IContainer Container) : this()
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
			this.Kontaktiert = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.Kontaktiert.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.Kontaktiert_Execute);
			//
			//Kontaktiert
			//
			this.Kontaktiert.Caption = "Kontaktiert";
			this.Kontaktiert.Category = "Kontaktiert";
			this.Kontaktiert.ConfirmationMessage = null;
			this.Kontaktiert.Id = "Kontaktiert";
			this.Kontaktiert.ToolTip = null;
			//
			//KontaktiertControler
			//
			this.Actions.Add(this.Kontaktiert);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction Kontaktiert;
		
	}
	
}
