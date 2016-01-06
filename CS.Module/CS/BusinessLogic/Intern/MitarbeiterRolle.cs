// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using DevExpress.ExpressApp.Security.Strategy;
using DevExpress.Persistent.Base;


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Intern
	{
		
		[ImageName("BO_Role")]public class MitarbeiterRolle : SecuritySystemRoleBase
			{
			
			public MitarbeiterRolle(Session session) : base(session)
			{
			}
			
[Association("Employees-EmployeeRoles")]public XPCollection<Mitarbeiter> Employees
			{
				get
				{
					return GetCollection<Mitarbeiter>("Employees");
				}
			}
			
		}
		
	}
}
