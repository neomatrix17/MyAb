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
        public class Produkt : XPObject
        {


            public Produkt(Session session)
                : base(session)
            {
                OldName = Name;
            }
            public override void AfterConstruction()
            {
                base.AfterConstruction();
            }

            protected override void OnSaving()
            {

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(GlobalBase.CurrentConn);

                try
                {
                    conn.Open();

                    string sql = "UPDATE [dbo].[Adresse] SET Produkt = @Produkt Where Produkt = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt2 = @Produkt Where Produkt2 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt3 = @Produkt Where Produkt3 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt4 = @Produkt Where Produkt4 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt5 = @Produkt Where Produkt5 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt6 = @Produkt Where Produkt6 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt7 = @Produkt Where Produkt7 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt8 = @Produkt Where Produkt8 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt9 = @Produkt Where Produkt9 = @OldProdukt; UPDATE [dbo].[Adresse] SET Produkt10 = @Produkt Where Produkt10 = @OldProdukt; ";

                    System.Data.SqlClient.SqlCommand sqlcommand = new System.Data.SqlClient.SqlCommand(sql, conn);

                    sqlcommand.Parameters.AddWithValue("@Produkt", Name);
                    sqlcommand.Parameters.AddWithValue("@OldProdukt", OldName);

                    sqlcommand.ExecuteNonQuery();

                    sqlcommand.Dispose();

                }
                catch (Exception ex)
                {
                    Gurock.SmartInspect.SiAuto.Main.LogException(ex);
                }

                base.OnSaving();

            }

            private string fOldName;
            [NonPersistent, VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public string OldName
            {
                get
                {
                    return fOldName;
                }
                set
                {
                    SetPropertyValue("Name", ref fOldName, value);
                }
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

            private ProduktTyp fProduktTyp;
            public ProduktTyp ProduktTyp
            {
                get
                {
                    return fProduktTyp;
                }
                set
                {
                    fProduktTyp = value;
                }
            }

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
                    SetPropertyValue("Beschreibung", ref fBeschreibung,value);
                }
            }

            private byte[] fProduktBild;
            [ImageEditor]
            public byte[] ProduktBild
            {
                get
                {
                    return fProduktBild;
                }
                set
                {
                    fProduktBild = value;
                }
            }

            [Association("TerminBericht-VerkauteNebenProdukte", typeof(BusinessLogic.Basis.TerminBericht))]
            [Browsable(false), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public XPCollection<BusinessLogic.Basis.TerminBericht> VerkauteNebenProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.TerminBericht>("VerkauteNebenProdukte");
                }
            }

            [Association("TerminBericht-VerkauteHProdukte", typeof(BusinessLogic.Basis.TerminBericht))]
            [Browsable(false), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public XPCollection<BusinessLogic.Basis.TerminBericht> VerkauteHauptProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.TerminBericht>("VerkauteHauptProdukte");
                }
            }

            [Association("TerminBericht-VerschenkteArtikel", typeof(BusinessLogic.Basis.TerminBericht))]
            [Browsable(false), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public XPCollection<BusinessLogic.Basis.TerminBericht> VerschenkteNArtikel
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.TerminBericht>("VerschenkteNArtikel");
                }
            }

            [Association("TerminBericht-ExterneProdukte", typeof(BusinessLogic.Basis.TerminBericht))]
            [Browsable(false), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
            public XPCollection<BusinessLogic.Basis.TerminBericht> ExterneNProdukte
            {
                get
                {
                    return GetCollection<BusinessLogic.Basis.TerminBericht>("ExterneNProdukte");
                }
            }

        }

    }
}
