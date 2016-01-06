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
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base;


namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class Anrufprotokoll
		{
			public Anrufprotokoll(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
				fDatum = DateTime.Now;
			}
			
			protected override void OnSaving()
			{
				if (!string.IsNullOrEmpty(Status))
				{
					base.OnSaving();
				}
				else
				{
					return;
				}
			}
			
			private string fGesprochenMit;
public string GesprochenMit
			{
				get
				{
					return fGesprochenMit;
				}
				set
				{
					fGesprochenMit = value;
				}
			}
			
			private BusinessLogic.Basis.Adresse fAdresse;
[Association("Adresse-Anrufprotololle")]public BusinessLogic.Basis.Adresse Adresse
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
			
			private BusinessLogic.Intern.Mitarbeiter fMitarbeiter;
[Association("Mitarbeiter-Anrufprotokoll")]public BusinessLogic.Intern.Mitarbeiter Mitarbeiter
				{
				get
				{
					return fMitarbeiter;
				}
				set
				{
					fMitarbeiter = value;
				}
			}
			
			private string fNotiz;
[Size(SizeAttribute.Unlimited)]public string Notiz
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
			
#region Audit Trail Log
			
			private XPCollection<AuditDataItemPersistent> m_userAuditTrail;
[VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]public XPCollection<AuditDataItemPersistent> ChangeLog
				{
				get
				{
					if (m_userAuditTrail == null)
					{
						m_userAuditTrail = AuditedObjectWeakReference.GetAuditTrail(Session, this);
					}
					return m_userAuditTrail;
				}
			}
			
#endregion
			
		}
		
	}
	
}
