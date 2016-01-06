// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Basis
	{
		
		public class CloneManager
		{
			
			public static BusinessLogic.Basis.Adresse GetClonedAddress(DevExpress.Xpo.Session pSession, BusinessLogic.Intern.Mitarbeiter pMitarbeiter, BusinessLogic.Basis.AdressArt pAddressArt, BusinessLogic.Basis.Adresse pOriginalAddress, string pPhoneNumber)
			{
				
				DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Besitzer] = (?) AND [TelefonNummer] = (?) OR [Besitzer] = (?) AND [TelefonNummer2] = (?) OR [Besitzer] = (?) AND [TelefonNummer3] = (?)", pMitarbeiter.Oid, pPhoneNumber, pMitarbeiter.Oid, pPhoneNumber, pMitarbeiter.Oid, pPhoneNumber);
				var exists = pSession.FindObject<BusinessLogic.Basis.Adresse>(filter);
				
				if (!(exists == null))
				{
					return exists;
				}
				else
				{
					
					BusinessLogic.Basis.Adresse address = new BusinessLogic.Basis.Adresse(pSession);
					
					address.Besitzer = pMitarbeiter;
					address.AdressArt = pAddressArt;
					
					try
					{
						address.AdressQualität = pSession.GetObjectByKey<BusinessLogic.Basis.AdressQualität>(pOriginalAddress.AdressQualität.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					try
					{
						address.Priorität = pOriginalAddress.Priorität;
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Anrede = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede.Oid);
						address.Anrede2 = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede2.Oid);
						address.Anrede3 = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Titel = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel.Oid);
						address.Titel2 = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel2.Oid);
						address.Titel3 = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Berufsstatus = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus.Oid);
						address.Berufsstatus2 = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus2.Oid);
						address.Berufsstatus3 = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					address.Vorname = pOriginalAddress.Vorname;
					address.Vorname2 = pOriginalAddress.Vorname2;
					address.Vorname3 = pOriginalAddress.Vorname3;
					
					address.Nachname = pOriginalAddress.Nachname;
					address.Nachname2 = pOriginalAddress.Nachname2;
					address.Nachname3 = pOriginalAddress.Nachname3;
					
					address.TelefonNummer = pOriginalAddress.TelefonNummer;
					address.TelefonNummer2 = pOriginalAddress.TelefonNummer2;
					address.TelefonNummer3 = pOriginalAddress.TelefonNummer3;
					
					address.GeburtsDatum = pOriginalAddress.GeburtsDatum;
					address.GeburtsDatum2 = pOriginalAddress.GeburtsDatum2;
					address.GeburtsDatum3 = pOriginalAddress.GeburtsDatum3;
					
					address.Email = pOriginalAddress.Email;
					address.Email2 = pOriginalAddress.Email2;
					address.Email3 = pOriginalAddress.Email3;
					
					address.Vorwahl = pOriginalAddress.Vorwahl;
					address.Vorwahl2 = pOriginalAddress.Vorwahl2;
					address.Vorwahl3 = pOriginalAddress.Vorwahl3;
					
					address.Beschreibung = pOriginalAddress.Beschreibung;
					address.Beschreibung2 = pOriginalAddress.Beschreibung2;
					address.Beschreibung3 = pOriginalAddress.Beschreibung3;
					
					address.Strasse = pOriginalAddress.Strasse;
					address.Postleitzahl = pOriginalAddress.Postleitzahl;
					address.Ortschaft = pOriginalAddress.Ortschaft;
					
					try
					{
						address.Land = pSession.GetObjectByKey<BusinessLogic.Basis.Land>(pOriginalAddress.Land.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					return address;
					
				}
				
			}
			
			public static BusinessLogic.Basis.Adresse GetClonedAddressByNumberList(DevExpress.Xpo.Session pSession, BusinessLogic.Intern.Mitarbeiter pMitarbeiter, BusinessLogic.Basis.AdressArt pAddressArt, BusinessLogic.Basis.Adresse pOriginalAddress, List<string> pPhoneNumber)
			{
				
				DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Besitzer] = (?) AND [TelefonNummer] = (?) OR [Besitzer] = (?) AND [TelefonNummer2] = (?) OR [Besitzer] = (?) AND [TelefonNummer3] = (?)", pMitarbeiter.Oid, pPhoneNumber[0], pMitarbeiter.Oid, pPhoneNumber[1], pMitarbeiter.Oid, pPhoneNumber[2]);
				var exists = pSession.FindObject<BusinessLogic.Basis.Adresse>(filter);
				
				if (!(exists == null))
				{
					return exists;
				}
				else
				{
					
					BusinessLogic.Basis.Adresse address = new BusinessLogic.Basis.Adresse(pSession);
					
					address.Besitzer = pMitarbeiter;
					address.AdressArt = pAddressArt;
					
					try
					{
						address.AdressQualität = pSession.GetObjectByKey<BusinessLogic.Basis.AdressQualität>(pOriginalAddress.AdressQualität.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					try
					{
						address.Priorität = pOriginalAddress.Priorität;
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Anrede = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede.Oid);
						address.Anrede2 = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede2.Oid);
						address.Anrede3 = pSession.GetObjectByKey<BusinessLogic.Formal.Anrede>(pOriginalAddress.Anrede3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Titel = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel.Oid);
						address.Titel2 = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel2.Oid);
						address.Titel3 = pSession.GetObjectByKey<MainModel.Titel>(pOriginalAddress.Titel3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					try
					{
						address.Berufsstatus = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus.Oid);
						address.Berufsstatus2 = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus2.Oid);
						address.Berufsstatus3 = pSession.GetObjectByKey<BusinessLogic.Basis.Berufsstatus>(pOriginalAddress.Berufsstatus3.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					address.Vorname = pOriginalAddress.Vorname;
					address.Vorname2 = pOriginalAddress.Vorname2;
					address.Vorname3 = pOriginalAddress.Vorname3;
					
					address.Nachname = pOriginalAddress.Nachname;
					address.Nachname2 = pOriginalAddress.Nachname2;
					address.Nachname3 = pOriginalAddress.Nachname3;
					
					address.TelefonNummer = pOriginalAddress.TelefonNummer;
					address.TelefonNummer2 = pOriginalAddress.TelefonNummer2;
					address.TelefonNummer3 = pOriginalAddress.TelefonNummer3;
					
					address.GeburtsDatum = pOriginalAddress.GeburtsDatum;
					address.GeburtsDatum2 = pOriginalAddress.GeburtsDatum2;
					address.GeburtsDatum3 = pOriginalAddress.GeburtsDatum3;
					
					address.Email = pOriginalAddress.Email;
					address.Email2 = pOriginalAddress.Email2;
					address.Email3 = pOriginalAddress.Email3;
					
					address.Vorwahl = pOriginalAddress.Vorwahl;
					address.Vorwahl2 = pOriginalAddress.Vorwahl2;
					address.Vorwahl3 = pOriginalAddress.Vorwahl3;
					
					address.Beschreibung = pOriginalAddress.Beschreibung;
					address.Beschreibung2 = pOriginalAddress.Beschreibung2;
					address.Beschreibung3 = pOriginalAddress.Beschreibung3;
					
					address.Strasse = pOriginalAddress.Strasse;
					address.Postleitzahl = pOriginalAddress.Postleitzahl;
					address.Ortschaft = pOriginalAddress.Ortschaft;
					
					try
					{
						address.Land = pSession.GetObjectByKey<BusinessLogic.Basis.Land>(pOriginalAddress.Land.Oid);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
					}
					
					return address;
					
				}
				
			}
			
		}
		
	}
}
