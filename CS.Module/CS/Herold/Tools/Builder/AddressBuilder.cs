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
		
		public class AddressBuilder
		{
			
			private ContentBuilder contentBuilder = new ContentBuilder();
			
			public Business.Address GetAddress(string pSource)
			{
				
				Business.Address address = new Business.Address();
				
				address.Name = contentBuilder.GetName(pSource);
				address.Street = contentBuilder.GetStreet(pSource);
				address.ZipCode = contentBuilder.GetZipCode(pSource);
				address.City = contentBuilder.GetCity(pSource);
				address.Phone = contentBuilder.GetPhone(pSource);
				address.Email = contentBuilder.GetEmail(pSource);
				address.WebSite = contentBuilder.GetWebsite(pSource);
				
				return address;
				
			}
			
			public void ResolveAddress(string pSource, Business.Address address)
			{
				
				address.Name = contentBuilder.GetName(pSource);
				address.Street = contentBuilder.GetStreet(pSource);
				address.ZipCode = contentBuilder.GetZipCode(pSource);
				address.City = contentBuilder.GetCity(pSource);
				address.Phone = contentBuilder.GetPhone(pSource);
				address.Email = contentBuilder.GetEmail(pSource);
				address.WebSite = contentBuilder.GetWebsite(pSource);
				
			}
			
			public List<Business.Address> GetInitAddresssList(string pSource)
			{
				
				List<Business.Address> mainList = new List<Business.Address>();
				bool found = false;
				string name = "";
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("<h2><a href=\"(.*?)data-clickpos=\"name\" class=\"bold\">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
				
				foreach (System.Text.RegularExpressions.Match m in regex.Matches(pSource))
				{
					Business.Address ad = new Business.Address();
					ad.NavigationUri = m.Value.Replace("<h2><a href=\"", "").Replace("data-clickpos=\"name\" class=\"bold\">", "");
					mainList.Add(ad);
				}
				
				if (!found)
				{
					System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex("<h2 class=\"fullw\"><a href=\"(.*?)data-clickpos=\"name\">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
					
					foreach (System.Text.RegularExpressions.Match m2 in regex2.Matches(pSource))
					{
						Business.Address ad = new Business.Address();
						ad.NavigationUri = m2.Value.Replace("<h2 class=\"fullw\"><a href=\"", "").Replace("data-clickpos=\"name\"", "").Replace("\"", "").Replace("/ >", "");
						mainList.Add(ad);
					}
				}
				
				if (!found)
				{
					System.Text.RegularExpressions.Regex regex2a = new System.Text.RegularExpressions.Regex("<h2><a href=\"(.*?)data-clickpos=\"name\">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
					
					foreach (System.Text.RegularExpressions.Match m2a in regex2a.Matches(pSource))
					{
						Business.Address ad = new Business.Address();
						ad.NavigationUri = m2a.Value.Replace("<h2><a href=\"", "").Replace("data-clickpos=\"name\"", "").Replace("\"", "").Replace("/ >", "");
						mainList.Add(ad);
					}
				}
				
				if (!found)
				{
					System.Text.RegularExpressions.Regex regex2 = new System.Text.RegularExpressions.Regex("<h2 class=\"fullw\"><a href=\"(.*?)data-clickpos=\"name\" class=\"bold\">", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
					
					foreach (System.Text.RegularExpressions.Match m2 in regex2.Matches(pSource))
					{
						Business.Address ad = new Business.Address();
						ad.NavigationUri = m2.Value.Replace("<h2 class=\"fullw\"><a href=\"", "").Replace("data-clickpos=\"name\" class=\"bold\">", "").Replace("\"", "").Replace("/ >", "");
						mainList.Add(ad);
					}
				}
				
				return mainList;
				
			}
			
		}
		
	}
}
