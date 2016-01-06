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
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;



namespace AdressenManagement.Module.Win
{
	namespace Controllers
	{
		public class TestControler : ViewController<DetailView>
		{
			
			protected override void OnActivated()
			{
				base.OnActivated();
				PropertyEditor propertyEditor = ((DetailView) View).FindItem("Person") as PropertyEditor;
				if (propertyEditor != null)
				{
					if (propertyEditor.Control != null)
					{
						Customize(propertyEditor, null);
					}
					else
					{
                        //check this!
                        //propertyEditor.ControlCreated += propertyEditor_ControlCreated;
					}
				}
			}
			private void Customize(object p, BusinessLogic.Basis.Termin prAdresse = null)
			{
				dynamic control = p;
				if (control != null)
				{
					control.Items.Clear();
					
					if (!(prAdresse.Adresse == null))
					{
						var pAdresse = prAdresse.Adresse;
						
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
				}
				
			}
			
			private void InitializeComponent()
			{
				//
				//TestControler
				//
				this.TargetObjectType = typeof(AdressenManagement.Module.BusinessLogic.Basis.Termin);
				
			}
			
			private void propertyEditor_ControlCreated(object sender, EventArgs e, BusinessLogic.Basis.Termin prAdresse = null)
			{
				
				var control = (PredefinedValuesStringEdit) (((PropertyEditor) sender).Control);
				
				control.Properties.Items.Clear();
				
				dynamic pAdresse = ((PropertyEditor) sender).CurrentObject;
				
				if (!(pAdresse == null))
				{
					
					var m = pAdresse.Adresse;
					
					if (!(m == null))
					{
						
						pAdresse = m;
						
						if (!(pAdresse.Anrede == null) && !(pAdresse.Vorname == null) && !(pAdresse.Nachname == null))
						{
							control.Properties.Items.Add(pAdresse.Anrede.Name + " " + pAdresse.Vorname + " " + pAdresse.Nachname);
						}
						
						if (!(pAdresse.Anrede2 == null) && !(pAdresse.Vorname2 == null) && !(pAdresse.Nachname2 == null))
						{
							control.Properties.Items.Add(pAdresse.Anrede2.Name + " " + pAdresse.Vorname2 + " " + pAdresse.Nachname2);
						}
						
						if (!(pAdresse.Anrede3 == null) && !(pAdresse.Vorname3 == null) && !(pAdresse.Nachname3 == null))
						{
							control.Properties.Items.Add(pAdresse.Anrede3.Name + " " + pAdresse.Vorname3 + " " + pAdresse.Nachname3);
						}
						
						if (control.Properties.Items.Count > 0)
						{
							control.SelectedIndex = 0;
							control.SelectedItem = 0;
						}
						
					}
					
				}
				
			}
			
		}
		
	}
}
