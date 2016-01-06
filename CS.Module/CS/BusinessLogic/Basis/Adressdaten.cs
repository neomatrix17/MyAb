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
		
		[DefaultProperty("Anschrift"), ImageName("BO_Address")]public class Adressdaten : XPObject
			{
			
			
			public Adressdaten(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
			}
			
			private string fStrasse;
public string Strasse
			{
				get
				{
					return fStrasse;
				}
				set
				{
					fStrasse = value;
				}
			}
			
			private int fPostleitzahl;
public int Postleitzahl
			{
				get
				{
					return fPostleitzahl;
				}
				set
				{
					fPostleitzahl = value;
				}
			}
			
			private string fOrtschaft;
public string Ortschaft
			{
				get
				{
					return fOrtschaft;
				}
				set
				{
					fOrtschaft = value;
				}
			}
			
			private Land fLand;
public Land Land
			{
				get
				{
					return fLand;
				}
				set
				{
					fLand = value;
				}
			}
			
[PersistentAlias("[Strasse] + \' \' + [Plz] + \' \' + [Ortschaft] + \' \' + [Land.Name]")]public string Anschrift
				{
				get
				{
					return System.Convert.ToString(EvaluateAlias("Anschrift"));
				}
			}
			
		}
		
	}
}
