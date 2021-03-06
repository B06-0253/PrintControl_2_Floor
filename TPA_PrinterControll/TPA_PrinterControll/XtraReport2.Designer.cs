﻿namespace TPA_PrinterControll
{
    partial class XtraReport2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.DataMatrixGenerator dataMatrixGenerator1 = new DevExpress.XtraPrinting.BarCode.DataMatrixGenerator();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCountryOfProduct = new DevExpress.XtraReports.UI.XRLabel();
            this.lblFosterPart = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSupplierCode = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCustomerPart = new DevExpress.XtraReports.UI.XRLabel();
            this.lblSerialNumber = new DevExpress.XtraReports.UI.XRLabel();
            this.topMarginBand1 = new DevExpress.XtraReports.UI.TopMarginBand();
            this.bottomMarginBand1 = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel1});
            this.Detail.HeightF = 83.00001F;
            this.Detail.MultiColumn.ColumnWidth = 110F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.BorderWidth = 1F;
            this.xrPanel1.CanGrow = false;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarCode1,
            this.lblDate,
            this.lblCountryOfProduct,
            this.lblFosterPart,
            this.lblSupplierCode,
            this.lblCustomerPart,
            this.lblSerialNumber});
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.LockedInUserDesigner = true;
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(110F, 82.00001F);
            this.xrPanel1.SnapLinePadding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorderWidth = false;
            // 
            // xrBarCode1
            // 
            this.xrBarCode1.AutoModule = true;
            this.xrBarCode1.Font = new System.Drawing.Font("Arial Black", 9.75F);
            this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(37F, 49F);
            this.xrBarCode1.LockedInUserDesigner = true;
            this.xrBarCode1.Name = "xrBarCode1";
            this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.xrBarCode1.ShowText = false;
            this.xrBarCode1.SizeF = new System.Drawing.SizeF(30F, 30F);
            this.xrBarCode1.StylePriority.UseFont = false;
            this.xrBarCode1.StylePriority.UsePadding = false;
            this.xrBarCode1.StylePriority.UseTextAlignment = false;
            this.xrBarCode1.Symbology = dataMatrixGenerator1;
            this.xrBarCode1.Text = "1234";
            this.xrBarCode1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lblDate
            // 
            this.lblDate.BorderColor = System.Drawing.Color.Transparent;
            this.lblDate.CanGrow = false;
            this.lblDate.Font = new System.Drawing.Font("Franklin Gothic Medium", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)), true);
            this.lblDate.LocationFloat = new DevExpress.Utils.PointFloat(8.999999F, 54F);
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblDate.SizeF = new System.Drawing.SizeF(27F, 10F);
            this.lblDate.StylePriority.UseBorderColor = false;
            this.lblDate.StylePriority.UseFont = false;
            this.lblDate.StylePriority.UsePadding = false;
            this.lblDate.StylePriority.UseTextAlignment = false;
            this.lblDate.Text = "180629";
            this.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblCountryOfProduct
            // 
            this.lblCountryOfProduct.BorderColor = System.Drawing.Color.Transparent;
            this.lblCountryOfProduct.Font = new System.Drawing.Font("Franklin Gothic Medium", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)));
            this.lblCountryOfProduct.LocationFloat = new DevExpress.Utils.PointFloat(7F, 45F);
            this.lblCountryOfProduct.Name = "lblCountryOfProduct";
            this.lblCountryOfProduct.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblCountryOfProduct.SizeF = new System.Drawing.SizeF(29F, 9F);
            this.lblCountryOfProduct.StylePriority.UseBorderColor = false;
            this.lblCountryOfProduct.StylePriority.UseFont = false;
            this.lblCountryOfProduct.StylePriority.UsePadding = false;
            this.lblCountryOfProduct.StylePriority.UseTextAlignment = false;
            this.lblCountryOfProduct.Text = "VIETNAM";
            this.lblCountryOfProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblFosterPart
            // 
            this.lblFosterPart.BorderColor = System.Drawing.Color.Transparent;
            this.lblFosterPart.Font = new System.Drawing.Font("Franklin Gothic Medium", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)), true);
            this.lblFosterPart.LocationFloat = new DevExpress.Utils.PointFloat(68F, 45F);
            this.lblFosterPart.Name = "lblFosterPart";
            this.lblFosterPart.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblFosterPart.SizeF = new System.Drawing.SizeF(29F, 10F);
            this.lblFosterPart.StylePriority.UseBorderColor = false;
            this.lblFosterPart.StylePriority.UseFont = false;
            this.lblFosterPart.StylePriority.UsePadding = false;
            this.lblFosterPart.StylePriority.UseTextAlignment = false;
            this.lblFosterPart.Text = "604306";
            this.lblFosterPart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.BorderColor = System.Drawing.Color.Transparent;
            this.lblSupplierCode.CanGrow = false;
            this.lblSupplierCode.Font = new System.Drawing.Font("Franklin Gothic Medium", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.lblSupplierCode.LocationFloat = new DevExpress.Utils.PointFloat(9F, 24F);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblSupplierCode.SizeF = new System.Drawing.SizeF(86F, 9F);
            this.lblSupplierCode.StylePriority.UseBorderColor = false;
            this.lblSupplierCode.StylePriority.UseFont = false;
            this.lblSupplierCode.StylePriority.UsePadding = false;
            this.lblSupplierCode.StylePriority.UseTextAlignment = false;
            this.lblSupplierCode.Text = "105795-10 FOSTER";
            this.lblSupplierCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblSupplierCode.WordWrap = false;
            // 
            // lblCustomerPart
            // 
            this.lblCustomerPart.BorderColor = System.Drawing.Color.Transparent;
            this.lblCustomerPart.CanGrow = false;
            this.lblCustomerPart.Font = new System.Drawing.Font("Franklin Gothic Medium", 2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(1)), true);
            this.lblCustomerPart.LocationFloat = new DevExpress.Utils.PointFloat(9F, 33F);
            this.lblCustomerPart.Name = "lblCustomerPart";
            this.lblCustomerPart.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblCustomerPart.SizeF = new System.Drawing.SizeF(86F, 8.999996F);
            this.lblCustomerPart.StylePriority.UseBorderColor = false;
            this.lblCustomerPart.StylePriority.UseFont = false;
            this.lblCustomerPart.StylePriority.UsePadding = false;
            this.lblCustomerPart.StylePriority.UseTextAlignment = false;
            this.lblCustomerPart.Text = "XXXX  8715683-01";
            this.lblCustomerPart.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblCustomerPart.WordWrap = false;
            // 
            // lblSerialNumber
            // 
            this.lblSerialNumber.BorderColor = System.Drawing.Color.Transparent;
            this.lblSerialNumber.Font = new System.Drawing.Font("Franklin Gothic Medium", 1.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter, ((byte)(0)), true);
            this.lblSerialNumber.LocationFloat = new DevExpress.Utils.PointFloat(68F, 55F);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lblSerialNumber.SizeF = new System.Drawing.SizeF(29F, 9F);
            this.lblSerialNumber.StylePriority.UseBorderColor = false;
            this.lblSerialNumber.StylePriority.UseFont = false;
            this.lblSerialNumber.StylePriority.UsePadding = false;
            this.lblSerialNumber.StylePriority.UseTextAlignment = false;
            this.lblSerialNumber.Text = "0001";
            this.lblSerialNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // topMarginBand1
            // 
            this.topMarginBand1.HeightF = 0F;
            this.topMarginBand1.Name = "topMarginBand1";
            // 
            // bottomMarginBand1
            // 
            this.bottomMarginBand1.HeightF = 0F;
            this.bottomMarginBand1.Name = "bottomMarginBand1";
            // 
            // XtraReport2
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.topMarginBand1,
            this.bottomMarginBand1});
            this.Font = new System.Drawing.Font("MS Gothic", 4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 112;
            this.PageWidth = 120;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PrinterName = "POSTEK G-3106";
            this.SnapGridSize = 2F;
            this.Version = "13.2";
            this.Watermark.Font = new System.Drawing.Font("Verdana", 1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Millimeter);
            this.Watermark.TextTransparency = 20;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.TopMarginBand topMarginBand1;
        private DevExpress.XtraReports.UI.BottomMarginBand bottomMarginBand1;
        private DevExpress.XtraReports.UI.XRLabel lblSerialNumber;
        private DevExpress.XtraReports.UI.XRLabel lblCustomerPart;
        private DevExpress.XtraReports.UI.XRLabel lblSupplierCode;
        private DevExpress.XtraReports.UI.XRLabel lblFosterPart;
        private DevExpress.XtraReports.UI.XRLabel lblCountryOfProduct;
        private DevExpress.XtraReports.UI.XRLabel lblDate;
        private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
    }
}
