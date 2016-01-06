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
		
		public class Datei : XPObject
		{
			
			
			public Datei(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				ErstelltAm = DateTime.Now;
			}
			
			private DateTime fErstelletAm;
[ReadOnly(true)]public DateTime ErstelltAm
				{
				get
				{
					return fErstelletAm;
				}
				set
				{
					fErstelletAm = value;
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
			
			private DateiTyp fDateiTyp;
public DateiTyp DateiTyp
			{
				get
				{
					return fDateiTyp;
				}
				set
				{
					fDateiTyp = value;
				}
			}
			
			private DevExpress.Persistent.BaseImpl.FileData fDatei;
[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), FileTypeFilter("AlleDatein", 1, "*.*")]public DevExpress.Persistent.BaseImpl.FileData Datei_Renamed
				{
				get
				{
					return fDatei;
				}
				set
				{
					SetPropertyValue("Datei", ref fDatei, value);
				}
			}
			
			private Adresse fAdresse;
[Association("Adresse-Datein"), VisibleInListView(false), VisibleInDetailView(false)]public Adresse Adresse
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
