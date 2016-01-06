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
using System.Web.UI.WebControls;
using System.Drawing;
using DevExpress.ExpressApp.Web.Editors;
using DevExpress.Web.Internal;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class AdresseColorViewControler : ObjectViewController<DetailView, global::AdressenManagement.Module.BusinessLogic.Basis.Adresse>
	{
		
		public AdresseColorViewControler()
		{
			
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			((WebLayoutManager) View.LayoutManager).ItemCreated += ViewController1_ItemCreated;
			
			foreach (StaticTextViewItem item in View.GetItems<StaticTextViewItem>())
			{
				item.ControlCreated += item_ControlCreated;
			}
			
		}
		private void ViewController1_ItemCreated(object sender, ItemCreatedEventArgs e)
		{
			PropertyEditor editor = e.ViewItem as PropertyEditor;
			if (editor != null && editor.Id == "AdressArt")
			{
				if (e.TemplateContainer.CaptionControl != null)
				{
					CustomizeCaptionControl(e.TemplateContainer.CaptionControl);
				}
				else
				{
					e.TemplateContainer.Load += TemplateContainer_Load;
				}
			}
		}
		private void TemplateContainer_Load(object sender, EventArgs e)
		{
			LayoutItemTemplateContainerBase templateControler = (LayoutItemTemplateContainerBase) sender;
			templateControler.Load -= TemplateContainer_Load;
			CustomizeCaptionControl(templateControler.CaptionControl);
		}
		private void CustomizeCaptionControl(WebControl captionControl)
		{
			captionControl.ForeColor = Color.Red;
		}
		
		protected override void OnDeactivated()
		{
			base.OnDeactivated();
			((WebLayoutManager) View.LayoutManager).ItemCreated -= ViewController1_ItemCreated;
		}
		
		private void item_ControlCreated(object sender, EventArgs e)
		{
			StaticTextViewItem item = (StaticTextViewItem) sender;
			
			if (item.Id == "ImageText")
			{
				item.Control.ForeColor = Color.Red;
			}
			else if (item.Id == "@c9c0126c-684c-4ca9-9a43-a739639fcb43")
			{
				
				item.Control.Height = 30;
				item.Control.Font.Bold = true;
				item.Control.Font.Size = 16;
				item.Text = System.Convert.ToString(((BusinessLogic.Basis.Adresse) item.CurrentObject).Info.Name);
				item.CurrentObjectChanged += CurrentObjectChanged;
				switch (item.Text)
				{
					case "Kunde":
						item.Control.ForeColor = Color.DarkGreen;
						break;
					case "Kein Kunde":
						item.Control.ForeColor = Color.Red;
						break;
				}
				
			}
			else
			{
				item.Control.ForeColor = Color.Blue;
			}
			
		}
		
		private void CurrentObjectChanged(object sender, EventArgs e)
		{
			StaticTextViewItem item = (StaticTextViewItem) sender;
			
			if (item.Id == "ImageText")
			{
				item.Control.ForeColor = Color.Red;
			}
			else if (item.Id == "@c9c0126c-684c-4ca9-9a43-a739639fcb43")
			{
				
				item.Control.Height = 30;
				item.Control.Font.Bold = true;
				item.Control.Font.Size = 16;
				item.Text = System.Convert.ToString(((BusinessLogic.Basis.Adresse) item.CurrentObject).Info.Name);
				item.CurrentObjectChanged -= CurrentObjectChanged;
				switch (item.Text)
				{
					case "Kunde":
						item.Control.ForeColor = Color.DarkGreen;
						break;
					case "Kein Kunde":
						item.Control.ForeColor = Color.Red;
						break;
				}
				
			}
			else
			{
				item.Control.ForeColor = Color.Blue;
			}
		}
		
	}
	
}
