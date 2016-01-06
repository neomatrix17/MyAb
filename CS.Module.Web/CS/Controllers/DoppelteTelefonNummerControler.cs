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
	public partial class DoppelteTelefonNummerControler : ViewController
	{
		
		private object adr;
		private string curr;
		
		public DoppelteTelefonNummerControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			var v = (DetailView) View;
			
			foreach (ViewItem o in v.Items)
			{
				
				if (o.Id == "TelefonNummer" || o.Id == "TelefonNummer2" || o.Id == "TelefonNummer3")
				{
					
					((PropertyEditor) o).ControlValueChanged += Telefonnummer_Changed;
					
					View.ObjectSpace.ObjectChanged += Chngd;
					
				}
				
			}
			AdressenVergleichen.Active.SetItemValue("myReason", false);
			
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
		
		private void Telefonnummer_Changed(object sender, EventArgs e)
		{
			
			var currentNum = ((PropertyEditor) sender).ControlValue;
			
			if (!(currentNum == null))
			{
				if (currentNum.ToString().StartsWith("0"))
				{
					currentNum = currentNum.ToString().Remove(0, 1);
				}
			}
			
			var addres = ObjectSpace.FindObject<BusinessLogic.Basis.Adresse>(CriteriaOperator.Parse("Contains([TelefonNummer], ?)",  currentNum));
			var addres2 = ObjectSpace.FindObject<BusinessLogic.Basis.Adresse>(CriteriaOperator.Parse("Contains([TelefonNummer2], ?)",  currentNum));
			var addres3 = ObjectSpace.FindObject<BusinessLogic.Basis.Adresse>(CriteriaOperator.Parse("Contains([TelefonNummer3], ?)", currentNum));
			//check this
			if (addres != null)
			{
				adr = addres;
				View.ErrorMessages.AddMessage("TelefonNummer", View.CurrentObject, "Diese Telefonnummer ist bereits im System vorhanden!");
				AdressenVergleichen.Active.SetItemValue("myReason", true);
				//Throw New UserFriendlyException(New Exception("Diese Telefonnummer ist bereits im System vorhanden! Drücken Sie den Adressen Vergleichen Button in der oberen Ebene."))
			}
			else if (addres2 != null)
			{
				adr = addres2;
				View.ErrorMessages.AddMessage("TelefonNummer2", View.CurrentObject, "Diese Telefonnummer ist bereits im System vorhanden!");
				AdressenVergleichen.Active.SetItemValue("myReason", true);
				//Throw New UserFriendlyException(New Exception("Diese Telefonnummer ist bereits im System vorhanden! Drücken Sie den Adressen Vergleichen Button in der oberen Ebene."))
			}
			else if (addres3 != null)
			{
				adr = addres3;
				View.ErrorMessages.AddMessage("TelefonNummer3", View.CurrentObject, "Diese Telefonnummer ist bereits im System vorhanden!");
				AdressenVergleichen.Active.SetItemValue("myReason", true);
				//Throw New UserFriendlyException(New Exception("Diese Telefonnummer ist bereits im System vorhanden! Drücken Sie den Adressen Vergleichen Button in der oberen Ebene."))
			}
			else
			{
				View.ErrorMessages.Clear();
				AdressenVergleichen.Active.SetItemValue("myReason", false);
			}
			
		}
		
		private void AdresseVergleichen_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			var os = Application.CreateObjectSpace();
			var ad = os.GetObjectByKey<BusinessLogic.Basis.Adresse>(((BusinessLogic.Basis.Adresse) adr).Oid);
			
			e.ShowViewParameters.CreatedView = Application.CreateDetailView(os, ad);
			
		}
		
		private void Chngd(object sender, ObjectChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Telefonnummer":
					curr = e.PropertyName;
					break;
				case "Telefonnummer2":
					curr = e.PropertyName;
					break;
				case "Telefonnummer3":
					curr = e.PropertyName;
					break;
			}
		}
		
		public void AdressenVergleichen_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
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
				
				var os = Application.CreateObjectSpace();
				var alteadresse = os.GetObjectByKey<BusinessLogic.Basis.Adresse>(((BusinessLogic.Basis.Adresse) adr).Oid);
				
				DetailView detailView = Application.CreateDetailView(os, alteadresse);
				detailView.ViewEditMode = ViewEditMode.Edit;
				e.View = detailView;
				
			}
			
		}
		
		public void AdressenVergleichen_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e)
		{
			
		}
	}
	
}
