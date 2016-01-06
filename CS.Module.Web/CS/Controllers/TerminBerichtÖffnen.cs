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
	public partial class TerminBerichtÖffnen : ViewController
	{
		public TerminBerichtÖffnen()
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
		
		private void TerminBerichtOeffnen_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
		{
			
		}
		
		private void TerminBerichtOeffnen_CustomizeTemplate(object sender, CustomizeTemplateEventArgs e)
		{
			
		}
		
		public void TerminBerichtOeffnen2_Execute(object sender, SimpleActionExecuteEventArgs e)
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
					
					if (!(((BusinessLogic.Basis.Termin) selectedTermin).TerminBericht == null))
					{
						
						DetailView detailView = Application.CreateDetailView(objectSpace, objectSpace.GetObjectByKey<BusinessLogic.Basis.TerminBericht>(((BusinessLogic.Basis.Termin) selectedTermin).TerminBericht.Oid));
						detailView.ViewEditMode = ViewEditMode.Edit;
						e.ShowViewParameters.CreatedView = detailView;
					}
					
				}
				
			}
			
		}
	}
	
}
