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


//------------------------------------------------------------------------------
// <automatisch generiert>
//     Der Code wurde von einem Tool generiert.
//
//     Änderungen an der Datei führen möglicherweise zu falschem Verhalten, und sie gehen verloren, wenn
//     der Code erneut generiert wird.
// </automatisch generiert>
//------------------------------------------------------------------------------



public partial class MyDefaultVerticalTemplateContent
{
	
	///<summary>
	///GE-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.Web.ASPxGlobalEvents GE;
	
	///<summary>
	///LogoLink-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::System.Web.UI.WebControls.HyperLink LogoLink;
	
	///<summary>
	///TIC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Controls.ThemedImageControl TIC;
	
	///<summary>
	///UPSAC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPSAC;
	
	///<summary>
	///SAC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder SAC;
	
	///<summary>
	///UPSHC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPSHC;
	
	///<summary>
	///SHC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder SHC;
	
	///<summary>
	///UPNC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPNC;
	
	///<summary>
	///NC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.NavigationActionContainer NC;
	
	///<summary>
	///UPTP-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPTP;
	
	///<summary>
	///TP-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::System.Web.UI.HtmlControls.HtmlGenericControl TP;
	
	///<summary>
	///TRP-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.Web.ASPxRoundPanel TRP;
	
	///<summary>
	///PanelContent1-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.Web.PanelContent PanelContent1;
	
	///<summary>
	///VTC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder VTC;
	
	///<summary>
	///DAC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder DAC;
	
	///<summary>
	///UPTB-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPTB;
	
	///<summary>
	///TB-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder TB;
	
	///<summary>
	///UPVH-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPVH;
	
	///<summary>
	///VIC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Controls.ViewImageControl VIC;
	
	///<summary>
	///VCC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Controls.ViewCaptionControl VCC;
	
	///<summary>
	///VHC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.NavigationHistoryActionContainer VHC;
	
	///<summary>
	///RNC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder RNC;
	
	///<summary>
	///UPEMA-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPEMA;
	
	///<summary>
	///EMA-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder EMA;
	
	///<summary>
	///UPEI-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPEI;
	
	///<summary>
	///ErrorInfo-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.Controls.ErrorInfoControl ErrorInfo;
	
	///<summary>
	///UPVSC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPVSC;
	
	///<summary>
	///VSC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Controls.ViewSiteControl VSC;
	
	///<summary>
	///EditModeActions2-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.ActionContainerHolder EditModeActions2;
	
	///<summary>
	///UPQC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPQC;
	
	///<summary>
	///QC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.ActionContainers.QuickAccessNavigationActionContainer QC;
	
	///<summary>
	///UPIMP-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Templates.XafUpdatePanel UPIMP;
	
	///<summary>
	///InfoMessagesPanel-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::System.Web.UI.WebControls.Literal InfoMessagesPanel;
	
	///<summary>
	///AIC-Steuerelement
	///</summary>
	///<remarks>
	///Automatisch generiertes Feld
	///Um dies zu ändern, verschieben Sie die Felddeklaration aus der Designerdatei in eine Code-Behind-Datei.
	///</remarks>
	protected global::DevExpress.ExpressApp.Web.Controls.AboutInfoControl AIC;
}

