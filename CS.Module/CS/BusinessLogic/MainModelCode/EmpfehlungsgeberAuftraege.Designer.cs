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

        public partial class EmpfehlungsgeberAuftraege : XPObject
        {
            [Size(SizeAttribute.Unlimited)]
            [Persistent("Anleitung")]
            string fAnleitung;
            [PersistentAlias("fAnleitung")]
            public string Anleitung
            {
                get
                {
                    return fAnleitung;
                }
            }
            string fTelefonNummern;
            [Size(SizeAttribute.Unlimited)]
            public string TelefonNummern
            {
                get
                {
                    return fTelefonNummern;
                }
                set
                {
                    SetPropertyValue<string>("TelefonNummern", ref fTelefonNummern, value);
                }
            }
            string fAdressenID;
            [Size(SizeAttribute.Unlimited)]
            public string AdressenID
            {
                get
                {
                    return fAdressenID;
                }
                set
                {
                    SetPropertyValue<string>("AdressenID", ref fAdressenID, value);
                }
            }
            string fNichtGefundeneObjekte;
            [Size(SizeAttribute.Unlimited)]
            public string NichtGefundeneObjekte
            {
                get
                {
                    return fNichtGefundeneObjekte;
                }
                set
                {
                    SetPropertyValue<string>("NichtGefundeneObjekte", ref fNichtGefundeneObjekte, value);
                }
            }
            string fStatus;
            [Size(SizeAttribute.Unlimited)]
            public string Status
            {
                get
                {
                    return fStatus;
                }
                set
                {
                    SetPropertyValue<string>("Status", ref fStatus, value);
                }
            }
            string fAutomatischErstellteAdressen;
            [Size(SizeAttribute.Unlimited)]
            public string AutomatischErstellteAdressen
            {
                get
                {
                    return fAutomatischErstellteAdressen;
                }
                set
                {
                    SetPropertyValue<string>("AutomatischErstellteAdressen", ref fAutomatischErstellteAdressen, value);
                }
            }
            string fSuchFilter;
            [Size(SizeAttribute.Unlimited)]
            public string SuchFilter
            {
                get
                {
                    return fSuchFilter;
                }
                set
                {
                    SetPropertyValue<string>("SuchFilter", ref fSuchFilter, value);
                }
            }
        }

    }

}