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
	public partial class FilterByProductViewControler
	{
		
		[System.Diagnostics.DebuggerNonUserCode()]public FilterByProductViewControler(System.ComponentModel.IContainer Container) : this()
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
			this.FilterProdukt = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
			this.FilterProdukt.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.FilterProdukt_Execute);
			//
			//FilterProdukt
			//
			this.FilterProdukt.Caption = "Produkt:";
			this.FilterProdukt.Category = "View";
			this.FilterProdukt.ConfirmationMessage = null;
			this.FilterProdukt.Id = "FilterProdukt";
			this.FilterProdukt.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.FilterProdukt.TargetViewNesting = DevExpress.ExpressApp.Nesting.Root;
			this.FilterProdukt.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.FilterProdukt.ToolTip = "Adresse nach Produkt Filtrieren";
			this.FilterProdukt.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			//
			//FilterByProductViewControler
			//
			this.Actions.Add(this.FilterProdukt);
			this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse);
			this.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
			this.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
			
		}
		internal DevExpress.ExpressApp.Actions.SingleChoiceAction FilterProdukt;
		
	}
	
}
