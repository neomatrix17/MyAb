#define Standard
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
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp.Model;
using System.Linq;
using System.Xml;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Security.Strategy;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Basis
	{
		
		[ImageName("BO_Scheduler")]public class Termin : DevExpress.Persistent.BaseImpl.Event
			{
			
			
			private bool isCreated = false;
			private MainModel.Anrufprotokoll anrufProtokoll;
			
			public Termin(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				Mitarbeiter = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
				TerminArt = Session.GetObjectByKey<BusinessLogic.Basis.TerminArt>(6);
				Gesprächsergebnis = null;
				Gesprächspartner = Session.GetObjectByKey<BusinessLogic.Basis.Gesprächspartner>(5);
				StartOn = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 0, 0);
				EndOn = StartOn.AddHours(1);
				anrufProtokoll = new MainModel.Anrufprotokoll(Session);
				SearchDate = DateTime.Now.Date.ToString("dd.MM.yyyy");
				
				
				var currUser = (BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser;
				
				if (!(currUser == null))
				{
					VereinbartVon = System.Convert.ToString(currUser.MitarbeiterName);
				}
				
			}
			
			protected override void OnDeleting()
			{
				
				if (!(Adresse == null))
				{
					if (!(Adresse.OriginalStatus == null))
					{
						if (!(Adresse.Status == null))
						{
							if (Adresse.Status.Oid != Adresse.OriginalStatus.Oid)
							{
								Adresse.Status = Adresse.OriginalStatus;
								Adresse.Save();
							}
						}
					}
				}
				
				base.OnDeleting();
				
			}
			
			private TerminBericht fTerminBericht;
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public TerminBericht TerminBericht
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
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispName
				{
				get
				{
					if (!(Adresse == null))
					{
						return System.Convert.ToString( Adresse.AnzeigeName);
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string EmpfDispName
				{
				get
				{
					if (!(Adresse == null) && !(Adresse.Empfehlungsgeber == null))
					{
						return System.Convert.ToString( Adresse.Empfehlungsgeber.AnzeigeName);
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispLand
				{
				get
				{
					if (!(Land == null))
					{
						return Land.Name;
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispMa
				{
				get
				{
					if (!(Mitarbeiter == null))
					{
						return Mitarbeiter.MitarbeiterName;
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispTel1
				{
				get
				{
					if (!(Adresse == null))
					{
						return Adresse.TelefonNummer;
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispTel2
				{
				get
				{
					if (!(Adresse == null))
					{
						return Adresse.TelefonNummer2;
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispTel3
				{
				get
				{
					if (!(Adresse == null))
					{
						return Adresse.TelefonNummer3;
					}
					else
					{
						return "";
					}
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispStart
				{
				get
				{
					return StartOn.ToString("HH:mm");
				}
			}
			
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), NonPersistent]public string DispDate
				{
				get
				{
					return StartOn.ToString("dd.MM.yyyy");
				}
			}
			
			private string fSearchDate;
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public string SearchDate
				{
				get
				{
					return fSearchDate;
				}
				set
				{
					fSearchDate = value;
				}
			}
			
			private string fVereinbartVon;
[VisibleInDetailView(false), VisibleInListView(true)]public string VereinbartVon
				{
				get
				{
					return fVereinbartVon;
				}
				set
				{
					fVereinbartVon = value;
				}
			}
			
			private string fZuGoogleMaps;
[NonPersistent, EditorAlias("HyperLinkPropertyEditor")]public string ZuGoogleMaps
				{
				get
				{
					
					if (!(Adresse == null))
					{
						if (!(Land == null))
						{
							return "https://www.google.at/maps/place/" + Adresse.Strasse + ",+" + System.Convert.ToString(Adresse.Postleitzahl) + "+" + Adresse.Ortschaft + ",+" + ConGoogleName(Adresse.Land.Name) + "/".Replace(" ", "%").Replace("  ", "%").Replace("   ", "%");
						}
						else
						{
							return "https://www.google.at/maps/place/";
						}
					}
					else
					{
						return "https://www.google.at/maps/place/";
					}
					
				}
				
				set
				{
					fZuGoogleMaps = value;
				}
			}
			
			private string ConGoogleName(string pName)
			{
				
				switch (pName.ToLower())
				{
					case "österreich":
						return "Austria";
					default:
						return "Austria";
				}
				
			}
			
			protected override void OnSaving()
			{
				
				try
				{
					if (!(Adresse == null))
					{
						
						if (!((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).HasWorked)
						{
							
							((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).HasWorked = true;
							
							Adresse.CreateCustomerAccount();
							
							Adresse.LetzterKontaktAm = DateTime.Now;
							Adresse.Save();
							
							
							if (!(Gesprächsergebnis == null))
							{
								switch (Gesprächsergebnis.Oid)
								{
									case 6:
										Subject = "";
										Description = Gesprächsnotiz;
										anrufProtokoll = null;
										break;
									default:
										Subject = Adresse.AnzeigeName + "\r\n" + Adresse.Strasse + " " + System.Convert.ToString(Adresse.Postleitzahl) + " " + Adresse.Ortschaft + "\r\n";
										Description = TerminArt.Name;
										break;
								}
							}
							else
							{
								Subject = Adresse.AnzeigeName + "\r\n" + Adresse.Strasse + " " + System.Convert.ToString(Adresse.Postleitzahl) + " " + Adresse.Ortschaft + "\r\n";
								Description = TerminArt.Name;
							}
							
							if (KontaktierenAb.HasValue || !KontaktierenAb.HasValue)
							{
								Adresse.LetzterKontaktAm = DateTime.Now;
								Adresse.KontaktierenAb = KontaktierenAb;
								Adresse.Save();
							}
							
						}
						
					}
					else
					{
						Subject = Gesprächsnotiz;
						try
						{
							Description = TerminArt.Name;
						}
						catch (Exception ex)
						{
							Gurock.SmartInspect.SiAuto.Main.LogException(ex);
							
							
							
							
							MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
							exeptionError.Zeitstempel = DateTime.Now;
							exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
							exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
							exeptionError.Aktion = "Protected Overrides Sub OnSaving()";
							exeptionError.Fehlermeldung = ex.Message;
						}
					}
					
					if (!(Mitarbeiter == null))
					{
						ResourceId = "<ResourceIds> <ResourceId Type=\"System.Guid\" Value=\"" + Mitarbeiter.Id.ToString() + "\"/> </ResourceIds>";
					}
					if (CurrentProtokoll == null)
					{
						
						if (!(anrufProtokoll == null))
						{
							anrufProtokoll.Adresse = Adresse;
							anrufProtokoll.Notiz = Gesprächsnotiz;
							if (!(Gesprächspartner == null))
							{
								anrufProtokoll.GesprochenMit = Gesprächspartner.Name;
							}
							if (!(Gesprächsergebnis == null))
							{
								anrufProtokoll.Status = Gesprächsergebnis.Name;
							}
							
							if (KontaktierenAb.HasValue)
							{
								anrufProtokoll.ErbeutKontaktierenAb = KontaktierenAb;
							}
							
							anrufProtokoll.Mitarbeiter = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(DevExpress.ExpressApp.SecuritySystem.CurrentUserId);
							anrufProtokoll.Save();
						}
						
						CurrentProtokoll = anrufProtokoll;
						
					}
					
					string temp_criteriaParametersList = Gesprächsnotiz;
					var isNotiz = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)",  temp_criteriaParametersList));
					Gesprächsnotiz = temp_criteriaParametersList;
					
					if (isNotiz == null)
					{
						try
						{
							
							if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
							{
								GlobalBase.LastInsert = DateTime.Now;
								BusinessLogic.Basis.Notiz notiz = new BusinessLogic.Basis.Notiz(Session);
								notiz.Adresse = Adresse;
								notiz.NotizFeld = Gesprächsnotiz;
								if (!(Gesprächspartner == null))
								{
									notiz.GesprochenMit = Gesprächspartner.Name;
								}
								notiz.Termin = this;
								notiz.TerminBericht = null;
								if (!(Gesprächspartner == null))
								{
									notiz.GesprochenMit = Gesprächspartner.Name;
								}
								notiz.Save();
							}
							
						}
						catch (Exception ex)
						{
							Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						}
						
					}
					
					if (!(Gesprächsergebnis == null))
					{
						if (Gesprächsergebnis.Oid == 27)
						{
							if (TerminBericht == null)
							{
								TerminBericht tBericht = new TerminBericht(Session);
								tBericht.Termin = this;
								tBericht.ResultatStatus = Gesprächsergebnis;
								tBericht.Adresse = Adresse;
								TerminBericht = tBericht;
								tBericht.Save();
							}
							base.OnSaving();
						}
						else
						{
							switch (Gesprächsergebnis.Oid)
							{
								case 25:
									IsRealAppointment = false;
									base.OnSaving();
									break;
								case 24:
									IsRealAppointment = false;
									base.OnSaving();
									break;
								case 26:
									IsRealAppointment = false;
									base.OnSaving();
									break;
								case 27:
									IsRealAppointment = null;
									base.OnSaving();
									break;
								default:
									IsRealAppointment = false;
									base.OnSaving();
									break;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "";
					exeptionError.Fehlermeldung = ex.Message;
				}
				
				if (!(Gesprächsergebnis == null))
				{
					switch (Gesprächsergebnis.Oid)
					{
						case 25:
							IsRealAppointment = false;
							base.OnSaving();
							break;
						case 24:
							IsRealAppointment = false;
							base.OnSaving();
							break;
						case 26:
							IsRealAppointment = false;
							base.OnSaving();
							break;
						case 27:
							IsRealAppointment = null;
							base.OnSaving();
							break;
						default:
							IsRealAppointment = null;
							base.OnSaving();
							break;
					}
				}
				else
				{
					Gesprächsergebnis = Session.GetObjectByKey<BusinessLogic.Basis.Status>(27);
					IsRealAppointment = null;
					base.OnSaving();
				}
				
			}
			
			private bool? fIsRealAppointment;
[VisibleInDetailView(false), VisibleInListView(false), ImmediatePostData(true)]public bool? IsRealAppointment
				{
				get
				{
					return fIsRealAppointment;
				}
				set
				{
					fIsRealAppointment = value;
				}
			}
			
			protected override void OnLoaded()
			{
				
				if (!(Adresse == null))
				{
					try
					{
						foreach (BusinessLogic.Basis.Empfehlung emf in Adresse.ListeDerEmpfehlungsgeberBeta)
						{
							Empfehlungsgeber += System.Convert.ToString(emf.Name);
						}
					}
					catch (Exception)
					{
						
					}
				}
				
				if (VereinbartVon == null || VereinbartVon == "")
				{
					var currUser = (BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser;
					
					if (!(currUser == null))
					{
						VereinbartVon = System.Convert.ToString(currUser.MitarbeiterName);
					}
				}
				
				try
				{
					if (!(Adresse == null))
					{
						Strasse = Adresse.Strasse;
						Postleitzahl = Adresse.Postleitzahl;
						Ortschaft = Adresse.Ortschaft;
						Land = Adresse.Land;
						
						GesprächsLeitfaden = Adresse.GesprächsLeitfaden;
						
						Anrede = Adresse.Anrede;
						Titel = Adresse.Titel;
						Vorname = Adresse.Vorname;
						Nachname = Adresse.Nachname;
						GeburtsDatum = Adresse.GeburtsDatum;
						Email = Adresse.Email;
						Berufsstatus = Adresse.Berufsstatus;
						TelefonNummer = Adresse.TelefonNummer;
						Beschreibung = Adresse.Beschreibung;
						Vorwahl = Adresse.Vorwahl;
						
						Anrede2 = Adresse.Anrede2;
						Titel2 = Adresse.Titel2;
						Vorname2 = Adresse.Vorname2;
						Nachname2 = Adresse.Nachname2;
						GeburtsDatum2 = Adresse.GeburtsDatum2;
						Email2 = Adresse.Email2;
						Berufsstatus2 = Adresse.Berufsstatus2;
						TelefonNummer2 = Adresse.TelefonNummer2;
						Beschreibung2 = Adresse.Beschreibung2;
						Vorwahl2 = Adresse.Vorwahl2;
						
						Titel3 = Adresse.Titel3;
						Vorname3 = Adresse.Firma;
						Nachname3 = Adresse.Firma2;
						Firma = Adresse.Firma3;
						
						GeburtsDatum3 = Adresse.GeburtsDatum3;
						Email3 = Adresse.Email3;
						Berufsstatus3 = Adresse.Berufsstatus3;
						TelefonNummer3 = Adresse.TelefonNummer3;
						Beschreibung3 = Adresse.Beschreibung3;
						Vorwahl3 = Adresse.Vorwahl3;
						Branche = Adresse.Branche;
						
						if (!(Beschreibung == null))
						{
							if (Beschreibung.Contains("Produkt"))
							{
								
							}
						}
						
						foreach (BusinessLogic.Basis.Empfehlung emf in Adresse.ListeDerEmpfehlungsgeberBeta)
						{
							Empfehlungsgeber += System.Convert.ToString(emf.Name);
						}
						
					}
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
				}
				
				base.OnLoaded();
				
			}
			
			protected override void OnChanged(string propertyName, object oldValue, object newValue)
			{
				
				if (!IsLoading)
				{
					if (propertyName == "StartOn")
					{
						try
						{
							EndOn = StartOn.AddHours(System.Convert.ToDouble(TerminArt != null ? TerminArt.StandardTerminDauer : 1));
						}
						catch (Exception ex)
						{
							Gurock.SmartInspect.SiAuto.Main.LogException(ex);
							
							
							MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
							exeptionError.Zeitstempel = DateTime.Now;
							exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
							exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
							exeptionError.Aktion = "Protected Overrides Sub OnChanged(propertyName As String, oldValue As Object, newValue As Object)";
							exeptionError.Fehlermeldung = ex.Message;
						}
					}
					
					if (propertyName == "Mitarbeiter")
					{
						
						if (!(newValue == null))
						{
							if (!(Adresse == null))
							{
                                //Check this
								Adresse.Besitzer = (BusinessLogic.Intern.Mitarbeiter)newValue;
								Adresse.Save();
							}
						}
						
					}
					
				}
				
			}
			
			public static Termin GetInstance(DevExpress.ExpressApp.IObjectSpace objectSpace, BusinessLogic.Basis.Adresse pAdresse)
			{
				Termin result = null;
				if (result == null)
				{
					result = new Termin(((XPObjectSpace) objectSpace).Session);
					
					result.Mitarbeiter = result.Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
					
					if (!(pAdresse == null))
					{
						result.Mitarbeiter = result.Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(pAdresse.Besitzer.Oid);
						result.Adresse = result.Session.GetObjectByKey<BusinessLogic.Basis.Adresse>(pAdresse.Oid);
					}
					result.Save();
				}
				return result;
			}
			
			private Intern.Mitarbeiter fMitarbeiter;
[Association("Mitarbeiter-Termine")]public Intern.Mitarbeiter Mitarbeiter
				{
				get
				{
					return fMitarbeiter;
				}
				set
				{
					fMitarbeiter = value;
					
					if (!IsLoading)
					{
						if (!(value == null))
						{
							
							((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).SelectedResourceName = value.UserName;
							
							if (!(Adresse == null))
							{
								Adresse.Besitzer = value;
								Adresse.Save();
							}
						}
					}
					
					if (!(value == null))
					{
						var user = SecuritySystem.CurrentUser as BusinessLogic.Intern.Mitarbeiter;
						
						if (!(user == null))
						{
							
							var roles = user.MitarbeiterRollen;
							
							foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
							{
								if (r.Name == "Telefonist")
								{
									fIsOwner = false;
								}
							}
						}
						
					}
					
				}
			}
			
			private bool fIsOwner = true;
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]public bool IsOwner
				{
				get
				{
					return fIsOwner;
				}
			}
			
			private MainModel.Anrufprotokoll fCurrentProtokoll;
			
[VisibleInDetailView(false), VisibleInListView(false)]public MainModel.Anrufprotokoll CurrentProtokoll
				{
				get
				{
					return fCurrentProtokoll;
				}
				set
				{
					fCurrentProtokoll = value;
				}
			}
			
			private Basis.Adresse fAdresse;
			
#if Standard
[Association("Adresse-Termine")]public Basis.Adresse Adresse
				{
				get
				{
					return fAdresse;
				}
				set
				{
					fAdresse = value;
					VerknüpfteAdresse = value;
				}
			}
#else
[Association("Adresse-Termine"), Indexed(Unique = false)]public Basis.Adresse Adresse
				{
				get
				{
					return fAdresse;
				}
				set
				{
					fAdresse = value;
					VerknüpfteAdresse = value;
				}
			}
#endif
			
			private Basis.Adresse fVerknüpfteAdresse;
#if Standard
[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]public Basis.Adresse VerknüpfteAdresse
				{
				get
				{
					return fVerknüpfteAdresse;
				}
				set
				{
					fVerknüpfteAdresse = value;
				}
			}
#else
[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never), Indexed(Unique = false)]public Basis.Adresse VerknüpfteAdresse
				{
				get
				{
					return fVerknüpfteAdresse;
				}
				set
				{
					fVerknüpfteAdresse = value;
				}
			}
#endif
			
			private Gesprächspartner fGesprächspartner;
public Gesprächspartner Gesprächspartner
			{
				get
				{
					return fGesprächspartner;
				}
				set
				{
					OnChanged("Gesprächspartner", Gesprächspartner, value);
					fGesprächspartner = value;
				}
			}
			
			private Status fGesprächsergebnis;
public Status Gesprächsergebnis
			{
				get
				{
					return fGesprächsergebnis;
				}
				set
				{
					OnChanged("Gesprächsergebnis", Gesprächsergebnis, value);
					fGesprächsergebnis = value;
					
					if (!IsLoading)
					{
						if (!Session.IsObjectsLoading)
						{
							if (!(Adresse == null))
							{
								Adresse.Status = value;
								Adresse.Save();
							}
						}
						
						if (!(value == null))
						{
							if (value.Oid == 24)
							{
								KontaktierenAb = DateTime.Now.Date.AddDays(1);
							}
						}
						
					}
					
				}
			}
			
			private string fGesprächsnotiz;
[Size(SizeAttribute.Unlimited)]public string Gesprächsnotiz
			{
				get
				{
					return fGesprächsnotiz;
				}
				set
				{
					OnChanged("Gesprächsnotiz", Gesprächsnotiz, value);
					fGesprächsnotiz = value;
				}
			}
			
			
			private DateTime? fKontaktierenAb;
[ModelDefault("DisplayFormat", "{0:dd.MM.yyyy HH:mm}"), 
ModelDefault("EditMask", "dd.MM.yyyy HH:mm"), NonPersistent]public DateTime? KontaktierenAb
				{
				get
				{
					return fKontaktierenAb;
				}
				set
				{
					fKontaktierenAb = value;
					if (!IsLoading)
					{
						if (!(Adresse == null))
						{
							Adresse.KontaktierenAb = value;
							Adresse.Save();
						}
					}
				}
			}
			
			private TerminArt fTerminArt;
public TerminArt TerminArt
			{
				get
				{
					return fTerminArt;
				}
				set
				{
					fTerminArt = value;
					try
					{
						if (!IsLoading)
						{
							EndOn = StartOn.AddHours(System.Convert.ToDouble(!(TerminArt == null) ? TerminArt.StandardTerminDauer : 1));
						}
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						
						
						MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
						exeptionError.Zeitstempel = DateTime.Now;
						exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
						exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
						exeptionError.Aktion = "Set(ByVal value As TerminArt)";
						exeptionError.Fehlermeldung = ex.Message;
					}
				}
			}
			
			private string fPerson;
[ModelDefault("PredefinedValues", "fake")]public string Person
				{
				get
				{
					return fPerson;
				}
				set
				{
					fPerson = value;
				}
			}
			
			private void Termin_Changed(object sender, ObjectChangeEventArgs e)
			{
				
				if (e.PropertyName == "Mitarbeiter")
				{
					
					if (!(e.NewValue == null))
					{
						if (!(Adresse == null))
						{
                            //Check this
							Adresse.Besitzer = (BusinessLogic.Intern.Mitarbeiter)e.NewValue;
							Adresse.Save();
						}
					}
					
				}
				
				base.OnChanged();
			}
			
#region Adresse Members
			
#region Global
			
			private string fGesprächsLeitfaden;
[ReadOnly(true), Size(SizeAttribute.Unlimited), NonPersistent]public string GesprächsLeitfaden
				{
				get
				{
					return fGesprächsLeitfaden;
				}
				set
				{
					fGesprächsLeitfaden = value;
				}
			}
			
			private string fEmpfehlungsgeber;
[Size(SizeAttribute.Unlimited), NonPersistent]public string Empfehlungsgeber
				{
				get
				{
					
					if (!IsLoading)
					{
						
						string st = "";
						
						if (!(Adresse == null) && !(Adresse.ListeDerEmpfehlungsgeberBeta == null))
						{
							try
							{
								foreach (BusinessLogic.Basis.Empfehlung emf in Adresse.ListeDerEmpfehlungsgeberBeta)
								{
									st += System.Convert.ToString(emf.Name);
								}
							}
							catch (Exception)
							{
								
							}
						}
						
						return st;
					}
					else
					{
						return "";
					}
					
				}
				set
				{
					fEmpfehlungsgeber = value;
				}
			}
			
			private string fVorwahl;
[NonPersistent, ReadOnly(true)]public string Vorwahl
				{
				get
				{
					return fVorwahl;
				}
				set
				{
					fVorwahl = value;
				}
			}
			
			private string fVorwahl2;
[ReadOnly(true), NonPersistent]public string Vorwahl2
				{
				get
				{
					return fVorwahl2;
				}
				set
				{
					fVorwahl2 = value;
				}
			}
			
			private string fVorwahl3;
[ReadOnly(true), NonPersistent]public string Vorwahl3
				{
				get
				{
					return fVorwahl3;
				}
				set
				{
					fVorwahl3 = value;
				}
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
			
			private int? fPostleitzahl;
public int? Postleitzahl
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
					if (!(value == null))
					{
						Vorwahl = value.Vorwahl;
						Vorwahl2 = value.Vorwahl;
						Vorwahl3 = value.Vorwahl;
					}
				}
			}
			
#endregion
			
#region Frau
			
			private Formal.Anrede fAnrede;
[ReadOnly(true), NonPersistent]public Formal.Anrede Anrede
				{
				get
				{
					return fAnrede;
				}
				set
				{
					SetPropertyValue("Anrede", ref fAnrede, value);
				}
			}
			
			private MainModel.Titel fTitel;
[NonPersistent]public MainModel.Titel Titel
				{
				get
				{
					return fTitel;
				}
				set
				{
					fTitel = value;
				}
			}
			
			private string fVorname;
[NonPersistent]public string Vorname
				{
				get
				{
					return fVorname;
				}
				set
				{
					SetPropertyValue("Vorname", ref fVorname, value);
				}
			}
			
			private string fNachname;
[NonPersistent]public string Nachname
				{
				get
				{
					return fNachname;
				}
				set
				{
					SetPropertyValue("Nachname", ref fNachname, value);
				}
			}
			
			private string fBeschreibung;
[Size(SizeAttribute.Unlimited), NonPersistent]public string Beschreibung
				{
				get
				{
					return fBeschreibung;
				}
				set
				{
					fBeschreibung = value;
				}
			}
			
			private string fEmail;
[NonPersistent]public string Email
				{
				get
				{
					return fEmail;
				}
				set
				{
					SetPropertyValue("Email", ref fEmail, value);
				}
			}
			
			private Berufsstatus fBerufsstatus;
[NonPersistent]public Berufsstatus Berufsstatus
				{
				get
				{
					return fBerufsstatus;
				}
				set
				{
					fBerufsstatus = value;
				}
			}
			
			private DateTime fGeburtsDatum;
[NonPersistent]public DateTime GeburtsDatum
				{
				get
				{
					return fGeburtsDatum;
				}
				set
				{
					fGeburtsDatum = value;
				}
			}
			
			private string fTelefonNummer;
[NonPersistent]public string TelefonNummer
				{
				get
				{
					if (!(fTelefonNummer == null) && !(string.IsNullOrEmpty(fTelefonNummer)))
					{
						if (!(Land == null))
						{
							if (!string.IsNullOrEmpty(fTelefonNummer))
							{
								return Land.Vorwahl + System.Convert.ToString((fTelefonNummer.StartsWith("0")) ? (fTelefonNummer.Remove(0, 1)) : fTelefonNummer);
							}
							else
							{
								return "";
							}
						}
						else
						{
							if (!(string.IsNullOrEmpty(fTelefonNummer)))
							{
								return System.Convert.ToString( ((fTelefonNummer.StartsWith("0")) ? (fTelefonNummer.Remove(0, 1)) : fTelefonNummer));
							}
							else
							{
								return "";
							}
						}
					}
					else
					{
						return "";
					}
				}
				set
				{
					fTelefonNummer = value;
				}
			}
			
#endregion
			
#region Mann
			
			private Formal.Anrede fAnrede2;
[ReadOnly(true), NonPersistent]public Formal.Anrede Anrede2
				{
				get
				{
					return fAnrede2;
				}
				set
				{
					SetPropertyValue("Anrede2", ref fAnrede2, value);
				}
			}
			
			private MainModel.Titel fTitel2;
[NonPersistent]public MainModel.Titel Titel2
				{
				get
				{
					return fTitel2;
				}
				set
				{
					fTitel2 = value;
				}
			}
			
			private string fVorname2;
[NonPersistent]public string Vorname2
				{
				get
				{
					return fVorname2;
				}
				set
				{
					SetPropertyValue("Vorname2", ref fVorname2, value);
				}
			}
			
			private string fNachname2;
[NonPersistent]public string Nachname2
				{
				get
				{
					return fNachname2;
				}
				set
				{
					SetPropertyValue("Nachname2", ref fNachname2, value);
				}
			}
			
			private string fBeschreibung2;
[Size(SizeAttribute.Unlimited), NonPersistent]public string Beschreibung2
				{
				get
				{
					return fBeschreibung2;
				}
				set
				{
					fBeschreibung2 = value;
				}
			}
			
			private string fEmail2;
[NonPersistent]public string Email2
				{
				get
				{
					return fEmail2;
				}
				set
				{
					SetPropertyValue("Email2", ref fEmail2, value);
				}
			}
			
			private Berufsstatus fBerufsstatus2;
[NonPersistent]public Berufsstatus Berufsstatus2
				{
				get
				{
					return fBerufsstatus2;
				}
				set
				{
					fBerufsstatus2 = value;
				}
			}
			
			private DateTime fGeburtsDatum2;
[NonPersistent]public DateTime GeburtsDatum2
				{
				get
				{
					return fGeburtsDatum2;
				}
				set
				{
					fGeburtsDatum2 = value;
				}
			}
			
			private string fTelefonNummer2;
[NonPersistent]public string TelefonNummer2
				{
				get
				{
					if (!(fTelefonNummer2 == null) && !(string.IsNullOrEmpty(fTelefonNummer2)))
					{
						if (!(Land == null))
						{
							if (!string.IsNullOrEmpty(fTelefonNummer2))
							{
								return Land.Vorwahl + System.Convert.ToString((fTelefonNummer2.StartsWith("0")) ? (fTelefonNummer2.Remove(0, 1)) : fTelefonNummer2);
							}
							else
							{
								return "";
							}
						}
						else
						{
							if (!(string.IsNullOrEmpty(fTelefonNummer2)))
							{
								return System.Convert.ToString( ((fTelefonNummer2.StartsWith("0")) ? (fTelefonNummer2.Remove(0, 1)) : fTelefonNummer2));
							}
							else
							{
								return "";
							}
						}
					}
					else
					{
						return "";
					}
				}
				set
				{
					fTelefonNummer2 = value;
				}
			}
			
#endregion
			
#region Firma
			
			
			private MainModel.Titel fTitel3;
[NonPersistent]public MainModel.Titel Titel3
				{
				get
				{
					return fTitel3;
				}
				set
				{
					fTitel3 = value;
				}
			}
			
			private string fFirma;
[NonPersistent]public string Firma
				{
				get
				{
					return fFirma;
				}
				set
				{
					SetPropertyValue("Firma", ref fFirma, value);
				}
			}
			
			private string fVorname3;
[NonPersistent]public string Vorname3
				{
				get
				{
					return fVorname3;
				}
				set
				{
					SetPropertyValue("Vorname3", ref fVorname3, value);
				}
			}
			
			private string fNachname3;
[NonPersistent]public string Nachname3
				{
				get
				{
					return fNachname3;
				}
				set
				{
					SetPropertyValue("Nachname3", ref fNachname3, value);
				}
			}
			
			private string fBeschreibung3;
[Size(SizeAttribute.Unlimited), NonPersistent]public string Beschreibung3
				{
				get
				{
					return fBeschreibung3;
				}
				set
				{
					fBeschreibung3 = value;
				}
			}
			
			private string fEmail3;
[NonPersistent]public string Email3
				{
				get
				{
					return fEmail3;
				}
				set
				{
					SetPropertyValue("Email3", ref fEmail3, value);
				}
			}
			
			private Berufsstatus fBerufsstatus3;
[NonPersistent]public Berufsstatus Berufsstatus3
				{
				get
				{
					return fBerufsstatus3;
				}
				set
				{
					fBerufsstatus3 = value;
				}
			}
			
			private DateTime fGeburtsDatum3;
[NonPersistent]public DateTime GeburtsDatum3
				{
				get
				{
					return fGeburtsDatum3;
				}
				set
				{
					fGeburtsDatum3 = value;
				}
			}
			
			private string fTelefonNummer3;
[NonPersistent]public string TelefonNummer3
				{
				get
				{
					if (!(fTelefonNummer3 == null) && !(string.IsNullOrEmpty(fTelefonNummer2)))
					{
						if (!(Land == null))
						{
							if (!string.IsNullOrEmpty(fTelefonNummer3))
							{
								return Land.Vorwahl + System.Convert.ToString((fTelefonNummer3.StartsWith("0")) ? (fTelefonNummer3.Remove(0, 1)) : fTelefonNummer3);
							}
							else
							{
								return "";
							}
						}
						else
						{
							if (!(string.IsNullOrEmpty(fTelefonNummer3)))
							{
								return System.Convert.ToString( ((fTelefonNummer3.StartsWith("0")) ? (fTelefonNummer3.Remove(0, 1)) : fTelefonNummer3));
							}
							else
							{
								return "";
							}
						}
					}
					else
					{
						return "";
					}
				}
				set
				{
					fTelefonNummer3 = value;
				}
			}
			
			private Branche fBranche;
[NonPersistent]public Branche Branche
				{
				get
				{
					return fBranche;
				}
				set
				{
					fBranche = value;
				}
			}
			
#endregion
			
#endregion
			
#region Audit Trail Log
			
			private XPCollection<AuditDataItemPersistent> m_userAuditTrail;
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public XPCollection<AuditDataItemPersistent> ChangeLog
				{
				get
				{
					if (m_userAuditTrail == null)
					{
						m_userAuditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
					}
					return m_userAuditTrail;
				}
			}
			
#endregion
			
		}
		
	}
}
