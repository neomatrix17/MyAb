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
	public partial class KontaktiertControler : ViewController
	{
		public KontaktiertControler()
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
		
		public void Kontaktiert_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			if (!(View == null))
			{
				
				object selectedAddress = null;
				
				if (View.ObjectTypeInfo.FullName == "AdressenManagement.Module.BusinessLogic.Basis.Adresse")
				{
					if (View.SelectedObjects.Count > 0)
					{
						selectedAddress = View.SelectedObjects[0];
						if (!(selectedAddress == null))
						{
							if (!(((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer == null))
							{
								if (((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer.Oid == 43)
								{
									var s = ((BusinessLogic.Basis.Adresse) selectedAddress).Session;
									((BusinessLogic.Basis.Adresse) selectedAddress).Besitzer = s.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
									((BusinessLogic.Basis.Adresse) selectedAddress).Save();
								}
							}
							((BusinessLogic.Basis.Adresse) selectedAddress).LetzterKontaktAm = DateTime.Now;
							((BusinessLogic.Basis.Adresse) selectedAddress).Save();
						}
					}
				}
				
				IObjectSpace objectSpace = Application.CreateObjectSpace();
                //check this
                var ter = (BusinessLogic.Basis.Termin)BusinessLogic.Basis.Termin.GetInstance(objectSpace, (BusinessLogic.Basis.Adresse)selectedAddress);
				
				ter.TerminArt = objectSpace.GetObjectByKey<BusinessLogic.Basis.TerminArt>(2);
				ter.Gesprächsergebnis = null;
				ter.Gesprächspartner = null;
				
				DetailView detailView = Application.CreateDetailView(objectSpace, ter);
				
				if (!(e.CurrentObject == null))
				{
					((BusinessLogic.Basis.Adresse) e.CurrentObject).Status = ((BusinessLogic.Basis.Adresse) e.CurrentObject).Session.GetObjectByKey<BusinessLogic.Basis.Status>(23);
					((BusinessLogic.Basis.Adresse) e.CurrentObject).LetzterKontaktAm = DateTime.Now;
					((BusinessLogic.Basis.Adresse) e.CurrentObject).Save();
				}
				
				detailView.ViewEditMode = ViewEditMode.Edit;
				
				e.ShowViewParameters.CreatedView = detailView;
				
			}
			else
			{
				
				IObjectSpace objectSpace = Application.CreateObjectSpace();
				
				if (!(e.CurrentObject == null))
				{
					((BusinessLogic.Basis.Adresse) e.CurrentObject).Save();
					((BusinessLogic.Basis.Adresse) e.CurrentObject).Status = ((BusinessLogic.Basis.Adresse) e.CurrentObject).Session.GetObjectByKey<BusinessLogic.Basis.Status>(23);
					((BusinessLogic.Basis.Adresse) e.CurrentObject).LetzterKontaktAm = DateTime.Now;
					objectSpace.SetModified(e.CurrentObject);
					objectSpace.CommitChanges();
					var controler = Frame.GetController<ModificationsController>();
					controler.SaveAction.DoExecute();
				}
                //check this
                var ter = (BusinessLogic.Basis.Termin)BusinessLogic.Basis.Termin.GetInstance(objectSpace, (BusinessLogic.Basis.Adresse)e.CurrentObject);
				
				ter.TerminArt = objectSpace.GetObjectByKey<BusinessLogic.Basis.TerminArt>(2);
				ter.Gesprächsergebnis = null;
				ter.Gesprächspartner = null;
				
				DetailView detailView = Application.CreateDetailView(objectSpace, ter);
				detailView.ViewEditMode = ViewEditMode.Edit;
				e.ShowViewParameters.CreatedView = detailView;
				
				
			}
			
		}
	}
	
}
