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
	public partial class FindNumbersViewControler : ViewController
	{
		public FindNumbersViewControler()
		{
			InitializeComponent();
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			
			((ListView) View).CollectionSource.Criteria["Filter5"] = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter;
			
			try
			{
				
				if (!(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter == null))
				{
					var par = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter;
					TelefonNummernSuchen.Value = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilterString;
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
		
		public void TelefonNummernSuchen_Execute(object sender, ParametrizedActionExecuteEventArgs e)
		{
			
			DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
			
			string paramValue = e.ParameterCurrentValue as string;
			
			if (!string.IsNullOrEmpty(paramValue))
			{
				
				var customRange = paramValue.Split(';');
				
				if (customRange.Count() > 0)
				{
					
					List<string> newrange = new List<string>();
					
					for (var i = 0; i <= customRange.Count() - 1; i++)
					{
						if (!(customRange[i] == ""))
						{
							newrange.Add(customRange[i]);
						}
					}
					
					if (newrange.Count > 0)
					{
						
						string[] list = new string[newrange.Count - 1 + 1];
						
						for (var i = 0; i <= newrange.Count - 1; i++)
						{
							list[(int) i] = System.Convert.ToString(newrange[i].Replace(";", "").TrimEnd().TrimStart());
						}
						
						DevExpress.Data.Filtering.InOperator devf = new DevExpress.Data.Filtering.InOperator("TelefonNummer", list);
						DevExpress.Data.Filtering.InOperator devf2 = new DevExpress.Data.Filtering.InOperator("TelefonNummer2", list);
						DevExpress.Data.Filtering.InOperator devf3 = new DevExpress.Data.Filtering.InOperator("TelefonNummer3", list);
						
						GroupOperator finalCriteria = new GroupOperator(GroupOperatorType.Or, devf, devf2, devf3);
						
						
						((ListView) View).CollectionSource.Criteria["Filter5"] = finalCriteria;
						
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter = devf;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilterString = paramValue;
						
						var currCaption = View.Caption;
						if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
						{
							View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
						}
						
					}
					else
					{
						((ListView) View).CollectionSource.Criteria["Filter5"] = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilterString = null;
						View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
					}
					
				}
				else
				{
					((ListView) View).CollectionSource.Criteria["Filter5"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilterString = null;
					View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
				}
				
			}
			else
			{
				try
				{
					((ListView) View).CollectionSource.Criteria["Filter5"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilter = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastPhonerangeFilterString = null;
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
