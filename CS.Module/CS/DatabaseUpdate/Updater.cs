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
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;

namespace AdressenManagement.Module
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppUpdatingModuleUpdatertopic
	public class Updater : ModuleUpdater
	{
		
		public Updater(DevExpress.ExpressApp.IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion)
		{
		}
		
		public override void UpdateDatabaseAfterUpdateSchema()
		{
			base.UpdateDatabaseAfterUpdateSchema();
			
			BusinessLogic.Intern.Mitarbeiter admin = ObjectSpace.FindObject<BusinessLogic.Intern.Mitarbeiter>(new BinaryOperator("UserName", "Haris"));
			if (admin == null)
			{
				admin = ObjectSpace.CreateObject<BusinessLogic.Intern.Mitarbeiter>();
				admin.SetUserName("Haris");
				admin.Nachname = "Bahtijarevic";
				admin.Vorname = "Haris";
				admin.SetPassword("");
			}
			
			BusinessLogic.Intern.MitarbeiterRolle adminRole = ObjectSpace.FindObject<BusinessLogic.Intern.MitarbeiterRolle>(new BinaryOperator("Name", "Administrator"));
			if (adminRole == null)
			{
				adminRole = ObjectSpace.CreateObject<BusinessLogic.Intern.MitarbeiterRolle>();
				adminRole.Name = "Administrator";
			}
			adminRole.IsAdministrative = true;
			
			admin.MitarbeiterRollen.Add(adminRole);
			
			MainModel.HeroldBranche heroldBranche = ObjectSpace.FindObject<MainModel.HeroldBranche>(new BinaryOperator("Name", "restaurants"));
			
			if (heroldBranche == null)
			{
				
				Herold.Tools.Builder.CategoryBuilder cb = new Herold.Tools.Builder.CategoryBuilder();
				
				List<Herold.Business.Category> lst = cb.GetCategories();
				
				if (!(lst == null))
				{
					foreach (Herold.Business.Category c in lst)
					{
						MainModel.HeroldBranche cat = ObjectSpace.CreateObject<MainModel.HeroldBranche>();
						cat.Name = System.Convert.ToString(c.Name);
						cat.Befehl = System.Convert.ToString(c.NavigationUri);
						cat.Save();
					}
				}
				
			}
			
			ObjectSpace.CommitChanges();
			
		}
		
		public override void UpdateDatabaseBeforeUpdateSchema()
		{
			base.UpdateDatabaseBeforeUpdateSchema();
			//If (CurrentDBVersion < New Version("1.1.0.0") AndAlso CurrentDBVersion > New Version("0.0.0.0")) Then
			//    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName")
			//End If
		}
	}
}
