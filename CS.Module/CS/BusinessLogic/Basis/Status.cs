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


namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        [DefaultProperty("Name")]
        public class Status : XPObject
        {


            public Status(Session session)
                : base(session)
            {
                if (!string.IsNullOrEmpty(PersistentTerminFarbe))
                {
                    TerminFarbe = System.Drawing.Color.FromArgb(Convert.ToInt32(PersistentTerminFarbe));
                }
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
            }

            private string fName;
            [Size(SizeAttribute.Unlimited)]
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

            private System.Drawing.Color fTerminFarbe;
            [Persistent]
            public System.Drawing.Color TerminFarbe
            {
                get
                {
                    return fTerminFarbe;
                }
                set
                {
                    SetPropertyValue("TerminFarbe", ref fTerminFarbe, value);
                }
            }

            private string fPersistentTerminFarbe;
            [Browsable(false)]
            public string PersistentTerminFarbe
            {
                get
                {
                    return fPersistentTerminFarbe;
                }
                set
                {
                    fPersistentTerminFarbe = value;
                    if (!(value == null))
                    {
                        TerminFarbe = System.Drawing.Color.FromArgb(Convert.ToInt32(value));
                    }
                }
            }

            private void Status_Changed(object sender, ObjectChangeEventArgs e)
            {
                try
                {
                    PersistentTerminFarbe = System.Convert.ToString(TerminFarbe.ToArgb());
                }
                catch (Exception ex)
                {
                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);



                    MainModel.FehlerProtokoll exeptionError = new MainModel.FehlerProtokoll(Session);
                    exeptionError.Zeitstempel = DateTime.Now;
                    exeptionError.AngemeldeterBenutzer = DevExpress.ExpressApp.SecuritySystem.CurrentUserName;
                    exeptionError.GewaehltesObjekt = this.ClassInfo.FullName;
                    exeptionError.Aktion = "Status_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed";
                    exeptionError.Fehlermeldung = ex.Message;
                    exeptionError.Save();
                }
            }
        }

    }
}
