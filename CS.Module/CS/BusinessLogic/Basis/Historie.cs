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
		
		[DefaultProperty("Kontaktierung")]public class Historie : XPObject
			{
			
			
			public Historie(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
			}
			
			private string fKontaktierung;
[Size(SizeAttribute.Unlimited)]public string Kontaktierung
				{
				get
				{
					return fKontaktierung;
				}
				set
				{
					fKontaktierung = value;
				}
			}
			
			private string fErgebniss;
[Size(SizeAttribute.Unlimited)]public string Ergebniss
				{
				get
				{
					return fErgebniss;
				}
				set
				{
					fErgebniss = value;
				}
			}
			
			private Adresse fAdresse;
[Association("Adresse-AltesSystemProtokoll"), Browsable(false), VisibleInDetailView(false), VisibleInListView(false)]public Adresse Adresse
				{
				get
				{
					return fAdresse;
				}
				set
				{
					fAdresse = value;
				}
			}
			
		}
		
	}
}
