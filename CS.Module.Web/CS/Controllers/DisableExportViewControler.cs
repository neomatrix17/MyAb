// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class DisableExportViewControler : ViewController
	{
		public DisableExportViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			
			string role = "";
			
			var user = SecuritySystem.CurrentUser as BusinessLogic.Intern.Mitarbeiter;
			
			if (!(user == null))
			{
				var roles = user.MitarbeiterRollen;
				foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
				{
					role = System.Convert.ToString(r.Name);
				}
			}
			
			if (!(role == "Administrator"))
			{
				foreach (DevExpress.ExpressApp.Controller iControler in Application.MainWindow.Controllers)
				{
					switch (iControler.Name)
					{
						case "DevExpress.ExpressApp.Web.SystemModule.WebExportController":
							((DevExpress.ExpressApp.Web.SystemModule.WebExportController) iControler).Active.SetItemValue("myReason", false);
							break;
					}
				}
			}
			
		}
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		protected override void OnDeactivated()
		{
			// Unsubscribe from previously subscribed events and release other references and resources.
			base.OnDeactivated();
		}
	}
	
}
