// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;


namespace AdressenManagement.Module.Web
{
	namespace Controllers
	{
		public class TestControler : ViewController<DetailView>
		{
			
			protected override void OnActivated()
			{
				base.OnActivated();
				ASPxStringPropertyEditor editor = View.FindItem("Person") as ASPxStringPropertyEditor;
				if (editor != null && View.ViewEditMode == DevExpress.ExpressApp.Editors.ViewEditMode.Edit)
				{
					if (editor.Control != null)
					{
						Customize(editor.Editor);
					}
					else
					{
                        //check this
                        editor.ControlCreated += (s, e) => Customize(editor.Editor, (BusinessLogic.Basis.Termin)editor.CurrentObject);
					}
				}
			}
			private void Customize(object p, BusinessLogic.Basis.Termin prAdresse = null)
			{
				ASPxComboBox control = p as ASPxComboBox;
				if (control != null)
				{
					
					control.Load += (s, e)=>
					{
						
						control.Items.Clear();
						//check this
						if (!(prAdresse.Adresse == null))
						{
                            BusinessLogic.Basis.Adresse pAdresse = prAdresse.Adresse;
							
							if (!(pAdresse == null))
							{
								
								if (!(pAdresse.Anrede == null) && !(pAdresse.Vorname == null) && !(pAdresse.Nachname == null))
								{
									control.Items.Add(pAdresse.Anrede.Name + " " + pAdresse.Vorname + " " + pAdresse.Nachname);
								}
								
								if (!(pAdresse.Anrede2 == null) && !(pAdresse.Vorname2 == null) && !(pAdresse.Nachname2 == null))
								{
									control.Items.Add(pAdresse.Anrede2.Name + " " + pAdresse.Vorname2 + " " + pAdresse.Nachname2);
								}
								
								if (!(pAdresse.Anrede3 == null) && !(pAdresse.Vorname3 == null) && !(pAdresse.Nachname3 == null))
								{
									control.Items.Add(pAdresse.Anrede3.Name + " " + pAdresse.Vorname3 + " " + pAdresse.Nachname3);
								}
								
							}
						}
						
					};
				}
			}
			
			private void InitializeComponent()
			{
				//
				//TestControler
				//
				this.TargetObjectType = typeof(global::AdressenManagement.Module.BusinessLogic.Basis.Termin);
				
			}
		}
	}
}
