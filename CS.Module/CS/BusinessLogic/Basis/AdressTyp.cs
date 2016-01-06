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
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.Persistent.Validation;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Basis
	{
		
		public class AdressTyp : XPObject
		{
			
			
			public AdressTyp(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
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
			
			private string fGesprächsLeitfaden;
[Size(SizeAttribute.Unlimited)]public string GesprächsLeitfaden
				{
				get
				{
					return fGesprächsLeitfaden;
				}
				set
				{
					fGesprächsLeitfaden = value;
				}
			}
			
		}
		
	}
}
