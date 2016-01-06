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
		
		public class Notiz : XPObject
		{
			
			
			public Notiz(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				ErstelltAm = DateTime.Now;
				Benutzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(DevExpress.ExpressApp.SecuritySystem.CurrentUserId);
			}
			
			private string fNotizFeld;
[Size(SizeAttribute.Unlimited)]public string NotizFeld
				{
				get
				{
					return fNotizFeld;
				}
				set
				{
					fNotizFeld = value;
				}
			}
			
			private DateTime fErstelltAm;
public DateTime ErstelltAm
			{
				get
				{
					return fErstelltAm;
				}
				set
				{
					fErstelltAm = value;
				}
			}
			
			private BusinessLogic.Intern.Mitarbeiter fBenutzer;
[Association("Benutzer-Notizen")]public BusinessLogic.Intern.Mitarbeiter Benutzer
				{
				get
				{
					return fBenutzer;
				}
				set
				{
					fBenutzer = value;
				}
			}
			
			private BusinessLogic.Basis.Adresse fAdresse;
[Association("Adresse-Notizen")]public BusinessLogic.Basis.Adresse Adresse
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
			
			private BusinessLogic.Basis.Termin fTermin;
[VisibleInDetailView(false), VisibleInListView(false)]public BusinessLogic.Basis.Termin Termin
				{
				get
				{
					return fTermin;
				}
				set
				{
					fTermin = value;
				}
			}
			
			private BusinessLogic.Basis.TerminBericht fTerminBericht;
[VisibleInDetailView(false), VisibleInListView(false)]public BusinessLogic.Basis.TerminBericht TerminBericht
				{
				get
				{
					return fTerminBericht;
				}
				set
				{
					fTerminBericht = value;
				}
			}
			
			private string fGesprochenMit;
public string GesprochenMit
			{
				get
				{
					return fGesprochenMit;
				}
				set
				{
					fGesprochenMit = value;
				}
			}
			
		}
		
	}
}
