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
		
		[DefaultProperty("ProduktName")]public class GekauftesProdukt : XPObject
			{
			
			
			public GekauftesProdukt(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				GekauftAm = DateTime.Now.Date;
				Anzahl = 1;
			}
			
			protected override void OnSaving()
			{
				
				base.OnSaving();
				
			}
			
			private void UpdateProdukt()
			{
				
				for (var i = 1; i <= 10; i++)
				{
					
					switch (i)
					{
						case 1:
							if (Adresse.Produkt == "")
							{
								Adresse.Produkt = Produkt.Name;
								return;
							}
							break;
						case 2:
							if (Adresse.Produkt2 == "")
							{
								Adresse.Produkt3 = Produkt.Name;
								return;
							}
							break;
						case 3:
							if (Adresse.Produkt3 == "")
							{
								Adresse.Produkt3 = Produkt.Name;
								return;
							}
							break;
						case 4:
							if (Adresse.Produkt4 == "")
							{
								Adresse.Produkt4 = Produkt.Name;
								return;
							}
							break;
						case 5:
							if (Adresse.Produkt5 == "")
							{
								Adresse.Produkt5 = Produkt.Name;
								return;
							}
							break;
						case 6:
							if (Adresse.Produkt6 == "")
							{
								Adresse.Produkt6 = Produkt.Name;
								return;
							}
							break;
						case 7:
							if (Adresse.Produkt7 == "")
							{
								Adresse.Produkt7 = Produkt.Name;
								return;
							}
							break;
						case 8:
							if (Adresse.Produkt8 == "")
							{
								Adresse.Produkt8 = Produkt.Name;
								return;
							}
							break;
						case 9:
							if (Adresse.Produkt9 == "")
							{
								Adresse.Produkt9 = Produkt.Name;
								return;
							}
							break;
						case 10:
							if (Adresse.Produkt10 == "")
							{
								Adresse.Produkt10 = Produkt.Name;
								return;
							}
							break;
					}
					
				}
				
			}
			
			private string fProduktName;
public string ProduktName
			{
				get
				{
					if (!(Produkt == null))
					{
						return Produkt.Name;
					}
					else
					{
						return fProduktName;
					}
				}
				set
				{
					fProduktName = value;
				}
			}
			
			private DateTime fGekauftAm;
[ReadOnly(true)]public DateTime GekauftAm
				{
				get
				{
					return fGekauftAm;
				}
				set
				{
					fGekauftAm = value;
				}
			}
			
			private int fAnzahl;
public int Anzahl
			{
				get
				{
					return fAnzahl;
				}
				set
				{
					fAnzahl = value;
				}
			}
			
			private BusinessLogic.Basis.Produkt fProdukt;
[ImmediatePostData(true)]public BusinessLogic.Basis.Produkt Produkt
				{
				get
				{
					return fProdukt;
				}
				set
				{
					fProdukt = value;
					if (!IsLoading)
					{
						if (!(value == null))
						{
							ProduktName = System.Convert.ToString(value.Name);
							
							if (!(Adresse == null))
							{
								if (!(Produkt == null))
								{
									UpdateProdukt();
								}
							}
							
							
						}
					}
				}
			}
			
[NonPersistent]public BusinessLogic.Basis.ProduktTyp ProduktTyp
				{
				get
				{
					if (!IsLoading)
					{
						if (!(Produkt == null))
						{
							return Produkt.ProduktTyp;
						}
						else
						{
							return null;
						}
					}
					else
					{
						return null;
					}
				}
			}
			
[ImageEditor, NonPersistent]public byte[] ProduktBild
				{
				get
				{
					if (!IsLoading)
					{
						if (!(Produkt == null))
						{
							return Produkt.ProduktBild;
						}
						else
						{
							return null;
						}
					}
					else
					{
						return null;
					}
				}
			}
			
			private BusinessLogic.Basis.Adresse fAdresse;
[Association("Adresse-GekauftesProdukt"), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false), ImmediatePostData(true)]public BusinessLogic.Basis.Adresse Adresse
				{
				get
				{
					return fAdresse;
				}
				set
				{
					fAdresse = value;
				}
			}
			
			private BusinessLogic.Intern.Mitarbeiter fVerkauftVon;
public BusinessLogic.Intern.Mitarbeiter VerkauftVon
			{
				get
				{
					return fVerkauftVon;
				}
				set
				{
					fVerkauftVon = value;
				}
			}
			
			private string fNotiz;
[Size(SizeAttribute.Unlimited), VisibleInDetailView(true), VisibleInListView(true)]public string Notiz
				{
				get
				{
					return fNotiz;
				}
				set
				{
					fNotiz = value;
				}
			}
			
		}
		
	}
}
