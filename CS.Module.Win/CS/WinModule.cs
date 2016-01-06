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

namespace AdressenManagement.Module.Win
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppModuleBasetopic.
	[ToolboxItemFilter("Xaf.Platform.Win")]public sealed 
	partial class AdressenManagementWindowsFormsModule : ModuleBase
	{
		public AdressenManagementWindowsFormsModule()
		{
			InitializeComponent();
		}
		public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB)
		{
			return ModuleUpdater.EmptyModuleUpdaters;
		}
		
		public override void Setup(XafApplication application)
		{
			base.Setup(application);
			// Manage various aspects of the application UI and behavior at the module level.
            this.RequiredModuleTypes.Add(typeof (AdressenManagementModule));
		}
	}
	
	
}
