// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Templates;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.ComponentModel;
using DevExpress.Persistent.Base.Security;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.ConditionalAppearance;
using System.Web;

namespace AdressenManagement.Module
{
	
	public partial class XtraReport1MaTagesKalender
	{
		
		public XtraReport1MaTagesKalender()
		{
			
			InitializeComponent();
			
			LoadDataIntoReport();
			
		}
		
		private void LoadDataIntoReport()
		{
			
			if (!(HttpContext.Current.Session["ShedulerDate"] == null))
			{
				
				Session sess = new Session();
				
				ICollection appointments = default(ICollection);
				DevExpress.Xpo.Metadata.XPClassInfo appointmentsClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
				DevExpress.Data.Filtering.CriteriaOperator criteria = default(DevExpress.Data.Filtering.CriteriaOperator);
				DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
				DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
				sess.ConnectionString = GlobalBase.CurrentConn;
				sortProps = new SortingCollection(null);
				appointmentsClass = sess.GetClassInfo<BusinessLogic.Basis.Termin>();
				DateTime dt =(DateTime)HttpContext.Current.Session["ShedulerDate"];
				DateTime dt1 = dt.AddDays(1);
				DateTime dt2 = dt.AddDays(0);
				
				string role = "";
				
				var user = SecuritySystem.CurrentUser as BusinessLogic.Intern.Mitarbeiter;
				
				if (!(user == null))
				{
					var roles = user.MitarbeiterRollen;
					foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
					{
						role = System.Convert.ToString(r.Name);
					}
				}
				
				
				if (role == "Administrator" || role == "Distributeur" || role == "Telefonist")
				{
					//Dim list(HttpContext.Current.Session("AppointmentList").Count - 1) As String
					//For i = 0 To HttpContext.Current.Session("AppointmentList").Count - 1
					//    list(i) = HttpContext.Current.Session("AppointmentList")(i)
					//Next
					//criteria = New InOperator("Oid", list)
					criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Mitarbeiter] = (?) AND [StartOn] between ( (?) , (?) ) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", SecuritySystem.CurrentUserId, dt2, dt1);
				}
				else
				{
					criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Mitarbeiter] = (?) AND [StartOn] between ( (?) , (?) ) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", SecuritySystem.CurrentUserId, dt2, dt1);
				}
				
				
				sortProps.Add(new SortProperty("Mitarbeiter", DevExpress.Xpo.DB.SortingDirection.Ascending));
				sortProps.Add(new SortProperty("StartOn", DevExpress.Xpo.DB.SortingDirection.Ascending));
				patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, sess.TypesManager);
				
				appointments = sess.GetObjects(appointmentsClass, criteria, sortProps, 0, patcher, true);
				
				
				ObjectDataSource1.DataSource = appointments;
				
				//HttpContext.Current.Session("ShedulerDate") = Nothing
				
			}
			else if (!(HttpContext.Current.Session["SchedulerWeekDate"] == null))
			{
				//check this
				List<DateTime> dateList =(List<DateTime>) HttpContext.Current.Session["SchedulerWeekDate"];
				
				if (!(dateList == null))
				{
					Session sess = new Session();
					
					DateTime date1 = dateList[0];
					DateTime date2 = dateList[1];
					
					ICollection appointments = default(ICollection);
					DevExpress.Xpo.Metadata.XPClassInfo appointmentsClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
					DevExpress.Data.Filtering.CriteriaOperator criteria = default(DevExpress.Data.Filtering.CriteriaOperator);
					DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
					DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
					sess.ConnectionString = GlobalBase.CurrentConn;
					sortProps = new SortingCollection(null);
					appointmentsClass = sess.GetClassInfo<BusinessLogic.Basis.Termin>();
					
					//criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Mitarbeiter] = (?) AND [SearchDate] = (?)", SecuritySystem.CurrentUserId, Now.Date.ToString("dd.MM.yyyy"))
					//criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[StartOn] between ('" & Now.Date.AddDays(-6) & "' , '" & Now.Date & "')  AND [Mitarbeiter] = (?)", SecuritySystem.CurrentUserId)
					//criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[StartOn] between ( (?) , (?) ) AND [Mitarbeiter] = (?)", date1, date2, SecuritySystem.CurrentUserId)
					//criteria = New BinaryOperator("Mitarbeiter", SecuritySystem.CurrentUserId)
					
					
					string role = "";
					
					var user = SecuritySystem.CurrentUser as BusinessLogic.Intern.Mitarbeiter;
					
					if (!(user == null))
					{
						var roles = user.MitarbeiterRollen;
						foreach (BusinessLogic.Intern.MitarbeiterRolle r in roles)
						{
							role = System.Convert.ToString(r.Name);
						}
					}
					
					
					if (role == "Administrator" || role == "Distributeur" || role == "Telefonist")
					{
						//Dim list(HttpContext.Current.Session("AppointmentList").Count - 1) As String
						
						//For i = 0 To HttpContext.Current.Session("AppointmentList").Count - 1
						//    list(i) = HttpContext.Current.Session("AppointmentList")(i)
						//Next
						
						//criteria = New InOperator("Oid", list)
						criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[StartOn] between ( (?) , (?) ) AND [Mitarbeiter] = (?) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", date1, date2, SecuritySystem.CurrentUserId);
					}
					else
					{
						criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[StartOn] between ( (?) , (?) ) AND [Mitarbeiter] = (?) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", date1, date2, SecuritySystem.CurrentUserId);
					}
					
					sortProps.Add(new SortProperty("Mitarbeiter", DevExpress.Xpo.DB.SortingDirection.Ascending));
					sortProps.Add(new SortProperty("StartOn", DevExpress.Xpo.DB.SortingDirection.Ascending));
					patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, sess.TypesManager);
					
					appointments = sess.GetObjects(appointmentsClass, criteria, sortProps, 0, patcher, true);
					
					ObjectDataSource1.DataSource = appointments;
					
				}
				
			}
			else
			{
				
				Session sess = new Session();
				
				ICollection appointments = default(ICollection);
				DevExpress.Xpo.Metadata.XPClassInfo appointmentsClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
				DevExpress.Data.Filtering.CriteriaOperator criteria = default(DevExpress.Data.Filtering.CriteriaOperator);
				DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
				DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
				sess.ConnectionString = GlobalBase.CurrentConn;
				sortProps = new SortingCollection(null);
				appointmentsClass = sess.GetClassInfo<BusinessLogic.Basis.Termin>();
				DateTime dt = (DateTime)HttpContext.Current.Session["ShedulerDate"];
				criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Mitarbeiter] = (?) AND [SearchDate] = (?) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", SecuritySystem.CurrentUserId, DateTime.Now.Date.ToString("dd.MM.yyyy"));
				//criteria = New BinaryOperator("Mitarbeiter", SecuritySystem.CurrentUserId)
				sortProps.Add(new SortProperty("StartOn", DevExpress.Xpo.DB.SortingDirection.Ascending));
				patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, sess.TypesManager);
				
				appointments = sess.GetObjects(appointmentsClass, criteria, sortProps, 0, patcher, true);
				
				ObjectDataSource1.DataSource = appointments;
				
			}
			
		}
		
	}
}
