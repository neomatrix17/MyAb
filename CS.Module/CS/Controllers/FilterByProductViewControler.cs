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
	public partial class FilterByProductViewControler : ViewController
	{
		
		const string refreshItemId = "clearfilter";
		public FilterByProductViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			PopulateItemsCollection();
			
			((ListView) View).CollectionSource.Criteria["Filter6"] = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastProduktFilter;
			
			try
			{
				var par = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastProduktFilter;
				//FilterByUser.SelectedIndex = DirectCast(DirectCast(SecuritySystem.CurrentUser, BusinessLogic.Intern.Mitarbeiter).LastSelectedMa, DevExpress.ExpressApp.Actions.ChoiceActionItem).Id
				
				foreach (DevExpress.ExpressApp.Actions.ChoiceActionItem i in FilterProdukt.Items)
				{
					if (!(i.Caption == null))
					{
						if (!(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedProdukt == null))
						{
							if (i.Caption == ((DevExpress.ExpressApp.Actions.ChoiceActionItem) (((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedProdukt)).Caption)
							{
								FilterProdukt.SelectedItem = i;
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
			
			List<string> originalItemsList = new List<string>();
			
			FilterProdukt.Items.Clear();
			List<SortProperty> sortProperties = new List<SortProperty>();
			FilterProdukt.Items.Add(new ChoiceActionItem(refreshItemId, "", null));
			sortProperties.Add(new SortProperty("Name", SortingDirection.Ascending));
			foreach (BusinessLogic.Basis.Produkt prod in View.ObjectSpace.CreateCollection(typeof(BusinessLogic.Basis.Produkt), null, sortProperties))
			{
				string itemCaption = System.Convert.ToString(prod.Name);
				if (!(itemCaption == " "))
				{
					
					if (!originalItemsList.Contains(itemCaption))
					{
						originalItemsList.Add(itemCaption);
					}
					
					FilterProdukt.Items.Add(new ChoiceActionItem(System.Convert.ToString(prod.Oid), itemCaption, prod));
					
				}
			}
			
			DataTable dtTemp = new DataTable();
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(GlobalBase.CurrentConn);
			
			try
			{
				
				conn.Open();
				
				string sqlQuery = "SELECT DISTINCT [Produkt] FROM [dbo].[Adresse] Where [Produkt] Is Not Null";
				
				System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand(sqlQuery, conn);
				
				System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
				
				sqlDataAdapter.SelectCommand = sqlCommand;
				sqlDataAdapter.Fill(dtTemp);
				
				sqlDataAdapter.Dispose();
				sqlCommand.Dispose();
				conn.Close();
				conn.Dispose();
				
				foreach (DataRow dr in dtTemp.Rows)
				{
					
					if (!originalItemsList.Contains(dr["Produkt"]))
					{
						originalItemsList.Add(dr["Produkt"].ToString());
						FilterProdukt.Items.Add(new ChoiceActionItem(null, System.Convert.ToString(dr["Produkt"]), null));
					}
					
				}
				
			}
			catch (Exception)
			{
				
			}
			
			
		}
		
		public void FilterProdukt_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
		{
			
			if (e.SelectedChoiceActionItem.Id == refreshItemId)
			{
				try
				{
					((ListView) View).CollectionSource.Criteria["Filter6"] = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastProduktFilter = null;
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedProdukt = null;
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
				string paramValue = "";
				
				if (!(e.SelectedChoiceActionItem.Data == null))
				{
					paramValue = System.Convert.ToString((e.SelectedChoiceActionItem.Data as BusinessLogic.Basis.Produkt).Name);
				}
				else
				{
					paramValue = e.SelectedChoiceActionItem.Caption;
				}
				
				if (!string.IsNullOrEmpty(paramValue))
				{
					
					DevExpress.Data.Filtering.BinaryOperator devf = new DevExpress.Data.Filtering.BinaryOperator("Produkt", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf2 = new DevExpress.Data.Filtering.BinaryOperator("Produkt2", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf3 = new DevExpress.Data.Filtering.BinaryOperator("Produkt3", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf4 = new DevExpress.Data.Filtering.BinaryOperator("Produkt4", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf5 = new DevExpress.Data.Filtering.BinaryOperator("Produkt5", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf6 = new DevExpress.Data.Filtering.BinaryOperator("Produkt6", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf7 = new DevExpress.Data.Filtering.BinaryOperator("Produkt7", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf8 = new DevExpress.Data.Filtering.BinaryOperator("Produkt8", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf9 = new DevExpress.Data.Filtering.BinaryOperator("Produkt9", paramValue);
					DevExpress.Data.Filtering.BinaryOperator devf10 = new DevExpress.Data.Filtering.BinaryOperator("Produkt10", paramValue);
					
					GroupOperator finalCriteria = new GroupOperator(GroupOperatorType.Or, devf, devf2, devf3, devf4, devf5, devf6, devf7, devf8, devf9, devf10);
					
					((ListView) View).CollectionSource.Criteria["Filter6"] = finalCriteria;
					
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastProduktFilter = ((ListView) View).CollectionSource.Criteria["Filter6"];
					((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedProdukt = e.SelectedChoiceActionItem;
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
						((ListView) View).CollectionSource.Criteria["Filter6"] = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastProduktFilter = null;
						((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastSelectedProdukt = null;
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
