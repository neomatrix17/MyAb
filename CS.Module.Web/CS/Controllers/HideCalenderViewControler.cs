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
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Scheduler.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.ExpressApp.Web;

namespace AdressenManagement.Module.Web
{
	
	
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class HideCalenderViewControler : ViewController<ListView>
	{
		public HideCalenderViewControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
			
			TargetObjectType = typeof(IEvent);
			
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			var usr = (BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser;
			
			if (!(usr == null))
			{
				
				if (!(WebWindow.CurrentRequestWindow == null))
				{
					if (!usr.IsCalenderVisible)
					{
						WebWindow.CurrentRequestWindow.PagePreRender += CurrentRequestWindow_PagePreRender;
					}
					else
					{
						WebWindow.CurrentRequestWindow.PagePreRender += CurrentRequestWindow_PagePreRenderShow;
					}
				}
				
			}
			
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
		
		public void ShowCalender_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			var usr = (BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser;
			
			if (!(usr == null))
			{
				usr.IsCalenderVisible = !usr.IsCalenderVisible;
				usr.Save();
				usr.Session.CommitTransaction();
				ASPxSchedulerListEditor listEditor = View.Editor as ASPxSchedulerListEditor;
				if (listEditor != null)
				{
					((ASPxDateNavigator) listEditor.DateNavigator).Visible = System.Convert.ToBoolean(usr.IsCalenderVisible);
					ProcessAction("Kal");
				}
				
			}
			
		}
		
		private void CurrentRequestWindow_PagePreRender(object sender, EventArgs e)
		{
			
			if (!(View == null))
			{
				if (!(View.Editor == null))
				{
					ASPxSchedulerListEditor listEditor = View.Editor as ASPxSchedulerListEditor;
					if (listEditor != null)
					{
						((ASPxDateNavigator) listEditor.DateNavigator).Visible = false;
					}
				}
			}
			
		}
		
		private void CurrentRequestWindow_PagePreRenderShow(object sender, EventArgs e)
		{
			
			if (!(View == null))
			{
				if (!(View.Editor == null))
				{
					ASPxSchedulerListEditor listEditor = View.Editor as ASPxSchedulerListEditor;
					if (listEditor != null)
					{
						((ASPxDateNavigator) listEditor.DateNavigator).Visible = true;
					}
				}
			}
			
		}
		
		public void ProcessAction(string parameter)
		{
			ShowNavigationItemController controller = Frame.GetController<ShowNavigationItemController>();
			if (controller != null)
			{
				ChoiceActionItem item = default(ChoiceActionItem);
				if (parameter.Contains("bottom"))
				{
					item = controller.ShowNavigationItemAction.FindItemByCaptionPath("Navigation/Navigation System");
				}
				else
				{
					item = controller.ShowNavigationItemAction.SelectedItem;
				}
				
				if (!(item == null))
				{
					controller.ShowNavigationItemAction.DoExecute(item);
				}
				
			}
		}
		
	}
	
}
