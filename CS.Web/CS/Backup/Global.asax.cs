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

using System.Web.Configuration;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using AdressenManagement.Module;
using DevExpress.ExpressApp.Security.Adapters;
using DevExpress.ExpressApp.Security.Xpo.Adapters;



public class Global : System.Web.HttpApplication
{
	public Global()
	{
		InitializeComponent();
	}
	protected void Application_Start(object sender, EventArgs e)
	{
		try
		{
			ASPxWebControl.CallbackError += Application_Error;
#if EASYTEST
			DevExpress.ExpressApp.Web.TestScripts.TestScriptsManager.EasyTestEnabled = true;
#endif
		}
		catch (Exception)
		{
			
		}
		
		IsGrantedAdapter.Enable(new XpoIntegratedCachedRequestSecurityAdapterProvider(), ReloadPermissionStrategy.NoCache);
		
		Trace.WriteLine("Start.");
		
	}
	
	protected void Session_Start(object sender, EventArgs e)
	{
		
		try
		{
			WebApplication.SetInstance(Session, new AdressenManagementAspNetApplication());
			if (!(ConfigurationManager.ConnectionStrings["ConnectionString"] == null))
			{
				WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
#if EASYTEST
			if (!(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] == null))
			{
				WebApplication.Instance.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
			if (System.Diagnostics.Debugger.IsAttached)
			{
				WebApplication.Instance.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
			}
			
			WebApplication.Instance.Settings.DefaultVerticalTemplateContentPath = 
				"MyDefaultVerticalTemplateContent.ascx";
			
			WebApplication.Instance.CheckCompatibilityType = CheckCompatibilityType.DatabaseSchema;
			WebApplication.Instance.Setup();
			Trace.WriteLine("Setup.");
			WebApplication.Instance.Start();
			
		}
		catch (Exception)
		{
		}
		
	}
	protected void Application_BeginRequest(object sender, EventArgs e)
	{
	}
	protected void Application_EndRequest(object sender, EventArgs e)
	{
	}
	protected void Application_AuthenticateRequest(object sender, EventArgs e)
	{
	}
	protected void Application_Error(object sender, EventArgs e)
	{
		//ErrorHandling.Instance.ProcessApplicationError()
	}
	protected void Session_End(object sender, EventArgs e)
	{
		try
		{
			WebApplication.LogOff(Session);
			WebApplication.DisposeInstance(Session);
		}
		catch (Exception)
		{
		}
	}
	protected void Application_End(object sender, EventArgs e)
	{
	}
#region Web Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	}
#endregion
	
}

