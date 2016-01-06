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

using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Security;

namespace AdressenManagement.Win
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/DevExpressExpressAppWinWinApplicationMembericAll
	public partial class AdressenManagementWindowsFormsApplication : WinApplication
	{
		public AdressenManagementWindowsFormsApplication()
		{
			InitializeComponent();
		}
		
		protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
		{
			//args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection)
			
			args.ObjectSpaceProvider = new SecuredObjectSpaceProvider((SecurityStrategyComplex) Security, args.ConnectionString, args.Connection);
			
		}
		public void AdressenManagementWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
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
				throw (new InvalidOperationException(
					"The application cannot connect to the specified database, because the latter doesn\'t exist or its version is older than that of the application." + Constants.vbCrLf + 
					"This error occurred  because the automatic database update was disabled when the application was started without debugging." + Constants.vbCrLf + 
					"To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " + 
					"source code of the \'DatabaseVersionMismatch\' event handler to enable automatic database update, " + 
					"or manually create a database Imports the \'DBUpdater\' tool." + Constants.vbCrLf + 
					"Anyway, refer to the \'Update Application and Database Versions\' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " + 
					"for more detailed information. If this doesn\'t help, please contact our Support Team at http://www.devexpress.com/Support/Center/"));
			}
#endif
		}
		private static void AdressenManagementWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e)
		{
			string userLanguageName = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
			if (userLanguageName != "en-US" && e.Languages.IndexOf(userLanguageName) == -1)
			{
				e.Languages.Add(userLanguageName);
			}
		}
	}
	
}
