// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Net;


namespace AdressenManagement.Module
{
	namespace Herold.Tools.Helper
	{
		
		public class PageHelper
		{
			
			public int GetMaxPages(string pSource)
			{
				
				int total = 0;
				
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("von <strong>(.*?)zu");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					name = WebUtility.UrlDecode(m.Value.Replace("von <strong>", "").Replace("</strong>", "").Replace("zu", "").Trim());
				}
				
				if (int.Parse(name) > 4000)
				{
					total = 268;
				}
				else if (Convert.ToInt32(name) <= 15)
				{
					total = 1;
				}
				else
				{
					total = (int) ((double) (int.Parse(name)) / 15);
				}
				
				return total;
				
			}
			
		}
		
	}
}
