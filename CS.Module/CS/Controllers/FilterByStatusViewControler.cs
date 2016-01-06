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
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using AdressenManagement.Module.BusinessLogic.Basis;

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class FilterByStatusViewControler : ViewController
	{
		
		const string refreshItemId = "clearfilter";
		
		public FilterByStatusViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			PopulateItemsCollection();
			
			((ListView) View).CollectionSource.Criteria["Filter3"] = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusFilter;
			
			try
			{
				var par = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusFilter;
				var parID = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusId;
				
				if (!(parID == 0))
				{
					
					var s = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Session;
					var curr = s.GetObjectByKey<BusinessLogic.Basis.Status>(parID);
					
					foreach (DevExpress.ExpressApp.Actions.ChoiceActionItem i in FilterByStatus.Items)
					{
						if (i.Caption == curr.Name)
						{
							FilterByStatus.SelectedItem = i;
							var currCaption = View.Caption;
							if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
							{
								View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
							}
							break;
						}
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
		
		private void PopulateItemsCollection()
		{
			FilterByStatus.Items.Clear();
			List<SortProperty> sortProperties = new List<SortProperty>();
			FilterByStatus.Items.Add(new ChoiceActionItem(refreshItemId, "", null));
			sortProperties.Add(new SortProperty("Name", SortingDirection.Ascending));
			foreach (BusinessLogic.Basis.Status status in View.ObjectSpace.CreateCollection(typeof(BusinessLogic.Basis.Status), null, sortProperties))
			{
                //Check this
				string itemCaption = System.Convert.ToString(status.Name);
				if (!(itemCaption == " "))
				{
					FilterByStatus.Items.Add(new ChoiceActionItem(System.Convert.ToString(status.Oid), itemCaption, status));
				}
			}
		}
		
		public void FilterByStatus_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
		{
			
			if (e.SelectedChoiceActionItem.Id == refreshItemId)
			{
				try
				{
					((ListView) View).CollectionSource.Criteria["Filter3"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusFilter = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusId = 0;
					View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					
					
					
				}
			}
			else
			{
				DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
				string paramValue = System.Convert.ToString((e.SelectedChoiceActionItem.Data as BusinessLogic.Basis.Status).Name);
				int paramID = System.Convert.ToInt32((e.SelectedChoiceActionItem.Data as BusinessLogic.Basis.Status).Oid);
				if (!string.IsNullOrEmpty(paramValue))
				{
					((ListView) View).CollectionSource.Criteria["Filter3"] = CriteriaOperator.Parse("Contains([Status.Name], ?)", paramValue);
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusFilter = ((ListView) View).CollectionSource.Criteria["Filter3"];
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusId = paramID;
					var currCaption = View.Caption;
					if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
					{
						View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
					}
				}
				else
				{
					try
					{
						((ListView) View).CollectionSource.Criteria["Filter3"] = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusFilter = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastStatusId = 0;
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
	
}
