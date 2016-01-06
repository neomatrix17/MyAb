// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports


namespace AdressenManagement.Module
{
	
	public partial class AdressenManagementModule
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			//
			//AdressenManagementModule
			//
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.AuditTrail.AuditTrailModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Chart.ChartModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.CloneObject.CloneObjectModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Notifications.NotificationsModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.PivotGrid.PivotGridModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ViewVariantsModule.ViewVariantsModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Workflow.WorkflowModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Kpi.KpiModule));
			
		}
		
#endregion
	}
	
}
