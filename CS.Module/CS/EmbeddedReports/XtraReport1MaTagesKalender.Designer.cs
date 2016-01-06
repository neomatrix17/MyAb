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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class XtraReport1MaTagesKalender : DevExpress.XtraReports.UI.XtraReport
	{
		
		//XtraReport overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		//Required by the Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Designer
		//It can be modified using the Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.XrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel17 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel18 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel19 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel20 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel21 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel23 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel24 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel25 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel27 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel29 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel30 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel31 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLine1 = new DevExpress.XtraReports.UI.XRLine();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.XrLabel22 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageFooterBand1 = new DevExpress.XtraReports.UI.PageFooterBand();
			this.XrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.XrPageInfo2 = new DevExpress.XtraReports.UI.XRPageInfo();
			this.ReportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
			this.XrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.XrLabel33 = new DevExpress.XtraReports.UI.XRLabel();
			this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
			this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
			this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
			this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
			this.ObjectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
			((System.ComponentModel.ISupportInitialize) this.ObjectDataSource1).BeginInit();
			((System.ComponentModel.ISupportInitialize) this).BeginInit();
			//
			//Detail
			//
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {this.XrLabel8, this.XrLabel7, this.XrLabel6, this.XrLabel1, this.XrLabel2, this.XrLabel3, this.XrLabel4, this.XrLabel5, this.XrLabel9, this.XrLabel13, this.XrLabel17, this.XrLabel18, this.XrLabel19, this.XrLabel20, this.XrLabel21, this.XrLabel23, this.XrLabel24, this.XrLabel25, this.XrLabel27, this.XrLabel29, this.XrLabel30, this.XrLabel31, this.XrLine1});
			this.Detail.HeightF = (float) (227.9821F);
			this.Detail.KeepTogether = true;
			this.Detail.KeepTogetherWithDetailReports = true;
			this.Detail.Name = "Detail";
			this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, (float) (100.0F));
			this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			//
			//XrLabel8
			//
			this.XrLabel8.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispDate")});
			this.XrLabel8.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0001F), (float) (32.99999F));
			this.XrLabel8.Name = "XrLabel8";
			this.XrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel8.SizeF = new System.Drawing.SizeF((float) (84.08322F), (float) (18.0F));
			this.XrLabel8.Text = "XrLabel8";
			//
			//XrLabel7
			//
			this.XrLabel7.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.000042F), (float) (182.7916F));
			this.XrLabel7.Name = "XrLabel7";
			this.XrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel7.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel7.StyleName = "FieldCaption";
			this.XrLabel7.Text = "Letzter Empfehlungsgeber";
			//
			//XrLabel6
			//
			this.XrLabel6.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "EmpfDispName")});
			this.XrLabel6.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (182.7916F));
			this.XrLabel6.Name = "XrLabel6";
			this.XrLabel6.NullValueText = "Kein Empfehlungsgeber vorhanden...";
			this.XrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel6.SizeF = new System.Drawing.SizeF((float) (657.0001F), (float) (18.00003F));
			//
			//XrLabel1
			//
			this.XrLabel1.Font = new System.Drawing.Font("Times New Roman", (float) (10.0F));
			this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.0F), (float) (9.0F));
			this.XrLabel1.Name = "XrLabel1";
			this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel1.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel1.StyleName = "FieldCaption";
			this.XrLabel1.StylePriority.UseFont = false;
			this.XrLabel1.Text = "Name/Haushalt";
			//
			//XrLabel2
			//
			this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.000056F), (float) (84.99249F));
			this.XrLabel2.Name = "XrLabel2";
			this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel2.SizeF = new System.Drawing.SizeF((float) (224.9999F), (float) (18.0F));
			this.XrLabel2.StyleName = "FieldCaption";
			this.XrLabel2.Text = "Beschreibung";
			//
			//XrLabel3
			//
			this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.000056F), (float) (60.99244F));
			this.XrLabel3.Name = "XrLabel3";
			this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel3.SizeF = new System.Drawing.SizeF((float) (224.9999F), (float) (18.0F));
			this.XrLabel3.StyleName = "FieldCaption";
			this.XrLabel3.Text = "Termin Art";
			//
			//XrLabel4
			//
			this.XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat((float) (5.999998F), (float) (108.9925F));
			this.XrLabel4.Name = "XrLabel4";
			this.XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel4.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel4.StyleName = "FieldCaption";
			this.XrLabel4.Text = "Gesprächsnotiz";
			//
			//XrLabel5
			//
			this.XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat((float) (5.999998F), (float) (132.9925F));
			this.XrLabel5.Name = "XrLabel5";
			this.XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel5.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel5.StyleName = "FieldCaption";
			this.XrLabel5.Text = "Adresse";
			//
			//XrLabel9
			//
			this.XrLabel9.ForeColor = System.Drawing.Color.Black;
			this.XrLabel9.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.000056F), (float) (33.0F));
			this.XrLabel9.Name = "XrLabel9";
			this.XrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel9.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel9.StyleName = "FieldCaption";
			this.XrLabel9.StylePriority.UseForeColor = false;
			this.XrLabel9.Text = "Termin am/um";
			//
			//XrLabel13
			//
			this.XrLabel13.ForeColor = System.Drawing.Color.Black;
			this.XrLabel13.LocationFloat = new DevExpress.Utils.PointFloat((float) (5.999998F), (float) (205.0F));
			this.XrLabel13.Name = "XrLabel13";
			this.XrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel13.SizeF = new System.Drawing.SizeF((float) (225.0F), (float) (18.0F));
			this.XrLabel13.StyleName = "FieldCaption";
			this.XrLabel13.StylePriority.UseForeColor = false;
			this.XrLabel13.StylePriority.UseTextAlignment = false;
			this.XrLabel13.Text = "Telefon Nummern:";
			this.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			//
			//XrLabel17
			//
			this.XrLabel17.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispName")});
			this.XrLabel17.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold);
			this.XrLabel17.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (9.0F));
			this.XrLabel17.Name = "XrLabel17";
			this.XrLabel17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel17.SizeF = new System.Drawing.SizeF((float) (657.0F), (float) (18.0F));
			this.XrLabel17.StyleName = "DataField";
			this.XrLabel17.StylePriority.UseFont = false;
			//
			//XrLabel18
			//
			this.XrLabel18.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Beschreibung")});
			this.XrLabel18.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0001F), (float) (84.99249F));
			this.XrLabel18.Name = "XrLabel18";
			this.XrLabel18.NullValueText = "Keine Beschreibung vorhanden...";
			this.XrLabel18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel18.SizeF = new System.Drawing.SizeF((float) (656.9999F), (float) (18.0F));
			this.XrLabel18.StyleName = "DataField";
			this.XrLabel18.Text = "XrLabel18";
			//
			//XrLabel19
			//
			this.XrLabel19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Description")});
			this.XrLabel19.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (60.99244F));
			this.XrLabel19.Name = "XrLabel19";
			this.XrLabel19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel19.SizeF = new System.Drawing.SizeF((float) (657.0F), (float) (18.0F));
			this.XrLabel19.StyleName = "DataField";
			this.XrLabel19.Text = "XrLabel19";
			//
			//XrLabel20
			//
			this.XrLabel20.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Gesprächsnotiz")});
			this.XrLabel20.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (108.9925F));
			this.XrLabel20.Name = "XrLabel20";
			this.XrLabel20.NullValueText = "Keine Notizen vorhanden...";
			this.XrLabel20.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel20.SizeF = new System.Drawing.SizeF((float) (657.0F), (float) (18.0F));
			this.XrLabel20.StyleName = "DataField";
			this.XrLabel20.Text = "XrLabel20";
			//
			//XrLabel21
			//
			this.XrLabel21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispLand")});
			this.XrLabel21.LocationFloat = new DevExpress.Utils.PointFloat((float) (470.7045F), (float) (157.9924F));
			this.XrLabel21.Name = "XrLabel21";
			this.XrLabel21.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel21.SizeF = new System.Drawing.SizeF((float) (423.2954F), (float) (18.0F));
			this.XrLabel21.StyleName = "DataField";
			//
			//XrLabel23
			//
			this.XrLabel23.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Ortschaft")});
			this.XrLabel23.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (157.9924F));
			this.XrLabel23.Name = "XrLabel23";
			this.XrLabel23.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel23.SizeF = new System.Drawing.SizeF((float) (233.7045F), (float) (18.0F));
			this.XrLabel23.StyleName = "DataField";
			this.XrLabel23.Text = "XrLabel23";
			//
			//XrLabel24
			//
			this.XrLabel24.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Postleitzahl", "Plz.: {0}")});
			this.XrLabel24.LocationFloat = new DevExpress.Utils.PointFloat((float) (470.7045F), (float) (132.9925F));
			this.XrLabel24.Name = "XrLabel24";
			this.XrLabel24.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel24.SizeF = new System.Drawing.SizeF((float) (423.2954F), (float) (18.0F));
			this.XrLabel24.StyleName = "DataField";
			//
			//XrLabel25
			//
			this.XrLabel25.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispStart", "Um {0} Uhr")});
			this.XrLabel25.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold);
			this.XrLabel25.ForeColor = System.Drawing.Color.Black;
			this.XrLabel25.LocationFloat = new DevExpress.Utils.PointFloat((float) (321.0833F), (float) (32.99999F));
			this.XrLabel25.Name = "XrLabel25";
			this.XrLabel25.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel25.SizeF = new System.Drawing.SizeF((float) (572.9168F), (float) (18.0F));
			this.XrLabel25.StyleName = "DataField";
			this.XrLabel25.StylePriority.UseFont = false;
			this.XrLabel25.StylePriority.UseForeColor = false;
			this.XrLabel25.XlsxFormatString = "{0:HH:mm}";
			//
			//XrLabel27
			//
			this.XrLabel27.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "Strasse")});
			this.XrLabel27.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (132.9925F));
			this.XrLabel27.Name = "XrLabel27";
			this.XrLabel27.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel27.SizeF = new System.Drawing.SizeF((float) (233.7045F), (float) (17.99998F));
			this.XrLabel27.StyleName = "DataField";
			this.XrLabel27.Text = "XrLabel27";
			//
			//XrLabel29
			//
			this.XrLabel29.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispTel1")});
			this.XrLabel29.LocationFloat = new DevExpress.Utils.PointFloat((float) (237.0F), (float) (205.0F));
			this.XrLabel29.Name = "XrLabel29";
			this.XrLabel29.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel29.SizeF = new System.Drawing.SizeF((float) (110.125F), (float) (18.0F));
			this.XrLabel29.StyleName = "DataField";
			//
			//XrLabel30
			//
			this.XrLabel30.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispTel2")});
			this.XrLabel30.LocationFloat = new DevExpress.Utils.PointFloat((float) (357.4544F), (float) (205.0F));
			this.XrLabel30.Name = "XrLabel30";
			this.XrLabel30.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel30.SizeF = new System.Drawing.SizeF((float) (113.2501F), (float) (18.0F));
			this.XrLabel30.StyleName = "DataField";
			//
			//XrLabel31
			//
			this.XrLabel31.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispTel3")});
			this.XrLabel31.LocationFloat = new DevExpress.Utils.PointFloat((float) (485.2879F), (float) (205.0F));
			this.XrLabel31.Name = "XrLabel31";
			this.XrLabel31.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel31.SizeF = new System.Drawing.SizeF((float) (112.2083F), (float) (18.0F));
			this.XrLabel31.StyleName = "DataField";
			//
			//XrLine1
			//
			this.XrLine1.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.0F), (float) (3.0F));
			this.XrLine1.Name = "XrLine1";
			this.XrLine1.SizeF = new System.Drawing.SizeF((float) (888.0F), (float) (2.0F));
			//
			//TopMargin
			//
			this.TopMargin.HeightF = (float) (72.53788F);
			this.TopMargin.Name = "TopMargin";
			this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, (float) (100.0F));
			this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			//
			//BottomMargin
			//
			this.BottomMargin.HeightF = (float) (100.0F);
			this.BottomMargin.Name = "BottomMargin";
			this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, (float) (100.0F));
			this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
			//
			//XrLabel22
			//
			this.XrLabel22.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {new DevExpress.XtraReports.UI.XRBinding("Text", null, "DispMa")});
			this.XrLabel22.Font = new System.Drawing.Font("Times New Roman", (float) (21.0F));
			this.XrLabel22.LocationFloat = new DevExpress.Utils.PointFloat((float) (456.0F), (float) (6.000014F));
			this.XrLabel22.Name = "XrLabel22";
			this.XrLabel22.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel22.SizeF = new System.Drawing.SizeF((float) (438.0F), (float) (34.99999F));
			this.XrLabel22.StyleName = "DataField";
			this.XrLabel22.StylePriority.UseFont = false;
			this.XrLabel22.StylePriority.UseTextAlignment = false;
			this.XrLabel22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			//
			//PageFooterBand1
			//
			this.PageFooterBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {this.XrPageInfo1, this.XrPageInfo2});
			this.PageFooterBand1.HeightF = (float) (49.8333F);
			this.PageFooterBand1.Name = "PageFooterBand1";
			//
			//XrPageInfo1
			//
			this.XrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.0F), (float) (6.0F));
			this.XrPageInfo1.Name = "XrPageInfo1";
			this.XrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
			this.XrPageInfo1.SizeF = new System.Drawing.SizeF((float) (438.0F), (float) (23.0F));
			this.XrPageInfo1.StyleName = "PageInfo";
			//
			//XrPageInfo2
			//
			this.XrPageInfo2.Format = "Seite {0} von {1}";
			this.XrPageInfo2.LocationFloat = new DevExpress.Utils.PointFloat((float) (456.0F), (float) (6.0F));
			this.XrPageInfo2.Name = "XrPageInfo2";
			this.XrPageInfo2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrPageInfo2.SizeF = new System.Drawing.SizeF((float) (438.0F), (float) (23.0F));
			this.XrPageInfo2.StyleName = "PageInfo";
			this.XrPageInfo2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
			//
			//ReportHeaderBand1
			//
			this.ReportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {this.XrLabel10, this.XrLabel33, this.XrLabel22});
			this.ReportHeaderBand1.HeightF = (float) (68.62501F);
			this.ReportHeaderBand1.Name = "ReportHeaderBand1";
			//
			//XrLabel10
			//
			this.XrLabel10.ForeColor = System.Drawing.Color.Red;
			this.XrLabel10.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.00001F), (float) (41.00002F));
			this.XrLabel10.Name = "XrLabel10";
			this.XrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel10.SizeF = new System.Drawing.SizeF((float) (888.0002F), (float) (23.0F));
			this.XrLabel10.StylePriority.UseForeColor = false;
			this.XrLabel10.StylePriority.UseTextAlignment = false;
			this.XrLabel10.Text = "Das exportieren des Kalenders ist nur für den  jeweils angemeldeten Benutzer mögl" + 
				"ich.";
			this.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			//
			//XrLabel33
			//
			this.XrLabel33.LocationFloat = new DevExpress.Utils.PointFloat((float) (6.00001F), (float) (6.00001F));
			this.XrLabel33.Name = "XrLabel33";
			this.XrLabel33.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			this.XrLabel33.SizeF = new System.Drawing.SizeF((float) (438.0F), (float) (35.0F));
			this.XrLabel33.StyleName = "Title";
			this.XrLabel33.Text = "Mitarbeiter Kalender";
			//
			//Title
			//
			this.Title.BackColor = System.Drawing.Color.Transparent;
			this.Title.BorderColor = System.Drawing.Color.Black;
			this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.Title.BorderWidth = (float) (1.0F);
			this.Title.Font = new System.Drawing.Font("Times New Roman", (float) (21.0F));
			this.Title.ForeColor = System.Drawing.Color.Black;
			this.Title.Name = "Title";
			//
			//FieldCaption
			//
			this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
			this.FieldCaption.BorderColor = System.Drawing.Color.Black;
			this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.FieldCaption.BorderWidth = (float) (1.0F);
			this.FieldCaption.Font = new System.Drawing.Font("Times New Roman", (float) (10.0F));
			this.FieldCaption.ForeColor = System.Drawing.Color.Black;
			this.FieldCaption.Name = "FieldCaption";
			//
			//PageInfo
			//
			this.PageInfo.BackColor = System.Drawing.Color.Transparent;
			this.PageInfo.BorderColor = System.Drawing.Color.Black;
			this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.PageInfo.BorderWidth = (float) (1.0F);
			this.PageInfo.Font = new System.Drawing.Font("Arial", (float) (8.0F));
			this.PageInfo.ForeColor = System.Drawing.Color.Black;
			this.PageInfo.Name = "PageInfo";
			//
			//DataField
			//
			this.DataField.BackColor = System.Drawing.Color.Transparent;
			this.DataField.BorderColor = System.Drawing.Color.Black;
			this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
			this.DataField.BorderWidth = (float) (1.0F);
			this.DataField.Font = new System.Drawing.Font("Arial", (float) (9.0F));
			this.DataField.ForeColor = System.Drawing.Color.Black;
			this.DataField.Name = "DataField";
			this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, (float) (100.0F));
			//
			//ObjectDataSource1
			//
			this.ObjectDataSource1.DataSource = typeof(AdressenManagement.Module.BusinessLogic.Basis.Termin);
			this.ObjectDataSource1.Name = "ObjectDataSource1";
			//
			//XtraReport1MaTagesKalender
			//
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {this.Detail, this.TopMargin, this.BottomMargin, this.PageFooterBand1, this.ReportHeaderBand1});
			this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {this.ObjectDataSource1});
			this.DataSource = this.ObjectDataSource1;
			this.Landscape = true;
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 73, 100);
			this.PageHeight = 850;
			this.PageWidth = 1100;
			this.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
			this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {this.Title, this.FieldCaption, this.PageInfo, this.DataField});
			this.Version = "14.2";
			((System.ComponentModel.ISupportInitialize) this.ObjectDataSource1).EndInit();
			((System.ComponentModel.ISupportInitialize) this).EndInit();
			
		}
		internal DevExpress.XtraReports.UI.DetailBand Detail;
		internal DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		internal DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel1;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel2;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel3;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel4;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel5;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel9;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel13;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel17;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel18;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel19;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel20;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel21;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel22;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel23;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel24;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel25;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel27;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel29;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel30;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel31;
		internal DevExpress.XtraReports.UI.XRLine XrLine1;
		internal DevExpress.DataAccess.ObjectBinding.ObjectDataSource ObjectDataSource1;
		internal DevExpress.XtraReports.UI.PageFooterBand PageFooterBand1;
		internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo1;
		internal DevExpress.XtraReports.UI.XRPageInfo XrPageInfo2;
		internal DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderBand1;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel33;
		internal DevExpress.XtraReports.UI.XRControlStyle Title;
		internal DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
		internal DevExpress.XtraReports.UI.XRControlStyle PageInfo;
		internal DevExpress.XtraReports.UI.XRControlStyle DataField;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel6;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel7;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel8;
		internal DevExpress.XtraReports.UI.XRLabel XrLabel10;
	}
	
}
