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
	public partial class StatusNeuControler : ViewController
	{
		public StatusNeuControler()
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
		
		public void NochNichtKontaktiertNeu_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			if (!(e.CurrentObject == null))
			{
				if (!(((BusinessLogic.Basis.Adresse) e.CurrentObject).Besitzer == null))
				{
					//If DirectCast(e.CurrentObject, BusinessLogic.Basis.Adresse).Besitzer.Oid = 43 Then
					//    Dim s = DirectCast(e.CurrentObject, BusinessLogic.Basis.Adresse).Session
					//    DirectCast(e.CurrentObject, BusinessLogic.Basis.Adresse).Besitzer = s.GetObjectByKey(Of BusinessLogic.Intern.Mitarbeiter)(SecuritySystem.CurrentUserId)
					//    DirectCast(e.CurrentObject, BusinessLogic.Basis.Adresse).Save()
					//End If
				}
                //check this
				((BusinessLogic.Basis.Adresse) e.CurrentObject).Status = ((BusinessLogic.Basis.Adresse) e.CurrentObject).Session.GetObjectByKey<BusinessLogic.Basis.Status>(28);
				var anrufProtokoll = ObjectSpace.CreateObject<MainModel.Anrufprotokoll>();
				anrufProtokoll.Mitarbeiter = ObjectSpace.FindObject<BusinessLogic.Intern.Mitarbeiter>(new DevExpress.Data.Filtering.BinaryOperator("Oid", SecuritySystem.CurrentUserId));
				anrufProtokoll.Adresse =(BusinessLogic.Basis.Adresse) e.CurrentObject;
				anrufProtokoll.Status = ((BusinessLogic.Basis.Adresse) e.CurrentObject).Status.Name;
				anrufProtokoll.Save();
				ObjectSpace.SetModified(e.CurrentObject);
				ObjectSpace.CommitChanges();
				var controler = Frame.GetController<ModificationsController>();
				controler.SaveAction.DoExecute();
			}
			
			Application.MainWindow.View.Close();
			
		}
	}
	
}
