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
using DevExpress.ExpressApp.Web.Layout;
using DevExpress.ExpressApp.Web.Editors;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class AdresseEmptyTabViewControler : ViewController<DetailView>
	{
		
		DevExpress.Web.ASPxPageControl control;
		
		public AdresseEmptyTabViewControler()
		{
			InitializeComponent();
			RegisterActions(components);
			// Target required Views (via the TargetXXX properties) and create their Actions.
			
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			((WebLayoutManager) View.LayoutManager).PageControlCreated += OnPageControlCreated;
			View.CurrentObjectChanged += Object_Changed;
		}
		protected override void OnDeactivated()
		{
			((WebLayoutManager) View.LayoutManager).PageControlCreated -= OnPageControlCreated;
			base.OnDeactivated();
		}
		private void OnPageControlCreated(object sender, PageControlCreatedEventArgs e)
		{
			
			if (e.Model.Id == "Item5")
			{
				control = e.PageControl;
				
				int tabID = 0;
				
				var adress = (BusinessLogic.Basis.Adresse) View.CurrentObject;
				
				if (!(adress == null))
				{
					if (!(adress.Vorname == null) && !(adress.Vorname == "") && !(adress.Nachname == null) && !(adress.Nachname == ""))
					{
						tabID = 0;
						if (control.TabPages.Count > 0)
						{
							control.TabPages[0].TabStyle.Font.Bold = true;
							control.TabPages[0].TabControl.DisabledStyle.ForeColor = System.Drawing.Color.Navy;
						}
					}
					if (!(adress.Vorname2 == null) && !(adress.Vorname2 == "") && !(adress.Nachname2 == null) && !(adress.Nachname2 == ""))
					{
						tabID = 1;
						if (control.TabPages.Count > 0)
						{
							control.TabPages[1].TabStyle.Font.Bold = true;
							control.TabPages[1].TabControl.DisabledStyle.ForeColor = System.Drawing.Color.Navy;
						}
					}
					if (!(adress.Firma3 == null) && !(adress.Firma3 == ""))
					{
						tabID = 2;
						if (control.TabPages.Count > 0)
						{
							control.TabPages[2].TabStyle.Font.Bold = true;
							control.TabPages[2].TabControl.DisabledStyle.ForeColor = System.Drawing.Color.Navy;
						}
					}
				}
				
				switch (tabID)
				{
					case 0:
						if (!(control == null))
						{
							control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
						}
						break;
					case 1:
						if (!(control == null))
						{
							control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
						}
						break;
					case 2:
						if (!(control == null))
						{
							control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
						}
						break;
				}
				
			}
			
		}
		
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
		}
		
		private void Object_Changed(object sender, EventArgs e)
		{
			
			int tabID = 0;
			
			var adress = (BusinessLogic.Basis.Adresse) View.CurrentObject;
			
			if (!(adress == null))
			{
				if (!(adress.Vorname == null) && !(adress.Vorname == "") && !(adress.Nachname == null) && !(adress.Nachname == ""))
				{
					tabID = 0;
					control.TabPages[0].TabStyle.Font.Bold = true;
					control.TabPages[0].TabControl.DisabledStyle.ForeColor = System.Drawing.Color.Navy;
				}
				if (!(adress.Vorname2 == null) && !(adress.Vorname2 == "") && !(adress.Nachname2 == null) && !(adress.Nachname2 == ""))
				{
					tabID = 1;
					control.TabPages[1].TabStyle.Font.Bold = true;
					control.TabPages[1].TabControl.DisabledStyle.ForeColor = System.Drawing.Color.Navy;
				}
				if (!(adress.Firma3 == null) && !(adress.Firma3 == ""))
				{
					tabID = 2;
					control.TabPages[2].TabStyle.Font.Bold = true;
					control.TabPages[2].TabStyle.ForeColor = System.Drawing.Color.Navy;
				}
			}
			
			switch (tabID)
			{
				case 0:
					if (!(control == null))
					{
						control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
					}
					break;
				case 1:
					if (!(control == null))
					{
						control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
					}
					break;
				case 2:
					if (!(control == null))
					{
						control.ClientSideEvents.Init = "function(s,e){s.SetActiveTabIndex(" + System.Convert.ToString(tabID) + ");}";
					}
					break;
			}
			
		}
		
		
	}
}
