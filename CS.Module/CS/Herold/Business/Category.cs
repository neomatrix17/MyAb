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
		
		public class Category
		{
			
#region Properties
			
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
			
#endregion
			
		}
		
	}
}
