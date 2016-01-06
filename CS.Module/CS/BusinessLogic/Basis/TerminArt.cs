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
		
		[DefaultProperty("Name")]public class TerminArt : XPObject
			{
			
			
			public TerminArt(Session session) : base(session)
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
			
			private double fStandardTerminDauer;
public double StandardTerminDauer
			{
				get
				{
					return fStandardTerminDauer;
				}
				set
				{
					fStandardTerminDauer = value;
				}
			}
			
			private System.Drawing.Color fTerminFarbe;
[Persistent]public System.Drawing.Color TerminFarbe
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
[Browsable(false)]public string PersistentTerminFarbe
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
			
			private string fThin;
[Browsable(false)]public string Thin
				{
				get
				{
					return fThin;
				}
				set
				{
					fThin = value;
				}
			}
			
			private void TerminArt_Changed(object sender, ObjectChangeEventArgs e)
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
					exeptionError.Aktion = "Private Sub TerminArt_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed";
					exeptionError.Fehlermeldung = ex.Message;
				}
				
			}
		}
		
	}
}
