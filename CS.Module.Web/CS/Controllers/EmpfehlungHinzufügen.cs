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
using DevExpress.ExpressApp.Xpo;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class EmpfehlungHinzufügen : ViewController
	{
		public EmpfehlungHinzufügen()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
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
		
		public void NeueEmpfehlungerstellen_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			try
			{
				if (!(View == null))
				{
					
					object selectedAddress = null;
					
					if (View.ObjectTypeInfo.FullName == "AdressenManagement.Module.BusinessLogic.Basis.Adresse")
					{
						if (View.SelectedObjects.Count > 0)
						{
							selectedAddress = View.SelectedObjects[0];
						}
					}
					
					var objectSpace = Application.CreateObjectSpace();
					
					BusinessLogic.Basis.Adresse neueAdresse = new BusinessLogic.Basis.Adresse(((DevExpress.ExpressApp.Xpo.XPObjectSpace) objectSpace).Session);
					neueAdresse.Empfehlungsgeber = ((DevExpress.ExpressApp.Xpo.XPObjectSpace) objectSpace).Session.GetObjectByKey<BusinessLogic.Basis.Adresse>(((BusinessLogic.Basis.Adresse) selectedAddress).Empfehlungsgeber.Oid);
					neueAdresse.AdressArt = ((DevExpress.ExpressApp.Xpo.XPObjectSpace) objectSpace).Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(1);
					
					DetailView detailView = Application.CreateDetailView(objectSpace, neueAdresse);
					detailView.ViewEditMode = ViewEditMode.Edit;
					e.ShowViewParameters.CreatedView = detailView;
					
				}
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				
				
				
				Session session = ((XPObjectSpace) View.ObjectSpace).Session;
				MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(session);
				exeptionError.Zeitstempel = DateTime.Now;
				exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
				exeptionError.GewähltesObjekt = "ViewControler: " + this.Name;
				exeptionError.Aktion = "Private Sub NeueEmpfehlungerstellen_Execute(sender As Object, e As SimpleActionExecuteEventArgs) Handles NeueEmpfehlungerstellen.Execute";
				exeptionError.Fehlermeldung = ex.Message;
			}
			
			
			
		}
	}
	
}
