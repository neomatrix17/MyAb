// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class LoggedInAsControler : ViewController
	{
		public LoggedInAsControler()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			
			var s = Frame.GetController<LogoffController>();
			
			if (!(s == null))
			{
				
				if (((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Vorname == "")
				{
					
					var address = ObjectSpace.FindObject<BusinessLogic.Basis.Adresse>(new BinaryOperator("VerknüpfterKunde", ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Oid, BinaryOperatorType.Equal));
					
					if (!(address == null))
					{
						
						string[] tempname = address.AnzeigeName.ToString().Split("-");
						
						try
						{
							s.LogoffAction.Caption = "Angemeldet als: " + tempname[0] + " " + " - Abmelden?";
						}
						catch (Exception)
						{
							s.LogoffAction.Caption = "Angemeldet als: " + address.AnzeigeName + " " + " - Abmelden?";
						}
						
						
					}
					else
					{
						s.LogoffAction.Caption = "Angemeldet als: " + "Kunde ID: " + ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Oid + " " + " - Abmelden?";
					}
					
				}
				else
				{
					s.LogoffAction.Caption = "Angemeldet als: " + ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Vorname + " " + ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Nachname + " - Abmelden?";
				}
				
			}
			
		}
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
			// Access and customize the target View control.
		}
		protected override void OnDeactivated()
		{
			// Unsubscribe from previously subscribed events and release other references and resources.
			base.OnDeactivated();
		}
	}
	
}
