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
	public partial class AdresseAendernTerminBericht
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public AdresseAendernTerminBericht(System.ComponentModel.IContainer Container) : this()
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
		
		//NOTE: The following procedure is required by the Component Designer
		//It can be modified using the Component Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.AdresseÖffnen = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // AdresseÖffnen
            // 
            this.AdresseÖffnen.Caption = "SAAdresse Oeffnen";
            this.AdresseÖffnen.Category = "TerminDaten";
            this.AdresseÖffnen.ConfirmationMessage = null;
            this.AdresseÖffnen.Id = "SAAdresseOeffnen";
            this.AdresseÖffnen.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.AdresseÖffnen.ToolTip = null;
            this.AdresseÖffnen.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.AdresseÖffnen.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.AdresseOeffnen_Execute);
            // 
            // AdresseAendernTerminBericht
            // 
            this.Actions.Add(this.AdresseÖffnen);

		}
		internal DevExpress.ExpressApp.Actions.SimpleAction AdresseÖffnen;
        private System.ComponentModel.IContainer components;
		
	}
	
}
