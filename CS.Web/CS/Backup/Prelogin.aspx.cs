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
using DevExpress.ExpressApp.Web.Templates;
using DevExpress.ExpressApp;


public partial class Prelogin : System.Web.UI.Page
{
	
	HttpCookie[] aCookie;
	
	private void Prelogin_Init(object sender, EventArgs e)
	{
		
		if (!IsPostBack)
		{
			
			if (!(Request.Cookies["mabsession"] == null))
			{
				string initData = Request.Cookies["mabsession"].Value;
				object[] tempData = initData.Split('#');
				if (tempData.Length > 0)
				{
					MaLogin.Value = tempData[0];
					MaPass.Value = tempData[1];
					MaRememberMe.Checked = tempData[2];
				}
			}
			else if (!(Request.Cookies["kasession"] == null))
			{
				string initData = Request.Cookies["kasession"].Value;
				KaLogin.Value = initData;
			}
			else
			{
				MaLogin.Value = "";
				MaPass.Value = "";
				KaLogin.Value = "";
				MaRememberMe.Checked = false;
			}
			
		}
		
	}
	
	protected void Page_Load(object sender, System.EventArgs e)
	{
		MaPass.Attributes["type"] = "password";
		MaSubmit.Focus();
	}
	
	private void MaSubmit_ServerClick(object sender, EventArgs e)
	{
		
		if (MaLogin.Value != "" || MaPass.Value != "")
		{
			ErrorLabel.Visible = false;
			ErrorLabel.Text = "";
			
			var maUsername = MaLogin.Value;
			var maPassword = MaPass.Value;
			
			var lp = SecuritySystem.LogonParameters;
			
			if (SecuritySystem.Instance == null)
			{
				
			}
			
			
			if (!(lp == null))
			{
				((DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters) lp).UserName = maUsername;
				((DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters) lp).Password = maPassword;
				
				if (MaRememberMe.Checked == true)
				{
					HttpCookie bCookie = new HttpCookie("mabsession");
					bCookie.Value = maUsername + "#" + maPassword + "#" + System.Convert.ToString(MaRememberMe.Checked);
					bCookie.Expires = DateTime.Now.AddDays(100);
					Response.Cookies.Add(bCookie);
				}
				else
				{
					if (!(Request.Cookies["mabsession"] == null))
					{
						var old = Request.Cookies["mabsession"];
						old.Expires = DateTime.Now.AddDays(-1);
						Response.Cookies.Add(old);
					}
				}
				
				var isAuthenticated = GlobalBase.MainSite.PerformOutsideLogOn(new LogonEventArgs(lp));
				
				if (isAuthenticated)
				{
					customerror.Text = "";
					customerror.Visible = false;
					Response.Redirect("Default.aspx");
				}
				else
				{
					
					if (!(HttpContext.Current.Session["CustomError"] == null))
					{
						customerror.Text = DoTranslate(HttpContext.Current.Session["CustomError"]);
						customerror.Visible = true;
					}
					
					ErrorLabel.Visible = true;
					ErrorLabel.Text = "Benutzername oder Passwort falsch.";
				}
				
			}
			
		}
		else
		{
			ErrorLabel.Visible = true;
			ErrorLabel.Text = "Benutzername und Passwort erforderlich.";
		}
		
		
	}
	
	private void KaSubmit_ServerClick(object sender, EventArgs e)
	{
		
		if (KaLogin.Value == "")
		{
			
			ErrorLabel2.Visible = true;
			ErrorLabel2.Text = "Kundennummer erforderlich.";
			
		}
		else
		{
			
			ErrorLabel2.Visible = false;
			ErrorLabel2.Text = "";
			
			var maUsername = KaLogin.Value;
			var maPassword = "";
			
			if (KaRememberMe.Checked == true)
			{
				HttpCookie bCookie = new HttpCookie("kasession");
				bCookie.Value = KaLogin.Value;
				bCookie.Expires = DateTime.Now.AddDays(100);
				Response.Cookies.Add(bCookie);
			}
			else
			{
				if (!(Request.Cookies["kasession"] == null))
				{
					var old = Request.Cookies["kasession"];
					old.Expires = DateTime.Now.AddDays(-1);
					Response.Cookies.Add(old);
				}
			}
			
			var lp = SecuritySystem.LogonParameters;
			
			if (!(lp == null))
			{
				((DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters) lp).UserName = maUsername;
				((DevExpress.ExpressApp.Security.AuthenticationStandardLogonParameters) lp).Password = maPassword;
				var isAuthenticated = GlobalBase.MainSite.PerformOutsideLogOn(new LogonEventArgs(lp));
				
				if (isAuthenticated)
				{
					Response.Redirect("Default.aspx");
				}
				else
				{
					ErrorLabel2.Visible = true;
					ErrorLabel2.Text = "Kundennummer nicht gefunden.";
				}
				
			}
			
		}
		
	}
	
	private string DoTranslate(string pText)
	{
		string retString = "";
		
		if (pText.StartsWith("Login failed for"))
		{
			retString = "Der Andmeldeversuch ist gescheitert, bitte beachten Sie gross und klein Buchstaben und versuchen Sie es erneut.";
		}
		
		if (pText.StartsWith("The application cannot connect"))
		{
			retString = "Das System befindet sich zur Zeit im Wartungsmodus... Bitte versuchen Sie es zu einem späteren Zeitpunkt erneut.";
		}
		
		return retString;
	}
	
}
