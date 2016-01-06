// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports


namespace AdressenManagement.Module
{
	namespace BusinessLogic.Intern
	{
		
		public class RecensaWatch : IDisposable
		{
			
			
			public Stopwatch TotalTimeWatch;
			public Stopwatch PartialTimeWatch;
			public List<int> UserInactivityTimeList;
			public ZeitstempelObjekt RecensaZeitstempelObjekt;
			
			public RecensaWatch(ZeitstempelObjekt pZeitStempelObjekt)
			{
				
				TotalTimeWatch = new Stopwatch();
				TotalTimeWatch.Start();
				
				PartialTimeWatch = new Stopwatch();
				PartialTimeWatch.Start();
				
				UserInactivityTimeList = new List<int>();
				RecensaZeitstempelObjekt = pZeitStempelObjekt;
				
			}
			
			public void AddTime()
			{
				if (!(RecensaZeitstempelObjekt == null))
				{
					RecensaZeitstempelObjekt.AddTime(TotalTimeWatch.Elapsed);
				}
			}
			
			public void RemoveTime()
			{
				if (!(RecensaZeitstempelObjekt == null))
				{
					RecensaZeitstempelObjekt.RemoveTime(PartialTimeWatch.Elapsed);
				}
			}
			
#region IDisposable Support
			private bool disposedValue; // So ermitteln Sie überflüssige Aufrufe
			
			protected virtual void Dispose(bool disposing)
			{
				if (!this.disposedValue)
				{
					if (disposing)
					{
						TotalTimeWatch.Stop();
						PartialTimeWatch.Stop();
						TotalTimeWatch = null;
						PartialTimeWatch = null;
						UserInactivityTimeList.Clear();
						UserInactivityTimeList = null;
						RecensaZeitstempelObjekt = null;
					}
				}
				this.disposedValue = true;
			}
			
			// TODO: Finalize() nur überschreiben, wenn Dispose(ByVal disposing As Boolean) oben über Code zum Freigeben von nicht verwalteten Ressourcen verfügt.
			~RecensaWatch()
			{
				Dispose(false);
				//base.Finalize();
			}
			
			// Dieser Code wird von Visual Basic hinzugefügt, um das Dispose-Muster richtig zu implementieren.
			public void Dispose()
			{
				Dispose(true);
				GC.SuppressFinalize(this);
			}
#endregion
			
		}
		
	}
}
