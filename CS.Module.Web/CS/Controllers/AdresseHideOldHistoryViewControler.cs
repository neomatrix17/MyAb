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
	public partial class AdresseHideOldHistoryViewControler : ViewController
	{
		public AdresseHideOldHistoryViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			//If Not View.CurrentObject Is Nothing Then
			//    Dim ad = TryCast(View.CurrentObject, BusinessLogic.Basis.Adresse)
			
			//    If Not ad Is Nothing Then
			//        If Not ad.AdressArt Is Nothing Then
			//            If ad.AdressArt.Oid = 10 Then
			//                Dim v = DirectCast(View, DetailView)
			
			//                For Each o As ViewItem In v.Items
			//                    If o.Id = "AltesSystemProtokoll" Then
			//                        v.RemoveItem(o.Id)
			//                    End If
			//                    If o.Id = "AlteSystemHistorie" Then
			//                        v.RemoveItem(o.Id)
			//                    End If
			//                    If o.Id = "Tabs" Then
			//                        Dim t = o
			//                    End If
			//                Next
			
			//            End If
			//        End If
			//    End If
			
			//End If
			
			
			
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
	}
	
}
