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
	public partial class DoppelteTelefonNummerControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public DoppelteTelefonNummerControler(System.ComponentModel.IContainer Container) : this()
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
			this.AdressenVergleichen = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
			this.AdressenVergleichen.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.AdressenVergleichen_CustomizePopupWindowParams);
			this.AdressenVergleichen.CustomizeTemplate += this.AdressenVergleichen_CustomizeTemplate;
			//
			//AdressenVergleichen
			//
			this.AdressenVergleichen.AcceptButtonCaption = null;
			this.AdressenVergleichen.CancelButtonCaption = null;
			this.AdressenVergleichen.Caption = "Adressen vergleichen";
			this.AdressenVergleichen.Category = "Filters";
			this.AdressenVergleichen.ConfirmationMessage = null;
			this.AdressenVergleichen.Id = "AdressenVergleichen";
			this.AdressenVergleichen.ImageName = "BO_Rules";
			this.AdressenVergleichen.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.AdressenVergleichen.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.AdressenVergleichen.ToolTip = null;
			this.AdressenVergleichen.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			//
			//DoppelteTelefonNummerControler
			//
			this.Actions.Add(this.AdressenVergleichen);
			this.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
			
		}
		internal DevExpress.ExpressApp.Actions.PopupWindowShowAction AdressenVergleichen;
		
	}
	
}
