#define Standard
// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Persistent.Base.General;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.ComponentModel;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp;
using System.Windows.Threading;


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        [DefaultProperty("AnzeigeName"), ImageName("BO_Address")]
        public class Adresse : XPObject, ISupportNotifications
        {



            public void SetPlz(string Plz)
            {
                fPostleitzahl = Convert.ToInt32(Plz);
            }

            protected override void OnSaving()
            {

                LetzteAenderung = DateTime.Now;

                if (KontaktierenAb.HasValue)
                {
                    DateTime dueData = KontaktierenAb.Value;
                    RemindIn = TimeSpan.FromHours(24);
                    AlarmTime = dueData.Subtract(RemindIn.Value);
                }
                else
                {
                    AlarmTime = null;
                }

                if (AlarmTime == null)
                {
                    RemindIn = null;
                    IsPostponed = false;
                }

                if (GekaufteProdukteBeta.Count > 0)
                {

                    try
                    {
                        int i = 0;

                        foreach (BusinessLogic.Basis.GekauftesProdukt prod in GekaufteProdukteBeta)
                        {

                            if (prod.ProduktTyp.Oid == 1)
                            {
                                Info = Session.GetObjectByKey<BusinessLogic.Basis.Info>(2);
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                    }
                }

                if (!(Besitzer == null))
                {

                    if (Besitzer.Oid == 43)
                    {

                        if (Information.IsNumeric(SecuritySystem.CurrentUserId))
                        {

                            if (!(Status == null))
                            {
                                if (!(Status.Oid == 29) && !(Status.Oid == 23))
                                {
                                    Besitzer = Session.GetObjectByKey<BusinessLogic.Intern.Mitarbeiter>(SecuritySystem.CurrentUserId);
                                }
                            }

                            int @int = 1;

                            foreach (BusinessLogic.Basis.Empfehlung adr in ListeDerEmpfehlungsgeberBeta)
                            {
                                switch (@int)
                                {
                                    case 1:
                                        EmpfOid = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 2:
                                        EmpfOid2 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 3:
                                        EmpfOid3 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 4:
                                        EmpfOid4 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 5:
                                        EmpfOid5 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 6:
                                        EmpfOid6 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 7:
                                        EmpfOid7 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 8:
                                        EmpfOid8 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 9:
                                        EmpfOid9 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                    case 10:
                                        EmpfOid10 = System.Convert.ToInt32(adr.Aoid);
                                        break;
                                }
                                @int++;
                            }

                            if (!(SecuritySystem.CurrentUser == null))
                            {

                                if (!((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked)
                                {
                                    ((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked = true;

                                    if (!string.IsNullOrEmpty(Beschreibung))
                                    {
                                        string temp_criteriaParametersList = Beschreibung;
                                        var isNotiz = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList));
                                        Beschreibung = temp_criteriaParametersList;

                                        if (isNotiz == null)
                                        {
                                            if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                            {
                                                GlobalBase.LastInsert = DateTime.Now;
                                                try
                                                {
                                                    BusinessLogic.Basis.Notiz notiz = new BusinessLogic.Basis.Notiz(Session);
                                                    notiz.Adresse = this;
                                                    notiz.NotizFeld = Beschreibung;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz.Termin = null;
                                                    notiz.TerminBericht = null;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz.Save();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                                }
                                            }
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(Beschreibung2))
                                    {
                                        string temp_criteriaParametersList2 = Beschreibung2;
                                        var isNotiz2 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)",  temp_criteriaParametersList2));
                                        Beschreibung2 = temp_criteriaParametersList2;

                                        if (isNotiz2 == null)
                                        {
                                            if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                            {
                                                GlobalBase.LastInsert = DateTime.Now;
                                                try
                                                {
                                                    BusinessLogic.Basis.Notiz notiz2 = new BusinessLogic.Basis.Notiz(Session);
                                                    notiz2.Adresse = this;
                                                    notiz2.NotizFeld = Beschreibung2;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz2.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz2.Termin = null;
                                                    notiz2.TerminBericht = null;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz2.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz2.Save();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                                }
                                            }
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(Beschreibung3))
                                    {
                                        string temp_criteriaParametersList3 = Beschreibung3;
                                        var isNotiz3 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList3));
                                        Beschreibung3 = temp_criteriaParametersList3;

                                        if (isNotiz3 == null)
                                        {
                                            if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                            {
                                                GlobalBase.LastInsert = DateTime.Now;
                                                try
                                                {
                                                    BusinessLogic.Basis.Notiz notiz3 = new BusinessLogic.Basis.Notiz(Session);
                                                    notiz3.Adresse = this;
                                                    notiz3.NotizFeld = Beschreibung3;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz3.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz3.Termin = null;
                                                    notiz3.TerminBericht = null;
                                                    if (!(Gesprächspartner == null))
                                                    {
                                                        notiz3.GesprochenMit = Gesprächspartner.Name;
                                                    }
                                                    notiz3.Save();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                                }
                                            }
                                        }
                                    }

                                }

                                if (GekaufteProdukteBeta.Count > 0)
                                {
                                    foreach (BusinessLogic.Basis.GekauftesProdukt pro in GekaufteProdukteBeta)
                                    {
                                        if (!(pro.ProduktTyp == null))
                                        {
                                            if (pro.ProduktTyp.Oid != 2)
                                            {
                                                Info = Session.GetObjectByKey<Info>(2);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Info = Session.GetObjectByKey<Info>(1);
                                }
                                try
                                {

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

                                try
                                {
                                    base.OnSaving();
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

                            }


                        }

                    }
                    else
                    {

                        int @int = 1;

                        foreach (BusinessLogic.Basis.Empfehlung adr in ListeDerEmpfehlungsgeberBeta)
                        {
                            switch (@int)
                            {
                                case 1:
                                    EmpfOid = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 2:
                                    EmpfOid2 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 3:
                                    EmpfOid3 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 4:
                                    EmpfOid4 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 5:
                                    EmpfOid5 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 6:
                                    EmpfOid6 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 7:
                                    EmpfOid7 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 8:
                                    EmpfOid8 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 9:
                                    EmpfOid9 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                                case 10:
                                    EmpfOid10 = System.Convert.ToInt32(adr.Aoid);
                                    break;
                            }
                            @int++;
                        }

                        if (!(SecuritySystem.CurrentUser == null))
                        {

                            if (!((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked)
                            {
                                ((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked = true;

                                if (!string.IsNullOrEmpty(Beschreibung))
                                {
                                    string temp_criteriaParametersList4 = Beschreibung;
                                    var isNotiz = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)",  temp_criteriaParametersList4));
                                    Beschreibung = temp_criteriaParametersList4;

                                    if (isNotiz == null)
                                    {
                                        if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                        {
                                            GlobalBase.LastInsert = DateTime.Now;
                                            try
                                            {
                                                BusinessLogic.Basis.Notiz notiz = new BusinessLogic.Basis.Notiz(Session);
                                                notiz.Adresse = this;
                                                notiz.NotizFeld = Beschreibung;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz.Termin = null;
                                                notiz.TerminBericht = null;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz.Save();
                                            }
                                            catch (Exception ex)
                                            {
                                                Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                            }
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(Beschreibung2))
                                {
                                    string temp_criteriaParametersList5 = Beschreibung2;
                                    var isNotiz2 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList5));
                                    Beschreibung2 = temp_criteriaParametersList5;

                                    if (isNotiz2 == null)
                                    {
                                        if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                        {
                                            GlobalBase.LastInsert = DateTime.Now;
                                            try
                                            {
                                                BusinessLogic.Basis.Notiz notiz2 = new BusinessLogic.Basis.Notiz(Session);
                                                notiz2.Adresse = this;
                                                notiz2.NotizFeld = Beschreibung2;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz2.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz2.Termin = null;
                                                notiz2.TerminBericht = null;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz2.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz2.Save();
                                            }
                                            catch (Exception ex)
                                            {
                                                Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                            }
                                        }
                                    }
                                }

                                if (!string.IsNullOrEmpty(Beschreibung3))
                                {
                                    string temp_criteriaParametersList6 = Beschreibung3;
                                    var isNotiz3 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)",  temp_criteriaParametersList6));
                                    Beschreibung3 = temp_criteriaParametersList6;

                                    if (isNotiz3 == null)
                                    {

                                        if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                        {
                                            GlobalBase.LastInsert = DateTime.Now;
                                            try
                                            {
                                                BusinessLogic.Basis.Notiz notiz3 = new BusinessLogic.Basis.Notiz(Session);
                                                notiz3.Adresse = this;
                                                notiz3.NotizFeld = Beschreibung3;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz3.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz3.Termin = null;
                                                notiz3.TerminBericht = null;
                                                if (!(Gesprächspartner == null))
                                                {
                                                    notiz3.GesprochenMit = Gesprächspartner.Name;
                                                }
                                                notiz3.Save();
                                            }
                                            catch (Exception ex)
                                            {
                                                Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                            }
                                        }
                                    }
                                }

                            }


                            if (GekaufteProdukteBeta.Count > 0)
                            {
                                foreach (BusinessLogic.Basis.GekauftesProdukt pro in GekaufteProdukteBeta)
                                {
                                    if (!(pro.ProduktTyp == null))
                                    {
                                        if (pro.ProduktTyp.Oid != 2)
                                        {
                                            Info = Session.GetObjectByKey<Info>(2);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Info = Session.GetObjectByKey<Info>(1);
                            }
                            try
                            {

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

                            try
                            {
                                base.OnSaving();
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

                        }

                    }

                }
                else
                {

                    int @int = 1;

                    foreach (BusinessLogic.Basis.Empfehlung adr in ListeDerEmpfehlungsgeberBeta)
                    {
                        switch (@int)
                        {
                            case 1:
                                EmpfOid = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 2:
                                EmpfOid2 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 3:
                                EmpfOid3 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 4:
                                EmpfOid4 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 5:
                                EmpfOid5 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 6:
                                EmpfOid6 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 7:
                                EmpfOid7 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 8:
                                EmpfOid8 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 9:
                                EmpfOid9 = System.Convert.ToInt32(adr.Aoid);
                                break;
                            case 10:
                                EmpfOid10 = System.Convert.ToInt32(adr.Aoid);
                                break;
                        }
                        @int++;
                    }

                    if (!(SecuritySystem.CurrentUser == null))
                    {

                        if (!((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked)
                        {
                            ((BusinessLogic.Intern.Mitarbeiter)SecuritySystem.CurrentUser).HasWorked = true;

                            if (!string.IsNullOrEmpty(Beschreibung))
                            {
                                string temp_criteriaParametersList7 = Beschreibung;
                                var isNotiz = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList7));
                                Beschreibung = temp_criteriaParametersList7;

                                if (isNotiz == null)
                                {

                                    if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                    {
                                        GlobalBase.LastInsert = DateTime.Now;
                                        try
                                        {
                                            BusinessLogic.Basis.Notiz notiz = new BusinessLogic.Basis.Notiz(Session);
                                            notiz.Adresse = this;
                                            notiz.NotizFeld = Beschreibung;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz.Termin = null;
                                            notiz.TerminBericht = null;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz.Save();
                                        }
                                        catch (Exception ex)
                                        {
                                            Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                        }
                                    }

                                }
                            }

                            if (!string.IsNullOrEmpty(Beschreibung2))
                            {
                                string temp_criteriaParametersList8 = Beschreibung2;
                                var isNotiz2 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)",  temp_criteriaParametersList8));
                                Beschreibung2 = temp_criteriaParametersList8;

                                if (isNotiz2 == null)
                                {

                                    if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                    {
                                        GlobalBase.LastInsert = DateTime.Now;
                                        try
                                        {
                                            BusinessLogic.Basis.Notiz notiz2 = new BusinessLogic.Basis.Notiz(Session);
                                            notiz2.Adresse = this;
                                            notiz2.NotizFeld = Beschreibung2;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz2.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz2.Termin = null;
                                            notiz2.TerminBericht = null;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz2.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz2.Save();
                                        }
                                        catch (Exception ex)
                                        {
                                            Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                        }
                                    }

                                }
                            }

                            if (!string.IsNullOrEmpty(Beschreibung3))
                            {
                                string temp_criteriaParametersList9 = Beschreibung3;
                                var isNotiz3 = Session.FindObject<BusinessLogic.Basis.Notiz>(CriteriaOperator.Parse("NotizFeld = (?)", temp_criteriaParametersList9));
                                Beschreibung3 = temp_criteriaParametersList9;

                                if (isNotiz3 == null)
                                {

                                    if (GlobalBase.LastInsert.AddSeconds(1) < DateTime.Now)
                                    {
                                        GlobalBase.LastInsert = DateTime.Now;
                                        try
                                        {
                                            BusinessLogic.Basis.Notiz notiz3 = new BusinessLogic.Basis.Notiz(Session);
                                            notiz3.Adresse = this;
                                            notiz3.NotizFeld = Beschreibung3;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz3.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz3.Termin = null;
                                            notiz3.TerminBericht = null;
                                            if (!(Gesprächspartner == null))
                                            {
                                                notiz3.GesprochenMit = Gesprächspartner.Name;
                                            }
                                            notiz3.Save();
                                        }
                                        catch (Exception ex)
                                        {
                                            Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                                        }
                                    }

                                }
                            }

                        }

                        if (GekaufteProdukteBeta.Count > 0)
                        {
                            foreach (BusinessLogic.Basis.GekauftesProdukt pro in GekaufteProdukteBeta)
                            {
                                if (!(pro.ProduktTyp == null))
                                {
                                    if (pro.ProduktTyp.Oid != 2)
                                    {
                                        Info = Session.GetObjectByKey<Info>(2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Info = Session.GetObjectByKey<Info>(1);
                        }
                        try
                        {

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

                        try
                        {
                            base.OnSaving();
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

                    }


                }

            }

            public void CreateCustomerAccount()
            {

                if (VerknüpfterKunde == null)
                {
                    BusinessLogic.Intern.Kunde kunde = new BusinessLogic.Intern.Kunde(Session);
                    kunde.VerknüpfteAdresse = this;
                    VerknüpfterKunde = kunde;
                    kunde.Save();
                }

            }

            private BusinessLogic.Intern.Kunde fVerknüpfterKunde;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public BusinessLogic.Intern.Kunde VerknüpfterKunde
            {
                get
                {
                    return fVerknüpfterKunde;
                }
                set
                {
                    fVerknüpfterKunde = value;

                    if (!(value == null))
                    {
                        KundenNummer = System.Convert.ToString(value.UserName);
                    }

                }
            }

            private DateTime fLetzleÄnderung;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public DateTime LetzteAenderung
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

            private bool fDiePersonistalleinigerEntscheidungsträger;
            public bool DiePersonistalleinigerEntscheidungsträger
            {
                get
                {
                    return fDiePersonistalleinigerEntscheidungsträger;
                }
                set
                {
                    fDiePersonistalleinigerEntscheidungsträger = value;
                }
            }

            private Info fInfo;
            public Info Info
            {
                get
                {
                    return fInfo;
                }
                set
                {
                    fInfo = value;
                }
            }

            private Branche fBranche;
            public Branche Branche
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

            private AdressQualität fAdressQualität;
            public AdressQualität AdressQualität
            {
                get
                {
                    return fAdressQualität;
                }
                set
                {
                    fAdressQualität = value;
                }
            }

            private string fVornameMitarbeiter;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string VornameMitarbeiter
            {
                get
                {
                    return fVornameMitarbeiter;
                }
                set
                {
                    fVornameMitarbeiter = value;
                }
            }

            private string fNachnameMitarbeiter;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string NachnameMitarbeiter
            {
                get
                {
                    return fNachnameMitarbeiter;
                }
                set
                {
                    fNachnameMitarbeiter = value;
                }
            }

            private string fNameMitarbeiter;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string NameMitarbeiter
            {
                get
                {
                    return fNameMitarbeiter;
                }
                set
                {
                    fNameMitarbeiter = value;
                }
            }

            private DateTime? fLetzterKontaktAm;
            public DateTime? LetzterKontaktAm
            {
                get
                {
                    return fLetzterKontaktAm;
                }
                set
                {
                    fLetzterKontaktAm = value;
                }
            }

            private string fVorwahl;
            public string Vorwahl
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
            public string Vorwahl2
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
            public string Vorwahl3
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

            public Adresse(Session session)
                : base(session)
            {
            }

            public override void AfterConstruction()
            {

                base.AfterConstruction();

                LetzteAenderung = DateTime.Now;

                IsClone = false;
                Status = Session.GetObjectByKey<Basis.Status>(28);
                Priorität = Basis.Priorität.Normal;
                ErfasstAm = DateTime.Now;

                if (!(Besitzer == null))
                {
                    VornameMitarbeiter = System.Convert.ToString(Besitzer.Vorname);
                    NachnameMitarbeiter = System.Convert.ToString(Besitzer.Nachname);
                    NameMitarbeiter = VornameMitarbeiter + " " + NachnameMitarbeiter;
                }
                else
                {
                    if (Information.IsNumeric(DevExpress.ExpressApp.SecuritySystem.CurrentUserId))
                    {
                        Besitzer = Session.GetObjectByKey<Intern.Mitarbeiter>(DevExpress.ExpressApp.SecuritySystem.CurrentUserId);
                        VornameMitarbeiter = System.Convert.ToString(Besitzer.Vorname);
                        NachnameMitarbeiter = System.Convert.ToString(Besitzer.Nachname);
                        NameMitarbeiter = VornameMitarbeiter + " " + NachnameMitarbeiter;
                    }
                }

                Anrede = Session.GetObjectByKey<BusinessLogic.Formal.Anrede>(2);
                Anrede2 = Session.GetObjectByKey<BusinessLogic.Formal.Anrede>(1);
                Info = Session.GetObjectByKey<BusinessLogic.Basis.Info>(1);
                AdressQualität = Session.GetObjectByKey<BusinessLogic.Basis.AdressQualität>(5);
                ErstKontaktierenAb = DateTime.Now.AddMinutes(5);

            }

            private DateTime fGeburtsDatum;
            public DateTime GeburtsDatum
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

            private DateTime fGeburtsDatum2;
            public DateTime GeburtsDatum2
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

            private DateTime fGeburtsDatum3;
            public DateTime GeburtsDatum3
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

            protected override void OnLoaded()
            {

                if (OriginalStatus == null)
                {
                    if (!(Status == null))
                    {
                        OriginalStatus = Status;
                    }
                }

                if (!(AdressArt == null))
                {
                    AdressTyp = AdressArt.StandardGesprächsleitfaden;
                    if (!(AdressTyp == null))
                    {
                        fGesprächsLeitfaden = AdressTyp.GesprächsLeitfaden;
                    }
                }
                if (!(Land == null))
                {
                    Vorwahl = Land.Vorwahl;
                    Vorwahl2 = Land.Vorwahl;
                    Vorwahl3 = Land.Vorwahl;
                }

                if (!(VerknüpfterKunde == null))
                {
                    KundenNummer = System.Convert.ToString(VerknüpfterKunde.UserName);
                }

                LetzteAenderung = DateTime.Now;

                base.OnLoaded();

            }

            private DateTime fErfasstAm;
            public DateTime ErfasstAm
            {
                get
                {
                    return fErfasstAm;
                }
                set
                {
                    fErfasstAm = value;
                }
            }

            private Formal.Anrede fAnrede;
            [Appearance("AnredeOneDisabled", Enabled = false)]
            public Formal.Anrede Anrede
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

            private string fFirma;
            public string Firma
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

            private string fAnsprechPartner;
            public string AnsprechPartner
            {
                get
                {
                    return fAnsprechPartner;
                }
                set
                {
                    SetPropertyValue("AnsprechPartner", ref fAnsprechPartner, value);
                }
            }

            private string fVorname;
#if Standard
            public string Vorname
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
#else
[Indexed(Unique = false)]public string Vorname
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
#endif


            private string fNachname;
#if Standard
            public string Nachname
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
#else
[Indexed(Unique = false)]public string Nachname
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
#endif


            private string fBeschreibung;
            [Size(SizeAttribute.Unlimited)]
            public string Beschreibung
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
            public string Email
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
            public Berufsstatus Berufsstatus
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

            private Formal.Anrede f2Anrede;
            [Appearance("AnredeTwoDisabled", Enabled = false)]
            public Formal.Anrede Anrede2
            {
                get
                {
                    return f2Anrede;
                }
                set
                {
                    SetPropertyValue("Anrede2", ref f2Anrede, value);
                }
            }

            private MainModel.Titel fTitel;
            public MainModel.Titel Titel
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

            private string f2Firma;
            public string Firma2
            {
                get
                {
                    return f2Firma;
                }
                set
                {
                    SetPropertyValue("Firma2", ref f2Firma, value);
                }
            }

            private string f2AnsprechPartner;
            public string AnsprechPartner2
            {
                get
                {
                    return f2AnsprechPartner;
                }
                set
                {
                    SetPropertyValue("AnsprechPartner2", ref f2AnsprechPartner, value);
                }
            }

            private string f2Vorname;
#if Standard
            public string Vorname2
            {
                get
                {
                    return f2Vorname;
                }
                set
                {
                    SetPropertyValue("Vorname2", ref f2Vorname, value);
                }
            }
#else
[Indexed(Unique = false)]public string Vorname2
				{
				get
				{
					return f2Vorname;
				}
				set
				{
					SetPropertyValue("Vorname2", ref f2Vorname, value);
				}
			}
#endif

            private string f2Nachname;
#if Standard
            public string Nachname2
            {
                get
                {
                    return f2Nachname;
                }
                set
                {
                    SetPropertyValue("Nachname2", ref f2Nachname, value);
                }
            }
#else
[Indexed(Unique = false)]public string Nachname2
				{
				get
				{
					return f2Nachname;
				}
				set
				{
					SetPropertyValue("Nachname2", ref f2Nachname, value);
				}
			}
#endif


            private string f2Beschreibung;
            [Size(SizeAttribute.Unlimited)]
            public string Beschreibung2
            {
                get
                {
                    return f2Beschreibung;
                }
                set
                {
                    f2Beschreibung = value;
                }
            }

            private string f2Email;
            public string Email2
            {
                get
                {
                    return f2Email;
                }
                set
                {
                    SetPropertyValue("Email2", ref f2Email, value);
                }
            }

            private Berufsstatus f2Berufsstatus;
            public Berufsstatus Berufsstatus2
            {
                get
                {
                    return f2Berufsstatus;
                }
                set
                {
                    f2Berufsstatus = value;
                }
            }

            private Formal.Anrede f3Anrede;
            public Formal.Anrede Anrede3
            {
                get
                {
                    return f3Anrede;
                }
                set
                {
                    SetPropertyValue("Anrede3", ref f3Anrede, value);
                }
            }

            private MainModel.Titel f3Titel;
            public MainModel.Titel Titel3
            {
                get
                {
                    return f3Titel;
                }
                set
                {
                    f3Titel = value;
                }
            }

            private string f3Firma;
#if Standard
            public string Firma3
            {
                get
                {
                    return f3Firma;
                }
                set
                {
                    SetPropertyValue("Firma3", ref f3Firma, value);
                }
            }
#else
[Indexed(Unique = false)]public string Firma3
				{
				get
				{
					return f3Firma;
				}
				set
				{
					SetPropertyValue("Firma3", ref f3Firma, value);
				}
			}
#endif

            private MainModel.Titel f2Titel;
            public MainModel.Titel Titel2
            {
                get
                {
                    return f2Titel;
                }
                set
                {
                    f2Titel = value;
                }
            }

            private string f3AnsprechPartner;
            public string AnsprechPartner3
            {
                get
                {
                    return f3AnsprechPartner;
                }
                set
                {
                    SetPropertyValue("AnsprechPartner3", ref f3AnsprechPartner, value);
                }
            }

            private string f3Vorname;
#if Standard
            public string Vorname3
            {
                get
                {
                    return f3Vorname;
                }
                set
                {
                    SetPropertyValue("Vorname3", ref f3Vorname, value);
                }
            }
#else
[Indexed(Unique = false)]public string Vorname3
				{
				get
				{
					return f3Vorname;
				}
				set
				{
					SetPropertyValue("Vorname3", ref f3Vorname, value);
				}
			}
#endif


            private string f3Nachname;
#if Standard
            public string Nachname3
            {
                get
                {
                    return f3Nachname;
                }
                set
                {
                    SetPropertyValue("Nachname3", ref f3Nachname, value);
                }
            }
#else
[Indexed(Unique = false)]public string Nachname3
				{
				get
				{
					return f3Nachname;
				}
				set
				{
					SetPropertyValue("Nachname3", ref f3Nachname, value);
				}
			}
#endif


            private string f3Beschreibung;
            [Size(SizeAttribute.Unlimited)]
            public string Beschreibung3
            {
                get
                {
                    return f3Beschreibung;
                }
                set
                {
                    f3Beschreibung = value;
                }
            }

            private string f3Email;
            public string Email3
            {
                get
                {
                    return f3Email;
                }
                set
                {
                    SetPropertyValue("Email3", ref f3Email, value);
                }
            }

            private Berufsstatus f3Berufsstatus;
            public Berufsstatus Berufsstatus3
            {
                get
                {
                    return f3Berufsstatus;
                }
                set
                {
                    f3Berufsstatus = value;
                }
            }

            [VisibleInDetailView(false), VisibleInListView(false)]
            public string Did
            {
                get
                {
                    if (!(Besitzer == null) && !(Besitzer.Distribution == null))
                    {
                        return Besitzer.Distribution.Tag;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            public dynamic AnzeigeName
            {
                get
                {
                    return ((!string.IsNullOrEmpty(Firma3)) ? Firma3 : (Vorname + " " + Nachname + System.Convert.ToString((!string.IsNullOrEmpty(Nachname2) && !string.IsNullOrEmpty(Vorname2)) ? (((!string.IsNullOrEmpty(Nachname)) ? " / " : "") + Vorname2 + " " + Nachname2) : ""))) + System.Convert.ToString(Postleitzahl.HasValue ? " - Plz. " + System.Convert.ToString(Postleitzahl) : "") + " - " + System.Convert.ToString(Oid);
                }
            }

            private bool fGetClone = false;
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false)]
            public bool GetClone
            {
                get
                {
                    return fGetClone;
                }
            }

            private bool fIsClone;
            [Persistent, VisibleInDetailView(false), VisibleInListView(false), Browsable(true)]
            public bool IsClone
            {
                get
                {
                    return fIsClone;
                }
                set
                {
                    fIsClone = value;
                }
            }

            private bool fIsTempClone;
            [Persistent, VisibleInDetailView(false), VisibleInListView(false), Browsable(true)]
            public bool IsTempClone
            {
                get
                {
                    return fIsTempClone;
                }
                set
                {
                    fIsTempClone = value;
                }
            }

            protected override void OnSaved()
            {
                base.OnSaved();

                //If GetClone Then
                //    Dim s As New BusinessLogic.Spider.SpiderJobManager
                //    s.GetSpiderAddressDataWithPhoneButCheckFirst(TelefonNummer)
                //End If

            }

            private string fKundenNummer;
            [NonPersistent, VisibleInListView(false), ReadOnly(true)]
            public string KundenNummer
            {
                get
                {
                    return fKundenNummer;
                }
                set
                {
                    fKundenNummer = value;
                }
            }

            private Intern.Mitarbeiter fBesitzer;
            [Association("Mitarbeiter-Adresse")]
            public Intern.Mitarbeiter Besitzer
            {
                get
                {
                    return fBesitzer;
                }
                set
                {

                    if (!IsSaving)
                    {
                        if (!(value == null))
                        {
                            if (!(fBesitzer == null))
                            {
                                if (!(fBesitzer.Oid == value.Oid))
                                {
                                    if (!(value.Oid == 43))
                                    {
                                        if (((BusinessLogic.Intern.Mitarbeiter)fBesitzer).Oid == 43)
                                        {
                                            fGetClone = true;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    fBesitzer = value;
                    if (!(value == null))
                    {
                        NameMitarbeiter = value.Vorname + " " + value.Nachname;
                    }
                    if (!IsLoading)
                    {
                        if (string.IsNullOrEmpty(Vorwahl))
                        {
                            if (!(value == null))
                            {
                                if (!(value.Distribution == null))
                                {
                                    if (!(value.Distribution.Land == null))
                                    {
                                        Land = value.Distribution.Land;
                                    }
                                }
                                else
                                {
                                    if (value.Oid == 1)
                                    {
                                        Land = Session.GetObjectByKey<BusinessLogic.Basis.Land>(1);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private Basis.Priorität fPriorität;
            public Basis.Priorität Priorität
            {
                get
                {
                    return fPriorität;
                }
                set
                {
                    SetPropertyValue("Priorität", ref fPriorität, value);
                }
            }

            private Status fOriginalStatus;
            [VisibleInDetailView(false), VisibleInLookupListView(false), VisibleInListView(false)]
            public Status OriginalStatus
            {
                get
                {
                    return fOriginalStatus;
                }
                set
                {
                    fOriginalStatus = value;
                }
            }

            private Status fStatus;
            public Status Status
            {
                get
                {
                    return fStatus;
                }
                set
                {

                    if (!IsLoading)
                    {
                        if (!(value == null))
                        {
                            if (!(Status == null))
                            {
                                if (value.Oid != Status.Oid)
                                {
                                    OriginalStatus = Status;
                                }
                            }
                        }
                    }
                    fStatus = value;
                }
            }

            private AdressTyp fAdressTyp;
            public AdressTyp AdressTyp
            {
                get
                {
                    return fAdressTyp;
                }
                set
                {
                    fAdressTyp = value;

                    if (!(value == null))
                    {
                        fGesprächsLeitfaden = value.GesprächsLeitfaden;
                    }

                }
            }

            private AdressArt fAdressArt;
            public AdressArt AdressArt
            {
                get
                {
                    return fAdressArt;
                }
                set
                {
                    fAdressArt = value;

                    if (!IsLoading)
                    {
                        if (!(value == null))
                        {
                            if (!(value.StandardGesprächsleitfaden == null))
                            {
                                AdressTyp = Session.GetObjectByKey<AdressTyp>(value.StandardGesprächsleitfaden.Oid);
                            }
                        }
                    }

                }
            }

            private Adresse fEmpfehlungsgeber;
            [ImmediatePostData(true)]
            public Adresse Empfehlungsgeber
            {
                get
                {
                    return fEmpfehlungsgeber;
                }
                set
                {
                    fEmpfehlungsgeber = value;
                    if (!(value == null))
                    {
                        if (!IsLoading)
                        {
                            BusinessLogic.Basis.Empfehlung empfehlung = new BusinessLogic.Basis.Empfehlung(this.Session);
                            empfehlung.Aoid = value.Oid;
                            empfehlung.Name = value.AnzeigeName;
                            empfehlung.Strasse = value.Strasse;
                            empfehlung.Postleitzahl = value.Postleitzahl;
                            empfehlung.Ortschaft = value.Ortschaft;
                            empfehlung.Land = value.Land;
                            empfehlung.NameFirma = AnzeigeName;

                            if (!(value.VerknüpfterKunde == null))
                            {
                                empfehlung.BesitzerUid = value.VerknüpfterKunde.Oid;
                            }

                            ListeDerEmpfehlungsgeberBeta.Add(empfehlung);
                        }
                        EmpfOid = value.Oid;
                    }
                }
            }

            private string fTelefonNummer;

#if Standard
            public string TelefonNummer
            {
                get
                {
                    if (!string.IsNullOrEmpty(fTelefonNummer))
                    {
                        return fTelefonNummer.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
                        if (value.Length > 2)
                        {
                            if (!value.StartsWith("0"))
                            {
                                value = "0" + value;
                            }
                        }
                    }
                    fTelefonNummer = value;
                }
            }
#else
[Indexed(Unique = false)]public string TelefonNummer
				{
				get
				{
					if (!string.IsNullOrEmpty(fTelefonNummer))
					{
						return fTelefonNummer.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
					}
					else
					{
						return string.Empty;
					}
				}
				set
				{
					if (!string.IsNullOrEmpty(value))
					{
						value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
						if (value.Length > 2)
						{
							if (!value.StartsWith("0"))
							{
								value = "0" + value;
							}
						}
					}
					fTelefonNummer = value;
				}
			}
#endif

            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), System.ComponentModel.DisplayName("Telefonnummer")]
            public string TempTelefonNummer
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
                            return System.Convert.ToString(((fTelefonNummer.StartsWith("0")) ? (fTelefonNummer.Remove(0, 1)) : fTelefonNummer));
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            private string fTelefonNummer2;
#if Standard
            public string TelefonNummer2
            {
                get
                {
                    if (!string.IsNullOrEmpty(fTelefonNummer2))
                    {
                        return fTelefonNummer2.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
                        if (value.Length > 2)
                        {
                            if (!value.StartsWith("0"))
                            {
                                value = "0" + value;
                            }
                        }
                    }
                    fTelefonNummer2 = value;
                }
            }
#else
[Indexed(Unique = false)]public string TelefonNummer2
				{
				get
				{
					if (!string.IsNullOrEmpty(fTelefonNummer2))
					{
						return fTelefonNummer2.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
					}
					else
					{
						return string.Empty;
					}
				}
				set
				{
					if (!string.IsNullOrEmpty(value))
					{
						value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
						if (value.Length > 2)
						{
							if (!value.StartsWith("0"))
							{
								value = "0" + value;
							}
						}
					}
					fTelefonNummer2 = value;
				}
			}
#endif


            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), System.ComponentModel.DisplayName("Telefonnummer")]
            public string TempTelefonNummer2
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
                            return System.Convert.ToString(((fTelefonNummer2.StartsWith("0")) ? (fTelefonNummer2.Remove(0, 1)) : fTelefonNummer2));
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            private string fTelefonNummer3;
#if Standard
            public string TelefonNummer3
            {
                get
                {
                    if (!string.IsNullOrEmpty(fTelefonNummer3))
                    {
                        return fTelefonNummer3.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
                        if (value.Length > 2)
                        {
                            if (!value.StartsWith("0"))
                            {
                                value = "0" + value;
                            }
                        }
                    }
                    fTelefonNummer3 = value;
                }
            }
#else
[Indexed(Unique = false)]public string TelefonNummer3
				{
				get
				{
					if (!string.IsNullOrEmpty(fTelefonNummer3))
					{
						return fTelefonNummer3.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", "");
					}
					else
					{
						return string.Empty;
					}
				}
				set
				{
					if (!string.IsNullOrEmpty(value))
					{
						value = System.Convert.ToString(value.Replace(";", "").Replace(" ", "").Replace("  ", "").Replace("-", "").Replace("/", "").Replace("\\", "").Replace("   ", ""));
						if (value.Length > 2)
						{
							if (!value.StartsWith("0"))
							{
								value = "0" + value;
							}
						}
					}
					fTelefonNummer3 = value;
				}
			}
#endif


            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), System.ComponentModel.DisplayName("Telefonnummer")]
            public string TempTelefonNummer3
            {
                get
                {
                    if (!(fTelefonNummer3 == null) && !(string.IsNullOrEmpty(fTelefonNummer3)))
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
                            return System.Convert.ToString(((fTelefonNummer3.StartsWith("0")) ? (fTelefonNummer3.Remove(0, 1)) : fTelefonNummer3));
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            private string fGesprächsLeitfaden;
            [Size(SizeAttribute.Unlimited)]
            public string GesprächsLeitfaden
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

            private Gesprächspartner fGesprächspartner;
            [NonPersistent]
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

            private BusinessLogic.Basis.Status fGesprächsergebnis;
            [NonPersistent]
            public BusinessLogic.Basis.Status Gesprächsergebnis
            {
                get
                {
                    return fGesprächsergebnis;
                }
                set
                {
                    OnChanged("Gesprächsergebnis", Gesprächsergebnis, value);
                    fGesprächsergebnis = value;
                }
            }

            private string fGesprächsnotiz;
            [Size(SizeAttribute.Unlimited), Persistent]
            public string Gesprächsnotiz
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

            private int fEmpfOid;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid
            {
                get
                {
                    return fEmpfOid;
                }
                set
                {
                    fEmpfOid = value;
                }
            }

            private int fEmpfOid2;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid2
            {
                get
                {
                    return fEmpfOid2;
                }
                set
                {
                    fEmpfOid2 = value;
                }
            }

            private int fEmpfOid3;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid3
            {
                get
                {
                    return fEmpfOid3;
                }
                set
                {
                    fEmpfOid3 = value;
                }
            }

            private int fEmpfOid4;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid4
            {
                get
                {
                    return fEmpfOid4;
                }
                set
                {
                    fEmpfOid4 = value;
                }
            }

            private int fEmpfOid5;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid5
            {
                get
                {
                    return fEmpfOid5;
                }
                set
                {
                    fEmpfOid5 = value;
                }
            }

            private int fEmpfOid6;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid6
            {
                get
                {
                    return fEmpfOid6;
                }
                set
                {
                    fEmpfOid6 = value;
                }
            }

            private int fEmpfOid7;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid7
            {
                get
                {
                    return fEmpfOid7;
                }
                set
                {
                    fEmpfOid7 = value;
                }
            }

            private int fEmpfOid8;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid8
            {
                get
                {
                    return fEmpfOid8;
                }
                set
                {
                    fEmpfOid8 = value;
                }
            }

            private int fEmpfOid9;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid9
            {
                get
                {
                    return fEmpfOid9;
                }
                set
                {
                    fEmpfOid9 = value;
                }
            }

            private int fEmpfOid10;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public int EmpfOid10
            {
                get
                {
                    return fEmpfOid10;
                }
                set
                {
                    fEmpfOid10 = value;
                }
            }

            #region Produkte

            private string fProdukt;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt
            {
                get
                {
                    return fProdukt;
                }
                set
                {
                    fProdukt = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt
				{
				get
				{
					return fProdukt;
				}
				set
				{
					fProdukt = value;
				}
			}
#endif


            private string fProdukt2;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt2
            {
                get
                {
                    return fProdukt2;
                }
                set
                {
                    fProdukt2 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt2
				{
				get
				{
					return fProdukt2;
				}
				set
				{
					fProdukt2 = value;
				}
			}
#endif

            private string fProdukt3;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt3
            {
                get
                {
                    return fProdukt3;
                }
                set
                {
                    fProdukt3 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt3
				{
				get
				{
					return fProdukt3;
				}
				set
				{
					fProdukt3 = value;
				}
			}
#endif

            private string fProdukt4;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt4
            {
                get
                {
                    return fProdukt4;
                }
                set
                {
                    fProdukt4 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt4
				{
				get
				{
					return fProdukt4;
				}
				set
				{
					fProdukt4 = value;
				}
			}
#endif

            private string fProdukt5;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt5
            {
                get
                {
                    return fProdukt5;
                }
                set
                {
                    fProdukt5 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt5
				{
				get
				{
					return fProdukt5;
				}
				set
				{
					fProdukt5 = value;
				}
			}
#endif

            private string fProdukt6;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt6
            {
                get
                {
                    return fProdukt6;
                }
                set
                {
                    fProdukt6 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt6
				{
				get
				{
					return fProdukt6;
				}
				set
				{
					fProdukt6 = value;
				}
			}
#endif

            private string fProdukt7;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt7
            {
                get
                {
                    return fProdukt7;
                }
                set
                {
                    fProdukt7 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt7
				{
				get
				{
					return fProdukt7;
				}
				set
				{
					fProdukt7 = value;
				}
			}
#endif

            private string fProdukt8;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt8
            {
                get
                {
                    return fProdukt8;
                }
                set
                {
                    fProdukt8 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt8
				{
				get
				{
					return fProdukt8;
				}
				set
				{
					fProdukt8 = value;
				}
			}
#endif

            private string fProdukt9;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt9
            {
                get
                {
                    return fProdukt9;
                }
                set
                {
                    fProdukt9 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt9
				{
				get
				{
					return fProdukt9;
				}
				set
				{
					fProdukt9 = value;
				}
			}
#endif

            private string fProdukt10;
#if Standard
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string Produkt10
            {
                get
                {
                    return fProdukt10;
                }
                set
                {
                    fProdukt10 = value;
                }
            }
#else
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Indexed(Unique = false)]public string Produkt10
				{
				get
				{
					return fProdukt10;
				}
				set
				{
					fProdukt10 = value;
				}
			}
#endif

            #endregion

            private DateTime? fKontaktierenAb;
            [Persistent, VisibleInListView(true), VisibleInDetailView(false)]
            public DateTime? KontaktierenAb
            {
                get
                {
                    return fKontaktierenAb;
                }
                set
                {
                    fKontaktierenAb = value;
                }
            }

            private DateTime? fErstKontaktierenAb;
            public DateTime? ErstKontaktierenAb
            {
                get
                {
                    return fErstKontaktierenAb;
                }
                set
                {
                    fErstKontaktierenAb = value;
                }
            }

            private XPCollection<BusinessLogic.Basis.GekauftesProdukt> fGekaufteProdukteBeta;
            [Association("Adresse-GekauftesProdukt", typeof(BusinessLogic.Basis.GekauftesProdukt)), Aggregated]
            public XPCollection<BusinessLogic.Basis.GekauftesProdukt> GekaufteProdukteBeta
            {
                get
                {

                    if (fGekaufteProdukteBeta == null)
                    {
                        fGekaufteProdukteBeta = GetCollection<BusinessLogic.Basis.GekauftesProdukt>("GekaufteProdukteBeta");
                        return fGekaufteProdukteBeta;
                    }
                    else
                    {
                        return fGekaufteProdukteBeta;
                    }

                    //Return GetCollection(Of BusinessLogic.Basis.GekauftesProdukt)("GekaufteProdukteBeta")

                }
            }

            private XPCollection<BusinessLogic.Basis.Termin> fTermine;
            [Association("Adresse-Termine", typeof(BusinessLogic.Basis.Termin)), Aggregated]
            public XPCollection<BusinessLogic.Basis.Termin> Termine
            {
                get
                {

                    if (fTermine == null)
                    {
                        fTermine = GetCollection<BusinessLogic.Basis.Termin>("Termine");
                        return fTermine;
                    }
                    else
                    {
                        return fTermine;
                    }

                    //Return GetCollection(Of BusinessLogic.Basis.Termin)("Termine")

                }
            }

            private XPCollection<BusinessLogic.Basis.TerminBericht> fTerminBerichte;
            [Association("Adresse-TerminBericht", typeof(BusinessLogic.Basis.TerminBericht)), Aggregated]
            public XPCollection<BusinessLogic.Basis.TerminBericht> TerminBerichte
            {
                get
                {

                    if (fTerminBerichte == null)
                    {
                        fTerminBerichte = GetCollection<BusinessLogic.Basis.TerminBericht>("TerminBerichte");
                        return fTerminBerichte;
                    }
                    else
                    {
                        return fTerminBerichte;
                    }

                    //Return GetCollection(Of BusinessLogic.Basis.TerminBericht)("TerminBerichte")

                }
            }

            private XPCollection<BusinessLogic.Basis.Empfehlung> fListeDerEmpfehlungsgeberBeta;
            [Association("Adresse-Empfehlung", typeof(BusinessLogic.Basis.Empfehlung)), Aggregated]
            public XPCollection<BusinessLogic.Basis.Empfehlung> ListeDerEmpfehlungsgeberBeta
            {
                get
                {

                    if (fListeDerEmpfehlungsgeberBeta == null)
                    {
                        fListeDerEmpfehlungsgeberBeta = GetCollection<BusinessLogic.Basis.Empfehlung>("ListeDerEmpfehlungsgeberBeta");
                        return fListeDerEmpfehlungsgeberBeta;
                    }
                    else
                    {
                        return fListeDerEmpfehlungsgeberBeta;
                    }

                    //Return GetCollection(Of BusinessLogic.Basis.Empfehlung)("ListeDerEmpfehlungsgeberBeta")

                }
            }

            private XPCollection<MainModel.Anrufprotokoll> fAnrufprotololle;
            [Association("Adresse-Anrufprotololle", typeof(MainModel.Anrufprotokoll)), Aggregated]
            public XPCollection<MainModel.Anrufprotokoll> Anrufprotololle
            {
                get
                {

                    if (fAnrufprotololle == null)
                    {
                        fAnrufprotololle = GetCollection<MainModel.Anrufprotokoll>("Anrufprotololle");
                        return fAnrufprotololle;
                    }
                    else
                    {
                        return fAnrufprotololle;
                    }

                    //Return GetCollection(Of MainModel.Anrufprotokoll)("Anrufprotololle")

                }
            }

            private XPCollection<Historie> fAltesSystemProtokoll;
            [Association("Adresse-AltesSystemProtokoll", typeof(Historie)), Aggregated]
            public XPCollection<Historie> AltesSystemProtokoll
            {
                get
                {

                    if (fAltesSystemProtokoll == null)
                    {
                        fAltesSystemProtokoll = GetCollection<Historie>("AltesSystemProtokoll");
                        return fAltesSystemProtokoll;
                    }
                    else
                    {
                        return fAltesSystemProtokoll;
                    }

                    return GetCollection<Historie>("AltesSystemProtokoll");

                }
            }


            private XPCollection<Notiz> fNotizen;
            [Association("Adresse-Notizen", typeof(Notiz)), Aggregated]
            public XPCollection<Notiz> Notizen
            {
                get
                {

                    if (fNotizen == null)
                    {
                        fNotizen = GetCollection<Notiz>("Notizen");
                        return fNotizen;
                    }
                    else
                    {
                        return fNotizen;
                    }

                    //Return GetCollection(Of Notiz)("Notizen")
                }
            }

            private XPCollection<Datei> fDatein;
            [Association("Adresse-Datein", typeof(Datei)), Aggregated]
            public XPCollection<Datei> Datein
            {
                get
                {

                    if (fDatein == null)
                    {
                        fDatein = GetCollection<Datei>("Datein");
                        return fDatein;
                    }
                    else
                    {
                        return fDatein;
                    }

                    //Return GetCollection(Of Datei)("Datein")

                }
            }

            private XPCollection<AuditDataItemPersistent> _auditTrail;
            public XPCollection<AuditDataItemPersistent> Ereignissprotokoll
            {
                get
                {
                    if (_auditTrail == null)
                    {
                        _auditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                    }
                    return _auditTrail;
                }
            }

            private string fChanger;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), Browsable(false), ImmediatePostData(true)]
            public string Changer
            {
                get
                {
                    return fChanger;
                }
                set
                {
                    fChanger = value;
                }
            }

            private void Adresse_Changed(object sender, ObjectChangeEventArgs e)
            {

            }

            private void Collection_Changed(object sender, XPCollectionChangedEventArgs e)
            {
                if (e.CollectionChangedType == XPCollectionChangedType.AfterAdd || e.CollectionChangedType == XPCollectionChangedType.AfterRemove)
                {
                    if (!IsLoading)
                    {
                        SetPropertyValue("LetzteÄnderung", DateTime.Now);
                        base.SetPropertyValue("LetzteÄnderung", DateTime.Now);
                        base.Save();
                    }
                }

            }

            #region ISupportNotifications members
            private DateTime? _alarmTime;
            [Browsable(false)]
            public DateTime? AlarmTime
            {
                get
                {
                    return _alarmTime;
                }
                set
                {
                    _alarmTime = value;
                    if (value == null)
                    {
                        RemindIn = null;
                        IsPostponed = false;
                    }
                }
            }
            [Browsable(false)]
            public bool IsPostponed { get; set; }
            [Browsable(false)]
            public string NotificationMessage
            {
                get
                {
                    return System.Convert.ToString(AnzeigeName);
                }
            }
            public System.TimeSpan? RemindIn { get; set; }
            [Browsable(false)]
            public dynamic UniqueId
            {
                get
                {
                    return Oid;
                }
            }
            #endregion

        }

    }
}
