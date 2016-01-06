// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;


namespace AdressenManagement.Module.Web
{
	namespace AdressenManagement.Module.Web
	{
		[PropertyEditor(typeof(XPBaseCollection), false)]public class WebCheckedListBoxPropertyEditor : ASPxPropertyEditor, IComplexViewItem
		{
			public WebCheckedListBoxPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model)
			{
			}
			private XafApplication application;
			private DevExpress.ExpressApp.IObjectSpace objectSpace;
			protected override WebControl CreateEditModeControlCore()
			{
				return new ASPxCheckBoxList();
			}
			protected override WebControl CreateViewModeControlCore()
			{
				ASPxCheckBoxList control = new ASPxCheckBoxList();
				control.ClientEnabled = false;
				return control;
			}
			private XPBaseCollection checkedItems;
			protected override void ReadValueCore()
			{
				base.ReadValueCore();
				if (PropertyValue is XPBaseCollection)
				{
					ASPxCheckBoxList control = ViewEditMode == DevExpress.ExpressApp.Editors.ViewEditMode.Edit ? Editor : InplaceViewModeEditor;
					control.SelectedIndexChanged -= Control_SelectedIndexChanged;
					checkedItems = (XPBaseCollection) PropertyValue;
					XPCollection dataSource = new XPCollection(checkedItems.Session, MemberInfo.ListElementType);
					IModelClass classInfo = application.Model.BOModel.GetClass(MemberInfo.ListElementTypeInfo.Type);
					if (checkedItems.Sorting.Count > 0)
					{
						dataSource.Sorting = checkedItems.Sorting;
					}
					else if (!string.IsNullOrEmpty(classInfo.DefaultProperty))
					{
						dataSource.Sorting.Add(new SortProperty(classInfo.DefaultProperty, DevExpress.Xpo.DB.SortingDirection.Ascending));
					}
					control.DataSource = dataSource;
					control.TextField = classInfo.DefaultProperty;
					control.ValueField = classInfo.KeyProperty;
					control.ValueType = classInfo.TypeInfo.KeyMember.MemberType;
					control.DataBind();
					foreach (object obj in checkedItems)
					{
						control.Items.FindByValue(objectSpace.GetKeyValue(obj)).Selected = true;
					}
					control.SelectedIndexChanged += Control_SelectedIndexChanged;
				}
			}
			private void Control_SelectedIndexChanged(object sender, EventArgs e)
			{
				ASPxCheckBoxList control = (ASPxCheckBoxList) sender;
				foreach (ListEditItem item in control.Items)
				{
					object obj = objectSpace.GetObjectByKey(MemberInfo.ListElementTypeInfo.Type, item.Value);
					if (item.Selected)
					{
						checkedItems.BaseAdd(obj);
					}
					else
					{
						checkedItems.BaseRemove(obj);
					}
				}
				OnControlValueChanged();
				objectSpace.SetModified(CurrentObject);
			}
public new ASPxCheckBoxList Editor
			{
				get
				{
					return ((ASPxCheckBoxList) base.Editor);
				}
			}
public new ASPxCheckBoxList InplaceViewModeEditor
			{
				get
				{
					return ((ASPxCheckBoxList) base.InplaceViewModeEditor);
				}
			}
			protected override void SetImmediatePostDataScript(string script)
			{
				Editor.ClientSideEvents.SelectedIndexChanged = script;
			}
			protected override bool IsMemberSetterRequired()
			{
				return false;
			}
			
#region IComplexViewItem Members
			
			public void Setup(IObjectSpace objectSpace, XafApplication application)
			{
				this.application = application;
				this.objectSpace = objectSpace;
			}
			
#endregion
			
		}
		
	}
}
