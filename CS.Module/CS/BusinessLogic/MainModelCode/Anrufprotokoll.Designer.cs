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

        public partial class Anrufprotokoll : XPObject
        {
            [Persistent("Datum")]
            DateTime fDatum;
            [PersistentAlias("fDatum")]
            public DateTime Datum
            {
                get
                {
                    return fDatum;
                }
            }
            string fStatus;
            public string Status
            {
                get
                {
                    return fStatus;
                }
                set
                {
                    SetPropertyValue<string>("Status",ref fStatus, value);
                }
            }
            Nullable<DateTime> fErneutKontaktierenAb;
            public Nullable<DateTime> ErbeutKontaktierenAb
            {
                get
                {
                    return fErneutKontaktierenAb;
                }
                set
                {
                    SetPropertyValue<Nullable<DateTime>>("ErbeutKontaktierenAb",ref fErneutKontaktierenAb, value);
                }
            }
        }

    }

}
