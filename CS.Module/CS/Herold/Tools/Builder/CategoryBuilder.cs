// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Text.RegularExpressions;
using System.Net;


namespace AdressenManagement.Module
{
	namespace Herold.Tools.Builder
	{
		
		public class CategoryBuilder
		{
			
			public CategoryBuilder()
			{
				
			}
			
			private string baseUri = "http://www.herold.at/gelbe-seiten/branchen-az/";
			
			public List<Business.Category> GetCategories()
			{
				
				//            Dim catList As New List(Of Business.Category)
				//            Dim extractString As String = ""
				//            Dim navigationSegments As New List(Of String)
				//            navigationSegments.AddRange({"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"})
				
				//            Dim webClient As New System.Net.WebClient()
				//            webClient.Encoding = System.Text.UTF8Encoding.UTF8
				//            For Each st As String In navigationSegments
				//                For i = 1 To 10
				//                    Try
				//                        If st = "a" AndAlso i = 1 Then
				//                            extractString = webClient.DownloadString(baseUri)
				//                        Else
				//                            extractString = webClient.DownloadString(baseUri & st & "/" & i & "/")
				//                        End If
				
				//                        GetUrls(extractString, catList)
				
				//                      Catch ex As Exception
				//Gurock.SmartInspect.SiAuto.Main.LogException(Ex)
				
				
				
				
				//                    End Try
				//                Next
				//            Next
				
				//            Return catList
				
				return default(List<Business.Category>);
				
			}
			
			private void GetUrls(string extractString, List<Business.Category> catList)
			{
				
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<ul class=\"linkBullets\"[^>]*>(.*?)<\\s*/\\s*ul>");
				System.Text.StringBuilder results = new System.Text.StringBuilder();
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(extractString))
				{
					results.Append(m.Value);
					foreach (Match _match in GetBetween(m.Value, "<li>", "</li>"))
					{
						string tempData = _match.Groups["data"].Value.Replace("<a href=\"", "").Replace("><i></i>", "").Replace("</a>", "");
						//check this
                        List<string> tempList = new List<string>();
                        // TODO Check this.
                        //tempList = tempData.Split(@'\"');
						catList.Add(new Business.Category {Name = WebUtility.UrlDecode(System.Convert.ToString(tempList[1])), NavigationUri = tempList[0].Replace("branchen-az/", "")});
					}
				}
				
			}
			
			private MatchCollection GetBetween(string Input, string StartString, string EndString)
			{
				return Regex.Matches(Input, Regex.Escape(StartString) + "(?<data>.*?)" + Regex.Escape(EndString));
			}
			
		}
		
	}
}
