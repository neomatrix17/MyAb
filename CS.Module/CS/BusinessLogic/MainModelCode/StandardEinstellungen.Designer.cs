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
		
		public partial class StandardEinstellungen : XPObject
		{
			[Persistent("ErstelltAm")]DateTime fErstelltAm;
[PersistentAlias("fErstelltAm")]public DateTime ErstelltAm
			{
				get
				{
					return fErstelltAm;
				}
			}
			string fSmtpServer;
public string SmtpServer
			{
				get
				{
					return fSmtpServer;
				}
				set
				{
					SetPropertyValue<string>("SmtpServer",  ref fSmtpServer, value);
				}
			}
			bool fSSL;
public bool SSL
			{
				get
				{
					return fSSL;
				}
				set
				{
                    SetPropertyValue<bool>("SSL", ref fSSL, value);
				}
			}
			short fSmtpPort;
public short SmtpPort
			{
				get
				{
					return fSmtpPort;
				}
				set
				{
                    SetPropertyValue<short>("SmtpPort", ref fSmtpPort, value);
				}
			}
			string fEmail;
public string Email
			{
				get
				{
					return fEmail;
				}
				set
				{
                    SetPropertyValue<string>("Email", ref fEmail, value);
				}
			}
			string fPasswort;
public string Passwort
			{
				get
				{
					return fPasswort;
				}
				set
				{
                    SetPropertyValue<string>("Passwort", ref fPasswort, value);
				}
			}
			DateTime fUhrzeit;
public DateTime Uhrzeit
			{
				get
				{
					return fUhrzeit;
				}
				set
				{
                    SetPropertyValue<DateTime>("Uhrzeit", ref fUhrzeit, value);
				}
			}
		}
		
	}
	
}