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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdressenManagement.Module
{
    namespace MainModel
    {

        public partial class SpiderAuftrag : XPObject
        {
            [Persistent("ErstelltAm")]
            DateTime fErstelltAm;
            [PersistentAlias("fErstelltAm")]
            public DateTime ErstelltAm
            {
                get
                {
                    return fErstelltAm;
                }
            }
            [Persistent("ErstelltVon")]
            string fErstelltVon;
            [PersistentAlias("fErstelltVon")]
            public string ErstelltVon
            {
                get
                {
                    return fErstelltVon;
                }
            }
            SpiderAuftragsArt fAuftragsArt;
            public SpiderAuftragsArt AuftragsArt
            {
                get
                {
                    return fAuftragsArt;
                }
                set
                {
                    SetPropertyValue<SpiderAuftragsArt>("AuftragsArt", ref fAuftragsArt, value);
                }
            }
            SpiderType fQuelle;
            public SpiderType Quelle
            {
                get
                {
                    return fQuelle;
                }
                set
                {
                    SetPropertyValue<SpiderType>("Quelle",ref fQuelle, value);
                }
            }
            bool fDoppelteAdressenUeberspringen;
            public bool DoppelteAdressenUeberspringen
            {
                get
                {
                    return fDoppelteAdressenUeberspringen;
                }
                set
                {
                    SetPropertyValue<bool>("DoppelteAdressenUeberspringen",ref fDoppelteAdressenUeberspringen, value);
                }
            }
            bool fAllePrivatenAdressenSuchen;
            public bool AllePrivatenAdressenSuchen
            {
                get
                {
                    return fAllePrivatenAdressenSuchen;
                }
                set
                {
                    SetPropertyValue<bool>("AllePrivatenAdressenSuchen", ref fAllePrivatenAdressenSuchen, value);
                }
            }
            HeroldBranche fHeroldBranche;
            public HeroldBranche HeroldBranche
            {
                get
                {
                    return fHeroldBranche;
                }
                set
                {
                    SetPropertyValue<HeroldBranche>("HeroldBranche", ref fHeroldBranche, value);
                }
            }
            SpiderBranche fBranche;
            [DevExpress.Xpo.DisplayName("Original Branche")]
            public SpiderBranche Branche
            {
                get
                {
                    return fBranche;
                }
                set
                {
                    SetPropertyValue<SpiderBranche>("Branche", ref fBranche, value);
                }
            }
            Nullable<int> fPostleitzahlVon;
            public Nullable<int> PostleitzahlVon
            {
                get
                {
                    return fPostleitzahlVon;
                }
                set
                {
                    SetPropertyValue<Nullable<int>>("PostleitzahlVon", ref fPostleitzahlVon, value);
                }
            }
            Nullable<int> fPostleitzahlBis;
            public Nullable<int> PostleitzahlBis
            {
                get
                {
                    return fPostleitzahlBis;
                }
                set
                {
                    SetPropertyValue<Nullable<int>>("PostleitzahlBis", ref fPostleitzahlBis, value);
                }
            }
            SpiderStatus fStatus;
            public SpiderStatus Status
            {
                get
                {
                    return fStatus;
                }
                set
                {
                    SetPropertyValue<SpiderStatus>("Status", ref fStatus, value);
                }
            }
            int fResultate;
            public int Resultate
            {
                get
                {
                    return fResultate;
                }
                set
                {
                    SetPropertyValue<int>("Resultate", ref fResultate, value);
                }
            }
            string fPrivateAdressenMitDiesenWoerternIgnorieren;
            [Size(SizeAttribute.Unlimited)]
            public string PrivateAdressenMitDiesenWoerternIgnorieren
            {
                get
                {
                    return fPrivateAdressenMitDiesenWoerternIgnorieren;
                }
                set
                {
                    SetPropertyValue<string>("PrivateAdressenMitDiesenWuerternIgnorieren",ref fPrivateAdressenMitDiesenWoerternIgnorieren, value);
                }
            }
            string fSystemMeldung;
            [Size(SizeAttribute.Unlimited)]
            public string SystemMeldung
            {
                get
                {
                    return fSystemMeldung;
                }
                set
                {
                    SetPropertyValue<string>("SystemMeldung", ref fSystemMeldung, value);
                }
            }
        }

    }

}