// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Text.RegularExpressions;
using System.Threading;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Spider
	{
		
		public class SpiderJobManager
		{
			
			private Session currentSession;
			private MainModel.SpiderAuftrag currentSpiderJob;
			private int? currentPlzVon;
			private int? currentPlzBis;
			private bool ignoreExistingAddresses;
			private List<string> badWordList = new List<string>();
			private List<string> nameBuilderList = new List<string>();
			private int originalOid = 0;
			private DevExpress.Xpo.UnitOfWork sess = new DevExpress.Xpo.UnitOfWork();
			private List<string> oldidList = new List<string>();
			private List<string> idList = new List<string>();
			private List<PersonAdresse> addressenListPerson = new List<PersonAdresse>();
			private List<FirmenAdresse> addressenListBusiness = new List<FirmenAdresse>();
			private int recordsIgnored = 0;
			private int recordsMatchFound = 0;
			private int recordsAdded = 0;
			private string personMainUri = "http://www.telefonabc.at/result.aspx?what=&where=";
			private string personMainUri2 = "http://www.telefonabc.at/result.aspx?what=&where=";
			private string personFixedUri = "&exact=True&firstname=&lastname=&street=&appendix=&telpre=&telnr=&branch=&p=";
			private string personFixedUri2 = "&exact=False&firstname=&lastname={0}&street=&appendix=&telpre=&telnr=&branch=&p=";
			private string personEndUri = "&l=&sid=&did=&cc=";
			private string personNamedUri = "&exact=True&firstname=";
			private string personNamedEndUri = "&lastname=&street=&appendix=&telpre=&telnr=&branch=0&p=";
			private string businessMainUri = "http://www.firmenabc.at/result.aspx?what=";
			private string businessFixedUri = "&where=%d6sterreich&exact=false&inTitleOnly=false&l=&si=";
			private string businessIdUri = "&iid=";
			private string businessEndUri = "&sid=&did=&cc=";
			private List<string> key = new List<string>();
			private System.Threading.Thread th;
			private string SpiderRunning = "ed";
			private bool LongJobStarted = false;
			private MainModel.SpiderBranche currentBranche;
			private BusinessLogic.Basis.Branche targetBranche;
			
			public enum EnumJobType
			{
				PrivateJob = 1,
				BusinessJob = 2
			}
			
			public enum EnumJobDeepnessType
			{
				Low = 1,
				Deep = 2
			}
			
			private static EnumJobType fCurrentJobType;
public static EnumJobType CurrentJobType
			{
				get
				{
					return fCurrentJobType;
				}
				set
				{
					fCurrentJobType = value;
				}
			}
			
			private static EnumJobDeepnessType fCurrentDeepnessJobType;
public static EnumJobDeepnessType CurrentDeepnessJobType
			{
				get
				{
					return fCurrentDeepnessJobType;
				}
				set
				{
					fCurrentDeepnessJobType = value;
				}
			}
			
			public void InitNewJob(Session pSession, MainModel.SpiderAuftrag pSpiderAuftrag)
			{
				
				currentSession = pSession;
				currentSpiderJob = pSpiderAuftrag;
				currentBranche = pSpiderAuftrag.Branche;
				ignoreExistingAddresses = System.Convert.ToBoolean(currentSpiderJob.DoppelteAdressenUeberspringen);
				
				var badWords = currentSpiderJob.PrivateAdressenMitDiesenWoerternIgnorieren.Split(';');
				
				foreach (string st in badWords)
				{
					if (!(string.IsNullOrEmpty(st)))
					{
						if (!(st == " "))
						{
							if (!badWordList.Contains(st.Trim()))
							{
								badWordList.Add(st.Trim());
							}
						}
					}
				}
				
				if (nameBuilderList.Count == 0)
				{
					nameBuilderList.AddRange(new[] {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "ä", "ö", "ü"});
				}
				
				if (sess.Connection == null)
				{
					sess.ConnectionString = GlobalBase.CurrentConn;
					sess.Connection = new System.Data.SqlClient.SqlConnection(sess.ConnectionString);
					sess.Connection.Open();
				}
				
			}
			
			private static Stopwatch lastinsert = new Stopwatch();
			
			public void GetSpiderAddressDataWithPhoneButCheckFirst(string pPhoneNumber)
			{
				
				if (!(lastinsert == null))
				{
					if (lastinsert.IsRunning)
					{
						
						if (lastinsert.Elapsed.TotalSeconds > 2)
						{
							lastinsert.Restart();
						}
						else
						{
							return;
						}
						
					}
					else
					{
						lastinsert.Start();
					}
				}
				
				DevExpress.Xpo.Session ses = new DevExpress.Xpo.Session();
				ses.ConnectionString = GlobalBase.CurrentConn;
				ses.Connection = new System.Data.SqlClient.SqlConnection(System.Convert.ToString(ses.ConnectionString));
				ses.Connection.Open();
				
				DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Besitzer] = (?) AND [TelefonNummer] = (?) OR [Besitzer] = (?) AND [TelefonNummer2] = (?) OR [Besitzer] = (?) AND [TelefonNummer3] = (?)", 43, pPhoneNumber, 43, pPhoneNumber, 43, pPhoneNumber);
				var exists = ses.FindObject<BusinessLogic.Basis.Adresse>(filter);
				
				if (!(exists == null))
				{
					exists.IsClone = true;
					exists.Save();
				}
				
				try
				{
					var naviString = "http://www.telefonabc.at/result.aspx?what={0}&where=&exact=True&firstname=&lastname=&street=&appendix=&telpre=&telnr=&branch=&p=0&l=&sid=&did=&cc=";
					
					System.Net.WebClient wc = new System.Net.WebClient();
					
					var stToNavigate = string.Format(naviString, pPhoneNumber);
					
					var sourceString = wc.DownloadString(stToNavigate.ToString());
					
					var st = ExtractTelefonAbcIdForPhone(sourceString.ToString());
					
					string customerString = wc.DownloadString(System.Convert.ToString(st));
					wc.Dispose();
					
					PersonAdresse fAdresse = new PersonAdresse();
					fAdresse.Vorname = TagManager.GetPeronVorName(customerString);
					fAdresse.Nachname = TagManager.GetNachVorName(customerString);
					fAdresse.PostLeitZahl = TagManager.GetPersonPostal(customerString);
					fAdresse.Email = TagManager.GetPersonEmailFirmenAbc(customerString);
					fAdresse.Strasse = TagManager.GetPersonStreetAddress(customerString);
					fAdresse.Ortschaft = TagManager.GetPersonAddress(customerString);
					fAdresse.TelefonNummer = TagManager.GetPersonPhoneNumber(customerString);
					
					BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(ses);
					xpoAddress.Vorname = fAdresse.Vorname;
					xpoAddress.Nachname = fAdresse.Nachname;
                    //check this
					xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
					xpoAddress.Email = fAdresse.Email;
					xpoAddress.Strasse = fAdresse.Strasse;
					xpoAddress.Ortschaft = fAdresse.Ortschaft;
					xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
					xpoAddress.IsClone = true;
					xpoAddress.Land = ses.GetObjectByKey<BusinessLogic.Basis.Land>(1);
					xpoAddress.Besitzer = ses.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(43);
					xpoAddress.AdressArt = ses.GetObjectByKey<BusinessLogic.Basis.AdressArt>(13);
					xpoAddress.Save();
					ses.Save(xpoAddress);
					ses.ExplicitCommitTransaction();
					
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					
					
				}
				
			}
			
			public BusinessLogic.Basis.Adresse GetSpiderAddressDataWithPhone(string pPhoneNumber, DevExpress.Xpo.Session pSess)
			{
				
				try
				{
					var naviString = "http://www.telefonabc.at/result.aspx?what={0}&where=&exact=True&firstname=&lastname=&street=&appendix=&telpre=&telnr=&branch=&p=0&l=&sid=&did=&cc=";
					
					System.Net.WebClient wc = new System.Net.WebClient();
					
					var stToNavigate = string.Format(naviString, pPhoneNumber);
					
					var sourceString = wc.DownloadString(stToNavigate.ToString());
					
					var st = ExtractTelefonAbcIdForPhone(sourceString.ToString());
					
					string customerString = wc.DownloadString(System.Convert.ToString(st));
					wc.Dispose();
					
					PersonAdresse fAdresse = new PersonAdresse();
					fAdresse.Vorname = TagManager.GetPeronVorName(customerString);
					fAdresse.Nachname = TagManager.GetNachVorName(customerString);
					fAdresse.PostLeitZahl = TagManager.GetPersonPostal(customerString);
					fAdresse.Email = TagManager.GetPersonEmailFirmenAbc(customerString);
					fAdresse.Strasse = TagManager.GetPersonStreetAddress(customerString);
					fAdresse.Ortschaft = TagManager.GetPersonAddress(customerString);
					try
					{
						fAdresse.TelefonNummer = TagManager.GetPersonPhoneNumberWithPhone(customerString, pPhoneNumber);
					}
					catch (Exception)
					{
						fAdresse.TelefonNummer = TagManager.GetPersonPhoneNumber(customerString, pPhoneNumber);
					}
					
					BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(pSess);
					xpoAddress.Vorname = fAdresse.Vorname;
					xpoAddress.Nachname = fAdresse.Nachname;
					xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
					xpoAddress.Email = fAdresse.Email;
					xpoAddress.Strasse = fAdresse.Strasse;
					xpoAddress.Ortschaft = fAdresse.Ortschaft;
					xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
					xpoAddress.IsTempClone = true;
					xpoAddress.Land = pSess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
					xpoAddress.Besitzer = pSess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(43);
					xpoAddress.AdressArt = pSess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(13);
					xpoAddress.Save();
					pSess.Save(xpoAddress);
					
					return xpoAddress;
					
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				}
				
				return null;
				
			}
			
			public void StartSpiderJob()
			{
				
				if (!AdressenManagement.Module.Spider.Sglobal.IsRunning)
				{
					
					AdressenManagement.Module.Spider.Sglobal.IsRunning = true;
					
					if (!(currentSpiderJob == null))
					{
						
						if (!(currentSpiderJob.Status == null))
						{
							
							if (!(currentSpiderJob.Status.Oid == 4))
							{
								
								try
								{
									
									originalOid = currentSpiderJob.Oid;
									
									if (!(currentSpiderJob.AuftragsArt == null))
									{
										switch (currentSpiderJob.AuftragsArt.Oid)
										{
											case 1:
												CurrentJobType = EnumJobType.PrivateJob;
												break;
											case 2:
												CurrentJobType = EnumJobType.BusinessJob;
												currentBranche = currentSpiderJob.Branche;
												targetBranche = currentSpiderJob.InterneBranche;
												break;
											default:
												currentSpiderJob.SystemMeldung = "Es wurde keine Auftrags Art angegeben.";
												currentSpiderJob.Status = currentSession.GetObjectByKey<MainModel.SpiderStatus>(4);
												return;
										}
									}
									else
									{
										currentSpiderJob.Status = currentSession.GetObjectByKey<MainModel.SpiderStatus>(4);
										return;
									}
									
									switch (CurrentJobType)
									{
										case EnumJobType.PrivateJob:
											currentPlzVon = currentSpiderJob.PostleitzahlVon;
											currentPlzBis = currentSpiderJob.PostleitzahlBis;
											
											if (currentSpiderJob.AllePrivatenAdressenSuchen == true)
											{
												CurrentDeepnessJobType = EnumJobDeepnessType.Deep;
											}
											else if (currentSpiderJob.AllePrivatenAdressenSuchen == false)
											{
												CurrentDeepnessJobType = EnumJobDeepnessType.Low;
											}
											
											currentSpiderJob = sess.GetObjectByKey<MainModel.SpiderAuftrag>(currentSpiderJob.Oid);
											
											if (SpiderRunning != "Started")
											{
												SpiderRunning = "Started";
                                                // TODO check this.
                                                //th = new System.Threading.Thread(new System.Threading.ThreadStart(ExecuteLongOperation(null)));
												th.IsBackground = true;
												th.Start();
											}
											break;
											
										case EnumJobType.BusinessJob:
											
											currentSpiderJob = sess.GetObjectByKey<MainModel.SpiderAuftrag>(currentSpiderJob.Oid);
											
											if (SpiderRunning != "Started")
											{
												SpiderRunning = "Started";
                                                // TODO check this.
                                                //th = new System.Threading.Thread(new System.Threading.ThreadStart(ExecuteLongOperation(null)));
												th.IsBackground = true;
												th.Start();
											}
											break;
											
									}
									
								}
								catch (Exception ex)
								{
									Gurock.SmartInspect.SiAuto.Main.LogException(ex);
									MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(sess);
									exeptionError.Zeitstempel = DateTime.Now;
									exeptionError.AngemeldeterBenutzer = "Recensa Spider";
									exeptionError.GewaehltesObjekt = "SpiderAuftrag";
									exeptionError.Aktion = "StartSpiderJob";
									exeptionError.Fehlermeldung = ex.Message;
									SpiderRunning = "ed";
									sess.CommitChanges();
								}
								
							}
							
						}
						
					}
					
				}
				
			}
			
			public void ExecuteLongOperation(object pObject)
			{
				
				switch (CurrentJobType)
				{
					case EnumJobType.PrivateJob:
						
						lock(key)
						{
							
							currentSpiderJob = sess.GetObjectByKey<MainModel.SpiderAuftrag>(originalOid);
							currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(2);
							currentSpiderJob.Save();
							sess.CommitChanges();
							try
							{
								for (var plz = currentPlzVon; plz <= currentPlzBis; plz++)
								{
									
									addressenListPerson.Clear();
									idList.Clear();
									
									try
									{
										
										switch (CurrentDeepnessJobType)
										{
											case EnumJobDeepnessType.Low:
												
												for (var navi = 0; navi <= 19; navi++)
												{
													
													System.Net.WebClient wc = new System.Net.WebClient();
													
													var sourceString = wc.DownloadString(personMainUri + System.Convert.ToString(plz) + personFixedUri + System.Convert.ToString(navi) + "&l=&sid=&did=&cc=");
													
													ExtractTelefonAbcId(sourceString.ToString());
													//check this
													sourceString = "\0";
													
													foreach (string st in idList)
													{
														
														try
														{
															string customerString = wc.DownloadString(st);
															wc.Dispose();
															
															PersonAdresse fAdresse = new PersonAdresse();
															fAdresse.Vorname = TagManager.GetPeronVorName(customerString);
															fAdresse.Nachname = TagManager.GetNachVorName(customerString);
															fAdresse.PostLeitZahl = TagManager.GetPersonPostal(customerString);
															fAdresse.Email = TagManager.GetPersonEmailFirmenAbc(customerString);
															fAdresse.Strasse = TagManager.GetPersonStreetAddress(customerString);
															fAdresse.Ortschaft = TagManager.GetPersonAddress(customerString);
															fAdresse.TelefonNummer = TagManager.GetPersonPhoneNumber(customerString);
															
															customerString = null;
															
															bool hasBadWords = false;
															
															foreach (string word in badWordList)
															{
																
																if (fAdresse.Vorname.Contains(word) || fAdresse.Nachname.Contains(word))
																{
																	hasBadWords = true;
																}
																
															}
															
															if (!hasBadWords)
															{
																
																if (currentSpiderJob.DoppelteAdressenUeberspringen)
																{
																	
																	var address = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																	var address2 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																	var address3 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																	
																	if (address == null && address2 == null && address3 == null)
																	{
																		BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																		xpoAddress.Vorname = fAdresse.Vorname;
																		xpoAddress.Nachname = fAdresse.Nachname;
																		xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
																		xpoAddress.Email = fAdresse.Email;
																		xpoAddress.Strasse = fAdresse.Strasse;
																		xpoAddress.Ortschaft = fAdresse.Ortschaft;
																		xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
																		xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																		xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																		xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																		xpoAddress.Save();
																		sess.CommitChanges();
																		xpoAddress = null;
																		recordsAdded++;
																		currentSpiderJob.Resultate = recordsAdded;
																		currentSpiderJob.Save();
																	}
																	else
																	{
																		address = null;
																		address2 = null;
																		address3 = null;
																		recordsMatchFound++;
																	}
																	
																}
																else
																{
																	
																	BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																	xpoAddress.Vorname = fAdresse.Vorname;
																	xpoAddress.Nachname = fAdresse.Nachname;
																	xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
																	xpoAddress.Email = fAdresse.Email;
																	xpoAddress.Strasse = fAdresse.Strasse;
																	xpoAddress.Ortschaft = fAdresse.Ortschaft;
																	xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
																	xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																	xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																	xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																	xpoAddress.Save();
																	sess.CommitChanges();
																	xpoAddress = null;
																	recordsAdded++;
																	currentSpiderJob.Resultate = recordsAdded;
																	currentSpiderJob.Save();
																}
																
															}
															else
															{
																recordsIgnored++;
															}
															
														}
														catch (Exception ex)
														{
															Gurock.SmartInspect.SiAuto.Main.LogException(ex);
															
															
															
															MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(sess);
															exeptionError.Zeitstempel = DateTime.Now;
															exeptionError.AngemeldeterBenutzer = "Recensa Spider";
															exeptionError.GewaehltesObjekt = "SpiderAuftrag";
															exeptionError.Aktion = "IdList";
															exeptionError.Fehlermeldung = ex.Message;
															sess.CommitChanges();
														}
														
													}
													
													sess.CommitChanges();
													
												}
												break;
												
											case EnumJobDeepnessType.Deep:
												
												try
												{
													
													foreach (string character in nameBuilderList)
													{
														
														for (var ichar = 0; ichar <= nameBuilderList.Count - 1; ichar++)
														{
															
															for (var navi = 0; navi <= 19; navi++)
															{
																
																try
																{
																	
																	System.Net.WebClient wc = new System.Net.WebClient();
																	
																	var findwhat = character + nameBuilderList[ichar];
																	
																	var newNavi = string.Format(personFixedUri2, findwhat);
																	
																	var tempSt = personMainUri2 + System.Convert.ToString(plz) + System.Convert.ToString(newNavi) + System.Convert.ToString(navi) + "&l=&sid=&did=&cc=";
																	Gurock.SmartInspect.SiAuto.Main.LogMessage(tempSt);
																	var sourceString = wc.DownloadString(personMainUri2 + System.Convert.ToString(plz) + System.Convert.ToString(newNavi) + System.Convert.ToString(navi) + "&l=&sid=&did=&cc=");
																	
																	ExtractTelefonAbcId(sourceString.ToString());
																	
																	if (idList.Count == 0)
																	{
																		goto endOfForLoop;
																	}
																	
																	sourceString = "\0";
																	
																	foreach (string st in idList)
																	{
																		
																		try
																		{
																			Gurock.SmartInspect.SiAuto.Main.LogMessage(st);
																			string customerString = wc.DownloadString(st);
																			wc.Dispose();
																			PersonAdresse fAdresse = new PersonAdresse();
																			fAdresse.Vorname = TagManager.GetPeronVorName(customerString);
																			fAdresse.Nachname = TagManager.GetNachVorName(customerString);
																			fAdresse.PostLeitZahl = TagManager.GetPersonPostal(customerString);
																			fAdresse.Email = TagManager.GetPersonEmailFirmenAbc(customerString);
																			fAdresse.Strasse = TagManager.GetPersonStreetAddress(customerString);
																			fAdresse.Ortschaft = TagManager.GetPersonAddress(customerString);
																			fAdresse.TelefonNummer = TagManager.GetPersonPhoneNumber(customerString);
																			
																			customerString = null;
																			
																			bool hasBadWords = false;
																			
																			foreach (string word in badWordList)
																			{
																				
																				if (fAdresse.Vorname.Contains(word) || fAdresse.Nachname.Contains(word))
																				{
																					hasBadWords = true;
																				}
																				
																			}
																			
																			if (!hasBadWords)
																			{
																				
																				if (currentSpiderJob.DoppelteAdressenUeberspringen)
																				{
																					
																					var address = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																					var address2 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																					var address3 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
																					
																					if (address == null && address2 == null && address3 == null)
																					{
																						BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																						xpoAddress.Vorname = fAdresse.Vorname;
																						xpoAddress.Nachname = fAdresse.Nachname;
																						xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
																						xpoAddress.Email = fAdresse.Email;
																						xpoAddress.Strasse = fAdresse.Strasse;
																						xpoAddress.Ortschaft = fAdresse.Ortschaft;
																						xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
																						xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																						xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																						xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																						xpoAddress.Save();
																						sess.CommitChanges();
																						xpoAddress = null;
																						recordsAdded++;
																						currentSpiderJob.Resultate = recordsAdded;
																						currentSpiderJob.Save();
																					}
																					else
																					{
																						address = null;
																						address2 = null;
																						address3 = null;
																						recordsMatchFound++;
																					}
																					
																				}
																				else
																				{
																					
																					BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																					xpoAddress.Vorname = fAdresse.Vorname;
																					xpoAddress.Nachname = fAdresse.Nachname;
																					xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
																					xpoAddress.Email = fAdresse.Email;
																					xpoAddress.Strasse = fAdresse.Strasse;
																					xpoAddress.Ortschaft = fAdresse.Ortschaft;
																					xpoAddress.TelefonNummer = fAdresse.TelefonNummer;
																					xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																					xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																					xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																					xpoAddress.Save();
																					sess.CommitChanges();
																					xpoAddress = null;
																					recordsAdded++;
																					currentSpiderJob.Resultate = recordsAdded;
																					currentSpiderJob.Save();
																				}
																				
																			}
																			else
																			{
																				recordsIgnored++;
																			}
																			
																		}
																		catch (Exception ex)
																		{
																			Gurock.SmartInspect.SiAuto.Main.LogException(ex);
																			
																			
																			
																		}
																		
																	}
																	
																}
																catch (Exception ex)
																{
																	Gurock.SmartInspect.SiAuto.Main.LogException(ex);
																	
																	
																	
																	goto endOfForLoop;
																}
																
																sess.CommitChanges();
																
															}
endOfForLoop:
															1.GetHashCode() ; //VBConversions note: C# requires an executable line here, so a dummy line was added.
															
														}
														
													}
													
												}
												catch (Exception ex)
												{
													Gurock.SmartInspect.SiAuto.Main.LogException(ex);
													
													
													
												}
												break;
												
										}
										
									}
									catch (Exception ex)
									{
										Gurock.SmartInspect.SiAuto.Main.LogException(ex);
										
										
										
										MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(sess);
										exeptionError.Zeitstempel = DateTime.Now;
										exeptionError.AngemeldeterBenutzer = "Recensa Spider";
										exeptionError.GewaehltesObjekt = "SpiderAuftrag";
										exeptionError.Aktion = "Plz Range";
										exeptionError.Fehlermeldung = ex.Message;
										sess.CommitChanges();
									}
									
								}
								
								currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(3);
								currentSpiderJob.Resultate = recordsAdded;
								currentSpiderJob.SystemMeldung = "Es wurden insgesammt " + System.Convert.ToString(recordsAdded) + " neue Adressen in das System eingetragen. " + System.Convert.ToString(recordsMatchFound) + " Adressen waren dem System schon bekannt und " + System.Convert.ToString(recordsIgnored) + " Adressen wurden aufgrund der suchkriterien ignoriert.";
								currentSpiderJob.Save();
								SpiderRunning = "ed";
								AdressenManagement.Module.Spider.Sglobal.IsRunning = false;
								GlobalBase.SpiderJobManagerList.Clear();
								sess.CommitChanges();
								th.Abort();
								
							}
							catch (Exception ex)
							{
								Gurock.SmartInspect.SiAuto.Main.LogException(ex);
								
								
								
								SpiderRunning = "ed";
								GlobalBase.SpiderJobManagerList.Clear();
								currentSpiderJob.SystemMeldung = ex.Message;
								currentSpiderJob.Status = currentSession.GetObjectByKey<MainModel.SpiderStatus>(4);
								currentSpiderJob.Save();
								MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(sess);
								AdressenManagement.Module.Spider.Sglobal.IsRunning = false;
								exeptionError.Zeitstempel = DateTime.Now;
								exeptionError.AngemeldeterBenutzer = "Recensa Spider";
								exeptionError.GewaehltesObjekt = "SpiderAuftrag";
								exeptionError.Aktion = "Fatal  Action";
								exeptionError.Fehlermeldung = ex.Message;
								sess.CommitChanges();
							}
							
						}
						break;
						
					case EnumJobType.BusinessJob:
						
						switch (currentSpiderJob.Quelle.Oid)
						{
							case 2:
								lock(key)
								{
									
									currentSpiderJob = sess.GetObjectByKey<MainModel.SpiderAuftrag>(originalOid);
									currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(2);
									currentSpiderJob.Save();
									sess.CommitChanges();
									
									System.Net.WebClient webclient = new System.Net.WebClient();
									webclient.Encoding = System.Text.UTF8Encoding.UTF8;
									
									Herold.Tools.Helper.PageHelper ph = new Herold.Tools.Helper.PageHelper();
									
									var total = ph.GetMaxPages(webclient.DownloadString(currentSpiderJob.HeroldBranche.Befehl));
									
									Herold.Tools.Builder.AddressBuilder ab = new Herold.Tools.Builder.AddressBuilder();
									
									List<Herold.Business.Address> la = new List<Herold.Business.Address>();
									
									for (var i = 1; i <= total; i++)
									{
										
										la.Clear();
										
										try
										{
											
											if (i == 1)
											{
												var list = ab.GetInitAddresssList(webclient.DownloadString(currentSpiderJob.HeroldBranche.Befehl));
												foreach (Herold.Business.Address adr in list)
												{
													la.Add(adr);
												}
												list.Clear();
												list = null;
											}
											else
											{
												var list = ab.GetInitAddresssList(webclient.DownloadString(currentSpiderJob.HeroldBranche.Befehl + System.Convert.ToString(i) + "/"));
												foreach (Herold.Business.Address adr in list)
												{
													la.Add(adr);
												}
												list.Clear();
												list = null;
											}
											
											foreach (Herold.Business.Address adress in la)
											{
												ab.ResolveAddress(webclient.DownloadString(System.Convert.ToString(adress.NavigationUri.Replace("\"", ""))), adress);
												
												try
												{
													
													if (!(adress.Phone == "") && !(adress.Phone == null))
													{
														
														if (adress.IsValidAddress)
														{
															if (currentSpiderJob.DoppelteAdressenUeberspringen)
															{
																
																var address = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + adress.Phone, BinaryOperatorType.Like));
																var address2 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + adress.Phone, BinaryOperatorType.Like));
																var address3 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + adress.Phone, BinaryOperatorType.Like));
																
																if (address == null && address2 == null && address3 == null)
																{
																	BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																	xpoAddress.Firma3 = adress.Name;
																	xpoAddress.Postleitzahl = Convert.ToInt32(adress.ZipCode);
																	xpoAddress.Email3 = adress.Email;
																	xpoAddress.Branche = sess.GetObjectByKey<BusinessLogic.Basis.Branche>(currentSpiderJob.InterneBranche2.Oid);
																	xpoAddress.Strasse = adress.Street;
																	xpoAddress.Ortschaft = adress.City;
																	xpoAddress.TelefonNummer3 = adress.Phone;
																	xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																	xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																	xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																	xpoAddress.Save();
																	sess.CommitChanges();
																	xpoAddress = null;
																	recordsAdded++;
																	currentSpiderJob.Resultate = recordsAdded;
																	currentSpiderJob.Save();
																}
																else
																{
																	address = null;
																	address2 = null;
																	address3 = null;
																	recordsMatchFound++;
																}
																
															}
															else
															{
																BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																xpoAddress.Firma3 = adress.Name;
																xpoAddress.Postleitzahl = Convert.ToInt32(adress.ZipCode);
																xpoAddress.Email3 = adress.Email;
																xpoAddress.Branche = sess.GetObjectByKey<BusinessLogic.Basis.Branche>(currentSpiderJob.InterneBranche2.Oid);
																xpoAddress.Strasse = adress.Street;
																xpoAddress.Ortschaft = adress.City;
																xpoAddress.TelefonNummer3 = adress.Phone;
																xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																xpoAddress.Save();
																sess.CommitChanges();
																xpoAddress = null;
																recordsAdded++;
																currentSpiderJob.Resultate = recordsAdded;
																currentSpiderJob.Save();
															}
														}
														
													}
													
												}
												catch (Exception ex)
												{
													Gurock.SmartInspect.SiAuto.Main.LogException(ex);
													
													
													
												}
												
											}
											
										}
										catch (Exception)
										{
											
										}
										
									}
									
								}
								
								currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(3);
								currentSpiderJob.Resultate = recordsAdded;
								currentSpiderJob.SystemMeldung = "Es wurden insgesammt " + System.Convert.ToString(recordsAdded) + " neue Adressen in das System eingetragen. " + System.Convert.ToString(recordsMatchFound) + " Adressen waren dem System schon bekannt und " + System.Convert.ToString(recordsIgnored) + " Adressen wurden aufgrund der suchkriterien ignoriert.";
								currentSpiderJob.Save();
								SpiderRunning = "ed";
								AdressenManagement.Module.Spider.Sglobal.IsRunning = false;
								GlobalBase.SpiderJobManagerList.Clear();
								sess.CommitChanges();
								th.Abort();
								break;
								
							case 1:
								lock(key)
								{
									
									currentSpiderJob = sess.GetObjectByKey<MainModel.SpiderAuftrag>(originalOid);
									currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(2);
									currentSpiderJob.Save();
									sess.CommitChanges();
									
									for (var i = 0; i <= 250000; i += 15)
									{
										
										try
										{
											
											System.Net.WebClient wc = new System.Net.WebClient();
											
											var sourceString = wc.DownloadString(businessMainUri + currentBranche.Befehl + businessFixedUri + System.Convert.ToString(i) + businessIdUri + currentBranche.NavID + businessEndUri);
											
											ExtractFirmenAbcIdsCompany(sourceString.ToString());
											
											foreach (string st in idList)
											{
												
												try
												{
													string customerString = wc.DownloadString(st);
													wc.Dispose();
													
													FirmenAdresse fAdresse = new FirmenAdresse();
													fAdresse.Name = TagManager.GetName(customerString);
													fAdresse.PostLeitZahl = TagManager.GetPostal(customerString);
													fAdresse.Email = TagManager.GetEmailFirmenAbc(customerString);
													fAdresse.Strasse = TagManager.GetStreetAddress(customerString);
													fAdresse.Ortschaft = TagManager.GetAddress(customerString);
													fAdresse.TelefonNummer = TagManager.GetPhoneNumber(customerString);
													
													if (!(fAdresse.TelefonNummer == "") && !(fAdresse.TelefonNummer == null))
													{
														
														customerString = null;
														
														if (currentSpiderJob.DoppelteAdressenUeberspringen)
														{
															
															var address = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
															var address2 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer2", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
															var address3 = sess.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("TelefonNummer3", "%" + fAdresse.TelefonNummer, BinaryOperatorType.Like));
															
															if (address == null && address2 == null && address3 == null)
															{
																BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
																xpoAddress.Firma3 = fAdresse.Name;
																xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
																xpoAddress.Email3 = fAdresse.Email;
																xpoAddress.Branche = sess.GetObjectByKey<BusinessLogic.Basis.Branche>(targetBranche.Oid);
																xpoAddress.Strasse = fAdresse.Strasse;
																xpoAddress.Ortschaft = fAdresse.Ortschaft;
																xpoAddress.TelefonNummer3 = fAdresse.TelefonNummer;
																xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
																xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
																xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
																xpoAddress.Save();
																sess.CommitChanges();
																xpoAddress = null;
																recordsAdded++;
																currentSpiderJob.Resultate = recordsAdded;
																currentSpiderJob.Save();
															}
															else
															{
																address = null;
																address2 = null;
																address3 = null;
																recordsMatchFound++;
															}
															
														}
														else
														{
															
															BusinessLogic.Basis.Adresse xpoAddress = new BusinessLogic.Basis.Adresse(sess);
															xpoAddress.Firma3 = fAdresse.Name;
															xpoAddress.Postleitzahl = Convert.ToInt32(fAdresse.PostLeitZahl);
															xpoAddress.Email3 = fAdresse.Email;
															xpoAddress.Branche = sess.GetObjectByKey<BusinessLogic.Basis.Branche>(targetBranche.Oid);
															xpoAddress.Strasse = fAdresse.Strasse;
															xpoAddress.Ortschaft = fAdresse.Ortschaft;
															xpoAddress.TelefonNummer3 = fAdresse.TelefonNummer;
															xpoAddress.Land = sess.GetObjectByKey<BusinessLogic.Basis.Land>(1);
															xpoAddress.Besitzer = sess.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(currentSpiderJob.BesitzerDerAdressen.Oid);
															xpoAddress.AdressArt = sess.GetObjectByKey<BusinessLogic.Basis.AdressArt>(currentSpiderJob.ArtDerAdressen.Oid);
															xpoAddress.Save();
															sess.CommitChanges();
															xpoAddress = null;
															recordsAdded++;
															currentSpiderJob.Resultate = recordsAdded;
															currentSpiderJob.Save();
														}
														
													}
													
												}
												catch (Exception ex)
												{
													Gurock.SmartInspect.SiAuto.Main.LogException(ex);
													
													
													
												}
												
											}
											
										}
										catch (Exception ex)
										{
											Gurock.SmartInspect.SiAuto.Main.LogException(ex);
											
											
											
										}
										
									}
									
									currentSpiderJob.Status = sess.GetObjectByKey<MainModel.SpiderStatus>(3);
									currentSpiderJob.Resultate = recordsAdded;
									currentSpiderJob.SystemMeldung = "Es wurden insgesammt " + System.Convert.ToString(recordsAdded) + " neue Adressen in das System eingetragen. " + System.Convert.ToString(recordsMatchFound) + " Adressen waren dem System schon bekannt und " + System.Convert.ToString(recordsIgnored) + " Adressen wurden aufgrund der suchkriterien ignoriert.";
									currentSpiderJob.Save();
									SpiderRunning = "ed";
									AdressenManagement.Module.Spider.Sglobal.IsRunning = false;
									GlobalBase.SpiderJobManagerList.Clear();
									sess.CommitChanges();
									th.Abort();
									
								}
								break;
						}
						break;
						
				}
				
				AdressenManagement.Module.Spider.Sglobal.IsRunning = false;
				
			}
			
			private string ExtractTelefonAbcIdForPhone(string source)
			{
				
				string retString = "";
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				mc = Regex.Matches(source, 
					"<a class=\"h_green\" href=\"(?<text>.*)\">");
				string[] results = new string[mc.Count - 1 + 1];
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"h_green\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					retString = results[i];
				}
				
				if (string.IsNullOrEmpty(retString))
				{
					retString = ExtractAgainTelefonAbcId(source, "O");
				}
				
				return retString;
				
			}
			
			public static string ExtractAgainTelefonAbcId(string source, string donot = "")
			{
				
				string phone = "";
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				mc = Regex.Matches(source, 
					"<a class=\"poi-link hidden-xs\" href=\"(?<text>.*)\">");
				string[] results = new string[mc.Count - 1 + 1];
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"poi-link hidden-xs\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					phone = results[i];
					
				}
				
				return phone;
				
			}
			
			private void ExtractTelefonAbcId(string source)
			{
				
				idList.Clear();
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				mc = Regex.Matches(source, 
					"<a class=\"h_green\" href=\"(?<text>.*)\">");
				string[] results = new string[mc.Count - 1 + 1];
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"h_green\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					if (!oldidList.Contains(results[i]))
					{
						oldidList.Add(results[i]);
						idList.Add(results[i]);
					}
					
				}
				
				if (idList.Count == 0)
				{
					ExtractAgainTelefonAbcId(source);
				}
				
			}
			
			private void ExtractAgainTelefonAbcId(string source)
			{
				
				idList.Clear();
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				mc = Regex.Matches(source, 
					"<a class=\"poi-link hidden-xs\" href=\"(?<text>.*)\">");
				string[] results = new string[mc.Count - 1 + 1];
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"poi-link hidden-xs\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					if (!oldidList.Contains(results[i]))
					{
						oldidList.Add(results[i]);
						idList.Add(results[i]);
					}
					
				}
				
				
			}
			
			private void ExtractFirmenAbcIdsCompany(string source)
			{
				
				idList.Clear();
				
				MatchCollection mc = default(MatchCollection);
				int i = 0;
				
				// expression garnered from www.regexlib.com - thanks guys!
				mc = Regex.Matches(source, 
					"<a class=\"textOrange\"  href=\"(?<text>.*)\">");
				string[] results = new string[mc.Count - 1 + 1];
				
				for (i = 0; i <= results.Length - 1; i++)
				{
					results[i] = System.Convert.ToString(mc[i].Value.Replace("<a class=\"textOrange\"  href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					if (!oldidList.Contains(results[i]))
					{
						oldidList.Add(results[i]);
						idList.Add(results[i]);
					}
					
				}
				
				MatchCollection mc2 = default(MatchCollection);
				int i2 = 0;
				
				// expression garnered from www.regexlib.com - thanks guys!
				mc2 = Regex.Matches(source, 
					"<a class=\"none\" href=\"(?<text>.*)\">");
				string[] results2 = new string[mc2.Count - 1 + 1];
				
				for (i2 = 0; i2 <= results2.Length - 1; i2++)
				{
					results2[i2] = System.Convert.ToString(mc2[i2].Value.Replace("<a class=\"none\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					if (!oldidList.Contains(results2[i2]))
					{
						oldidList.Add(results2[i2]);
						idList.Add(results2[i2]);
					}
					
				}
				
				MatchCollection mc3 = default(MatchCollection);
				int i3 = 0;
				
				// expression garnered from www.regexlib.com - thanks guys!
				mc3 = Regex.Matches(source, 
					"<a class=\"textOrange\" itemprop=\"url\" href=\"(?<text>.*)\">");
				string[] results3 = new string[mc3.Count - 1 + 1];
				
				for (i3 = 0; i3 <= results3.Length - 1; i3++)
				{
					results3[i3] = System.Convert.ToString(mc3[i3].Value.Replace("<a class=\"textOrange\" itemprop=\"url\" href=\"", "").Replace("\">", "").Replace("\'", ""));
					
					if (!oldidList.Contains(results3[i3]))
					{
						oldidList.Add(results3[i3]);
						idList.Add(results3[i3]);
					}
					
				}
				
			}
			
		}
		
	}
}
