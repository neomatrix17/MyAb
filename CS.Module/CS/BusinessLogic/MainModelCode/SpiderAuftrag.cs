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
using DevExpress.ExpressApp;


namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class SpiderAuftrag
		{
			public SpiderAuftrag(Session session) : base(session)
			{
			}
			
			private bool isNewJob = false;
			
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				fErstelltAm = DateTime.Now;
				fErstelltVon = SecuritySystem.CurrentUserName;
				fStatus = Session.GetObjectByKey<MainModel.SpiderStatus>(1);
				fPrivateAdressenMitDiesenWoerternIgnorieren = "gmbh; gesmbh; kfz; pension; restaurant; heuriger; .co; .ag; fa.; firma; hotel; praxis; schule; mab; .gesmh; .gmbh; sonderschule; admiral; sportwetten; kg;" + 
					"gesellschaft; OG; Co Kg; CO KG; 2K; IT; It; Solutions; solutions; GmBh; GmbH; Technologies; Service; Apotheke; M.b.h; NÖ; Consulting; ANL KFZ; GesmbH; BIPA; Bipa; bipa; Billa; BILLA; billa;" + 
					"BMW; VSP; &; OEG; oeg; Oeg; O.E.G; Immobilien; immobilien; BEV; Bev; BAUMEISTER; Baumeister; BAUMAX; Baumax; OBI; Obi; Gesellschaft m.b.h; GESMBH; TAXI; Taxi; KG; Kg; AG; SPAR; Spar; bauMax; WIENER";
				BesitzerDerAdressen = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(43);
				ArtDerAdressen = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(13);
				AllePrivatenAdressenSuchen = true;
				DoppelteAdressenUeberspringen = true;
				AdressenManagement.Module.Spider.Sglobal.IsNewJob = true;
			}
			
			protected override void OnLoaded()
			{
				
			}
			
			private BusinessLogic.Intern.Mitarbeiter fBesitzerDerAdressen;
public BusinessLogic.Intern.Mitarbeiter BesitzerDerAdressen
			{
				get
				{
					return fBesitzerDerAdressen;
				}
				set
				{
					fBesitzerDerAdressen = value;
				}
			}
			
			private BusinessLogic.Basis.AdressArt fArtDerAdressen;
public BusinessLogic.Basis.AdressArt ArtDerAdressen
			{
				get
				{
					return fArtDerAdressen;
				}
				set
				{
					fArtDerAdressen = value;
				}
			}
			
			private BusinessLogic.Basis.Branche fInterneBranche;
public BusinessLogic.Basis.Branche InterneBranche
			{
				get
				{
					return fInterneBranche;
				}
				set
				{
					fInterneBranche = value;
				}
			}
			
			private BusinessLogic.Basis.Branche fInterneBranche2;
public BusinessLogic.Basis.Branche InterneBranche2
			{
				get
				{
					return fInterneBranche2;
				}
				set
				{
					fInterneBranche2 = value;
				}
			}
			
			protected override void OnSaved()
			{
				
				if (AdressenManagement.Module.Spider.Sglobal.IsNewJob)
				{
					AdressenManagement.Module.Spider.Sglobal.IsNewJob = false;
					BusinessLogic.Spider.SpiderJobManager s = new BusinessLogic.Spider.SpiderJobManager();
					GlobalBase.SpiderJobManagerList.Add(s);
					s.InitNewJob(Session, this);
					s.StartSpiderJob();
					base.OnSaved();
				}
				else
				{
					base.OnSaved();
				}
				
			}
			
			protected override void OnSaving()
			{
				base.OnSaving();
			}
			
			private void SpiderAuftrag_Changed(object sender, ObjectChangeEventArgs e)
			{
				
				if (e.PropertyName == "AuftragsArt")
				{
					
					switch (AuftragsArt.Oid)
					{
						case 1:
							break;
							
						case 2:
							ArtDerAdressen = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(4);
							Quelle = Session.GetObjectByKey<MainModel.SpiderType>(1);
							break;
					}
					
				}
				
			}
		}
		
	}
}
