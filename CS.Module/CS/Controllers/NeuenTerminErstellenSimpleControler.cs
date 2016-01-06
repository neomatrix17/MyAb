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
	public partial class NeuenTerminErstellenSimpleControler : ViewController
	{
		public NeuenTerminErstellenSimpleControler()
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
		
		public void SimpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			if (!(View == null))
			{
				
				object selectedAddress = null;
                // TODO Check this.
                DetailView detailView = null;
				
				if (!(((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer == null))
				{
					if (((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer.Oid == 43)
					{
						var s = ((BusinessLogic.Basis.Adresse) selectedAddress).Session;
						((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer = s.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
						((BusinessLogic.Basis.Adresse) selectedAddress).Save();
					}
				}
				
				if (View.ObjectTypeInfo.FullName == "AdressenManagement.Module.BusinessLogic.Basis.Adresse")
				{
					if (View.SelectedObjects.Count > 0)
					{
						selectedAddress = View.SelectedObjects[0];
					}
				}
				else
				{
                    DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();

                    detailView = Application.CreateDetailView(objectSpace, BusinessLogic.Basis.Termin.GetInstance(objectSpace, null));
                    detailView.ViewEditMode = ViewEditMode.Edit;
                    e.ShowViewParameters.CreatedView = detailView;
				}
				
				DevExpress.ExpressApp.IObjectSpace os1 = Application.CreateObjectSpace();
                var ter = BusinessLogic.Basis.Termin.GetInstance(os1, (BusinessLogic.Basis.Adresse)selectedAddress);

                ter.TerminArt = os1.GetObjectByKey<BusinessLogic.Basis.TerminArt>(2);
				ter.Gesprächsergebnis = null;
				ter.Gesprächspartner = null;
				
				//TerminArt = Session.GetObjectByKey(Of BusinessLogic.Basis.TerminArt)(2)
				//Gesprächsergebnis = Session.GetObjectByKey(Of BusinessLogic.Basis.Status)(27)
				//Gesprächspartner = Session.GetObjectByKey(Of BusinessLogic.Basis.Gesprächspartner)(5)

                detailView = Application.CreateDetailView(os1, ter);
				
				detailView.ViewEditMode = ViewEditMode.Edit;
				
				e.ShowViewParameters.CreatedView = detailView;
				
			}
			else
			{
				
				
				DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
				
				DetailView detailView = Application.CreateDetailView(objectSpace, BusinessLogic.Basis.Termin.GetInstance(objectSpace, null));
				detailView.ViewEditMode = ViewEditMode.Edit;
				e.ShowViewParameters.CreatedView = detailView;
				
			}
			
		}
		
	}
}
