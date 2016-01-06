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
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp;


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        public class TerminBericht : XPObject
        {


            public TerminBericht(Session session)
                : base(session)
            {

            }

            private DateTime fLetzleÄnderung;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), ImmediatePostData(true)]
            public DateTime LetzteÄnderung
            {
                get
                {
                    return fLetzleÄnderung;
                }
                set
                {
                    fLetzleÄnderung = value;
                }
            }

            private Info fInfoStatus;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), System.ComponentModel.DisplayName("Bestellstatus")]
            public Info InfoStatus
            {
                get
                {
                    return fInfoStatus;
                }
                set
                {
                    fInfoStatus = value;
                }
            }

            public override void AfterConstruction()
            {
                base.AfterConstruction();
                Datum = DateTime.Now.Date;

                ICollection products = default(ICollection);
                DevExpress.Xpo.Metadata.XPClassInfo productClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
                DevExpress.Data.Filtering.CriteriaOperator criteria = default(DevExpress.Data.Filtering.CriteriaOperator);
                DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
                DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);

                productClass = Session.GetClassInfo(typeof(BusinessLogic.Basis.Produkt));

                sortProps = new SortingCollection(null);
                sortProps.Add(new SortProperty("Name", DevExpress.Xpo.DB.SortingDirection.Ascending));

                patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, Session.TypesManager);

                products = Session.GetObjects(productClass, criteria, sortProps, 0, patcher, true);

                BusinessLogic.Basis.Produkt product = default(BusinessLogic.Basis.Produkt);
                foreach (BusinessLogic.Basis.Produkt tempLoopVar_product in products)
                {
                    product = tempLoopVar_product;

                    MainModel.ProduktBericht pb = new MainModel.ProduktBericht(Session);
                    pb.Adresse = Adresse;
                    pb.TerminBericht = this;
                    pb.ProduktID = product.Oid;
                    pb.ProduktTyp = System.Convert.ToString(product.ProduktTyp.Name);
                    pb.ProduktTypID = System.Convert.ToInt32(product.ProduktTyp.Oid);
                    pb.Produkt = System.Convert.ToString(product.Name);
                    pb.Save();
                    this.ProduktBericht.Add(pb);

                }

                Gesamtumsatz = 0;
                UmsatzHauptProdukte = 0;
                UmsatzNebenProdukte = 0;

                base.Save();

            }
            protected override void OnLoaded()
            {
                base.OnLoaded();

                ProduktBericht.CollectionChanged += Collection_Changed;

                PerformUpdate();

                LetzteÄnderung = DateTime.Now;

                foreach (MainModel.ProduktBericht pb in ProduktBericht)
                {

                }

                ProduktBericht.ListChanged += ProduktBericht_ListChanged;

            }

            protected override void OnSaving()
            {

                foreach (MainModel.ProduktBericht pb in ProduktBericht)
                {
                    switch (pb.ProduktTypID)
                    {
                        case 1:
                            if (pb.Verkauft == true)
                            {
                                VerkauteHProdukte.Add(Session.GetObjectByKey<BusinessLogic.Basis.Produkt>(pb.ProduktID));
                                InfoStatus = Session.GetObjectByKey<BusinessLogic.Basis.Info>(2);
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            if (pb.Verkauft == true)
                            {
                                VerkauteNProdukte.Add(Session.GetObjectByKey<BusinessLogic.Basis.Produkt>(pb.ProduktID));
                            }
                            break;
                    }
                }

                if (!((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked)
                {
                    ((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked = true;
                    string temp_criteriaParametersList = KundenBeschreibung;
                    var isNotiz = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList));
                    KundenBeschreibung = temp_criteriaParametersList;

                    if (isNotiz == null)
                    {
                        try
                        {
                            BusinessLogic.Basis.Notiz notiz = new BusinessLogic.Basis.Notiz(Session);
                            notiz.Adresse = Adresse;
                            notiz.NotizFeld = KundenBeschreibung;
                            notiz.Termin = Termin;
                            notiz.TerminBericht = this;
                            notiz.Save();
                        }
                        catch (Exception ex)
                        {

                            Gurock.SmartInspect.SiAuto.Main.LogException(ex);

                        }
                    }
                }

                ((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked = true;

                try
                {
                    if (!(Termin == null))
                    {
                        Termin.Gesprächsergebnis = ResultatStatus;
                        Termin.Save();
                    }
                    if (!(Adresse == null))
                    {
                        if (NochmalsKontaktieren.HasValue || !NochmalsKontaktieren.HasValue)
                        {
                            Adresse.KontaktierenAb = NochmalsKontaktieren;
                            Adresse.Save();
                        }
                    }
                    if (!(VerkauteNProdukte == null))
                    {
                        if (VerkauteNProdukte.Count > 0)
                        {

                            foreach (BusinessLogic.Basis.Produkt pro in VerkauteNProdukte)
                            {

                                if (Adresse.GekaufteProdukteBeta.Count > 0)
                                {

                                    bool hasProduct = false;

                                    foreach (BusinessLogic.Basis.GekauftesProdukt itm in Adresse.GekaufteProdukteBeta)
                                    {
                                        if (itm.Produkt.Name == pro.Name)
                                        {
                                            hasProduct = true;
                                        }
                                    }

                                    if (!hasProduct)
                                    {
                                        BusinessLogic.Basis.GekauftesProdukt gekauftesTempProdukt = new BusinessLogic.Basis.GekauftesProdukt(Session);
                                        gekauftesTempProdukt.Produkt = pro;
                                        gekauftesTempProdukt.Adresse = Adresse;
                                        gekauftesTempProdukt.VerkauftVon = Termin.Mitarbeiter;
                                        Adresse.GekaufteProdukteBeta.Add(gekauftesTempProdukt);
                                    }

                                }
                                else
                                {
                                    BusinessLogic.Basis.GekauftesProdukt gekauftesTempProdukt = new BusinessLogic.Basis.GekauftesProdukt(Session);
                                    gekauftesTempProdukt.Produkt = pro;
                                    gekauftesTempProdukt.Adresse = Adresse;
                                    gekauftesTempProdukt.VerkauftVon = Termin.Mitarbeiter;
                                    Adresse.GekaufteProdukteBeta.Add(gekauftesTempProdukt);
                                }

                            }
                            Adresse.Save();
                        }
                    }
                    if (!(VerkauteHProdukte == null))
                    {
                        if (VerkauteHProdukte.Count > 0)
                        {

                            foreach (BusinessLogic.Basis.Produkt pro in VerkauteHProdukte)
                            {

                                if (Adresse.GekaufteProdukteBeta.Count > 0)
                                {

                                    bool hasProduct = false;

                                    foreach (BusinessLogic.Basis.GekauftesProdukt itm in Adresse.GekaufteProdukteBeta)
                                    {
                                        if (itm.Produkt.Name == pro.Name)
                                        {
                                            hasProduct = true;
                                        }
                                    }

                                    if (!hasProduct)
                                    {
                                        BusinessLogic.Basis.GekauftesProdukt gekauftesTempProdukt = new BusinessLogic.Basis.GekauftesProdukt(Session);
                                        gekauftesTempProdukt.Produkt = pro;
                                        gekauftesTempProdukt.Adresse = Adresse;
                                        gekauftesTempProdukt.VerkauftVon = Termin.Mitarbeiter;
                                        Adresse.GekaufteProdukteBeta.Add(gekauftesTempProdukt);
                                    }

                                }
                                else
                                {
                                    BusinessLogic.Basis.GekauftesProdukt gekauftesTempProdukt = new BusinessLogic.Basis.GekauftesProdukt(Session);
                                    gekauftesTempProdukt.Produkt = pro;
                                    gekauftesTempProdukt.Adresse = Adresse;
                                    gekauftesTempProdukt.VerkauftVon = Termin.Mitarbeiter;
                                    Adresse.GekaufteProdukteBeta.Add(gekauftesTempProdukt);
                                }

                            }
                            Adresse.Save();
                        }
                    }
                    base.OnSaving();
                }
                catch (Exception ex)
                {
                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                }

            }

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


            private Termin fTermin;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
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

            private Adresse fAdresse;
            [Association("Adresse-TerminBericht"), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public Adresse Adresse
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

            private int fKundenZufriedenheit;
            [EditorAlias("AdressenManagement.Module.Web.Editors.CustomIntegerEditor")]
            public int KundenZufriedenheit
            {
                get
                {
                    return fKundenZufriedenheit;
                }
                set
                {
                    fKundenZufriedenheit = value;
                }
            }

            private Status fResultatStatus;
            [System.ComponentModel.DisplayName("Resultat / Status")]
            public Status ResultatStatus
            {
                get
                {
                    return fResultatStatus;
                }
                set
                {
                    fResultatStatus = value;
                }
            }

            private TerminAusgang fTerminAusgang;
            public TerminAusgang TerminAusgang
            {
                get
                {
                    return fTerminAusgang;
                }
                set
                {
                    fTerminAusgang = value;
                }
            }

            private double fVerbrachteZeit;
            [System.ComponentModel.DisplayName("Verbrachte Zeit beim Kunden")]
            public double VerbrachteZeit
            {
                get
                {
                    return fVerbrachteZeit;
                }
                set
                {
                    fVerbrachteZeit = value;
                }
            }

            private DateTime? fNochmalsKontaktieren;
            [System.ComponentModel.DisplayName("Nochmals tel. kontaktieren ab")]
            public DateTime? NochmalsKontaktieren
            {
                get
                {
                    return fNochmalsKontaktieren;
                }
                set
                {
                    fNochmalsKontaktieren = value;
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

            private string fNotiz;
            [Size(SizeAttribute.Unlimited)]
            public string Notiz
            {
                get
                {
                    return fNotiz;
                }
                set
                {
                    fNotiz = value;
                }
            }

            [Association("TerminBericht-VerkauteHProdukte", typeof(BusinessLogic.Basis.Produkt))]
            public XPCollection<BusinessLogic.Basis.Produkt> VerkauteHProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Produkt>("VerkauteHProdukte");
                }
            }

            [Association("TerminBericht-VerkauteNebenProdukte", typeof(BusinessLogic.Basis.Produkt))]
            public XPCollection<BusinessLogic.Basis.Produkt> VerkauteNProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Produkt>("VerkauteNProdukte");
                }
            }

            [Association("TerminBericht-VerschenkteArtikel", typeof(BusinessLogic.Basis.Produkt))]
            public XPCollection<BusinessLogic.Basis.Produkt> VerschenkteArtikel
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Produkt>("VerschenkteArtikel");
                }
            }

            [Association("TerminBericht-ExterneProdukte", typeof(BusinessLogic.Basis.Produkt))]
            public XPCollection<BusinessLogic.Basis.Produkt> ExterneProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.Produkt>("ExterneProdukte");
                }
            }

            [Association("TerminBericht-ProduktBericht", typeof(MainModel.ProduktBericht))]
            public XPCollection<MainModel.ProduktBericht> ProduktBericht
            {
                get
                {
                    return GetCollection<MainModel.ProduktBericht>("ProduktBericht");
                }
            }

            private decimal fUmsatzHauptProdukte;
            public decimal UmsatzHauptProdukte
            {
                get
                {
                    return fUmsatzHauptProdukte;
                }
                set
                {
                    fUmsatzHauptProdukte = value;
                    Gesamtumsatz = UmsatzHauptProdukte + UmsatzNebenProdukte;
                }
            }

            private decimal fUmsatzNebenProdukte;
            public decimal UmsatzNebenProdukte
            {
                get
                {
                    return fUmsatzNebenProdukte;
                }
                set
                {
                    fUmsatzNebenProdukte = value;
                    Gesamtumsatz = UmsatzHauptProdukte + UmsatzNebenProdukte;
                }
            }

            private decimal fGesamtumsatz;
            public decimal Gesamtumsatz
            {
                get
                {
                    return fGesamtumsatz;
                }
                set
                {
                    fGesamtumsatz = value;
                }
            }

            private bool fFinanzierungBank;
            [System.ComponentModel.DisplayName("Finanzierung-Bank")]
            public bool FinanzierungBank
            {
                get
                {
                    return fFinanzierungBank;
                }
                set
                {
                    fFinanzierungBank = value;
                }
            }

            private int? fAnzahlRatenFB;
            public int? AnzahlRatenFB
            {
                get
                {
                    return fAnzahlRatenFB;
                }
                set
                {
                    fAnzahlRatenFB = value;
                }
            }

            private bool fFinanzierungBuB;
            [System.ComponentModel.DisplayName("Finanzierung-B&B")]
            public bool FinanzierungBuB
            {
                get
                {
                    return fFinanzierungBuB;
                }
                set
                {
                    fFinanzierungBuB = value;
                }
            }

            private int? fAnzahlRatenBB;
            public int? AnzahlRatenBB
            {
                get
                {
                    return fAnzahlRatenBB;
                }
                set
                {
                    fAnzahlRatenBB = value;
                }
            }

            private bool fFinanzierungH;
            [System.ComponentModel.DisplayName("Händler-Finanzierung")]
            public bool FinanzierungH
            {
                get
                {
                    return fFinanzierungH;
                }
                set
                {
                    fFinanzierungH = value;
                }
            }

            private int? fAnzahlRatenH;
            public int? AnzahlRatenH
            {
                get
                {
                    return fAnzahlRatenH;
                }
                set
                {
                    fAnzahlRatenH = value;
                }
            }

            private bool fFinanzierungBar;
            [System.ComponentModel.DisplayName("Bar")]
            public bool FinanzierungBar
            {
                get
                {
                    return fFinanzierungBar;
                }
                set
                {
                    fFinanzierungBar = value;
                }
            }

            private double? fAnzahlung;
            [System.ComponentModel.DisplayName("Anzahlung kassiert")]
            public double? Anzahlung
            {
                get
                {
                    return fAnzahlung;
                }
                set
                {
                    fAnzahlung = value;
                }
            }

            private string fKundenBeschreibung;
            [Size(SizeAttribute.Unlimited)]
            public string KundenBeschreibung
            {
                get
                {
                    return fKundenBeschreibung;
                }
                set
                {
                    fKundenBeschreibung = value;
                }
            }

            private void HprodukteChanged(object sender, XPCollectionChangedEventArgs e)
            {


                if (!IsLoading)
                {
                    LetzteÄnderung = DateTime.Now;
                    PerformUpdate();
                }

                //If e.CollectionChangedType = XPCollectionChangedType.AfterRemove Then
                //    If Not Adresse Is Nothing Then
                //        Try
                //            Adresse.GekaufteProdukte.Remove(e.ChangedObject)
                //            Adresse.Save()
                //          Catch ex As Exception
                //Gurock.SmartInspect.SiAuto.Main.LogException(Ex)



                //            Dim exeptionError As New MainModel.FehlerProtokoll(Session)
                //            exeptionError.Zeitstempel = Now
                //            exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName
                //            exeptionError.GewaehltesObjekt = Me.ClassInfo.FullName
                //            exeptionError.Aktion = ""
                //            exeptionError.Fehlermeldung = ex.Message
                //        End Try
                //    End If
                //End If
            }

            public void PerformUpdate()
            {

                UmsatzHauptProdukte = 0;
                UmsatzNebenProdukte = 0;
                Gesamtumsatz = 0;
                LetzteÄnderung = DateTime.Now;

                try
                {
                    foreach (MainModel.ProduktBericht pb in ProduktBericht)
                    {

                        switch (pb.ProduktTypID)
                        {
                            case 1:
                                if (pb.Verkauft == true)
                                {
                                    UmsatzHauptProdukte += pb.ProduktPreis;
                                }
                                break;
                            case 2:
                                break;
                            case 3:
                                if (pb.Verkauft == true)
                                {
                                    UmsatzNebenProdukte += pb.ProduktPreis;
                                }
                                break;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                }

            }

            private void Collection_Changed(object sender, XPCollectionChangedEventArgs e)
            {

                LetzteÄnderung = DateTime.Now;

                if (!(Adresse == null))
                {
                    Adresse.LetzteAenderung = DateTime.Now;
                }

                //If e.CollectionChangedType = XPCollectionChangedType.AfterAdd OrElse e.CollectionChangedType = XPCollectionChangedType.AfterRemove Then
                //    If Not IsLoading Then
                //        SetPropertyValue("LetzteÄnderung", Now)
                //        MyBase.SetPropertyValue("LetzteÄnderung", Now)
                //        MyBase.Save()
                //    End If
                //End If

            }

            private void TerminBericht_Changed(object sender, ObjectChangeEventArgs e)
            {

                if (!IsLoading)
                {
                    LetzteÄnderung = DateTime.Now;
                    PerformUpdate();
                }

            }

            private void ProduktBericht_ListChanged(object sender, ListChangedEventArgs e)
            {

                if (e.ListChangedType == ListChangedType.ItemChanged)
                {
                    if (!IsLoading)
                    {
                        SetPropertyValue("LetzteÄnderung", DateTime.Now);
                        base.SetPropertyValue("LetzteÄnderung", DateTime.Now);
                        base.Save();
                    }
                }

            }

        }

    }
}
