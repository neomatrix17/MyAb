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
		
		[DefaultProperty("Version")]public class Changelog : XPObject
			{
			
			
			public Changelog(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				Datum = DateTime.Now.Date;
			}
			
			private DateTime fDatum;
public DateTime Datum
			{
				get
				{
					return fDatum;
				}
				set
				{
					fDatum = value;
				}
			}
			
			private string fVersion;
public string Version
			{
				get
				{
					return fVersion;
				}
				set
				{
					fVersion = value;
				}
			}
			
			private string fÄnderungen;
[Size(SizeAttribute.Unlimited)]public string Änderungen
				{
				get
				{
					return fÄnderungen;
				}
				set
				{
					fÄnderungen = value;
				}
			}
			
		}
		
	}
}
