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
	public partial class NeuerTerminWindowControler : ObjectViewController
	{
		public NeuerTerminWindowControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			//For Each item As PropertyEditor In View.GetItems(Of PropertyEditor)()
			//    If item.Id = "StartOn" Then
			//        AddHandler item.ControlValueChanged, AddressOf StartOnChanged
			//        AddHandler item.CurrentObjectChanged, AddressOf test
			//    End If
			//Next
			
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
		
		private void StartOnChanged(object sender, EventArgs e)
		{
			foreach (PropertyEditor item in View.GetItems<PropertyEditor>())
			{
				if (item.Id == "EndOn")
				{
					DateTime currDate = System.Convert.ToDateTime(((global::AdressenManagement.Module.Web.CustomDateTimeEditor) sender).PropertyValue);
					((global::AdressenManagement.Module.Web.CustomDateTimeEditor) item).PropertyValue = currDate.AddHours(1);
				}
			}
		}
		
		private void test(object sender, EventArgs e)
		{
			
		}
		
	}
	
}
