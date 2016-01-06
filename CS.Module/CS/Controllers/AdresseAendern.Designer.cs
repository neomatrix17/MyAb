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
	public partial class AdresseAendern
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public AdresseAendern(System.ComponentModel.IContainer Container) : this()
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
			this.AdresseAendernControler = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
			this.AdresseAendernControler.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.AdresseAendernControler_Execute);
			//
			//AdresseAendernControler
			//
			this.AdresseAendernControler.Caption = "Addressdaten bearbeiten";
			this.AdresseAendernControler.Category = "Adressdaten";
			this.AdresseAendernControler.ConfirmationMessage = null;
			this.AdresseAendernControler.Id = "AdresseAendern";
			this.AdresseAendernControler.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.AdresseAendernControler.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.AdresseAendernControler.ToolTip = null;
			this.AdresseAendernControler.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			//
			//AdresseAendern
			//
			this.Actions.Add(this.AdresseAendernControler);
			
		}
		internal DevExpress.ExpressApp.Actions.SimpleAction AdresseAendernControler;
		
	}
	
}
