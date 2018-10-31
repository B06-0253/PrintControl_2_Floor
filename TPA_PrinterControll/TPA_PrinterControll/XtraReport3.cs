using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace TPA_PrinterControll
{
    public partial class XtraReport3 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport3(string customerPartNumber, string supplierCode, string country, string dateString, string fosterPart, string serialNumber,string matrixText)
        {
            InitializeComponent();

            lblSerialNumber.Text = serialNumber;
            lblCustomerPart.Text = customerPartNumber;
            lblSupplierCode.Text = supplierCode;
            lblFosterPart.Text = fosterPart;
            lblCountryOfProduct.Text = country;
            lblDate.Text = dateString;
            xrBarCode1.Text = matrixText;

            lblSupplierCode.Location = new Point(MyConfig._X_SupplierCode, MyConfig._Y_SupplierCode);
            lblCustomerPart.Location = new Point(MyConfig._X_CustomerPartNumber, MyConfig._Y_CustomerPartNumber);
            lblSerialNumber.Location = new Point(MyConfig._X_Serial, MyConfig._Y_Serial);
            lblFosterPart.Location = new Point(MyConfig._X_FosterNo, MyConfig._Y_FosterNo);
            lblCountryOfProduct.Location = new Point(MyConfig._X_Country, MyConfig._Y_Country);
            lblDate.Location = new Point(MyConfig._X_Date, MyConfig._Y_Date);
            xrBarCode1.Location = new Point(MyConfig._X_Matrix, MyConfig._Y_Matrix);

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
