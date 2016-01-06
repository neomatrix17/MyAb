// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Persistent.BaseImpl;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic.
	[ToolboxItemFilter("Xaf.Platform.Web")]public sealed 
	partial class AdressenManagementAspNetModule : ModuleBase
	{
		public AdressenManagementAspNetModule()
		{
			InitializeComponent();
		}
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
		{
			return ModuleUpdater.EmptyModuleUpdaters;
		}
		
		private void Application_CreateCustomModelDifferenceStore(object sender, CreateCustomModelDifferenceStoreEventArgs e)
		{
			e.Store = new ModelDifferenceDbStore((XafApplication) sender, typeof(ModelDifference), true);
			e.Handled = true;
		}
		private void Application_CreateCustomUserModelDifferenceStore(object sender, CreateCustomModelDifferenceStoreEventArgs e)
		{
			e.Store = new ModelDifferenceDbStore((XafApplication) sender, typeof(ModelDifference), false);
			e.Handled = true;
		}
		
		public override void Setup(XafApplication application)
		{
			base.Setup(application);
			// Manage various aspects of the application UI and behavior at the module level.
			//AddHandler application.CreateCustomModelDifferenceStore, AddressOf Application_CreateCustomModelDifferenceStore
			//AddHandler application.CreateCustomUserModelDifferenceStore, AddressOf Application_CreateCustomUserModelDifferenceStore

            this.RequiredModuleTypes.Add(typeof(AdressenManagementModule));

		}
	}
	
	
}
