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
	namespace Herold.Tools.Builder
	{
		
		public class ContentBuilder
		{
			
			public string GetName(string pSource)
			{
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<span itemprop=\"name\">(.*?)</span>");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					name = WebUtility.UrlDecode(System.Convert.ToString(m.Value.Replace("<span itemprop=\"name\">", "").Replace("</span>", "")));
				}
				
				return name;
				
			}
			
			public string GetStreet(string pSource)
			{
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<span itemprop=\"streetAddress\">(.*?)</span>");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					name = WebUtility.UrlDecode(System.Convert.ToString(m.Value.Replace("<span itemprop=\"streetAddress\">", "").Replace("</span>", "")));
				}
				
				return name;
				
			}
			
			public string GetZipCode(string pSource)
			{
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<span itemprop=\"postalCode\">(.*?)</span>");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					name = WebUtility.UrlDecode(System.Convert.ToString(m.Value.Replace("<span itemprop=\"postalCode\">", "").Replace("</span>", "")));
				}
				
				return name;
				
			}
			
			public string GetCity(string pSource)
			{
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<span itemprop=\"addressRegion\">(.*?)</span>");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					name = WebUtility.UrlDecode(System.Convert.ToString(m.Value.Replace("<span itemprop=\"addressRegion\">", "").Replace("</span>", "")));
				}
				
				return name;
				
			}
			
			public string GetPhone(string pSource)
			{
				
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<td class=\"lnumber\">(.*?)</td>");
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					if (m.Value.Contains("+43"))
					{
						name = WebUtility.UrlDecode(m.Value.Replace("<td class=\"lnumber\">", "").Replace("</td>", "").Replace("+43", "").Replace(" ", "").Trim());
					}
					
				}
				
				return name;
				
			}
			
			public string GetEmail(string pSource)
			{
				
				string name = "";
				
				return name;
				
			}
			
			public string GetWebsite(string pSource)
			{
				
				string name = "";
				
				return name;
				
			}
			
		}
		
	}
}
