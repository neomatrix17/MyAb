// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Spider
	{
		
		public class FirmenAdresse
		{
			
			private string fName;
public string Name
			{
				get
				{
					return fName;
				}
				set
				{
					fName = value;
				}
			}
			
			private string fStrasse;
public string Strasse
			{
				get
				{
					return fStrasse;
				}
				set
				{
					fStrasse = value;
				}
			}
			
			private string fPostLeitZahl;
public string PostLeitZahl
			{
				get
				{
					return fPostLeitZahl;
				}
				set
				{
					fPostLeitZahl = value;
				}
			}
			
			private string fOrtschaft;
public string Ortschaft
			{
				get
				{
					return fOrtschaft;
				}
				set
				{
					fOrtschaft = value;
				}
			}
			
			private int? fBranche;
public int? Branche
			{
				get
				{
					return fBranche;
				}
				set
				{
					fBranche = value;
				}
			}
			
			private string fTelefonNummer;
public string TelefonNummer
			{
				get
				{
					return fTelefonNummer;
				}
				set
				{
					fTelefonNummer = value;
				}
			}
			
			private string fWebseite;
public string Webseite
			{
				get
				{
					return fWebseite;
				}
				set
				{
					fWebseite = value;
				}
			}
			
			private string fEmail;
public string Email
			{
				get
				{
					return fEmail;
				}
				set
				{
					fEmail = value;
				}
			}
			
			private string fLogo;
public string Logo
			{
				get
				{
					return fLogo;
				}
				set
				{
					fLogo = value;
				}
			}
			
		}
		
	}
	
	
}
