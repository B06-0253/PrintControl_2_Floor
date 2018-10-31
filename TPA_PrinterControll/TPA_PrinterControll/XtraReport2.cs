﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Linq;

namespace TPA_PrinterControll
{
    public partial class XtraReport2 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport2(string customerPartNumber, string supplierCode, string country, string dateString, string fosterPart, 
            string serialNumber, string matrixText, List<PrinterSetting> lstPrinterSetting)
        {
            InitializeComponent();

            lblSerialNumber.Text = serialNumber;
            lblCustomerPart.Text = customerPartNumber;
            lblSupplierCode.Text = supplierCode;
            lblFosterPart.Text = fosterPart;
            lblCountryOfProduct.Text = country;
            lblDate.Text = dateString;
            xrBarCode1.Text = matrixText;

            PrinterSetting oCustomerPartNo = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CustomerPartNo");
            PrinterSetting oCountryOfProduction = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CountryOfProduction");
            PrinterSetting oDate = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "Date");
            PrinterSetting oFosterPartNo = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "FosterPartNo");
            PrinterSetting oSerialNumber = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SerialNumber");
            PrinterSetting oSupplierCode = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SupplierCode");
            PrinterSetting oDataMatrix = lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "DataMatrix");

            lblSupplierCode.LocationF = new PointF(oSupplierCode.PX, oSupplierCode.PY);
            lblCustomerPart.LocationF = new PointF(oCustomerPartNo.PX, oCustomerPartNo.PY);
            lblSerialNumber.LocationF = new PointF(oSerialNumber.PX, oSerialNumber.PY);
            lblFosterPart.LocationF = new PointF(oFosterPartNo.PX, oFosterPartNo.PY);
            lblCountryOfProduct.LocationF = new PointF(oCountryOfProduction.PX, oCountryOfProduction.PY);
            lblDate.LocationF = new PointF(oDate.PX, oDate.PY);
            xrBarCode1.LocationF = new PointF(oDataMatrix.PX, oDataMatrix.PY);

            lblSupplierCode.Font = new Font(lblSupplierCode.Font.FontFamily, oSupplierCode.FontSize, lblSupplierCode.Font.Style, lblSupplierCode.Font.Unit, lblSupplierCode.Font.GdiCharSet, lblSupplierCode.Font.GdiVerticalFont);
            lblCustomerPart.Font = new Font(lblCustomerPart.Font.FontFamily, oCustomerPartNo.FontSize, lblCustomerPart.Font.Style, lblCustomerPart.Font.Unit, lblCustomerPart.Font.GdiCharSet, lblCustomerPart.Font.GdiVerticalFont);
            lblSerialNumber.Font = new Font(lblSerialNumber.Font.FontFamily, oSerialNumber.FontSize, lblSerialNumber.Font.Style, lblSerialNumber.Font.Unit, lblSerialNumber.Font.GdiCharSet, lblSerialNumber.Font.GdiVerticalFont);
            lblFosterPart.Font = new Font(lblFosterPart.Font.FontFamily, oFosterPartNo.FontSize, lblFosterPart.Font.Style, lblFosterPart.Font.Unit, lblFosterPart.Font.GdiCharSet, lblFosterPart.Font.GdiVerticalFont);
            lblCountryOfProduct.Font = new Font(lblCountryOfProduct.Font.FontFamily, oCountryOfProduction.FontSize, lblCountryOfProduct.Font.Style, lblCountryOfProduct.Font.Unit, lblCountryOfProduct.Font.GdiCharSet, lblCountryOfProduct.Font.GdiVerticalFont);
            lblDate.Font = new Font(lblDate.Font.FontFamily, oDate.FontSize, lblDate.Font.Style, lblDate.Font.Unit, lblDate.Font.GdiCharSet, lblDate.Font.GdiVerticalFont);
            //xrBarCode1.Font = new Font(xrBarCode1.Font.FontFamily, oCustomerPartNo.FontSize, xrBarCode1.Font.Style, xrBarCode1.Font.Unit, xrBarCode1.Font.GdiCharSet, xrBarCode1.Font.GdiVerticalFont);

            
            //lblDate.Location = new Point(10, 54);
            //lblSerialNumber.Location = new Point(68, 54);
            //lblCustomerPart.Location = new Point(9, 33);
            //lblSupplierCode.Location = new Point(9, 24);
            //lblFosterPart.Location = new Point(68, 45);
            //lblCountryOfProduct.Location = new Point(10, 45);
            //xrBarCode1.Location = new Point(37, 49);
        }

    }
}
