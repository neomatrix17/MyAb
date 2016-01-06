// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Web.Editors.ASPx;

namespace AdressenManagement.Module.Web
{
	//...
	[PropertyEditor(typeof(DateTime), false)]public class CustomDateTimeEditor : ASPxDateTimePropertyEditor
	{
		
		public CustomDateTimeEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info)
		{
		}
		protected override WebControl CreateEditModeControlCore()
		{
			ASPxDateEdit dateEdit = (ASPxDateEdit) (base.CreateEditModeControlCore());
			dateEdit.TimeSectionProperties.Visible = true;
			dateEdit.UseMaskBehavior = true;
			return dateEdit;
		}
	}
}
