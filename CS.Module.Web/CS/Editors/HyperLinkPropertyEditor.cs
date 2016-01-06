// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Web;
using DevExpress.Web;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using System.Text.RegularExpressions;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace AdressenManagement.Module.Web
{
	
	[PropertyEditor(typeof(System.String), "HyperLinkPropertyEditor", false)]public class HyperLinkPropertyEditor : ASPxStringPropertyEditor
		{
		
		public const string UrlEmailMask = "(((http|https|ftp)\\://)?[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\\\'/\\\\\\+&amp;%\\$#\\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6})";
		public HyperLinkPropertyEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info)
		{
			this.CancelClickEventPropagation = true;
		}
		protected override WebControl CreateEditModeControlCore()
		{
			ASPxTextBox textBox = (ASPxTextBox) (base.CreateEditModeControlCore());
			textBox.ValidationSettings.RegularExpression.ValidationExpression = UrlEmailMask;
			return textBox;
		}
		protected override WebControl CreateViewModeControlCore()
		{
			return CreateHyperLink();
		}
		protected override void ReadViewModeValueCore()
		{
			base.ReadViewModeValueCore();
			SetupHyperLink(PropertyValue);
		}
		private static string GetResolvedUrl(object value)
		{
			string url = Convert.ToString(value);
			if (!string.IsNullOrEmpty(url))
			{
				if (url.Contains("@") && IsValidUrl(url))
				{
					return string.Format("mailto:{0}", url);
				}
				if (!url.Contains("://") && !url.StartsWith("+") && !url.StartsWith("0"))
				{
					url = string.Format("http://{0}", url);
				}
				if (url.StartsWith("+"))
				{
					url = string.Format("tel:{0}", url);
					return url;
				}
				if (url.StartsWith("0"))
				{
					url = string.Format("tel:{0}", url);
					return url;
				}
				if (IsValidUrl(url))
				{
					return url;
				}
			}
			return string.Empty;
		}
		private static bool IsValidUrl(string url)
		{
			return Regex.IsMatch(url, UrlEmailMask);
		}
		private ASPxHyperLink CreateHyperLink()
		{
			ASPxHyperLink hyperlink = RenderHelper.CreateASPxHyperLink();
			return hyperlink;
		}
		private void SetupHyperLink(object value)
		{
			ASPxHyperLink hyperlink = (ASPxHyperLink) InplaceViewModeEditor;
			string url = Convert.ToString(value);
			hyperlink.Text = url;
			hyperlink.NavigateUrl = GetResolvedUrl(url);
		}
	}
}
