// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using System.Windows.Threading;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.ExpressApp;
using System.Net.Mail;
using System.Xml;


namespace AdressenManagement.Module
{
	namespace Manager.Mail
	{
		
		public class MailManager
		{
			
			private bool isSendingMail = false;
			private int sendMailAtHour;
			private int sendMailAtMinute;
			public bool IsRunning;
			
			public MailManager()
			{
				
				GlobalBase.MailManager = this;
				
				Gurock.SmartInspect.SiAuto.Main.LogMessage("Mail Manager Initialized!");
				
				DevExpress.Xpo.Session ses = new DevExpress.Xpo.Session();
				ses.ConnectionString = GlobalBase.CurrentConn;
				
				ses.Connection = new System.Data.SqlClient.SqlConnection(System.Convert.ToString(ses.ConnectionString));
				ses.Connection.Open();
				
				var standardEinstellungen = ses.GetObjectByKey<MainModel.StandardEinstellungen>(1);
				
				if (!(standardEinstellungen == null))
				{
					sendMailAtHour = System.Convert.ToInt32(standardEinstellungen.Uhrzeit.Hour);
					sendMailAtMinute = System.Convert.ToInt32(standardEinstellungen.Uhrzeit.Minute);
				}
				else
				{
					sendMailAtHour = 6;
					sendMailAtMinute = 0;
				}
				
				System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(LoopDelivery));
				th.IsBackground = true;
				th.Start();
				
			}
			
			public void SetupNewTime()
			{
				
				try
				{
					DevExpress.Xpo.Session ses = new DevExpress.Xpo.Session();
					ses.ConnectionString = GlobalBase.CurrentConn;
					ses.Connection = new System.Data.SqlClient.SqlConnection(System.Convert.ToString(ses.ConnectionString));
					ses.Connection.Open();
					
					var standardEinstellungen = ses.GetObjectByKey<MainModel.StandardEinstellungen>(1);
					
					if (!(standardEinstellungen == null))
					{
						sendMailAtHour = System.Convert.ToInt32(standardEinstellungen.Uhrzeit.Hour);
						sendMailAtMinute = System.Convert.ToInt32(standardEinstellungen.Uhrzeit.Minute);
					}
					else
					{
						sendMailAtHour = 6;
						sendMailAtMinute = 0;
					}
				}
				catch (Exception)
				{
					
				}
				
			}
			
			private void LoopDelivery()
			{
				
				int msgCenter = 0;
				
				while (true)
				{
					
					IsRunning = true;
					
					try
					{
						System.Threading.Thread.Sleep(55000);
						
						msgCenter++;
						
						if (msgCenter >= 10)
						{
							msgCenter = 0;
							Gurock.SmartInspect.SiAuto.Main.LogMessage("Mail Manager Performing Check!");
						}
						
						if (DateTime.Now.Hour == sendMailAtHour && DateTime.Now.Minute == sendMailAtMinute || DateTime.Now.Hour == sendMailAtHour && DateTime.Now.Minute == sendMailAtMinute + 1 || DateTime.Now.Hour == sendMailAtHour && DateTime.Now.Minute == sendMailAtMinute - 1)
						{
							if (!isSendingMail)
							{
								Gurock.SmartInspect.SiAuto.Main.LogDebug("Sending Mail to Recipients!");
								isSendingMail = true;
								
								DevExpress.Xpo.Session ses = new DevExpress.Xpo.Session();
								ses.ConnectionString = GlobalBase.CurrentConn;
								ses.Connection = new System.Data.SqlClient.SqlConnection(System.Convert.ToString(ses.ConnectionString));
								ses.Connection.Open();
								
								var dl = XpoDefault.GetDataLayer(ses.Connection, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
								XPObjectSpaceProvider xPObjectSpaceProvider = new XPObjectSpaceProvider(new ConnectionDataStoreProvider(dl.Connection));
								var os = (DevExpress.ExpressApp.Xpo.XPObjectSpace) (xPObjectSpaceProvider.CreateUpdatingObjectSpace(false));
								var aboClients = os.GetObjects<BusinessLogic.Intern.Mitarbeiter>();
								
								foreach (BusinessLogic.Intern.Mitarbeiter aboUser in aboClients)
								{
									if (aboUser.TageskalenderAboniert)
									{
										
										if (!(aboUser.Email == null) && !(aboUser.Email == ""))
										{
											
											Session sess = new Session();
											
											DateTime dt = DateTime.Now.Date;
											DateTime dt1 = dt.AddDays(1);
											DateTime dt2 = dt.AddDays(0);
											
											ICollection appointments = default(ICollection);
											DevExpress.Xpo.Metadata.XPClassInfo appointmentsClass = default(DevExpress.Xpo.Metadata.XPClassInfo);
											DevExpress.Data.Filtering.CriteriaOperator criteria = default(DevExpress.Data.Filtering.CriteriaOperator);
											DevExpress.Xpo.SortingCollection sortProps = default(DevExpress.Xpo.SortingCollection);
											DevExpress.Xpo.Generators.CollectionCriteriaPatcher patcher = default(DevExpress.Xpo.Generators.CollectionCriteriaPatcher);
											sess.ConnectionString = GlobalBase.CurrentConn;
											sortProps = new SortingCollection(null);
											appointmentsClass = sess.GetClassInfo<BusinessLogic.Basis.Termin>();
											criteria = DevExpress.Data.Filtering.CriteriaOperator.Parse("[Mitarbeiter] = (?) AND [StartOn] between ( (?) , (?) ) AND Not [Gesprächsergebnis] In (\'24\', \'25\', \'26\')", aboUser.Oid, dt2, dt1);
											sortProps.Add(new SortProperty("StartOn", DevExpress.Xpo.DB.SortingDirection.Ascending));
											patcher = new DevExpress.Xpo.Generators.CollectionCriteriaPatcher(false, sess.TypesManager);
											
											appointments = sess.GetObjects(appointmentsClass, criteria, sortProps, 0, patcher, true);
											
											string mailBody = "Sie haben <span>" + System.Convert.ToString(appointments.Count) + "</span> Termin(e) für das heutige Datum.<p>&nbsp;</p>" + "\r\n" + "\r\n" + "\r\n";
											
											foreach (BusinessLogic.Basis.Termin ap in appointments)
											{
												
												string mailSubBody = "";
												
												if (!(ap.Adresse == null))
												{
													
													string cdata = "<style type=\"text/css\">" +".tg  {border-collapse:collapse;border-spacing:0;border-color:red;}" +".tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#aabcfe;color:#669;background-color:#e8edff;}" +".tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#aabcfe;color:#039;background-color:#b9c9fe;}" +".tg .tg-9hbo{font-weight:bold;vertical-align:top}" +".tg .tg-yw4l{vertical-align:top}" + "</style>" + "<table class=\"tg\">" + "<tr>" + "<th class=\"tg-9hbo\">Bezeichnung</th>" + "<th class=\"tg-9hbo\">Daten</th>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Terminart:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"red\">" + ap.Description + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Uhrzeit:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"green\">" + ap.StartOn.ToString("HH:mm") + " - " + ap.EndOn.ToString("HH:mm") + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 1:" + "</td>" + "<td class=\"tg-yw4l\"><a href=\"tel:" + ap.Adresse.TempTelefonNummer + "\">" + ap.Adresse.TempTelefonNummer + "</a>" + "</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 2:" + "</td>" + "<td class=\"tg-yw4l\"><a href=\"tel:" + ap.Adresse.TempTelefonNummer2 + "\">" + ap.Adresse.TempTelefonNummer2 + "</a>" + "</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 3:" + "</td>" + "<td class=\"tg-yw4l\"><a href=\"tel:" + ap.Adresse.TempTelefonNummer3 + "\">" + ap.Adresse.TempTelefonNummer3 + "</a>" + "</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Adresse:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"red\">" + ap.Adresse.AnzeigeName + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Empf. von:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"red\">" + ap.Empfehlungsgeber + "</font></td>"
													+ "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Notiz:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"black\">" + ap.Gesprächsnotiz + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Strasse:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"black\">" + ap.Adresse.Strasse + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Postleitzahl:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"black\">" + ap.Adresse.Postleitzahl + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Ortschaft:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"black\">" + ap.Adresse.Ortschaft + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Navigation:" + "</td>" + "<td class=\"tg-yw4l\"><a href=\"" + ap.ZuGoogleMaps + "\">Zu Google Maps</a></td>" + "</tr>" + "</table>" + "<p>&nbsp;</p>";
													
													mailSubBody += cdata;
												}
												else
												{
													
													string cdata = "<style type=\"text/css\">" +".tg  {border-collapse:collapse;border-spacing:0;border-color:red;}" +".tg td{font-family:Arial, sans-serif;font-size:14px;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#aabcfe;color:#669;background-color:#e8edff;}" +".tg th{font-family:Arial, sans-serif;font-size:14px;font-weight:normal;padding:10px 5px;border-style:solid;border-width:1px;overflow:hidden;word-break:normal;border-color:#aabcfe;color:#039;background-color:#b9c9fe;}" +".tg .tg-9hbo{font-weight:bold;vertical-align:top}" +".tg .tg-yw4l{vertical-align:top}" + "</style>" + "<table class=\"tg\">" + "<tr>" + "<th class=\"tg-9hbo\">Bezeichnung</th>" + "<th class=\"tg-9hbo\">Daten</th>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Terminart:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"red\">" + ap.Description + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Uhrzeit:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"green\">" + ap.StartOn.ToString("HH:mm") + " - " + ap.EndOn.ToString("HH:mm") + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 1:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 2:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Telefon 3:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Adresse:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Notiz:" + "</td>" + "<td class=\"tg-yw4l\"><font color=\"black\">" + ap.Gesprächsnotiz + "</font></td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Strasse:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Postleitzahl:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Ortschaft:" + "</td>"
													+ "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "<tr>" + "<td class=\"tg-yw4l\">" + "Navigation:" + "</td>" + "<td class=\"tg-yw4l\">Keine angabe</td>" + "</tr>" + "</table>" + "<p>&nbsp;</p>";
													
													mailSubBody += cdata;
													
												}
												
												mailBody += mailSubBody;
											}
											
											if (!string.IsNullOrEmpty(mailBody))
											{
												
												SmtpClient smtpServer = new SmtpClient();
												MailMessage mail = new MailMessage();
												
												var standardEinstellungen = sess.GetObjectByKey<MainModel.StandardEinstellungen>(1);
												
												if (!(standardEinstellungen == null))
												{
													smtpServer.Credentials = new System.Net.NetworkCredential(System.Convert.ToString(standardEinstellungen.Email), System.Convert.ToString(standardEinstellungen.Passwort));
													smtpServer.Port = System.Convert.ToInt32(standardEinstellungen.SmtpPort);
													smtpServer.Host = System.Convert.ToString(standardEinstellungen.SmtpServer);
													smtpServer.EnableSsl = System.Convert.ToBoolean(standardEinstellungen.SSL);
												}
												
												mail = new MailMessage();
												mail.IsBodyHtml = true;
												mail.From = new MailAddress(System.Convert.ToString(standardEinstellungen.Email),
													"Myab.eu Tageskalender Automailer", System.Text.Encoding.UTF8);
												
												mail.To.Add(System.Convert.ToString(aboUser.Email.ToString()));
												
												mail.Subject = "Myab.eu Tageskalender";
												mail.Body = mailBody;
												
												mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
												
												try
												{
													smtpServer.Send(mail);
												}
												catch (Exception ex)
												{
													isSendingMail = false;
													Gurock.SmartInspect.SiAuto.Main.LogException(ex);
												}
												
											}
											else
											{
												
											}
											
										}
										
									}
								}
								
							}
							
						}
						else
						{
							isSendingMail = false;
						}
						
					}
					catch (Exception)
					{
						isSendingMail = false;
					}
					
					IsRunning = false;
					
				}
				
			}
			
		}
		
	}
}
