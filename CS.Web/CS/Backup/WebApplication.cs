// VBConversions Note: VB project level imports
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Web.Security;
using System.Collections.Generic;
using System.Data;
using System.Collections.Specialized;
using System.Web.Profile;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections;
using System;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Text;
using System.Web.Caching;
using System.Web.UI.WebControls.WebParts;
// End of VB project level imports

using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using AdressenManagement.Module;


// For more typical usage scenarios, be sure to check out http:'documentation.devexpress.com/#Xaf/DevExpressExpressAppWebWebApplicationMembericAll
public partial class AdressenManagementAspNetApplication : WebApplication
{
	private DevExpress.ExpressApp.SystemModule.SystemModule module1;
	private DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule module2;
	private AdressenManagement.Module.AdressenManagementModule module3;
	internal DevExpress.ExpressApp.Chart.Web.ChartAspNetModule ChartAspNetModule1;
	internal DevExpress.ExpressApp.Chart.ChartModule ChartModule1;
	internal DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule FileAttachmentsAspNetModule1;
	internal DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule HtmlPropertyEditorAspNetModule1;
	internal DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule NotificationsModuleWeb1;
	internal DevExpress.ExpressApp.Notifications.NotificationsModule NotificationsModule1;
	internal DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule PivotChartAspNetModule1;
	internal DevExpress.ExpressApp.PivotChart.PivotChartModuleBase PivotChartModuleBase1;
	internal DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule PivotGridAspNetModule1;
	internal DevExpress.ExpressApp.PivotGrid.PivotGridModule PivotGridModule1;
	internal DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2 ReportsAspNetModuleV21;
	internal DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 ReportsModuleV21;
	internal DevExpress.ExpressApp.AuditTrail.AuditTrailModule AuditTrailModule1;
	internal DevExpress.ExpressApp.CloneObject.CloneObjectModule CloneObjectModule1;
	internal DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule ConditionalAppearanceModule1;
	internal DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule BusinessClassLibraryCustomizationModule1;
	internal DevExpress.ExpressApp.Validation.ValidationModule ValidationModule1;
	internal DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule ViewVariantsModule1;
	internal DevExpress.ExpressApp.Workflow.WorkflowModule WorkflowModule1;
	internal DevExpress.ExpressApp.Security.SecurityStrategyComplex SecurityStrategyComplex1;
	internal DevExpress.ExpressApp.Security.AuthenticationStandard AuthenticationStandard1;
	internal DevExpress.ExpressApp.Security.SecurityModule SecurityModule1;
	internal DevExpress.ExpressApp.TreeListEditors.Web.TreeListEditorsAspNetModule TreeListEditorsAspNetModule1;
	internal DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase TreeListEditorsModuleBase1;
	internal DevExpress.ExpressApp.Kpi.KpiModule KpiModule1;
	internal DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule SchedulerAspNetModule1;
	internal DevExpress.ExpressApp.Scheduler.SchedulerModuleBase SchedulerModuleBase1;
	internal AdressenManagement.Module.AdressenManagementModule AdressenManagementModule1;
	private AdressenManagement.Module.Web.AdressenManagementAspNetModule module4;
	
	
	public AdressenManagementAspNetApplication()
	{
		InitializeComponent();
		GlobalBase.MainSite = this;
		//Me.DelayedViewItemsInitialization = False
		MaxLogonAttemptCount = 20;
	}
	
	protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
	{
		//args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
		
		args.ObjectSpaceProvider = new SecuredObjectSpaceProvider((SecurityStrategyComplex) Security, args.ConnectionString, args.Connection);
		
		AdressenManagement.Module.GlobalBase.CurrentConn = args.ConnectionString;
		
		var tempList = AdressenManagement.Module.GlobalBase.CurrentConn.Split('=');
		
		AdressenManagement.Module.GlobalBase.ModuleName = tempList[4];
		
		Gurock.SmartInspect.SiAuto.Si.Connections = "tcp()";
		Gurock.SmartInspect.SiAuto.Si.Enabled = true;
		Gurock.SmartInspect.SiAuto.Si.AppName = AdressenManagement.Module.GlobalBase.ModuleName;
		Gurock.SmartInspect.SiAuto.Main.LogSystem();
		Gurock.SmartInspect.SiAuto.Main.LogMessage("Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)");
		
		try
		{
			if (AdressenManagement.Module.GlobalBase.MailManager == null)
			{
				AdressenManagement.Module.Manager.Mail.MailManager mm = new AdressenManagement.Module.Manager.Mail.MailManager();
			}
		}
		catch (Exception)
		{
			
		}
		
	}
	private void AdressenManagementAspNetApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
	{
		
#if EASYTEST
		e.Updater.Update();
		e.Handled = true;
#else
		if (System.Diagnostics.Debugger.IsAttached)
		{
			e.Updater.Update();
			e.Handled = true;
		}
		else
		{
			string message = "The application cannot connect to the specified database, because the latter doesn\'t exist or its version is older than that of the application." + Constants.vbCrLf + 
				"This error occurred  because the automatic database update was disabled when the application was started without debugging." + Constants.vbCrLf + 
				"To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " + 
				"source code of the \'DatabaseVersionMismatch\' event handler to enable automatic database update, " + 
				"or manually create a database using the \'DBUpdater\' tool." + Constants.vbCrLf + 
				"Anyway, refer to the following help topics for more detailed information:" + Constants.vbCrLf + 
				"\'Update Application and Database Versions\' at http:\'www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm" + Constants.vbCrLf + 
				"\'Database Security References\' at http:\'www.devexpress.com/Help/?document=ExpressApp/CustomDocument3237.htm" + Constants.vbCrLf + 
				"If this doesn\'t help, please contact our Support Team at http:\'www.devexpress.com/Support/Center/";
			
			if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
			{
				message += Constants.vbCrLf + Constants.vbCrLf + "Inner exception: " + e.CompatibilityError.Exception.Message;
			}
			throw (new InvalidOperationException(message));
		}
#endif
	}
	private void InitializeComponent()
	{
		this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
		base.DatabaseVersionMismatch += new System.EventHandler(AdressenManagementAspNetApplication_DatabaseVersionMismatch);
		this.LoggedOn += new System.EventHandler(WebApplication_LoggedOn);
		this.LoggingOff += new System.EventHandler(WebApplication_LoggingOff);
		this.LogonFailed += new System.EventHandler(BauManager2015AspNetApplication_LogonFailed);
		this.module2 = new DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule();
		this.ChartAspNetModule1 = new DevExpress.ExpressApp.Chart.Web.ChartAspNetModule();
		this.ChartModule1 = new DevExpress.ExpressApp.Chart.ChartModule();
		this.FileAttachmentsAspNetModule1 = new DevExpress.ExpressApp.FileAttachments.Web.FileAttachmentsAspNetModule();
		this.HtmlPropertyEditorAspNetModule1 = new DevExpress.ExpressApp.HtmlPropertyEditor.Web.HtmlPropertyEditorAspNetModule();
		this.NotificationsModuleWeb1 = new DevExpress.ExpressApp.Notifications.Web.NotificationsAspNetModule();
		this.NotificationsModule1 = new DevExpress.ExpressApp.Notifications.NotificationsModule();
		this.PivotChartAspNetModule1 = new DevExpress.ExpressApp.PivotChart.Web.PivotChartAspNetModule();
		this.PivotChartModuleBase1 = new DevExpress.ExpressApp.PivotChart.PivotChartModuleBase();
		this.PivotGridAspNetModule1 = new DevExpress.ExpressApp.PivotGrid.Web.PivotGridAspNetModule();
		this.PivotGridModule1 = new DevExpress.ExpressApp.PivotGrid.PivotGridModule();
		this.ReportsAspNetModuleV21 = new DevExpress.ExpressApp.ReportsV2.Web.ReportsAspNetModuleV2();
		this.ReportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
		this.AuditTrailModule1 = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
		this.CloneObjectModule1 = new DevExpress.ExpressApp.CloneObject.CloneObjectModule();
		this.ConditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
		this.BusinessClassLibraryCustomizationModule1 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
		this.ValidationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
		this.ViewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
		this.WorkflowModule1 = new DevExpress.ExpressApp.Workflow.WorkflowModule();
		this.TreeListEditorsAspNetModule1 = new DevExpress.ExpressApp.TreeListEditors.Web.TreeListEditorsAspNetModule();
		this.TreeListEditorsModuleBase1 = new DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase();
		this.KpiModule1 = new DevExpress.ExpressApp.Kpi.KpiModule();
		this.SchedulerAspNetModule1 = new DevExpress.ExpressApp.Scheduler.Web.SchedulerAspNetModule();
		this.SchedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
		this.module3 = new AdressenManagement.Module.AdressenManagementModule();
		this.module4 = new AdressenManagement.Module.Web.AdressenManagementAspNetModule();
		this.SecurityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
		this.SecurityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
		this.AuthenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
		this.AdressenManagementModule1 = new AdressenManagement.Module.AdressenManagementModule();
		((System.ComponentModel.ISupportInitialize) this).BeginInit();
		//
		//NotificationsModule1
		//
		this.NotificationsModule1.DefaultNotificationsProvider = null;
		this.NotificationsModule1.NotificationsRefreshInterval = System.TimeSpan.Parse("00:30:00");
		//
		//PivotChartModuleBase1
		//
		this.PivotChartModuleBase1.ShowAdditionalNavigation = false;
		//
		//ReportsModuleV21
		//
		this.ReportsModuleV21.EnableInplaceReports = true;
		this.ReportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
		//
		//AuditTrailModule1
		//
		this.AuditTrailModule1.AuditDataItemPersistentType = typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent);
		//
		//ValidationModule1
		//
		this.ValidationModule1.AllowValidationDetailsAccess = true;
		this.ValidationModule1.IgnoreWarningAndInformationRules = false;
		//
		//WorkflowModule1
		//
		this.WorkflowModule1.RunningWorkflowInstanceInfoType = typeof(DevExpress.ExpressApp.Workflow.Xpo.XpoRunningWorkflowInstanceInfo);
		this.WorkflowModule1.StartWorkflowRequestType = typeof(DevExpress.ExpressApp.Workflow.Xpo.XpoStartWorkflowRequest);
		this.WorkflowModule1.UserActivityVersionType = typeof(DevExpress.ExpressApp.Workflow.Versioning.XpoUserActivityVersion);
		this.WorkflowModule1.WorkflowControlCommandRequestType = typeof(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowInstanceControlCommandRequest);
		this.WorkflowModule1.WorkflowDefinitionType = typeof(DevExpress.ExpressApp.Workflow.Xpo.XpoWorkflowDefinition);
		this.WorkflowModule1.WorkflowInstanceKeyType = typeof(DevExpress.Workflow.Xpo.XpoInstanceKey);
		this.WorkflowModule1.WorkflowInstanceType = typeof(DevExpress.Workflow.Xpo.XpoWorkflowInstance);
		//
		//SecurityStrategyComplex1
		//
		this.SecurityStrategyComplex1.Authentication = this.AuthenticationStandard1;
		this.SecurityStrategyComplex1.RoleType = typeof(AdressenManagement.Module.BusinessLogic.Intern.MitarbeiterRolle);
		this.SecurityStrategyComplex1.UserType = typeof(AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter);
		//
		//AuthenticationStandard1
		//
		this.AuthenticationStandard1.LogonParametersType = typeof(DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters);
		//
		//AdressenManagementAspNetApplication
		//
		this.ApplicationName = "AdressenManagement";
		this.Modules.Add(this.module1);
		this.Modules.Add(this.module2);
		this.Modules.Add(this.AuditTrailModule1);
		this.Modules.Add(this.ChartModule1);
		this.Modules.Add(this.CloneObjectModule1);
		this.Modules.Add(this.ConditionalAppearanceModule1);
		this.Modules.Add(this.NotificationsModule1);
		this.Modules.Add(this.PivotGridModule1);
		this.Modules.Add(this.BusinessClassLibraryCustomizationModule1);
		this.Modules.Add(this.ReportsModuleV21);
		this.Modules.Add(this.ValidationModule1);
		this.Modules.Add(this.ViewVariantsModule1);
		this.Modules.Add(this.WorkflowModule1);
		this.Modules.Add(this.KpiModule1);
		this.Modules.Add(this.module3);
		this.Modules.Add(this.module4);
		this.Modules.Add(this.ChartAspNetModule1);
		this.Modules.Add(this.FileAttachmentsAspNetModule1);
		this.Modules.Add(this.HtmlPropertyEditorAspNetModule1);
		this.Modules.Add(this.NotificationsModuleWeb1);
		this.Modules.Add(this.PivotChartModuleBase1);
		this.Modules.Add(this.PivotChartAspNetModule1);
		this.Modules.Add(this.PivotGridAspNetModule1);
		this.Modules.Add(this.ReportsAspNetModuleV21);
		this.Modules.Add(this.SecurityModule1);
		this.Modules.Add(this.TreeListEditorsModuleBase1);
		this.Modules.Add(this.TreeListEditorsAspNetModule1);
		this.Modules.Add(this.SchedulerModuleBase1);
		this.Modules.Add(this.SchedulerAspNetModule1);
		this.Security = this.SecurityStrategyComplex1;
		((System.ComponentModel.ISupportInitialize) this).EndInit();
		
	}
	
	protected override void OnLoggingOn(LogonEventArgs args)
	{
		
		try
		{
			base.OnLoggingOn(args);
			if (!(ShowViewStrategy == null))
			{
				((ShowViewStrategy) base.ShowViewStrategy).CollectionsEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
			}
		}
		catch (Exception ex)
		{
			Gurock.SmartInspect.SiAuto.Main.LogException(ex);
		}
		
	}
	
	public bool PerformOutsideLogOn(DevExpress.ExpressApp.LogonEventArgs args)
	{
		
		if (!(args == null))
		{
			Trace.WriteLine(args.LogonParameters.UserName);
			try
			{
				base.Logon(new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventArgs(null, null, null));
				return true;
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				HttpContext.Current.Session.Add("CustomError", ex.Message);
				Trace.TraceError(ex.Message);
				return false;
			}
		}
		
	}
	
	protected override void OnLoggedOn(LogonEventArgs args)
	{
		
		if (!(args == null))
		{
			try
			{
				base.OnLoggedOn(args);
				
				string role = "";
				
				var user = SecuritySystem.CurrentUser as AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter;
				
				if (!(user == null))
				{
					var roles = user.MitarbeiterRollen;
					foreach (AdressenManagement.Module.BusinessLogic.Intern.MitarbeiterRolle r in roles)
					{
						role = r.Name;
					}
				}
				
				if (!(role == "Telefonist"))
				{
					IModelApplicationNavigationItems navigationItems = this.Model as IModelApplicationNavigationItems;
					if (navigationItems != null)
					{
						foreach (IModelNavigationItem item in navigationItems.NavigationItems.AllItems)
						{
							if (!(item.View == null) && item.View.Id == "Termine_SchedulerView")
							{
								navigationItems.NavigationItems.StartupNavigationItem = item;
								break;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				Trace.TraceError(ex.Message);
			}
		}
		
	}
	
	private void WebApplication_LoggedOn(object sender, LogonEventArgs e)
	{
		
		try
		{
			if (!(SecuritySystem.CurrentUser == null))
			{
				
				if (!((AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).IsKunde.HasValue)
				{
					
					try
					{
						//TODO Remember this line of code
						var os = ((XafApplication) sender).CreateObjectSpace();
						
						var logRecord = os.CreateObject<AdressenManagement.Module.BusinessLogic.Basis.CustomLog>();
						
						logRecord.Benutzername = SecuritySystem.CurrentUserName;
						logRecord.BenutzerID = SecuritySystem.CurrentUserId;
						logRecord.SystemName = this.ApplicationName;
						logRecord.Zeitstempel = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
						logRecord.AktionsProtokoll = AdressenManagement.Module.BusinessLogic.Basis.CustomLog.AktionsTyp.BenutzerAnmeldung;
						os.CommitChanges();
						
						DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] = (?) AND [Mitarbeietr] = (?)", DateTime.Now.Date, SecuritySystem.CurrentUserId);
						var zo = os.FindObject<AdressenManagement.Module.BusinessLogic.Intern.ZeitstempelObjekt>(filter);
						
						if (zo == null)
						{
							zo = os.CreateObject<AdressenManagement.Module.BusinessLogic.Intern.ZeitstempelObjekt>();
							zo.Mitarbeietr = os.FindObject<AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter>(new DevExpress.Data.Filtering.BinaryOperator("Oid", SecuritySystem.CurrentUserId));
							zo.AngemeldetUm = DateTime.Now;
							zo.Anmeldungen = zo.Anmeldungen + 1;
							zo.Save();
							os.CommitChanges();
						}
						else
						{
							zo.Anmeldungen = zo.Anmeldungen + 1;
							zo.Save();
							os.CommitChanges();
						}
						
						AdressenManagement.Module.BusinessLogic.Intern.RecensaWatch recensaWatch = new AdressenManagement.Module.BusinessLogic.Intern.RecensaWatch(zo);
						HttpContext.Current.Session.Add("Watch" + System.Convert.ToString(SecuritySystem.CurrentUserId), recensaWatch);
						//ProcessFormsAuthenticationRedirectUrl(True)
						
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					}
					
				}
				
			}
		}
		catch (Exception)
		{
			
		}
		
	}
	
	private void WebApplication_LoggingOff(object sender, LoggingOffEventArgs e)
	{
		
		try
		{
			if (!(SecuritySystem.CurrentUser == null))
			{
				
				if (!((AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).IsKunde.HasValue)
				{
					
					var os = ((XafApplication) sender).CreateObjectSpace();
					
					AdressenManagement.Module.BusinessLogic.Intern.RecensaWatch recensaWatch = default(AdressenManagement.Module.BusinessLogic.Intern.RecensaWatch);
					recensaWatch = null;
					
					if (!(HttpContext.Current == null))
					{
						var s = HttpContext.Current.Session["Watch" + System.Convert.ToString(SecuritySystem.CurrentUserId)];
						if (!(s == null))
						{
							recensaWatch = s;
						}
					}
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] = (?) AND [Mitarbeietr] = (?)", DateTime.Now.Date, SecuritySystem.CurrentUserId);
					var zo = os.FindObject<AdressenManagement.Module.BusinessLogic.Intern.ZeitstempelObjekt>(filter);
					
					if (!(zo == null))
					{
						zo.AbgemeldetUm = DateTime.Now;
						zo.Abmeldungen = zo.Abmeldungen + 1;
						zo.Save();
						os.CommitChanges();
						recensaWatch.Dispose();
					}
					
				}
				
			}
		}
		catch (Exception ex)
		{
			Gurock.SmartInspect.SiAuto.Main.LogException(ex);
			
			
			
		}
		
	}
	
	private void BauManager2015AspNetApplication_LogonFailed(object sender, DevExpress.ExpressApp.LogonFailedEventArgs e)
	{
		
		try
		{
			var os = ((XafApplication) sender).CreateObjectSpace();
			
			var logRecord = os.CreateObject<AdressenManagement.Module.BusinessLogic.Basis.CustomLog>();
			
			logRecord.Benutzername = e.LogonParameters.UserName;
			logRecord.SystemName = this.ApplicationName;
			logRecord.Zeitstempel = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			logRecord.AktionsProtokoll = AdressenManagement.Module.BusinessLogic.Basis.CustomLog.AktionsTyp.FehlgeschlageneBenutzerAnmeldung;
			logRecord.Fehlermeldung = e.Exception.Message;
			os.CommitChanges();
			
		}
		catch (Exception ex)
		{
			Gurock.SmartInspect.SiAuto.Main.LogException(ex);
			
			
			
		}
		
	}
	
}
