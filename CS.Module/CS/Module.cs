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
using DevExpress.ExpressApp.ReportsV2;

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic.
	public sealed partial class AdressenManagementModule : ModuleBase
	{
		public AdressenManagementModule()
		{
			InitializeComponent();
		}
		
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(DevExpress.ExpressApp.IObjectSpace objectSpace, Version versionFromDB)
		{
			ModuleUpdater updater = new Updater(objectSpace, versionFromDB);
			DevExpress.ExpressApp.ReportsV2.PredefinedReportsUpdater reportsUpdater = new DevExpress.ExpressApp.ReportsV2.PredefinedReportsUpdater(Application, objectSpace, versionFromDB);
			reportsUpdater.AddPredefinedReport<XtraReport1MaTagesKalender>("Mitarbeiter Tageskalender", typeof(BusinessLogic.Basis.Termin));
			return new ModuleUpdater[] {updater, reportsUpdater};
		}
		
		public override void Setup(XafApplication application)
		{
			base.Setup(application);
			//Manage various aspects of the application UI and behavior at the module level.
		}
	}
	
}
