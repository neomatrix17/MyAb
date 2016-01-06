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
	public partial class AdresseNestedViewControler : ViewController
	{
		public AdresseNestedViewControler()
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
		
		public void AdresseNestedViewControler_Activated(object sender, EventArgs e)
		{
			
			//DirectCast(View, ListView).CollectionSource.Criteria.Clear()
			
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter1") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter2") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter3") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter4") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter5") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter6") = Nothing
			//DirectCast(View, ListView).CollectionSource.Criteria("Filter7") = Nothing
			
			//DirectCast(View, ListView).CollectionSource.Reload()
			
		}
		
	}
	
}
