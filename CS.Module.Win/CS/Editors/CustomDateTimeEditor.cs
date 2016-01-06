// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Win.Editors;

namespace AdressenManagement.Module.Win
{
	//...
	[PropertyEditor(typeof(DateTime), true)]public class CustomDateTimeEditor : DatePropertyEditor
	{
		
		
		public CustomDateTimeEditor(Type objectType, IModelMemberViewItem info) : base(objectType, info)
		{
		}
		protected override void SetupRepositoryItem(RepositoryItem item)
		{
			base.SetupRepositoryItem(item);
			RepositoryItemDateTimeEdit dateProperties = (RepositoryItemDateTimeEdit) item;
			dateProperties.CalendarTimeEditing = DefaultBoolean.True;
			dateProperties.CalendarView = CalendarView.Vista;
		}
		
	}
}
