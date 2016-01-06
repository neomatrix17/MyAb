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

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class FinPlzViewControler : ViewController
	{
		public FinPlzViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			((ListView) View).CollectionSource.Criteria["Filter2"] = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPlzFilter;
			
			try
			{
				var par = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPlzFilter;
				if (!(par == null))
				{
					PostleitzahlSuchen.Value = ((BetweenOperator) par).BeginExpression.ToString().Replace("\'", "") + "-" + ((BetweenOperator) par).EndExpression.ToString().Replace("\'", "");
					var currCaption = View.Caption;
					if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
					{
						View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
					}
				}
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
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
		
		public void PostleitzahlSuchen_Execute(object sender, ParametrizedActionExecuteEventArgs e)
		{
			DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
			
			string paramValue = e.ParameterCurrentValue as string;
			
			if (!string.IsNullOrEmpty(paramValue))
			{
				
				var range = paramValue.Split('-');
				
				if (range.Length > 1)
				{
					((ListView) View).CollectionSource.Criteria["Filter2"] = new BetweenOperator("Postleitzahl", range[0], range[1]);
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPlzFilter = ((ListView) View).CollectionSource.Criteria["Filter2"];
					var currCaption = View.Caption;
					if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
					{
						View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
					}
				}
				else
				{
					((ListView) View).CollectionSource.Criteria["Filter2"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPlzFilter = null;
					View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
				}
				
			}
			else
			{
				try
				{
					((ListView) View).CollectionSource.Criteria["Filter2"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPlzFilter = null;
					View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					
					
					
				}
			}
			
		}
	}
}
