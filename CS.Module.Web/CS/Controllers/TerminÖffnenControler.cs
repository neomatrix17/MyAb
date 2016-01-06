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
	public partial class TerminÖffnenControler : ViewController
	{
		public TerminÖffnenControler()
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
		
		public void TerminÖffnen_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			if (!(View == null))
			{
				
				object selectedTermin = null;
				
				if (View.ObjectTypeInfo.FullName == "AdressenManagement.Module.BusinessLogic.Basis.Termin")
				{
					if (View.SelectedObjects.Count > 0)
					{
						selectedTermin = View.SelectedObjects[0];
					}
					else
					{
						return;
					}
				}
				
				var objectSpace = Application.CreateObjectSpace();
				
				if (!(selectedTermin == null))
				{
					
					if (!(((BusinessLogic.Basis.Termin) selectedTermin) == null))
					{
						DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.GetObjectByKey<BusinessLogic.Basis.Termin>(((BusinessLogic.Basis.Termin) selectedTermin).Oid));
						detailView.ViewEditMode = ViewEditMode.View;
						e.ShowViewParameters.CreatedView = detailView;
					}
					
				}
				
			}
			
		}
	}
	
}
