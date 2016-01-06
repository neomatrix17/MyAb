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

namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class StandardEinstellungen
		{
			public StandardEinstellungen(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				fErstelltAm = DateTime.Now;
			}
			
			protected override void OnSaved()
			{
				base.OnSaved();
				
				if (!(GlobalBase.MailManager == null))
				{
					GlobalBase.MailManager.SetupNewTime();
				}
				
			}
			
			private BusinessLogic.Intern.MitarbeiterRolle fStandardBenutzerRolle;
public BusinessLogic.Intern.MitarbeiterRolle StandardBenutzerRolle
			{
				get
				{
					return fStandardBenutzerRolle;
				}
				set
				{
					fStandardBenutzerRolle = value;
				}
			}
			
			private BusinessLogic.Intern.Distribution fStandardDistribution;
public BusinessLogic.Intern.Distribution StandardDistribution
			{
				get
				{
					return fStandardDistribution;
				}
				set
				{
					fStandardDistribution = value;
				}
			}
			
			private int fBenutzerInaktivNach;
public int BenutzerInaktivNach
			{
				get
				{
					return fBenutzerInaktivNach;
				}
				set
				{
					fBenutzerInaktivNach = value;
				}
			}
			
		}
		
	}
	
}
