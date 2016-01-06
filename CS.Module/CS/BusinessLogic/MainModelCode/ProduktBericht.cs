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
using DevExpress.Persistent.Base;


namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class ProduktBericht
		{
			public ProduktBericht(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
			}
			
			protected override void OnSaved()
			{
				if (!(TerminBericht == null))
				{
					TerminBericht.PerformUpdate();
				}
				base.OnSaved();
			}
			
			
			private BusinessLogic.Basis.Adresse fAdresse;
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public BusinessLogic.Basis.Adresse Adresse
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
			
			private BusinessLogic.Basis.TerminBericht fTerminBericht;
[Association("TerminBericht-ProduktBericht"), VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public BusinessLogic.Basis.TerminBericht TerminBericht
				{
				get
				{
					return fTerminBericht;
				}
				set
				{
					fTerminBericht = value;
				}
			}
			
			private void ProduktBericht_Changed(object sender, ObjectChangeEventArgs e)
			{
				
				if (!IsLoading)
				{
					if (!(TerminBericht == null))
					{
						TerminBericht.LetzteÄnderung = DateTime.Now;
					}
					if (!(Adresse == null))
					{
						Adresse.LetzteAenderung = DateTime.Now;
					}
				}
			}
		}
		
	}
	
}
