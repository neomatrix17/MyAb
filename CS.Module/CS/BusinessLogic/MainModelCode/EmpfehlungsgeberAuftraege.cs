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
using DevExpress.ExpressApp.Actions;


namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		[System.ComponentModel.DisplayName("dasdas")]public partial class EmpfehlungsgeberAuftraege
			{
			
			private List<BusinessLogic.Basis.Adresse> adressenListe = new List<BusinessLogic.Basis.Adresse>();
			private List<BusinessLogic.Basis.Adresse> clonedAdressenListe = new List<BusinessLogic.Basis.Adresse>();
			private List<string> notFoundNumbers = new List<string>();
			private List<string> spiderFoundNumbers = new List<string>();
			private List<string> numberfilterString = new List<string>();
			
			public EmpfehlungsgeberAuftraege(Session session) : base(session)
			{
			}
			
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				fAnleitung = "Anletung:" + "\r\n" + "1. Waehlen Sie eine Adresse aus der Liste aus, welche als Empfehlungsgeber angegeben werden soll." + "\r\n" + 
					"2. Schreiben Sie in eine der beiden Listen (Telefon Nummern) oder (Adressen ID\'s) die Telefonnummern oder Adressen ID\'s immer mit einem Beistrich getrennt ein." + "\r\n" + "\r\n" + 
					"Das System wird versuchen die von Ihnen angegeben Telefonnummern und Adressen ID\'s zu finden. Sollte das System einige der Telefonnummern oder Adressen ID\'s nicht finden, bekommen Sie" + "\r\n" + 
					"diese in dem untersten Feld angezeigt." + "\r\n" + 
					"Betaetigen Sie die Speichern und schliessen Aktion." + "\r\n" + "\r\n" + 
					"Hinweis: Telefonnummern bitte immer ohne Landesvorwahl angeben zb.: 0664123456 oder 01123456.";
				
				Datum = DateTime.Now.Date;
				
				AdressArt = null;
				Benutzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
				NichtGefundeneObjekte = "";
				NichtGefundeneObjekte = "";
				Adresse = null;
				TelefonNummern = "";
				AdressenID = "";
				Status = "";
				AutomatischErstellteAdressen = "";
				SuchFilter = "";
				AdressenGruppieren = true;
				AdressenManagement.Module.Spider.Sglobal.IsNewAddressJob = true;
			}
			
			private BusinessLogic.Intern.Mitarbeiter fBenutzer;
public BusinessLogic.Intern.Mitarbeiter Benutzer
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
public BusinessLogic.Basis.Adresse Adresse
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
			
			private BusinessLogic.Basis.AdressArt fAdressArt;
public BusinessLogic.Basis.AdressArt AdressArt
			{
				get
				{
					return fAdressArt;
				}
				set
				{
					fAdressArt = value;
				}
			}
			
			private DateTime fDatum;
[ReadOnly(true)]public DateTime Datum
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
			
			
			protected override void OnLoaded()
			{
				base.OnLoaded();
			}
			
			private bool fAdressenGruppieren;
public bool AdressenGruppieren
			{
				get
				{
					return fAdressenGruppieren;
				}
				set
				{
					fAdressenGruppieren = value;
				}
			}
			
			protected override void OnSaving()
			{
				
				if (AdressenManagement.Module.Spider.Sglobal.IsNewAddressJob)
				{
					AdressenManagement.Module.Spider.Sglobal.IsNewAddressJob = false;
					
					AdressenID = System.Convert.ToString(AdressenID.Replace(";", ",").Replace(" ", "").Replace("  ", ""));
					TelefonNummern = System.Convert.ToString(TelefonNummern.Replace(";", ",").Replace(" ", "").Replace("  ", ""));
					
					if (!(Adresse == null))
					{
						
						if (string.IsNullOrEmpty(AdressenID) && string.IsNullOrEmpty(TelefonNummern) && string.IsNullOrEmpty(NichtGefundeneObjekte) && Adresse != null)
						{
							throw (new UserFriendlyException(new Exception("Sie muessen Telefonnummern oder Adressen ID\'s in die vorgesehenen Felder eintragen.")));
							return;
						}
						
						int notFound = 0;
						int total = 0;
						
						if (!string.IsNullOrEmpty(AdressenID))
						{
							
							var ids = AdressenID.Split(',');
							
							total = ids.Length;
							
							foreach (var ph in ids)
							{
								 ph.Trim();
							}
							
							foreach (string st in ids)
							{
								
								var address = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("Oid", st.Replace(" ", "").Replace("  ", "").Replace("  ", "").Trim()));
								
								if (!(address == null))
								{
									address.Empfehlungsgeber = Adresse;
									address.AdressArt = AdressArt;
									address.Save();
									adressenListe.Add(address);
								}
								
								if (address == null)
								{
									notFound++;
									NichtGefundeneObjekte += "ID " + st + "; ";
								}
								
							}
							
						}
						else if (!string.IsNullOrEmpty(TelefonNummern))
						{
							
							if (TelefonNummern.EndsWith(","))
							{
								TelefonNummern = TelefonNummern.Remove(TelefonNummern.Length - 1, 1);
							}
							
							var phones = TelefonNummern.Split(',');
							List<string> recreatedPhones = new List<string>();
							
							foreach (string ph in phones)
							{
								string temp = ph.Trim().Replace(" ", "");
								recreatedPhones.Add(temp);
							}
							
							foreach (string phs in recreatedPhones)
							{
								numberfilterString.Add(phs + ";");
							}
							
							total = phones.Length;

                            for (int i = 0; i < recreatedPhones.Count - 1; i++)                       

                            {

                                if (recreatedPhones[i].StartsWith("0"))
                                {
                                    string tempSt = recreatedPhones[i].Remove(0, 1);
                                    recreatedPhones[i] = System.Convert.ToString(tempSt.Replace(" ", "").Replace("  ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", ""));
                                }
                                else
                                {
                                    string tempSt = recreatedPhones[i];
                                    recreatedPhones[i] = System.Convert.ToString(tempSt.Replace(" ", "").Replace("  ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", ""));
                                }

                                var address = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + recreatedPhones[i] + "%", BinaryOperatorType.Like));
                                var address2 = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + recreatedPhones[i] + "%", BinaryOperatorType.Like));
                                var address3 = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + recreatedPhones[i] + "%", BinaryOperatorType.Like));

                                if (!(address == null))
                                {
                                    if (!(address.Besitzer.Oid == Benutzer.Oid) && !(address.Besitzer.Oid == 43))
                                    {
                                        address = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address, recreatedPhones[i]);
                                        address.Empfehlungsgeber = Adresse;
                                        address.AdressArt = AdressArt;
                                        address.Save();
                                        clonedAdressenListe.Add(address);
                                    }
                                    else
                                    {

                                        if (address.Besitzer.Oid == 43)
                                        {
                                            address.Besitzer = Benutzer;
                                        }

                                        address.Empfehlungsgeber = Adresse;
                                        address.AdressArt = AdressArt;
                                        address.Save();
                                        adressenListe.Add(address);

                                    }
                                }

                                if (!(address2 == null))
                                {
                                    if (!(address2.Besitzer.Oid == Benutzer.Oid) && !(address2.Besitzer.Oid == 43))
                                    {
                                        address2 = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address2, recreatedPhones[i]);
                                        address2.Empfehlungsgeber = Adresse;
                                        address2.AdressArt = AdressArt;
                                        address2.Save();
                                        clonedAdressenListe.Add(address2);
                                    }
                                    else
                                    {

                                        if (address2.Besitzer.Oid == 43)
                                        {
                                            address2.Besitzer = Benutzer;
                                        }

                                        address2.Empfehlungsgeber = Adresse;
                                        address2.AdressArt = AdressArt;
                                        address2.Save();
                                        adressenListe.Add(address2);

                                    }
                                }

                                if (!(address3 == null))
                                {
                                    if (!(address3.Besitzer.Oid == Benutzer.Oid) && !(address3.Besitzer.Oid == 43))
                                    {
                                        address3 = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address3, recreatedPhones[i]);
                                        address3.Empfehlungsgeber = Adresse;
                                        address3.AdressArt = AdressArt;
                                        address3.Save();
                                        clonedAdressenListe.Add(address3);
                                    }
                                    else
                                    {

                                        if (address3.Besitzer.Oid == 43)
                                        {
                                            address3.Besitzer = Benutzer;
                                        }

                                        address3.Empfehlungsgeber = Adresse;
                                        address3.AdressArt = AdressArt;
                                        address3.Save();
                                        adressenListe.Add(address3);

                                    }
                                }

                                if (address == null && address2 == null && address3 == null)
                                {
                                    notFound++;
                                    notFoundNumbers.Add("0" + recreatedPhones[i]);
                                    NichtGefundeneObjekte += "0" + recreatedPhones[i] + "; ";
                                }

                            }
							
						}
						
						int spiderFound = 0;
						
						foreach (string st in notFoundNumbers)
						{
							
							BusinessLogic.Spider.SpiderJobManager s = new BusinessLogic.Spider.SpiderJobManager();
							
							var retAddress = s.GetSpiderAddressDataWithPhone(st, Session);
							
							if (!(retAddress == null))
							{
								
								//Dim myAddress = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, retAddress, st)
								retAddress.Empfehlungsgeber = Adresse;
								retAddress.AdressArt = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(AdressArt.Oid);
								retAddress.Besitzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(Benutzer.Oid);
								retAddress.Save();
								clonedAdressenListe.Add(retAddress);
								spiderFound++;
								spiderFoundNumbers.Add(st);
								
							}
							
						}
						
						notFound = notFound - spiderFound;
						
						foreach (string stspiderFound in spiderFoundNumbers)
						{
							NichtGefundeneObjekte = NichtGefundeneObjekte.Replace(stspiderFound + "; ", "");
							notFoundNumbers.Remove(stspiderFound);
						}
						
						string mainString = "";
						
						foreach (BusinessLogic.Basis.Adresse adr in adressenListe)
						{
							mainString += adr.AnzeigeName + "\r\n";
						}
						
						string mainString2 = "";
						
						foreach (BusinessLogic.Basis.Adresse adr2 in clonedAdressenListe)
						{
							mainString2 += adr2.AnzeigeName + "\r\n";
						}
						
						if (!(total == 0))
						{
							Status = "Die Adresse " + Adresse.AnzeigeName + " wurde bei " + System.Convert.ToString(total - notFound) + " Adressen als Empfehlungsgeber eingetragen. - " + System.Convert.ToString(notFound) + " Objekte wurden nicht gefunden." + "\r\n" + "\r\n" + 
								"Folgende Adressen wurden gefunden und vervollstaendigt:" + "\r\n" + "\r\n" + 
								mainString2;
							
						}
						else
						{
							Status = "Es wurde kein Ergebniss erzielt.";
						}
						
						foreach (string st in notFoundNumbers)
						{
							BusinessLogic.Basis.Adresse ad = new BusinessLogic.Basis.Adresse(Session);
							ad.Besitzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(Benutzer.Oid);
							ad.Empfehlungsgeber = Adresse;
							ad.AdressArt = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(AdressArt.Oid);
							ad.Status = Session.GetObjectByKey<BusinessLogic.Basis.Status>(28);
							ad.TelefonNummer = st.Replace(";", "");
							AutomatischErstellteAdressen += st + "; ";
							ad.Save();
						}
						
					}
					else
					{
						
						if (string.IsNullOrEmpty(AdressenID) && string.IsNullOrEmpty(TelefonNummern) && string.IsNullOrEmpty(NichtGefundeneObjekte) && Adresse != null)
						{
							throw (new UserFriendlyException(new Exception("Sie muessen Telefonnummern oder Adressen ID\'s in die vorgesehenen Felder eintragen.")));
							return;
						}
						
						int notFound = 0;
						int total = 0;
						
						if (!string.IsNullOrEmpty(AdressenID))
						{
							
							var ids = AdressenID.Split(',');
							
							total = ids.Length;
							
							foreach (string ph in ids)
							{
								 ph.Trim();
							}
							
							foreach (string st in ids)
							{
								
								var address = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("Oid", st.Replace(" ", "").Replace("  ", "").Replace("  ", "").Trim()));
								
								if (!(address == null))
								{
									address.Save();
									address.AdressArt = AdressArt;
									adressenListe.Add(address);
								}
								
								if (address == null)
								{
									notFound++;
									NichtGefundeneObjekte += "ID " + st + "; ";
								}
								
							}
							
						}
						else if (!string.IsNullOrEmpty(TelefonNummern))
						{
							
							if (TelefonNummern.EndsWith(","))
							{
								TelefonNummern = TelefonNummern.Remove(TelefonNummern.Length - 1, 1);
							}
							
							var phones = TelefonNummern.Split(',');
							List<string> recreatedPhones = new List<string>();
							
							foreach (string ph in phones)
							{
								string temp = ph.Trim().Replace(" ", "");
								recreatedPhones.Add(temp);
							}
							
							foreach (string phs in recreatedPhones)
							{
								numberfilterString.Add(phs + ";");
							}
							
							total = phones.Length;
							
							for (int i = 0; i < recreatedPhones.Count - 1; i++)       
							{

                                string st = recreatedPhones[i];

								if (st.StartsWith("0"))
								{
									string tempSt = st.Remove(0, 1);
									st = System.Convert.ToString(tempSt.Replace(" ", "").Replace("  ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", ""));
								}
								else
								{
									string tempSt = st;
									st = System.Convert.ToString(tempSt.Replace(" ", "").Replace("  ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", ""));
								}
								
								var address = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + st + "%", BinaryOperatorType.Like));
								var address2 = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + st + "%", BinaryOperatorType.Like));
								var address3 = Session.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + st + "%", BinaryOperatorType.Like));
								
								if (!(address == null))
								{
									if (!(address.Besitzer.Oid == Benutzer.Oid) && !(address.Besitzer.Oid == 43))
									{
										address = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address, st);
										address.AdressArt = AdressArt;
										address.Empfehlungsgeber = Adresse;
										address.Save();
										clonedAdressenListe.Add(address);
									}
									else
									{
										
										if (address.Besitzer.Oid == 43)
										{
											address.Besitzer = Benutzer;
										}
										
										address.Empfehlungsgeber = Adresse;
										address.AdressArt = AdressArt;
										address.Save();
										adressenListe.Add(address);
										
									}
								}
								
								if (!(address2 == null))
								{
									if (!(address2.Besitzer.Oid == Benutzer.Oid) && !(address2.Besitzer.Oid == 43))
									{
										address2 = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address2, st);
										address2.Empfehlungsgeber = Adresse;
										address2.AdressArt = AdressArt;
										address2.Save();
										clonedAdressenListe.Add(address2);
									}
									else
									{
										
										if (address2.Besitzer.Oid == 43)
										{
											address2.Besitzer = Benutzer;
										}
										
										address2.Empfehlungsgeber = Adresse;
										address2.AdressArt = AdressArt;
										address2.Save();
										adressenListe.Add(address2);
										
									}
								}
								
								if (!(address3 == null))
								{
									if (!(address3.Besitzer.Oid == Benutzer.Oid) && !(address3.Besitzer.Oid == 43))
									{
										address3 = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, address3, st);
										address3.Empfehlungsgeber = Adresse;
										address3.AdressArt = AdressArt;
										address3.Save();
										clonedAdressenListe.Add(address3);
									}
									else
									{
										
										if (address3.Besitzer.Oid == 43)
										{
											address3.Besitzer = Benutzer;
										}
										
										address3.Empfehlungsgeber = Adresse;
										address3.AdressArt = AdressArt;
										address3.Save();
										adressenListe.Add(address3);
										
									}
								}
								
								if (address == null && address2 == null && address3 == null)
								{
									notFound++;
									notFoundNumbers.Add("0" + st);
									NichtGefundeneObjekte += "0" + st + "; ";
								}
								
							}
							
						}
						
						int spiderFound = 0;
						
						foreach (string st in notFoundNumbers)
						{
							
							BusinessLogic.Spider.SpiderJobManager s = new BusinessLogic.Spider.SpiderJobManager();
							
							var retAddress = s.GetSpiderAddressDataWithPhone(st, Session);
							
							if (!(retAddress == null))
							{
								
								//Dim myAddress = BusinessLogic.Basis.CloneManager.GetClonedAddress(Session, Benutzer, AdressArt, retAddress, st)
								retAddress.Empfehlungsgeber = Adresse;
								retAddress.AdressArt = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(AdressArt.Oid);
								retAddress.Besitzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(Benutzer.Oid);
								retAddress.Save();
								clonedAdressenListe.Add(retAddress);
								spiderFound++;
								spiderFoundNumbers.Add(st);
								
							}
							
						}
						
						notFound = notFound - spiderFound;
						
						foreach (string stspiderFound in spiderFoundNumbers)
						{
							NichtGefundeneObjekte = NichtGefundeneObjekte.Replace("0" + stspiderFound + "; ", "");
							notFoundNumbers.Remove(stspiderFound);
						}
						
						string mainString = "";
						
						foreach (BusinessLogic.Basis.Adresse adr in adressenListe)
						{
							mainString += adr.AnzeigeName + "\r\n";
						}
						
						string mainString2 = "";
						
						foreach (BusinessLogic.Basis.Adresse adr2 in clonedAdressenListe)
						{
							mainString2 += adr2.AnzeigeName + "\r\n";
						}
						
						if (!(total == 0))
						{
							Status = "Es wurden insgesammt " + System.Convert.ToString(total - notFound) + " Adressen im System gefunden. - " + System.Convert.ToString(notFound) + " Objekte wurden nicht gefunden." + "\r\n" + "\r\n" + 
								"Folgende Adressen wurden gefunden und vervollstaendigt:" + "\r\n" + "\r\n" + 
								mainString2;
						}
						else
						{
							Status = "Es wurde kein Ergebniss erzielt.";
						}
						
						foreach (string st in notFoundNumbers)
						{
							BusinessLogic.Basis.Adresse ad = new BusinessLogic.Basis.Adresse(Session);
							ad.Besitzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(Benutzer.Oid);
							ad.Status = Session.GetObjectByKey<BusinessLogic.Basis.Status>(28);
							ad.TelefonNummer = st.Replace(";", "");
							ad.AdressArt = Session.GetObjectByKey<BusinessLogic.Basis.AdressArt>(AdressArt.Oid);
							AutomatischErstellteAdressen += st + "; ";
							ad.Save();
							clonedAdressenListe.Add(ad);
						}
						
					}
					
					if (SuchFilter == "" || SuchFilter == null)
					{
						foreach (string Str in numberfilterString)
						{
							SuchFilter += Str;
						}
					}
					
					base.OnSaving();
				}
				else
				{
					base.OnSaving();
					
				}
				
			}
			
		}
		
	}
	
}
