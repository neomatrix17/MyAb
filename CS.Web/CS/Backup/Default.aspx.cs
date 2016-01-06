// VBConversions Note: VB project level imports
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Web.Security;
using System.Collections.Generic;
using System.Data;
using System.Collections.Specialized;
using System.Web.Profile;
using Microsoft.VisualBasic;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections;
using System;
using System.Web;
using System.Web.UI;
using System.Web.SessionState;
using System.Text;
using System.Web.Caching;
using System.Web.UI.WebControls.WebParts;
// End of VB project level imports

using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.ExpressApp.Web.Controls;
using System.Drawing;
using DevExpress.ExpressApp;


public partial class Default : BaseXafPage
{
	
	static Default()
	{
	}
	
	protected override ContextActionsMenu CreateContextActionsMenu()
	{
		return new ContextActionsMenu(this, "Edit", "RecordEdit", "ObjectsCreation", "ListView", "Reports");
	}
	
	private void PopupWindowControl_CustomizePopupControl(object sender, DevExpress.ExpressApp.Web.Controls.CustomizePopupControlEventArgs e)
	{
		
	}
	
	protected void PopupWindowControl_CustomizePopupWindowSize(object sender, CustomizePopupWindowSizeEventArgs e)
	{
		PopupWindow window = default(PopupWindow);
		try
		{
			window = e.FindPopupWindow(WebApplication.Instance);
		}
		catch (ArgumentException)
		{
			return ;
		}
		if (window != null && window.View != null)
		{
			if (!(window.View.ObjectTypeInfo == null))
			{
				if (window.View.ObjectTypeInfo.Type == typeof(AdressenManagement.Module.BusinessLogic.Basis.Adresse))
				{
					e.Size = new Size(1024, 1200);
					e.Handled = true;
				}
				else if (window.View.ObjectTypeInfo.Type == typeof(AdressenManagement.Module.BusinessLogic.Basis.Termin))
				{
					e.Size = new Size(1024, 1200);
					e.Handled = true;
				}
				else if (window.View.ObjectTypeInfo.Type == typeof(DevExpress.Persistent.BaseImpl.Event))
				{
					e.Size = new Size(1024, 1200);
					e.Handled = true;
				}
				else if (window.View.ObjectTypeInfo.Type == typeof(AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter))
				{
					e.Size = new Size(1024, 1200);
					e.Handled = true;
				}
			}
		}
	}
	
	protected void Page_Init()
	{
		
		try
		{
			CustomizeTemplateContent += (sender, e) =>;
			DefaultVerticalTemplateContent _content = TemplateContent as DefaultVerticalTemplateContent;
			if (_content == null)
			{
				return ;
			}
			
			if (!(SecuritySystem.CurrentUser == null))
			{
				if (!((AdressenManagement.Module.BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).IsKunde.HasValue)
				{
					_content.HeaderImageControl.DefaultThemeImageLocation = "~/Images";
					_content.HeaderImageControl.ImageName = "AdressenManagement.Web.Images.MainLogo.png";
				}
				else
				{
					_content.HeaderImageControl.DefaultThemeImageLocation = "~/Images";
					_content.HeaderImageControl.ImageName = "AdressenManagement.Web.Images.KundenLogo.png";
				}
			}
			else
			{
				_content.HeaderImageControl.DefaultThemeImageLocation = "~/Images";
				_content.HeaderImageControl.ImageName = "AdressenManagement.Web.Images.MainLogo.png";
			}
			
			
		}
		
		AdressenManagement.Module.BusinessLogic.Intern.RecensaWatch recensaWatch;
		recensaWatch = null;
		
		if (!(HttpContext.Current == null))
		{
			System.Object s; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
			if (!(s == null))
			{
				DevExpress.ExpressApp.IObjectSpace os; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
				dynamic se; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
				
				int inaktiv = 15;
				
				if (!(se == null))
				{
					inaktiv = System.Convert.ToInt32(se.BenutzerInaktivNach);
				}
				
				recensaWatch = s;
				if (recensaWatch.PartialTimeWatch.Elapsed.TotalMinutes > inaktiv)
				{
					recensaWatch.PartialTimeWatch.Reset();
					recensaWatch.PartialTimeWatch.Start();
				}
				else
				{
					
					DevExpress.Data.Filtering.CriteriaOperator filter; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
					dynamic zo; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
					
					if (!(zo == null))
					{
						System.Double min; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
						zo.TotalMinuten = zo.TotalMinuten + min;
						zo.TotalStunden = zo.TotalMinuten / 60;
						zo.Save();
						os.CommitChanges();
					}
					recensaWatch.AddTime();
					recensaWatch.PartialTimeWatch.Reset();
					recensaWatch.PartialTimeWatch.Start();
				}
			}
			
		}
	}
	catch (Exception ex)
	{
		Gurock.SmartInspect.SiAuto.Main.LogException(ex);
	}
	
}

public override Control InnerContentPlaceHolder
{
	get
	{
		return Content;
	}
}

private void Page_Load(object sender, EventArgs e)
{
	
}

}

