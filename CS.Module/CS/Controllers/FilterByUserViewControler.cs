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

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class FilterByUserViewControler : ViewController
	{
		
		const string refreshItemId = "clearfilter";
		
		public FilterByUserViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			PopulateItemsCollection();
			
			((ListView) View).CollectionSource.Criteria["Filter1"] = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastMaFilter;
			
			try
			{
				var par = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastMaFilter;
				//FilterByUser.SelectedIndex = DirectCast(DirectCast(SecuritySystem.CurrentUser, BusinessLogic.Intern.Mitarbeiter).LastSelectedMa, DevExpress.ExpressApp.Actions.ChoiceActionItem).Id
				
				foreach (DevExpress.ExpressApp.Actions.ChoiceActionItem i in FilterByUser.Items)
				{
					if (!(i.Caption == null))
					{
						if (!(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedMa == null))
						{
							if (i.Caption == ((DevExpress.ExpressApp.Actions.ChoiceActionItem) (((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedMa)).Caption)
							{
								FilterByUser.SelectedItem = i;
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
			FilterByUser.Items.Clear();
			List<SortProperty> sortProperties = new List<SortProperty>();
			FilterByUser.Items.Add(new ChoiceActionItem(refreshItemId, "", null));
			sortProperties.Add(new SortProperty("MitarbeiterName", SortingDirection.Ascending));
			foreach (BusinessLogic.Intern.Mitarbeiter mitarbeiter in View.ObjectSpace.CreateCollection(typeof(BusinessLogic.Intern.Mitarbeiter), null, sortProperties))
			{
				string itemCaption = System.Convert.ToString(mitarbeiter.MitarbeiterName);
				if (!(itemCaption == " "))
				{
					FilterByUser.Items.Add(new ChoiceActionItem(System.Convert.ToString(mitarbeiter.Oid), itemCaption, mitarbeiter));
				}
			}
		}
		
		public void FilterByUser_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
		{
			
			
			if (e.SelectedChoiceActionItem.Id == refreshItemId)
			{
				try
				{
					((ListView) View).CollectionSource.Criteria["Filter1"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastMaFilter = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedMa = null;
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
				string paramValue = System.Convert.ToString((e.SelectedChoiceActionItem.Data as BusinessLogic.Intern.Mitarbeiter).MitarbeiterName.Trim());
				
				if (!string.IsNullOrEmpty(paramValue))
				{
					((ListView) View).CollectionSource.Criteria["Filter1"] = CriteriaOperator.Parse("Contains([NameMitarbeiter], ?)", paramValue);
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastMaFilter = ((ListView) View).CollectionSource.Criteria["Filter1"];
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedMa = e.SelectedChoiceActionItem;
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
						((ListView) View).CollectionSource.Criteria["Filter1"] = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastMaFilter = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedMa = null;
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
