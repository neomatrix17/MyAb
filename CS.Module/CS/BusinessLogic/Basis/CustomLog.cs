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

namespace AdressenManagement.Module
{
    namespace BusinessLogic.Basis
    {

        public class CustomLog : XPObject
        {

            public CustomLog(Session session)
                : base(session)
            {
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
                ZusaetzlicheInformationen = "Keine weiteren Informationen vorhanden.";
            }

            string fBenutzername;
            public string Benutzername
            {
                get
                {
                    return fBenutzername;
                }
                set
                {
                    SetPropertyValue<string>("Benutzername", ref fBenutzername, value);
                }
            }
            string fZeitstempel;
            public string Zeitstempel
            {
                get
                {
                    return fZeitstempel;
                }
                set
                {
                    SetPropertyValue<string>("Zeitstempel", ref fZeitstempel, value);
                }
            }
            string fSystemName;
            public string SystemName
            {
                get
                {
                    return fSystemName;
                }
                set
                {
                    SetPropertyValue<string>("SystemName", ref fSystemName, value);
                }
            }
            string fAktion;
            public string Aktion
            {
                get
                {
                    return fAktion;
                }
                set
                {
                    SetPropertyValue<string>("Aktion", ref fAktion, value);
                }
            }
            string fZusätzlicheInformationen;
            [Size(SizeAttribute.Unlimited)]
            public string ZusaetzlicheInformationen
            {
                get
                {
                    return fZusätzlicheInformationen;
                }
                set
                {
                    SetPropertyValue<string>("ZusaetzlicheInformationen", ref fZusätzlicheInformationen, value);
                }
            }
            string fFehlermeldung;
            [Size(SizeAttribute.Unlimited)]
            public string Fehlermeldung
            {
                get
                {
                    return fFehlermeldung;
                }
                set
                {
                    SetPropertyValue<string>("Fehlermeldung", ref fFehlermeldung, value);
                }
            }
            short fBenutzerID;
            public short BenutzerID
            {
                get
                {
                    return fBenutzerID;
                }
                set
                {
                    SetPropertyValue<short>("BenutzerID", ref fBenutzerID, value);
                }
            }
            string fIpAdresse;
            public string IpAdresse
            {
                get
                {
                    return fIpAdresse;
                }
                set
                {
                    SetPropertyValue<string>("IpAdresse", ref fIpAdresse, value);
                }
            }

            private AktionsTyp fAktionsProtokoll;
            public AktionsTyp AktionsProtokoll
            {
                get
                {
                    return fAktionsProtokoll;
                }
                set
                {
                    fAktionsProtokoll = value;

                    switch (value)
                    {
                        case AktionsTyp.BenutzerAnmeldung:
                            Aktion = "Benutzer Anmeldung am System.";
                            break;
                        case AktionsTyp.BenutzerAbmeldung:
                            Aktion = "Benutzer Abmeldung vom System.";
                            break;
                        case AktionsTyp.AndereAktion:
                            Aktion = "Benutzer Aktion wurde ausgeführt.";
                            break;
                        case AktionsTyp.FehlgeschlageneBenutzerAnmeldung:
                            Aktion = "Ein Benutzer hat versucht sich am System anzumelden.";
                            break;
                        case AktionsTyp.BenutzerNavigation:
                            Aktion = "Benutzer Navigierte zu Ansicht.";
                            break;
                    }

                }
            }

            public enum AktionsTyp
            {
                AndereAktion = 0,
                BenutzerAnmeldung = 1,
                BenutzerAbmeldung = 2,
                FehlgeschlageneBenutzerAnmeldung = 3,
                BenutzerNavigation = 4
            }

        }

    }
}
