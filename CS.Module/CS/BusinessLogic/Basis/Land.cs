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


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        [DefaultProperty("Name"), ImageName("BO_Country_v92")]
        public class Land : XPObject
        {


            public Land(Session session)
                : base(session)
            {
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
            }

            private string fName;
            public string Name
            {
                get
                {
                    return fName;
                }
                set
                {
                    SetPropertyValue("Name", ref fName, value);
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

            private byte[] fBild;
            [ImageEditor]
            public byte[] Bild
            {
                get
                {
                    return fBild;
                }
                set
                {
                    SetPropertyValue("Bild", ref fBild, value);
                }
            }

        }

    }
}
