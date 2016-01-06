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
	public class GlobalBase
	{
		
		public static List<BusinessLogic.Spider.SpiderJobManager> SpiderJobManagerList = new List<BusinessLogic.Spider.SpiderJobManager>();
		public static Manager.Mail.MailManager MailManager;
		public static DateTime LastInsert = DateTime.Now;
		public static string CurrentConn;
		public static string ModuleName;
		
	}
}
