// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.Persistent.Base.Security;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Text;


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Intern
    {

        public class Kunde : Mitarbeiter
        {


            public Kunde(Session session)
                : base(session)
            {
                IsKunde = true;
            }

            protected override void OnSaving()
            {

                if (UserName == null || UserName == "")
                {
                    Random rnd = new Random();
                    string kundenNummer = "";
                    for (var i = 1; i <= 10; i++)
                    {
                        if (!(i == 4))
                        {
                            kundenNummer += rnd.Next(0, 9).ToString();
                        }
                        else
                        {
                            string validchars = "abcdefghijklmnopqrstuvwxyz";

                            StringBuilder sb = new StringBuilder();
                            Random rand = new Random();
                            for (int i2 = 1; i2 <= 2; i2++)
                            {
                                int idx = rand.Next(0, validchars.Length);
                                char randomChar = validchars[idx];
                                sb.Append(randomChar);
                            }
                            var randomString = sb.ToString();
                            kundenNummer += randomString.ToString();

                        }
                    }
                    IsKunde = true;
                    SetUserName(kundenNummer);
                    System.Guid g = new System.Guid("54A074E2-49F2-4DEC-93BE-5DCB8B177B30");
                    System.Guid h = new System.Guid("16FC2416-A640-4A48-8A31-B16EF3E62520");
                    MitarbeiterRollen.Remove(Session.GetObjectByKey<BusinessLogic.Intern.MitarbeiterRolle>(h));
                    MitarbeiterRollen.Add(Session.GetObjectByKey<BusinessLogic.Intern.MitarbeiterRolle>(g));
                    Distribution = null;
                    ChangePasswordOnFirstLogon = false;
                    var t = this;
                    base.OnSaving();
                }

            }

            public override void AfterConstruction()
            {
                base.AfterConstruction();
            }

            private BusinessLogic.Basis.Adresse fVerknüpfteAdresse;
            [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public BusinessLogic.Basis.Adresse VerknüpfteAdresse
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

        }

    }
}
