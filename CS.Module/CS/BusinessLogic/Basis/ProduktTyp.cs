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

        [DefaultProperty("Name"), ImageName("BO_Sale_Item")]
        public class ProduktTyp : XPObject
        {


            public ProduktTyp(Session session)
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

        }

    }
}
