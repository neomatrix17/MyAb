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
	public partial class FinPlzViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public FinPlzViewControler(System.ComponentModel.IContainer Container) : this()
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
			this.PostleitzahlSuchen = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
			this.PostleitzahlSuchen.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.PostleitzahlSuchen_Execute);
			//
			//PostleitzahlSuchen
			//
			this.PostleitzahlSuchen.Caption = "Suchen";
			this.PostleitzahlSuchen.Category = "View";
			this.PostleitzahlSuchen.ConfirmationMessage = null;
			this.PostleitzahlSuchen.Id = "PostleitzahlSuchen";
			this.PostleitzahlSuchen.NullValuePrompt = "Postleitzahl (von-bis)";
			this.PostleitzahlSuchen.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
			this.PostleitzahlSuchen.ShortCaption = null;
			this.PostleitzahlSuchen.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.PostleitzahlSuchen.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.PostleitzahlSuchen.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.PostleitzahlSuchen.ToolTip = "Um eine Postleitzahl (von - bis) zu filtrieren geben Sie bitte das folgende Forma" + 
				"t an: 1000-2000";
			this.PostleitzahlSuchen.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//FinPlzViewControler
			//
			this.Actions.Add(this.PostleitzahlSuchen);
			this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			
		}
		internal DevExpress.ExpressApp.Actions.ParametrizedAction PostleitzahlSuchen;
		
	}
	
}
