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
	public partial class AdresseViewCaptionViewController : ViewController
	{
		
		System.Timers.Timer tmr = new System.Timers.Timer();
		
		public AdresseViewCaptionViewController()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			//tmr.Interval = 10
			//AddHandler tmr.Elapsed, AddressOf Tmr_Ellapsed
			//tmr.Start()
			//Dim adr = TryCast(View.CurrentObject, BusinessLogic.Basis.Adresse)
			
			//If Not adr Is Nothing Then
			//    If Not adr.Status Is Nothing Then
			//        View.Caption = "Status: " & adr.Status.Name
			//    End If
			//End If
			
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
		
		private void Tmr_Ellapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			
			try
			{
				if (!(View == null))
				{
					
					if (!(View.CurrentObject == null))
					{
						
						var adr = View.CurrentObject as BusinessLogic.Basis.Adresse;
						
						if (!(adr == null))
						{
							if (!(adr.Status == null))
							{
								
								if (View.Caption != "Status: " + adr.Status.Name)
								{
									View.Caption = "Status: " + adr.Status.Name;
								}
								
							}
						}
						
					}
					
				}
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				
				
				
				
			}
			
		}
		
	}
	
}
