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


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        public class Empfehlung : XPObject
        {


            public Empfehlung(Session session)
                : base(session)
            {
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
                EmpfohlenAm = DateTime.Now.Date;
                CurrentStatus = EnumStatus.Neu;
            }

            private int fBesitzerUid;
#if Standard
            public int BesitzerUid
            {
                get
                {
                    return fBesitzerUid;
                }
                set
                {
                    fBesitzerUid = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int BesitzerUid
				{
				get
				{
					return fBesitzerUid;
				}
				set
				{
					fBesitzerUid = value;
				}
			}
#endif

            private Termin fTermin;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public Termin Termin
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
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public Termin Termin
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
#endif

            private int fUid;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public int Uid
            {
                get
                {
                    return fUid;
                }
                set
                {
                    fUid = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int Uid
				{
				get
				{
					return fUid;
				}
				set
				{
					fUid = value;
				}
			}
#endif


            private int fUid2;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public int Uid2
            {
                get
                {
                    return fUid2;
                }
                set
                {
                    fUid2 = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int Uid2
				{
				get
				{
					return fUid2;
				}
				set
				{
					fUid2 = value;
				}
			}
#endif

            private int fUid3;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public int Uid3
            {
                get
                {
                    return fUid3;
                }
                set
                {
                    fUid3 = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int Uid3
				{
				get
				{
					return fUid3;
				}
				set
				{
					fUid3 = value;
				}
			}
#endif


            private int fUid4;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public int Uid4
            {
                get
                {
                    return fUid4;
                }
                set
                {
                    fUid4 = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int Uid4
				{
				get
				{
					return fUid4;
				}
				set
				{
					fUid4 = value;
				}
			}
#endif


            private int fUid5;
#if Standard
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public int Uid5
            {
                get
                {
                    return fUid5;
                }
                set
                {
                    fUid5 = value;
                }
            }
#else
[NonPersistent, VisibleInDetailView(false), VisibleInListView(false), Indexed(Unique = false)]public int Uid5
				{
				get
				{
					return fUid5;
				}
				set
				{
					fUid5 = value;
				}
			}
#endif

            public enum EnumStatus
            {

                Neu,

                Bestellt,

                NochNichtBestellt
            }

            private string fRealStatu;
            [System.ComponentModel.DisplayName("Adress Status"), VisibleInDetailView(false)]
            public string RealStatus
            {
                get
                {
                    return fRealStatu;
                }
                set
                {
                    fRealStatu = value;
                }
            }

            protected override void OnLoaded()
            {

                try
                {
                    if (!(Adresse == null))
                    {
                        System.Int32 temp_criteriaParametersList = Adresse.Oid;
                        var tb = Session.FindObject<BusinessLogic.Basis.TerminBericht>(CriteriaOperator.Parse("[Adresse] = (?)",  temp_criteriaParametersList));
                        Adresse.Oid = temp_criteriaParametersList;

                        if (!(tb == null))
                        {

                            if (!(tb.ResultatStatus == null))
                            {
                                RealStatus = System.Convert.ToString(tb.ResultatStatus.Name);
                            }

                            TerminVereinbartDurch = Adresse.Empfehlungsgeber;

                            if (!(tb.VerkauteHProdukte == null))
                            {
                                if (tb.VerkauteHProdukte.Count > 0)
                                {
                                    CurrentStatus = EnumStatus.Bestellt;
                                }
                                else
                                {
                                    if (!(tb.ProduktBericht.Count == 0))
                                    {
                                        CurrentStatus = EnumStatus.NochNichtBestellt;
                                    }
                                }
                            }

                        }

                        tb = null;

                        try
                        {
                            if (!(RealStatus == null))
                            {
                                if (CurrentStatus == EnumStatus.Neu)
                                {
                                    if (RealStatus.Contains("Kein"))
                                    {
                                        CurrentStatus = EnumStatus.NochNichtBestellt;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                        }

                        if (!(Adresse.Empfehlungsgeber == null))
                        {

                            TerminVereinbartDurch = Adresse.Empfehlungsgeber;

                            if (!(Adresse.Status == null))
                            {
                                RealStatus = Adresse.Status.Name;
                            }

                            try
                            {
                                if (!(RealStatus == null))
                                {
                                    if (CurrentStatus == EnumStatus.Neu)
                                    {
                                        if (RealStatus.Contains("Kein"))
                                        {
                                            CurrentStatus = EnumStatus.NochNichtBestellt;
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                            }

                            if (!(Adresse.Empfehlungsgeber.VerknüpfterKunde == null))
                            {
                                Uid = System.Convert.ToInt32(Adresse.Empfehlungsgeber.VerknüpfterKunde.Oid);
                                NameFirma = System.Convert.ToString(Adresse.AnzeigeName);
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                }

                base.OnLoaded();

            }

            #region Empfehlung Daten

            private string fNameFirma;
            public string NameFirma
            {
                get
                {
                    return fNameFirma;
                }
                set
                {
                    fNameFirma = value;
                }
            }

            #endregion

            private EnumStatus fCurrentStatus;
            [System.ComponentModel.DisplayName("Bestell Status")]
            public EnumStatus CurrentStatus
            {
                get
                {
                    return fCurrentStatus;
                }
                set
                {
                    fCurrentStatus = value;
                }
            }

            private string fName;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            [System.ComponentModel.DisplayName("EmpfohlenVon")]
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

            private int fAoid;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int Aoid
            {
                get
                {
                    return fAoid;
                }
                set
                {
                    fAoid = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public int Aoid
				{
				get
				{
					return fAoid;
				}
				set
				{
					fAoid = value;
				}
			}
#endif

            private DateTime fEmpfohlenAm;
            public DateTime EmpfohlenAm
            {
                get
                {
                    return fEmpfohlenAm;
                }
                set
                {
                    fEmpfohlenAm = value;
                }
            }

            private BusinessLogic.Basis.Adresse fTerminVereinbartDurch;
            public BusinessLogic.Basis.Adresse TerminVereinbartDurch
            {
                get
                {
                    return fTerminVereinbartDurch;
                }
                set
                {
                    fTerminVereinbartDurch = value;
                }
            }

            private BusinessLogic.Intern.Mitarbeiter fTerminAbgehaltenVon;
            public BusinessLogic.Intern.Mitarbeiter TerminAbgehaltenVon
            {
                get
                {
                    return fTerminAbgehaltenVon;
                }
                set
                {
                    fTerminAbgehaltenVon = value;
                }
            }

            public void SetAddressData(BusinessLogic.Basis.Adresse pAddress)
            {

                if (!(pAddress == null))
                {
                    Aoid = System.Convert.ToInt32(pAddress.Oid);
                    Name = System.Convert.ToString(pAddress.AnzeigeName);
                    Strasse = System.Convert.ToString(pAddress.Strasse);
                    Postleitzahl = pAddress.Postleitzahl;
                    Ortschaft = System.Convert.ToString(pAddress.Ortschaft);
                    Land = pAddress.Land;
                }

            }

            private BusinessLogic.Basis.Adresse fAdresse;
            [Association("Adresse-Empfehlung"), ImmediatePostData(true), VisibleInDetailView(false), VisibleInListView(false)]
            public BusinessLogic.Basis.Adresse Adresse
            {
                get
                {
                    return fAdresse;
                }
                set
                {
                    fAdresse = value;
                    if (!(value == null))
                    {
                        NameFirma = System.Convert.ToString(value.AnzeigeName);
                    }
                }
            }

            private string fStrasse;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
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
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
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
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
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
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public Land Land
            {
                get
                {
                    return fLand;
                }
                set
                {
                    fLand = value;
                }
            }

        }

    }
}
