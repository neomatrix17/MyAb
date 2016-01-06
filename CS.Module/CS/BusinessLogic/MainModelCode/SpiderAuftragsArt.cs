// VBConversions Note: VB project level imports
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
// End of VB project level imports

using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using System.ComponentModel;

namespace AdressenManagement.Module
{
	namespace MainModel
	{
		
		public partial class SpiderAuftragsArt
		{
			public SpiderAuftragsArt(Session session) : base(session)
			{
			}
			public override void AfterConstruction()
			{
				base.AfterConstruction();
			}
		}
		
	}
	
}
