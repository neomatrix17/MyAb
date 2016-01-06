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
using DevExpress.XtraPrinting.Export;
using DevExpress.ExpressApp.Web.Layout;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class AdresseHeaderDetailViewControler : ViewController<DetailView>
	{
		public AdresseHeaderDetailViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			
			base.OnActivated();
			
			((WebLayoutManager) View.LayoutManager).ItemCreated += ItemCreated;
		}
		protected override void OnDeactivated()
		{
			((WebLayoutManager) View.LayoutManager).ItemCreated -= ItemCreated;
			base.OnDeactivated();
		}
		
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		
		private void ItemCreated(object sender, ItemCreatedEventArgs e)
		{
			
			if (!(e.ModelLayoutElement == null))
			{
				if (e.ModelLayoutElement.Id == "Adresse")
				{
					((DevExpress.ExpressApp.Model.IModelLayoutGroup) e.ModelLayoutElement).Caption = "";
				}
			}
			
		}
		
		
		
	}
}
