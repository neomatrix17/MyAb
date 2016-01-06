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

using System.Configuration;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Win;
using DevExpress.Persistent.BaseImpl;
using AdressenManagement.Win;


namespace AdressenManagement.Win
{
	
	public class Program
	{
		
		[STAThread()]public static void Main(string[] arguments)
		{
#if EASYTEST
			DevExpress.ExpressApp.Win.EasyTest.EasyTestRemotingRegistration.Register();
#endif
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			EditModelPermission.AlwaysGranted = System.Diagnostics.Debugger.IsAttached;
			AdressenManagementWindowsFormsApplication _application = new AdressenManagementWindowsFormsApplication();
			// Refer to the http://documentation.devexpress.com/#Xaf/CustomDocument2680 help article for more details on how to provide a custom splash form.
			_application.SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen();
			if (!(ConfigurationManager.ConnectionStrings["ConnectionString"] == null))
			{
				_application.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
			}
#if EASYTEST
			if (!(ConfigurationManager.ConnectionStrings["EasyTestConnectionString"] == null))
			{
				_application.ConnectionString = ConfigurationManager.ConnectionStrings["EasyTestConnectionString"].ConnectionString;
			}
#endif
			if (System.Diagnostics.Debugger.IsAttached)
			{
				_application.DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
			}
			try
			{
				_application.Setup();
				_application.Start();
			}
			catch (Exception e)
			{
				_application.HandleException(e);
			}
			
		}
	}
}
