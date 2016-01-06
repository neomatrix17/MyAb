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
	public partial class FindNumbersViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public FindNumbersViewControler(System.ComponentModel.IContainer Container) : this()
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
			this.TelefonNummernSuchen = new DevExpress.ExpressApp.Actions.ParametrizedAction(this.components);
			this.TelefonNummernSuchen.Execute += new DevExpress.ExpressApp.Actions.ParametrizedActionExecuteEventHandler(this.TelefonNummernSuchen_Execute);
			//
			//TelefonNummernSuchen
			//
			this.TelefonNummernSuchen.Caption = "Suchen";
			this.TelefonNummernSuchen.Category = "View";
			this.TelefonNummernSuchen.ConfirmationMessage = null;
			this.TelefonNummernSuchen.Id = "TelefonNummernSuchen";
			this.TelefonNummernSuchen.NullValuePrompt = "Tel. z.b.: 0664123456; ...";
			this.TelefonNummernSuchen.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.Image;
			this.TelefonNummernSuchen.ShortCaption = null;
			this.TelefonNummernSuchen.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TelefonNummernSuchen.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.TelefonNummernSuchen.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TelefonNummernSuchen.ToolTip = null;
			this.TelefonNummernSuchen.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//FindNumbersViewControler
			//
			this.Actions.Add(this.TelefonNummernSuchen);
			this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			
		}
		internal DevExpress.ExpressApp.Actions.ParametrizedAction TelefonNummernSuchen;
		
	}
	
}
