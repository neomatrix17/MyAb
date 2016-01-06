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
using DevExpress.Persistent.Base.Security;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Intern
	{
		
		public class ZeitstempelObjekt : XPObject
		{
			
			
			public ZeitstempelObjekt(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				Datum = DateTime.Now.Date;
			}
			
			public void AddTime(TimeSpan pTime)
			{
				TotalMinuten = pTime.Minutes;
				TotalStunden = pTime.Hours;
			}
			
			public void RemoveTime(TimeSpan pTime)
			{
				TotalMinutenInaktiv = pTime.Minutes;
				TotalStundenInaktiv = pTime.Hours;
			}
			
#region Properties
			
			private DateTime fDatum;
public DateTime Datum
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
			
			private DateTime fAngemeldetUm;
[System.ComponentModel.DisplayName("Ang. um")]public DateTime AngemeldetUm
				{
				get
				{
					return fAngemeldetUm;
				}
				set
				{
					fAngemeldetUm = value;
				}
			}
			
			private DateTime fAbgemeldetUm;
[ImmediatePostData(true), System.ComponentModel.DisplayName("Abg. um")]public DateTime AbgemeldetUm
				{
				get
				{
					return fAbgemeldetUm;
				}
				set
				{
					fAbgemeldetUm = value;
				}
			}
			
			private int fTotalStunden;
public int TotalStunden
			{
				get
				{
					return fTotalStunden;
				}
				set
				{
					fTotalStunden = value;
				}
			}
			
			private int fTotalMinuten;
public int TotalMinuten
			{
				get
				{
					return fTotalMinuten;
				}
				set
				{
					fTotalMinuten = value;
				}
			}
			
			private int fTotalStundenInaktiv;
public int TotalStundenInaktiv
			{
				get
				{
					return fTotalStundenInaktiv;
				}
				set
				{
					fTotalStundenInaktiv = value;
				}
			}
			
			private int fTotalMinutenInaktiv;
public int TotalMinutenInaktiv
			{
				get
				{
					return fTotalMinutenInaktiv;
				}
				set
				{
					fTotalMinutenInaktiv = value;
				}
			}
			
public string ArbeitsZeit
			{
				get
				{
					
					string tempTime = "";
					
					TimeSpan t = new TimeSpan(0, TotalMinuten, 0);
					tempTime = t.Hours + ":" + System.Convert.ToString(t.Minutes);
					tempTime = t.ToString().Remove(5, 3);
					return tempTime;
					
				}
			}
			
			private Mitarbeiter fMitarbeiter;
public Mitarbeiter Mitarbeietr
			{
				get
				{
					return fMitarbeiter;
				}
				set
				{
					fMitarbeiter = value;
				}
			}
			
			private int fAnmeldungen;
[VisibleInDetailView(true), VisibleInListView(false)]public int Anmeldungen
				{
				get
				{
					return fAnmeldungen;
				}
				set
				{
					fAnmeldungen = value;
				}
			}
			
			private int fAbmeldungen;
[VisibleInDetailView(true), VisibleInListView(false)]public int Abmeldungen
				{
				get
				{
					return fAbmeldungen;
				}
				set
				{
					fAbmeldungen = value;
				}
			}
			
			private int fAdressenKontaktiert;
[System.ComponentModel.DisplayName("Kontaktiert")]public int AdressenKontaktiert
				{
				get
				{
					if (!IsLoading)
					{
						GetAdressenKontaktiert();
						return fAdressenKontaktiert;
					}
					else
					{
						return fAdressenKontaktiert;
					}
				}
			}
			
			private int fKeinKontakt;
[System.ComponentModel.DisplayName("Gewählt - kein Kontakt")]public int KeinKontakt
				{
				get
				{
					if (!IsLoading)
					{
						GetKeinKontakt();
						return fKeinKontakt;
					}
					else
					{
						return fKeinKontakt;
					}
				}
			}
			
			private int fFalscheNummer;
[System.ComponentModel.DisplayName("Falsche Tel. Nr.")]public int FalscheNummer
				{
				get
				{
					if (!IsLoading)
					{
						GetFalscheNummer();
						return fFalscheNummer;
					}
					else
					{
						return fFalscheNummer;
					}
				}
			}
			
			private int fTermineVereinbart;
public int TermineVereinbart
			{
				get
				{
					if (!IsLoading)
					{
						GetTermineVereinbart();
						return fTermineVereinbart;
					}
					else
					{
						return fTermineVereinbart;
					}
				}
			}
			
			private int fKeinInteresseVomKunden;
public int KeinInteresseVomKunden
			{
				get
				{
					if (!IsLoading)
					{
						GetKeinInteresseVomKunden();
						return fKeinInteresseVomKunden;
					}
					else
					{
						return fKeinInteresseVomKunden;
					}
				}
			}
			
			
			private int fKeinInteresseUnsererseits;
public int KeinInteresseUnsererseits
			{
				get
				{
					if (!IsLoading)
					{
						GetKeinInteresseUnsererseits();
						return fKeinInteresseUnsererseits;
					}
					else
					{
						return fKeinInteresseUnsererseits;
					}
				}
			}
			
			private int fErneutKontaktieren;
public int ErneutKontaktieren
			{
				get
				{
					if (!IsLoading)
					{
						GetErneutKontaktieren();
						return fErneutKontaktieren;
					}
					else
					{
						return fErneutKontaktieren;
					}
				}
			}
			
			private int fAktionenAusgeführt;
public int AktionenAusgeführt
			{
				get
				{
					if (!IsLoading)
					{
						GetAktionenAusgeführt();
						return fAktionenAusgeführt;
					}
					else
					{
						return fAktionenAusgeführt;
					}
				}
			}
			
#endregion
			
			private void GetAdressenKontaktiert()
			{
				
				try
				{
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (!(pro.Status == null))
							{
								if (!(pro.Status == null))
								{
									if (IsKnownStatus(pro.Status))
									{
										totalCount++;
									}
								}
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (!(pro.Status == null))
								{
									if (IsKnownStatus(pro.Status))
									{
										totalCount++;
									}
								}
							}
						}
					}
					
					fAdressenKontaktiert = totalCount;
					
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetAdressenKontaktiert";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetTermineVereinbart()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Termin vereinbart")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Termin vereinbart")
								{
									totalCount++;
								}
							}
						}
					}
					
					fTermineVereinbart = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetKeinInteresseVomKunden()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Kein Interesse vom Kunden" || pro.Status == "Kein Interesse vom Kunden oder kein Termin notwendig")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Kein Interesse vom Kunden" || pro.Status == "Kein Interesse vom Kunden oder kein Termin notwendig")
								{
									totalCount++;
								}
							}
						}
					}
					
					fKeinInteresseVomKunden = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetKeinInteresseUnsererseits()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Kein Interesse unsererseits")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Kein Interesse unsererseits")
								{
									totalCount++;
								}
							}
						}
					}
					
					fKeinInteresseUnsererseits = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetErneutKontaktieren()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Weitere Kontakte notwendig" || pro.Status == "erneut anrufen" || pro.Status == "nochmals kontaktieren")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Weitere Kontakte notwendig" || pro.Status == "erneut anrufen" || pro.Status == "nochmals kontaktieren")
								{
									totalCount++;
								}
							}
						}
					}
					
					fErneutKontaktieren = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetAktionenAusgeführt()
			{
				
				try
				{
					int totalCount = 0;
					
					var s = AuditedObjectWeakReference.GetAuditTrail(Session, Mitarbeietr);
					
					foreach (DevExpress.Persistent.BaseImpl.AuditDataItemPersistent trail in s)
					{
						if (trail.ModifiedOn.ToString("dd.MM.yyyy") == Datum.ToString("dd.MM.yyyy"))
						{
							totalCount++;
						}
					}
					
					fAktionenAusgeführt = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetAktionenAusgeführt";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetKeinKontakt()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Gewählt - kein Kontakt" || pro.Status == "Gewählt/angerufen-kein Kontakt")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Gewählt - kein Kontakt" || pro.Status == "Gewählt/angerufen-kein Kontakt")
								{
									totalCount++;
								}
							}
						}
					}
					
					fKeinKontakt = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private void GetFalscheNummer()
			{
				
				try
				{
					
					int totalCount = 0;
					ICollection objects = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					
					productClass = Session.GetClassInfo(typeof(MainModel.Anrufprotokoll));
					
					DevExpress.Data.Filtering.CriteriaOperator filter = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Datum] between ( (?) , (?) )  AND [Mitarbeiter] = (?)", Datum.AddDays(0), Datum.AddDays(1), Mitarbeietr.Oid);
					sortProps = new SortingCollection(null);
					sortProps.Add(new SortProperty("Datum", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);
					objects = Session.GetObjects(productClass, filter, sortProps, 0, patcher, true);
					
					string role = "";
					
					var user = Mitarbeietr as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					if (role == "Telefonist")
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Status == "Falsche Tel. Nummer")
							{
								totalCount++;
							}
						}
					}
					else
					{
						MainModel.Anrufprotokoll pro = default(MainModel.Anrufprotokoll);
						foreach (MainModel.Anrufprotokoll tempLoopVar_pro in objects)
						{
							pro = tempLoopVar_pro;
							if (pro.Mitarbeiter.Oid == (int)SecuritySystem.CurrentUserId)
							{
								if (pro.Status == "Falsche Tel. Nummer")
								{
									totalCount++;
								}
							}
						}
					}
					
					fFalscheNummer = totalCount;
				}
				catch (Exception ex)
				{
					Gurock.SmartInspect.SiAuto.Main.LogException(ex);
					
					MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
					exeptionError.Zeitstempel = DateTime.Now;
					exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
					exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
					exeptionError.Aktion = "GetTermineVereinbart";
					exeptionError.Fehlermeldung = ex.Message;
					exeptionError.Save();
					Session.Save(exeptionError);
				}
				
			}
			
			private bool IsKnownStatus(string p1)
			{
				
				//Dim tempList As New List(Of String)
				//tempList.AddRange({"Termin vereinbart", "nochmals kontaktieren", "Gewählt/angerufen-kein Kontakt", "Kein Interesse unsererseits", "Kein Interesse vom Kunden", "Falsche Tel. Nummer"})
				
				//Return tempList.Contains(p1)
				
				return true;
				
			}
			
		}
		
	}
}
