// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports


namespace AdressenManagement.Win
{
	
	public partial class AdressenManagementWindowsFormsApplication
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
       		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (!(components == null)))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
#region Component Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.module1 = new DevExpress.ExpressApp.SystemModule.SystemModule();
			base.DatabaseVersionMismatch += AdressenManagementWindowsFormsApplication_DatabaseVersionMismatch;
			this.module2 = new DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule();
			this.module3 = new AdressenManagement.Module.AdressenManagementModule();
			this.module4 = new AdressenManagement.Module.Win.AdressenManagementWindowsFormsModule();
			this.AuditTrailModule1 = new DevExpress.ExpressApp.AuditTrail.AuditTrailModule();
			this.ChartModule1 = new DevExpress.ExpressApp.Chart.ChartModule();
			this.CloneObjectModule1 = new DevExpress.ExpressApp.CloneObject.CloneObjectModule();
			this.ConditionalAppearanceModule1 = new DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule();
			this.NotificationsModule1 = new DevExpress.ExpressApp.Notifications.NotificationsModule();
			this.PivotGridModule1 = new DevExpress.ExpressApp.PivotGrid.PivotGridModule();
			this.BusinessClassLibraryCustomizationModule1 = new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule();
			this.ReportsModuleV21 = new DevExpress.ExpressApp.ReportsV2.ReportsModuleV2();
			this.ValidationModule1 = new DevExpress.ExpressApp.Validation.ValidationModule();
			this.ViewVariantsModule1 = new DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule();
			this.WorkflowModule1 = new DevExpress.ExpressApp.Workflow.WorkflowModule();
			this.ChartWindowsFormsModule1 = new DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule();
			this.FileAttachmentsWindowsFormsModule1 = new DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule();
			this.NotificationsModuleWin1 = new DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule();
			this.HtmlPropertyEditorWindowsFormsModule1 = new DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule();
			this.PivotChartWindowsFormsModule1 = new DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule();
			this.PivotChartModuleBase1 = new DevExpress.ExpressApp.PivotChart.PivotChartModuleBase();
			this.PivotGridWindowsFormsModule1 = new DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule();
			this.ReportsWindowsFormsModuleV21 = new DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2();
			this.SchedulerWindowsFormsModule1 = new DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule();
			this.SchedulerModuleBase1 = new DevExpress.ExpressApp.Scheduler.SchedulerModuleBase();
			this.ValidationWindowsFormsModule1 = new DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule();
			this.WorkflowWindowsFormsModule1 = new DevExpress.ExpressApp.Workflow.Win.WorkflowWindowsFormsModule();
			this.SecurityStrategyComplex1 = new DevExpress.ExpressApp.Security.SecurityStrategyComplex();
			this.AuthenticationStandard1 = new DevExpress.ExpressApp.Security.AuthenticationStandard();
			this.SecurityModule1 = new DevExpress.ExpressApp.Security.SecurityModule();
			this.TreeListEditorsWindowsFormsModule1 = new DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule();
			this.TreeListEditorsModuleBase1 = new DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase();
			this.KpiModule1 = new DevExpress.ExpressApp.Kpi.KpiModule();
			((System.ComponentModel.ISupportInitialize) this).BeginInit();
			//
			//AuditTrailModule1
			//
			this.AuditTrailModule1.AuditDataItemPersistentType = typeof(DevExpress.Persistent.BaseImpl.AuditDataItemPersistent);
			//
			//NotificationsModule1
			//
			this.NotificationsModule1.DefaultNotificationsProvider = null;
			this.NotificationsModule1.NotificationsRefreshInterval = System.TimeSpan.Parse("01:00:00");
			//
			//ReportsModuleV21
			//
			this.ReportsModuleV21.EnableInplaceReports = true;
			this.ReportsModuleV21.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.ReportDataV2);
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
			//PivotChartModuleBase1
			//
			this.PivotChartModuleBase1.ShowAdditionalNavigation = false;
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
			//AdressenManagementWindowsFormsApplication
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
			this.Modules.Add(this.ChartWindowsFormsModule1);
			this.Modules.Add(this.FileAttachmentsWindowsFormsModule1);
			this.Modules.Add(this.NotificationsModuleWin1);
			this.Modules.Add(this.HtmlPropertyEditorWindowsFormsModule1);
			this.Modules.Add(this.PivotChartModuleBase1);
			this.Modules.Add(this.PivotChartWindowsFormsModule1);
			this.Modules.Add(this.PivotGridWindowsFormsModule1);
			this.Modules.Add(this.ReportsWindowsFormsModuleV21);
			this.Modules.Add(this.SchedulerModuleBase1);
			this.Modules.Add(this.SchedulerWindowsFormsModule1);
			this.Modules.Add(this.ValidationWindowsFormsModule1);
			this.Modules.Add(this.WorkflowWindowsFormsModule1);
			this.Modules.Add(this.SecurityModule1);
			this.Modules.Add(this.TreeListEditorsModuleBase1);
			this.Modules.Add(this.TreeListEditorsWindowsFormsModule1);
			this.Security = this.SecurityStrategyComplex1;
			this.UseOldTemplates = false;
			((System.ComponentModel.ISupportInitialize) this).EndInit();
			
		}
		
#endregion
		
		private DevExpress.ExpressApp.SystemModule.SystemModule module1;
		private DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule module2;
		private global::AdressenManagement.Module.AdressenManagementModule module3;
		private global::AdressenManagement.Module.Win.AdressenManagementWindowsFormsModule module4;
		internal DevExpress.ExpressApp.AuditTrail.AuditTrailModule AuditTrailModule1;
		internal DevExpress.ExpressApp.Chart.ChartModule ChartModule1;
		internal DevExpress.ExpressApp.CloneObject.CloneObjectModule CloneObjectModule1;
		internal DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule ConditionalAppearanceModule1;
		internal DevExpress.ExpressApp.Notifications.NotificationsModule NotificationsModule1;
		internal DevExpress.ExpressApp.PivotGrid.PivotGridModule PivotGridModule1;
		internal DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule BusinessClassLibraryCustomizationModule1;
		internal DevExpress.ExpressApp.ReportsV2.ReportsModuleV2 ReportsModuleV21;
		internal DevExpress.ExpressApp.Validation.ValidationModule ValidationModule1;
		internal DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule ViewVariantsModule1;
		internal DevExpress.ExpressApp.Workflow.WorkflowModule WorkflowModule1;
		internal DevExpress.ExpressApp.Chart.Win.ChartWindowsFormsModule ChartWindowsFormsModule1;
		internal DevExpress.ExpressApp.FileAttachments.Win.FileAttachmentsWindowsFormsModule FileAttachmentsWindowsFormsModule1;
		internal DevExpress.ExpressApp.Notifications.Win.NotificationsWindowsFormsModule NotificationsModuleWin1;
		internal DevExpress.ExpressApp.HtmlPropertyEditor.Win.HtmlPropertyEditorWindowsFormsModule HtmlPropertyEditorWindowsFormsModule1;
		internal DevExpress.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule PivotChartWindowsFormsModule1;
		internal DevExpress.ExpressApp.PivotChart.PivotChartModuleBase PivotChartModuleBase1;
		internal DevExpress.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule PivotGridWindowsFormsModule1;
		internal DevExpress.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2 ReportsWindowsFormsModuleV21;
		internal DevExpress.ExpressApp.Scheduler.Win.SchedulerWindowsFormsModule SchedulerWindowsFormsModule1;
		internal DevExpress.ExpressApp.Scheduler.SchedulerModuleBase SchedulerModuleBase1;
		internal DevExpress.ExpressApp.Validation.Win.ValidationWindowsFormsModule ValidationWindowsFormsModule1;
		internal DevExpress.ExpressApp.Workflow.Win.WorkflowWindowsFormsModule WorkflowWindowsFormsModule1;
		internal DevExpress.ExpressApp.Security.SecurityStrategyComplex SecurityStrategyComplex1;
		internal DevExpress.ExpressApp.Security.AuthenticationStandard AuthenticationStandard1;
		internal DevExpress.ExpressApp.Security.SecurityModule SecurityModule1;
		internal DevExpress.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule TreeListEditorsWindowsFormsModule1;
		internal DevExpress.ExpressApp.TreeListEditors.TreeListEditorsModuleBase TreeListEditorsModuleBase1;
		internal DevExpress.ExpressApp.Kpi.KpiModule KpiModule1;
	}
	
}
