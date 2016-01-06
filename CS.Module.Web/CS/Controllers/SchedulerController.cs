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
using DevExpress.Persistent.Base.General;
using DevExpress.ExpressApp.Scheduler.Web;
using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using System.Drawing;
using DevExpress.ExpressApp.Web.Editors;
using System.Windows.Threading;
using System.Web;

namespace AdressenManagement.Module.Web
{
	
	// For more typical usage scenarios, be sure to check out http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppViewControllertopic.
	public partial class SchedulerController : ViewController
	{
		
		private ASPxScheduler pScheduler;
		private bool isInitRun = true;
		private Stopwatch watch = new Stopwatch();
		
		public SchedulerController()
		{
			InitializeComponent();
			// Target required Views (via the TargetXXX properties) and create their Actions.
		}
		protected override void OnActivated()
		{
			base.OnActivated();
			// Perform various tasks depending on the target View.
			
			if (!(View == null))
			{
				if (!(View.ObjectTypeInfo == null))
				{
					if (View.ObjectTypeInfo.Implements<IEvent>())
					{
						View.ControlsCreated += View_ControlsCreated;
					}
				}
			}
			
			Frame.GetController<DevExpress.ExpressApp.Scheduler.Web.SchedulerActionsController>().EditSeriesAction.Active.SetItemValue("myReason", false);
			Frame.GetController<DevExpress.ExpressApp.Scheduler.Web.SchedulerActionsController>().OpenSeriesAction.Active.SetItemValue("myreason", false);
			Frame.GetController<DevExpress.ExpressApp.Scheduler.Web.SchedulerActionsController>().RestoreOccurrenceAction.Active.SetItemValue("myreason", false);
			
		}
		
		private void View_ControlsCreated(object sender, EventArgs e)
		{
			
			ListView currentView = View as ListView;
			
			if (!(currentView == null))
			{
				
				ASPxSchedulerListEditor listEditor = currentView.Editor as ASPxSchedulerListEditor;
				
				if (!(listEditor == null))
				{
					ASPxScheduler scheduler = listEditor.SchedulerControl;
					
					if (!(scheduler == null))
					{
						scheduler.Views.DayView.VisibleTime = new TimeOfDayInterval(new TimeSpan(7, 0, 0), new TimeSpan(22, 0, 0));
						scheduler.Views.WorkWeekView.VisibleTime = new TimeOfDayInterval(new TimeSpan(7, 0, 0), new TimeSpan(22, 0, 0));
						scheduler.Views.FullWeekView.VisibleTime = new TimeOfDayInterval(new TimeSpan(7, 0, 0), new TimeSpan(22, 0, 0));
						scheduler.WorkDays.BeginUpdate();
						scheduler.WorkDays.Clear();
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Monday);
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Tuesday);
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Wednesday);
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Thursday);
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Friday);
						scheduler.WorkDays.Add(DevExpress.XtraScheduler.WeekDays.Saturday);
						scheduler.WorkDays.EndUpdate();
						scheduler.OptionsLoadingPanel.Delay = 0;
						scheduler.OptionsCustomization.AllowAppointmentResize = UsedAppointmentType.Custom;
						scheduler.OptionsCustomization.AllowAppointmentDragBetweenResources = UsedAppointmentType.Custom;
						scheduler.OptionsCustomization.AllowAppointmentDrag = UsedAppointmentType.Custom;
						scheduler.ActiveViewType = SchedulerViewType.Day;
						scheduler.EnablePagingGestures = DevExpress.Web.AutoBoolean.False;
						scheduler.DayView.ShowMoreButtons = false;
						scheduler.DayView.ShowMoreButtonsOnEachColumn = false;
						
						pScheduler = scheduler;
						
						ASPxSchedulerListEditor schedulerListEditor = currentView.Editor as ASPxSchedulerListEditor;
						if (schedulerListEditor != null)
						{
							schedulerListEditor.ResourceDataSourceCreated += ResourceDataSource_Created;
						}
						
						scheduler.PopupMenuShowing += PopupMenue_Show;
						scheduler.ResourceCollectionLoaded += ResourceDataSourceCreated;
						scheduler.AppointmentViewInfoCustomizing += AppointmentViewInfo_Customizing;
						scheduler.AllowAppointmentDrag += Appointment_CanDrag;
						scheduler.AllowAppointmentResize += Allow_Resize;
						scheduler.AllowAppointmentDragBetweenResources += Allow_DragResources;
						
					}
					
				}
				
			}
			
		}
		
		protected override void OnViewControlsCreated()
		{
			base.OnViewControlsCreated();
		}
		protected override void OnDeactivated()
		{
			base.OnDeactivated();
		}
		
		private void PopupMenue_Show(object sender, DevExpress.Web.ASPxScheduler.PopupMenuShowingEventArgs e)
		{
			
			var deleteItem = e.Menu.Items.FindByName("Xaf_Delete");
			
			if (!(deleteItem == null))
			{
				deleteItem.Visible = false;
			}
			
			var item = e.Menu.Items.FindByName("Xaf_TerminBerichtOeffnen");
			
			if (!(item == null))
			{
				item.Visible = false;
			}
			
		}
		
		private void AppointmentViewInfo_Customizing(object sender, DevExpress.Web.ASPxScheduler.AppointmentViewInfoCustomizingEventArgs e)
		{
			
			DevExpress.Web.ASPxScheduler.Drawing.AppointmentViewInfo appointmentViewInfo = e.ViewInfo as DevExpress.Web.ASPxScheduler.Drawing.AppointmentViewInfo;
			if (!(appointmentViewInfo == null))
			{
				
				var termin = appointmentViewInfo.Appointment;
				
				var id = termin.Id;
				
				var allAppList = ObjectSpace.GetObjects<BusinessLogic.Basis.Termin>();
				
				foreach (BusinessLogic.Basis.Termin ter in allAppList)
				{
					
					try
					{
						if (ter.AppointmentId == id)
						{
							if (!(ter.TerminArt == null))
							{
								if (!ter.TerminArt.TerminFarbe.IsEmpty)
								{
									appointmentViewInfo.StatusDisplayType = AppointmentStatusDisplayType.Never;
									appointmentViewInfo.AppointmentStyle.Border.BorderColor = ter.TerminArt.TerminFarbe;
									appointmentViewInfo.AppointmentStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid;
									appointmentViewInfo.AppointmentStyle.Border.BorderWidth = new System.Web.UI.WebControls.Unit(5);
								}
							}
							if (!(ter.Gesprächsergebnis == null))
							{
								if (!ter.Gesprächsergebnis.TerminFarbe.IsEmpty)
								{
									appointmentViewInfo.AppointmentStyle.BackColor = ter.Gesprächsergebnis.TerminFarbe;
								}
							}
							
							if (!(ter.TerminBericht == null))
							{
								
								if (appointmentViewInfo.HasLeftBorder)
								{
									if (appointmentViewInfo.Appointment.SameDay)
									{
										if (ter.TerminBericht.VerkauteHProdukte.Count > 0)
										{
											appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroGreen.png";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
										}
										else if (ter.TerminBericht.VerkauteNProdukte.Count > 0)
										{
											appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroPink.png";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
										}
										else
										{
											
										}
									}
									else
									{
										if (ter.TerminBericht.VerkauteHProdukte.Count > 0)
										{
											appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroGreen16.png";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
										}
										else if (ter.TerminBericht.VerkauteNProdukte.Count > 0)
										{
											appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroPink16.png";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
											appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
										}
										else
										{
											
										}
									}
								}
								else
								{
									if (ter.TerminBericht.VerkauteHProdukte.Count > 0)
									{
										appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroGreen16.png";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
									}
									else if (ter.TerminBericht.VerkauteNProdukte.Count > 0)
									{
										appointmentViewInfo.AppointmentStyle.BackgroundImage.ImageUrl = "~/Images/AdressenManagement.Module.Images.EuroPink16.png";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.HorizontalPosition = "right";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.VerticalPosition = "bottom";
										appointmentViewInfo.AppointmentStyle.BackgroundImage.Repeat = DevExpress.Web.BackgroundImageRepeat.NoRepeat;
									}
									else
									{
										
									}
								}
								
							}
							
						}
					}
					catch (Exception)
					{
						
					}
					
				}
				
			}
			
		}
		
		private void ResourceDataSourceCreated(object sender, EventArgs e)
		{
			
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
			
			
			if (!(role == "Administrator") && !(role == "Telefonist") && !(role == "Distributeur"))
			{
				
				var collection = sender as DevExpress.Web.ASPxScheduler.ASPxSchedulerStorage;
				
				if (!(collection == null))
				{
					
					foreach (DevExpress.XtraScheduler.Resource r in collection.Resources.Items)
					{
						if (!(r.Caption == ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).Caption))
						{
							r.Visible = false;
						}
					}
					
				}
				
			}
			else
			{
				var collection = sender as DevExpress.Web.ASPxScheduler.ASPxSchedulerStorage;
				
				if (!(collection == null))
				{
					
					foreach (DevExpress.XtraScheduler.Resource r in collection.Resources.Items)
					{
						if (r.Caption == " ")
						{
							r.Visible = false;
						}
						else
						{
							if (!IsValidUser(r.Caption))
							{
								r.Visible = false;
							}
						}
					}
					
				}
			}
			
		}
		
		private bool IsValidUser(string pCaption)
		{
			
			bool isValid = true;
			
			var ma = ObjectSpace.GetObjects<BusinessLogic.Intern.Mitarbeiter>();
			
			foreach (BusinessLogic.Intern.Mitarbeiter m in ma)
			{
				if (m.Caption == pCaption)
				{
					if (m.IsActive == false)
					{
						isValid = false;
					}
				}
			}
			
			return isValid;
			
		}
		
		private void Appointment_CanDrag(object sender, AppointmentOperationEventArgs e)
		{
			
			e.Allow = false;
			
		}
		
		private void Allow_Resize(object sender, AppointmentOperationEventArgs e)
		{
			
			e.Allow = false;
			
		}
		
		private void Allow_DragResources(object sender, AppointmentOperationEventArgs e)
		{
			
			e.Allow = false;
			
		}
		
		private void ResourceDataSource_Created(object sender, DevExpress.ExpressApp.Scheduler.ResourceDataSourceCreatedEventArgs e)
		{
			
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
			
			if (!(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).SelectedResourceName == null) && !(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).SelectedResourceName == ""))
			{
				
				DevExpress.Web.ASPxScheduler.SchedulerViewBase currentSchedulerView = ((ASPxSchedulerListEditor) sender).SchedulerControl.ActiveView;
				IList resources = (IList) (((WebDataSource) e.DataSource).Collection);
				
				foreach (BusinessLogic.Intern.Mitarbeiter resource in resources)
				{
					
					if (!resource.IsKunde.HasValue)
					{
						if (resource.UserName == ((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).SelectedResourceName)
						{
							((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).SelectedResourceName = null;
							currentSchedulerView.FirstVisibleResourceIndex = resources.IndexOf(resource);
							currentSchedulerView.ResourcesPerPage = 1;
							if (!(pScheduler.Storage == null))
							{
								currentSchedulerView.SetSelection(currentSchedulerView.SelectedInterval, pScheduler.Storage.Resources.GetResourceById(resource.MitarbeiterUniqueId));
							}
							break;
						}
						
					}
					
				}
				
			}
			else
			{
				
				if (isInitRun)
				{
					isInitRun = false;
					if (!(pScheduler.Storage == null))
					{
						pScheduler.ActiveView.SetSelection(pScheduler.ActiveView.SelectedInterval, pScheduler.Storage.Resources.GetResourceById(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).MitarbeiterUniqueId));
						watch.Restart();
					}
				}
				else
				{
					
					if (watch.Elapsed.TotalSeconds > 5)
					{
						watch.Restart();
						ListView currentView = View as ListView;
						
						if (!(currentView == null))
						{
							
							ASPxSchedulerListEditor listEditor = currentView.Editor as ASPxSchedulerListEditor;
							
							if (!(listEditor == null))
							{
								ASPxScheduler scheduler = listEditor.SchedulerControl;
								
								var storage = scheduler.Storage;
								
								if (!(storage == null))
								{
									scheduler.ActiveView.SetSelection(scheduler.ActiveView.SelectedInterval, scheduler.Storage.Resources.GetResourceById(((BusinessLogic.Intern.Mitarbeiter) SecuritySystem.CurrentUser).MitarbeiterUniqueId));
								}
								
							}
							
						}
					}
					
				}
				
				//TODO Test this
				
			}
			
		}
		
		private void Res_Changed(object sender, PersistentObjectsEventArgs e)
		{
			
		}
		
		private void Res_Changing(object sender, PersistentObjectCancelEventArgs e)
		{
			
		}
		
	}
}
