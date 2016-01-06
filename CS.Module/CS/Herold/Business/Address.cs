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
	namespace Herold.Business
	{
		
		public class Address
		{
			
#region Properties
			
			private string fNavigationUri;
public string NavigationUri
			{
				get
				{
					return fNavigationUri;
				}
				set
				{
					fNavigationUri = value;
				}
			}
			
			private string fName;
public string Name
			{
				get
				{
					return fName;
				}
				set
				{
					fName = value;
				}
			}
			
			private string fStreet;
public string Street
			{
				get
				{
					return fStreet;
				}
				set
				{
					fStreet = value;
				}
			}
			
			private string fZipCode;
public string ZipCode
			{
				get
				{
					return fZipCode;
				}
				set
				{
					fZipCode = value;
				}
			}
			
			private string fCity;
public string City
			{
				get
				{
					return fCity;
				}
				set
				{
					fCity = value;
				}
			}
			
			private string fEmail;
public string Email
			{
				get
				{
					return fEmail;
				}
				set
				{
					fEmail = value;
				}
			}
			
			private string fWebSite;
public string WebSite
			{
				get
				{
					return fWebSite;
				}
				set
				{
					fWebSite = value;
				}
			}
			
			private string fPhone;
public string Phone
			{
				get
				{
					return fPhone;
				}
				set
				{
					fPhone = value;
					if (!(value == null) && !(string.IsNullOrEmpty(value)))
					{
						IsValidAddress = true;
					}
				}
			}
			
			private bool fIsValidAddress;
public bool IsValidAddress
			{
				get
				{
					return fIsValidAddress;
				}
				set
				{
					fIsValidAddress = value;
				}
			}
			
			
#endregion
			
		}
		
	}
}
