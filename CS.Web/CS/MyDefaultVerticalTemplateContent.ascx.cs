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

using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Web.Controls;
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.ExpressApp.Templates;


public partial class MyDefaultVerticalTemplateContent : TemplateContent
{
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		if (WebWindow.CurrentRequestWindow != null)
		{
			WebWindow.CurrentRequestWindow.PagePreRender += CurrentRequestWindow_PagePreRender;
		}
	}
	protected override void OnUnload(EventArgs e)
	{
		if (WebWindow.CurrentRequestWindow != null)
		{
			WebWindow.CurrentRequestWindow.PagePreRender -= CurrentRequestWindow_PagePreRender;
		}
		base.OnUnload(e);
	}
	private void CurrentRequestWindow_PagePreRender(object sender, EventArgs e)
	{
		WebWindow.CurrentRequestWindow.RegisterStartupScript("OnLoadCore", string.Format("Init(\"{0}\", \"VerticalCS\");OnLoadCore(\"LPcell\", \"separatorCell\", \"separatorImage\", true, true);", BaseXafPage.CurrentTheme), true);
		UpdateTRPVisibility();
	}
	private void UpdateTRPVisibility()
	{
		bool isVisible = false;
		foreach (Control control in TRP.Controls)
		{
			if (control is ActionContainerHolder)
			{
				if (((ActionContainerHolder) control).HasActiveActions())
				{
					isVisible = true;
					break;
				}
			}
		}
		TRP.Visible = isVisible;
	}
public override IActionContainer DefaultContainer
	{
		get
		{
			if (TB != null)
			{
				return TB.FindActionContainerById("View");
			}
			return null;
		}
	}
	public override void SetStatus(ICollection<string> statusMessages)
	{
		InfoMessagesPanel.Text = string.Join("<br>", new List<string>(statusMessages).ToArray());
	}
public override dynamic ViewSiteControl
	{
		get
		{
			return VSC;
		}
	}
public ActionContainerHolder LeftToolsActionContainer
	{
		get
		{
			return VTC;
		}
	}
public ActionContainerHolder DiagnosticActionContainer
	{
		get
		{
			return DAC;
		}
	}
public ActionContainerHolder MainToolBarActionContainer
	{
		get
		{
			return TB;
		}
	}
public ActionContainerHolder SecurityActionContainer
	{
		get
		{
			return SAC;
		}
	}
public ActionContainerHolder TopToolsActionContainer
	{
		get
		{
			return SHC;
		}
	}
public ThemedImageControl HeaderImageControl
	{
		get
		{
			return TIC;
		}
	}
}

