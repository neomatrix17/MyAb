// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.ExpressApp.Web.SystemModule;
using DevExpress.Persistent.Validation;

namespace AdressenManagement.Module.Web
{
	
	public class MyWebDetailViewController : WebModificationsController
	{
		
		bool autoclose = false;
		
		protected override void Save(DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs args)
		{
			ProcessSelectedObjects(args.SelectedObjects);
			try
			{
				base.Save(args);
			}
			catch (Exception ex)
			{
				if (ex.Message.Contains("The object you are trying to save was changed by another user. Please refresh data."))
				{
					View.Refresh();
					View.ErrorMessages.Clear();
					var ad = View.CurrentObject as BusinessLogic.Basis.Adresse;
					
					if (!(ad == null))
					{
						ad.Reload();
						ad.Save();
						View.ObjectSpace.Refresh();
					}
					
				}
			}
			
		}
		protected override void SaveAndClose(DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs args)
		{
			
			autoclose = false;
			
			ProcessSelectedObjects(args.SelectedObjects);
			try
			{
				base.SaveAndClose(args);
			}
			catch (Exception ex)
			{
				Gurock.SmartInspect.SiAuto.Main.LogException(ex);
				
			}
			
			if (autoclose)
			{
				View.Close();
			}
			
		}
		private void ProcessSelectedObjects(System.Collections.IList list)
		{
			foreach (object obj in list)
			{
				//...
				if (obj is BusinessLogic.Basis.Termin)
				{
					autoclose = true;
					
					try
					{
						Validator.RuleSet.Validate(ObjectSpace, View.CurrentObject, null);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						autoclose = false;
					}
					
				}
				
				if (obj is BusinessLogic.Basis.Adresse)
				{
					autoclose = true;
					
					try
					{
						Validator.RuleSet.Validate(ObjectSpace, View.CurrentObject, null);
					}
					catch (Exception ex)
					{
						Gurock.SmartInspect.SiAuto.Main.LogException(ex);
						
						
						autoclose = false;
					}
					
				}
				//...
			}
		}
	}
	
}
