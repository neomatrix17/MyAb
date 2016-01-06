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
	public partial class MyTextSearchControler : ViewController<ListView>
	{
		public MyTextSearchControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
			TargetObjectType = typeof(BusinessLogic.Basis.Adresse);
			
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			
			FilterController standardFilterController = 
				Frame.GetController<FilterController>();
			if (!(standardFilterController == null))
			{
				standardFilterController.CustomGetFullTextSearchProperties += standardFilterController_CustomGetFullTextSearchProperties;
				
				standardFilterController.FullTextFilterAction.Execute += Execute;
				
			}
			
			try
			{
				if (!(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastFullTextSearch == null))
				{
					standardFilterController.FullTextFilterAction.Value = ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastFullTextSearch;
					standardFilterController.FullTextFilterAction.DoExecute(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastFullTextSearch);
				}
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				
				
				
				MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(DevExpress.Xpo.Session.DefaultSession);
				exeptionError.Zeitstempel = DateTime.Now;
				exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
				exeptionError.GewähltesObjekt = "MyTextSearchControler";
				exeptionError.Aktion = "";
				exeptionError.Fehlermeldung = ex.Message;
			}
			
		}
		
		private void standardFilterController_CustomGetFullTextSearchProperties(
			object sender, CustomGetFullTextSearchPropertiesEventArgs e)
		{
			foreach (string property in GetFullTextSearchProperties())
			{
				e.Properties.Add(property);
			}
			e.Handled = true;
		}
		private List<string> GetFullTextSearchProperties()
		{
			List<string> searchProperties = new List<string>();
			searchProperties.AddRange(new[] {"Vorname", "Vorname2", "Vorname3", "Nachname", "Nachname2", "Nachname3", "Strasse", "Postleitzahl", "Ortschaft", "Land", "TelefonNummer", "TelefonNummer2", "TelefonNummer3", "Firma3", "Firma", "Firma2", "Oid", "EmpfOid", "EmpfOid10", "EmpfOid2", "EmpfOid3", "EmpfOid4", "EmpfOid5", "EmpfOid6", "EmpfOid7", "EmpfOid8", "EmpfOid9", "Branche.Name", "Produkt", "Produkt2", "Produkt3", "Produkt4", "Produkt5", "Produkt6", "Produkt7", "Produkt8", "Produkt9", "Produkt10", "GekaufteProdukteBeta.ProduktName", "Beschreibung", "Beschreibung2", "Beschreibung3", "KundenNummer"});
			return searchProperties;
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
		
		private void Execute(object sender, ParametrizedActionExecuteEventArgs e)
		{
			
			//Try
			//    Dim s As String = e.ParameterCurrentValue.ToString
			
			//    If Not String.IsNullOrEmpty(s) Then
			
			//        If s.StartsWith("tel:") Then
			
			//            s = s.Replace("tel:", "")
			//            Dim Phones() = s.Split(";")
			
			//            If Phones.Length > 0 Then
			
			//                For i = 0 To Phones.Count - 1
			//                    Dim st As String = Phones(i)
			//                    st = st.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\", "").Replace("   ", "")
			//                    If st.StartsWith("0") Then
			//                        st = st.Remove(0, 1)
			//                    End If
			//                    Phones(i) = st
			//                Next
			
			//                CType(View, ListView).CollectionSource.Criteria("Filter1") = New InOperator("TelefonNummer3", Phones)
			//                CType(View, ListView).CollectionSource.Criteria("Filter2") = New InOperator("TelefonNummer3", Phones)
			//                CType(View, ListView).CollectionSource.Criteria("Filter3") = New InOperator("TelefonNummer3", Phones)
			
			//            End If
			
			//        End If
			
			//    End If
			
			// Catch ex As Exception
			//Gurock.SmartInspect.SiAuto.Main.LogException(Ex)
			
			
			
			//End Try
			
			((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastFullTextSearch = e.ParameterCurrentValue;
			if (((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).LastFullTextSearch == null)
			{
				try
				{
					if (View.CollectionSource.Criteria["Filter1"] == null & View.CollectionSource.Criteria["Filter2"] == null & View.CollectionSource.Criteria["Filter3"] == null)
					{
						View.Caption = View.Caption.Replace(" - Ihre Daten werden mit Filtern angezeigt!", "");
					}
					else
					{
						
					}
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					
					
					
				}
			}
			else
			{
				var currCaption = View.Caption;
				if (!currCaption.Contains(" - Ihre Daten werden mit Filtern angezeigt!"))
				{
					View.Caption = View.Caption + " - Ihre Daten werden mit Filtern angezeigt!";
				}
			}
		}
		
	}
	
}
