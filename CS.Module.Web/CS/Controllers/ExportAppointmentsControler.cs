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
using System.Web;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
using System.IO;
using DevExpress.XtraPrinting;
using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Web.ASPxScheduler;
using DevExpress.ExpressApp.Scheduler.Web;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class ExportAppointmentsControler : ViewController
	{
		public ExportAppointmentsControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			//Frame.GetController(Of WebExportAnalysisController).Active.SetItemValue("MyReason", True)
			//Frame.GetController(Of ExportController).Active.SetItemValue("EmptyItems", True)
			
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
		
		public void AlsPdfExportieren_Execute(object sender, SimpleActionExecuteEventArgs e)
		{
			
			ListView currentView = View as ListView;
			
			if (!(currentView == null))
			{
				
				ASPxSchedulerListEditor listEditor = currentView.Editor as ASPxSchedulerListEditor;
				
				if (!(listEditor == null))
				{
					ASPxScheduler scheduler = listEditor.SchedulerControl;
					
					if (!(scheduler == null))
					{
						
						var dates = scheduler.ActiveView.GetVisibleIntervals();
						DateTime selecteddate = DateTime.Now.Date;
						if (!(dates == null))
						{
							selecteddate = dates.Start;
						}
						
						var apps = scheduler.Storage.Appointments;
						List<string> ids = new List<string>();
						foreach (DevExpress.XtraScheduler.Appointment appointment in apps.Items)
						{
							ids.Add(appointment.Id.ToString());
						}
						
						HttpContext.Current.Session.Add("ShedulerDate", selecteddate);
						HttpContext.Current.Session.Add("AppointmentList", ids);
						
					}
					
				}
				
			}
			
			IObjectSpace objectSpace = 
				ReportDataProvider.ReportObjectSpaceProvider.CreateObjectSpace(typeof(ReportDataV2));
			IReportDataV2 reportData = 
				objectSpace.FindObject<ReportDataV2>(CriteriaOperator.Parse("[DisplayName] = \'Mitarbeiter Tageskalender\'"));
			string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
			Frame.GetController<ReportServiceController>().ShowPreview(handle);
			
		}
		
	}
}
