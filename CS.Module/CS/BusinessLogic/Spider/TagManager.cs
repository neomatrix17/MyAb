// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Text.RegularExpressions;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Spider
	{
		
		public class TagManager
		{
			
			public static string GetName(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<b class=\"h1\">(?<text>.*)</b>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<b class=\"h1\"", "").Replace("</b>", "").Replace("<br>", " ").Replace("</br>", " ").Replace("<br\\>", " ").Replace("<br />", " ").Replace("<", "").Replace(">", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPostal(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<span itemprop=\"postalCode\">(?<text>.*)</span>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<span itemprop=\"postalCode\">", "").Replace("</span>", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetStreetAddress(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<span itemprop=\"streetAddress\">(?<text>.*)</span>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<span itemprop=\"streetAddress\">", "").Replace("</span>", "").Replace("&nbsp;", " ").Replace("&#223;", "ß"));
					returnString = results[i];
					
					if (returnString.Contains("&"))
					{
						string t = "";
					}
					
				}
				
				return returnString;
				
			}
			
			public static string GetAddress(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<span itemprop=\"addressLocality\">(?<text>.*)</span>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<span itemprop=\"addressLocality\">", "").Replace("</span>", "").Replace("&nbsp;", " "));
					returnString = results[i];
					
					if (returnString.Contains("&"))
					{
						string t = "";
					}
					
				}
				
				return returnString;
				
			}
			
			public static string GetPhoneNumber(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "Tel.:(?<text>.*)<br/>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("Tel.:", "").Replace("</span>", "").Replace("&nbsp;", " ").Replace("<br/>", ""));
					returnString = System.Convert.ToString(results[i].ToString().Trim().Remove(0, 1).Replace(" ", "").Replace("  ", ""));
				}
				
				return returnString;
				
			}
			
			public static string GetBranche(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<span >(?<text>.*)</span></div>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<span >", "").Replace("</span></div>", "").Replace("&nbsp;", " ").Replace("</span>,", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetLogo(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<img src=\"(?<text>.*)\" data-inithide=\'");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<img src=\"", "").Replace("\" data-inithide=\'", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetWebsite(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<a class=\"link\" href=\"(?<text>.*)\" rel=\"follow\"");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"link\" href=\"", "").Replace("\" rel=\"follow\"", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetEmail2(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "countWA(\'send to email\')(?<text>.*)");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"link\" href=\"", "").Replace("\" rel=\"follow\"", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetEmailFirmenAbc(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				MatchCollection mc2 = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "var strFirst = \"(?<text>.*)\";");
				mc2 = Regex.Matches(source, "var strLast = \"(?<text>.*)\";");
				
				string[] results = new string[2];
				
				if (mc.Count > 0)
				{
					for (i = 0; i <= 0; i++)
					{
						results[0] = System.Convert.ToString(mc[i].Value.Replace("var strFirst = \"", "").Replace(";", "").Replace("\"", ""));
						results[1] = System.Convert.ToString(mc2[i].Value.Replace("var strLast = \"", "").Replace(";", "").Replace("\"", ""));
						returnString = results[0] + "@" + results[1];
					}
				}
				
				
				
				return returnString;
				
			}
			
			public static string GetEmail(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "([a-zA-Z0-9_\\-\\.]+)\\[at]([a-zA-Z0-9_\\-\\.]+)\\[dot]([a-zA-Z]{2,5})");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("[at]", "@").Replace("[dot]", "."));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
#region Person Firmen Abc
			
			public static string GetPersonName(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<b class=\"h1\">(?<text>.*)</b>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<b class=\"h1\"", "").Replace("</b>", "").Replace("<br>", " ").Replace("</br>", " ").Replace("<br\\>", " ").Replace("<br />", " ").Replace("<", "").Replace(">", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPeronVorName(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "\'Firstname\':(?<text>.*),");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("\'Firstname\':", "").Replace(",", "").Replace("<br>", " ").Replace("</br>", " ").Replace("<br\\>", " ").Replace("<br />", " ").Replace("\"", "").Replace(">", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetNachVorName(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "\'Lastname\':(?<text>.*),");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("\'Lastname\':", "").Replace(",", "").Replace("<br>", " ").Replace("</br>", " ").Replace("<br\\>", " ").Replace("<br />", " ").Replace("<", "").Replace("\"", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonPostal(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "\'Zipexact\':(?<text>.*),");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("\'Zipexact\':", "").Replace(",", "").Replace("\"", ""));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonStreetAddress(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "\'Address\':(?<text>.*),");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("\'Address\':", "").Replace(",", "").Replace("&nbsp;", " ").Replace("&#223;", "ß").Replace("\"", ""));
					returnString = results[i];
					
					if (returnString.Contains("&"))
					{
						string t = "";
					}
					
				}
				
				return returnString;
				
			}
			
			public static string GetPersonAddress(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "\'City\':(?<text>.*),");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("\'City\':", "").Replace(",", "").Replace("\"", ""));
					returnString = results[i];
					
					if (returnString.Contains("&"))
					{
						string t = "";
					}
					
				}
				
				return returnString;
				
			}
			
			public static string GetPersonPhoneNumber(string source, string pPhone = null)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "href=\"tel:+(?<text>.*)\">");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					
					var tempString = mc[i].Value;
					
					returnString = tempString.ToString().Replace("\">", "").Replace("href=\"tel:+", "").Trim();
					
					if (returnString.StartsWith("43"))
					{
						returnString = returnString.Remove(0, 2);
					}
					
				}
				
				return returnString;
				
			}
			public static string GetPersonPhoneNumberWithPhone(string source, string pPhone = null)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "href=\"tel:+(?<text>.*)\">");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					
					var tempString = mc[i].Value;
					
					if (tempString.Contains(pPhone.Substring((int) ((double) pPhone.Length / 2))))
					{
						returnString = tempString.ToString().Replace("\">", "").Replace("href=\"tel:+", "").Trim();
						
						if (returnString.StartsWith("43"))
						{
							returnString = returnString.Remove(0, 2);
						}
						
					}
					
				}
				
				return returnString;
				
			}
			
			public static string GetPersonBranche(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<span >(?<text>.*)</span></div>");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<span >", "").Replace("</span></div>", "").Replace("&nbsp;", " ").Replace("</span>,", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonLogo(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<img src=\"(?<text>.*)\" data-inithide=\'");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<img src=\"", "").Replace("\" data-inithide=\'", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonWebsite(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<a class=\"link\" href=\"(?<text>.*)\" rel=\"follow\"");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"link\" href=\"", "").Replace("\" rel=\"follow\"", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonEmail2(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "countWA(\'send to email\')(?<text>.*)");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"link\" href=\"", "").Replace("\" rel=\"follow\"", "").Replace("&nbsp;", " "));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
			public static string GetPersonEmailFirmenAbc(string source)
			{
				
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "<a href=\"mailto:(?<text>.*)\">");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					
					var tempString = mc[i].Value;
					
					returnString = tempString.ToString().Replace("<a href=\"mailto:", "").Replace("\">", "").Trim();
					
					if (returnString.StartsWith("43"))
					{
						returnString = returnString.Remove(0, 2);
					}
					
				}
				
				return returnString;
				
				//If source.Contains("mailto") Then
				//    Stop
				//End If
				
				//Dim mc As MatchCollection
				//Dim mc2 As MatchCollection
				//Dim i As Integer
				
				//Dim returnString As String = ""
				
				//mc = Regex.Matches(source, "var strFirst = ""(?<text>.*)"";")
				//mc2 = Regex.Matches(source, "var strLast = ""(?<text>.*)"";")
				
				//Dim results(1) As String
				
				//If mc.Count > 0 Then
				//    For i = 0 To 0
				//        results(0) = mc(i).Value.Replace("var strFirst = """, "").Replace(";", "").Replace("""", "")
				//        results(1) = mc2(i).Value.Replace("var strLast = """, "").Replace(";", "").Replace("""", "")
				//        returnString = results(0) & "@" & results(1)
				//    Next
				//End If
				
				
				
				//Return returnString
				
			}
			
			public static string GetPersonEmail(string source)
			{
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				string returnString = "";
				
				mc = Regex.Matches(source, "([a-zA-Z0-9_\\-\\.]+)\\[at]([a-zA-Z0-9_\\-\\.]+)\\[dot]([a-zA-Z]{2,5})");
				
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("[at]", "@").Replace("[dot]", "."));
					returnString = results[i];
				}
				
				return returnString;
				
			}
			
#endregion
			
		}
		
	}
}
