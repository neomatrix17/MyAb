// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.ComponentModel;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class SpiderAuftragsArt : XPObject
		{
			string fName;
public string Name
			{
				get
				{
					return fName;
				}
				set
				{
					SetPropertyValue<string>("Name", ref fName, value);
				}
			}
		}
		
	}
	
}
