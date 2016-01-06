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
	public partial class NewObjectFromNavigationController : WindowController
	{
		
		public NewObjectFromNavigationController()
		{
			TargetWindowType = WindowType.Main;
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			ShowNavigationItemController showNavigationItemController = Frame.GetController<ShowNavigationItemController>();
			showNavigationItemController.CustomShowNavigationItem += showNavigationItemController_CustomShowNavigationItem;
		}
		
		
		private void showNavigationItemController_CustomShowNavigationItem(object sender, CustomShowNavigationItemEventArgs e)
		{
			if (e.ActionArguments.SelectedChoiceActionItem.Id == "@78672aa1-1dd1-41a5-9160-b68d5da0c99f")
			{
				SingleChoiceAction newObjectAction = GetNewObjectAction();
				if (newObjectAction != null)
				{
					DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
					BusinessLogic.Basis.Adresse newIssue = objectSpace.CreateObject<BusinessLogic.Basis.Adresse>();
					DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
					detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
					e.ActionArguments.ShowViewParameters.CreatedView = detailView;
				}
				else
				{
					DevExpress.ExpressApp.IObjectSpace objectSpace = Application.CreateObjectSpace();
					BusinessLogic.Basis.Adresse newIssue = objectSpace.CreateObject<BusinessLogic.Basis.Adresse>();
					DetailView detailView = Application.CreateDetailView(objectSpace, newIssue);
					detailView.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
					e.ActionArguments.ShowViewParameters.CreatedView = detailView;
				}
				e.Handled = true;
			}
		}
		
		protected virtual SingleChoiceAction GetNewObjectAction()
		{
			return Frame.GetController<NewObjectViewController>().NewObjectAction;
		}
		
	}
	
}
