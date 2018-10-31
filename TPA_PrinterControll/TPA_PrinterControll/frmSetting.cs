using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPA_PrinterControll
{
    public partial class frmSetting : Form
    {
        ConfigSetting _oConfigSetting = null;
        Printer _oPrinterOK =  null;
        Printer _oPrinterNG =  null;
        List<PrinterSetting> _lstPrinterSetting = null;

        public frmSetting()
        {
            InitializeComponent();            
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            //Lấy ra danh sách cài đặt chung
            IConfigSettingRepository repConfigSetting = new SqLiteConfigSettingRepository();
            _oConfigSetting = repConfigSetting.GetConfigSetting(1);
            nudPortCom.Value = _oConfigSetting.PortCom;
            nudPinIn.Value = _oConfigSetting.PinIn;
            nudPinOut.Value = _oConfigSetting.PinOut;
            nudPinOnTime.Value = _oConfigSetting.PinOnTime;
            nudPinInNG.Value = _oConfigSetting.PinInNG;
            cboShowPrint.SelectedIndex = (int)_oConfigSetting.PrinterActiveType;

            //Lấy ra danh sách máy in
            IPrinterRepository repPrinter = new SqLitePrinterRepository();   

            _oPrinterOK = repPrinter.GetPrinter(1);
            _oPrinterNG= repPrinter.GetPrinter(2);

            tbxPrinterName.Text = _oPrinterOK.PrinterName;
            tbxPrinterNameNG.Text = _oPrinterNG.PrinterName;           
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            _oConfigSetting.PinIn = (long)nudPinIn.Value;
            _oConfigSetting.PortCom = (int)nudPortCom.Value;
            _oConfigSetting.PinOut = (long)nudPinOut.Value;
            _oConfigSetting.PinOnTime = (long)nudPinOnTime.Value;
            _oConfigSetting.PinInNG = (long)nudPinInNG.Value;
            _oConfigSetting.PrinterActiveType = cboShowPrint.SelectedIndex;
            IConfigSettingRepository repConfigSetting = new SqLiteConfigSettingRepository();
            repConfigSetting.UpdateConfigSetting(_oConfigSetting);

            IPrinterRepository repPrinter = new SqLitePrinterRepository();
            _oPrinterOK.PrinterName = tbxPrinterName.Text.Trim();
            _oPrinterNG.PrinterName = tbxPrinterNameNG.Text.Trim();
            repPrinter.UpdatePrinter(_oPrinterNG);
            repPrinter.UpdatePrinter(_oPrinterOK);

            if (cboPrinter.SelectedIndex > 0 && cboStampType.SelectedIndex >= 0)
            {
                IPrinterSettingRepository repPrinterSetting = new SqLitePrinterSettingRepository();
                PrinterSetting oCustomerPartNo = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CustomerPartNo" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oCountryOfProduction = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CountryOfProduction" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oDate = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "Date" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oFosterPartNo = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "FosterPartNo" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oSerialNumber = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SerialNumber" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oSupplierCode = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SupplierCode" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);
                PrinterSetting oDataMatrix = _lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "DataMatrix" && o.PrinterID == cboPrinter.SelectedIndex && o.HasMatrix == cboStampType.SelectedIndex);

                oCustomerPartNo.PY = (float)nudYCustomerPartNumber.Value;
                oCustomerPartNo.PX = (float)nudXCustomerPartNumber.Value;
                oCustomerPartNo.FontSize = (float)nudSCustomerPartNumber.Value;

                oCountryOfProduction.PY = (float)nudYCountry.Value;
                oCountryOfProduction.PX = (float)nudXCountry.Value;
                oCountryOfProduction.FontSize = (float)nudSCountry.Value;

                oDate.PY = (float)nudYDate.Value;
                oDate.PX = (float)nudXDate.Value;
                oDate.FontSize = (float)nudSDate.Value;

                oFosterPartNo.PY = (float)nudYFosterNo.Value;
                oFosterPartNo.PX = (float)nudXFosterNo.Value;
                oFosterPartNo.FontSize = (float)nudSFosterNo.Value;

                oSerialNumber.PY = (float)nudYSerial.Value;
                oSerialNumber.PX = (float)nudXSerial.Value;
                oSerialNumber.FontSize = (float)nudSSerial.Value;

                oSupplierCode.PY = (float)nudYSupplierCode.Value;
                oSupplierCode.PX = (float)nudXSupplierCode.Value;
                oSupplierCode.FontSize = (float)nudSSupplierCode.Value;

                oDataMatrix.PY = (float)nudYMatrix.Value;
                oDataMatrix.PX = (float)nudXMatrix.Value;

                repPrinterSetting.UpdatePrinterSetting(oCustomerPartNo);
                repPrinterSetting.UpdatePrinterSetting(oCountryOfProduction);
                repPrinterSetting.UpdatePrinterSetting(oDate);
                repPrinterSetting.UpdatePrinterSetting(oFosterPartNo);
                repPrinterSetting.UpdatePrinterSetting(oSerialNumber);
                repPrinterSetting.UpdatePrinterSetting(oSupplierCode);
                repPrinterSetting.UpdatePrinterSetting(oDataMatrix);
            }                   

            DialogResult = DialogResult.OK;
            this.Close();
        }

        void loadPrinterSetting()
        {
            if (cboPrinter.SelectedIndex < 1 || cboStampType.SelectedIndex < 0) return;
            //Lấy ra danh sách cài đặt theo máy in
            IPrinterSettingRepository repPrinterSetting = new SqLitePrinterSettingRepository();
            _lstPrinterSetting = repPrinterSetting.GetPrinterSettingByPrinter(cboPrinter.SelectedIndex, cboStampType.SelectedIndex);

            nudXCustomerPartNumber.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CustomerPartNo").PX;
            nudXCountry.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CountryOfProduction").PX;
            nudXDate.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "Date").PX;
            nudXFosterNo.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "FosterPartNo").PX;
            nudXSerial.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SerialNumber").PX;
            nudXSupplierCode.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SupplierCode").PX;
            nudXMatrix.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "DataMatrix").PX;

            nudYCustomerPartNumber.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CustomerPartNo").PY;
            nudYCountry.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CountryOfProduction").PY;
            nudYDate.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "Date").PY;
            nudYFosterNo.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "FosterPartNo").PY;
            nudYSerial.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SerialNumber").PY;
            nudYSupplierCode.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SupplierCode").PY;
            nudYMatrix.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "DataMatrix").PY;

            nudSCustomerPartNumber.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CustomerPartNo").FontSize;
            nudSCountry.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "CountryOfProduction").FontSize;
            nudSDate.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "Date").FontSize;
            nudSFosterNo.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "FosterPartNo").FontSize;
            nudSSerial.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SerialNumber").FontSize;
            nudSSupplierCode.Value = (decimal)_lstPrinterSetting.FirstOrDefault(o => o.OptionCode == "SupplierCode").FontSize;
        }

        private void cboPrinter_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPrinterSetting();
        }

        private void cboStampType_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPrinterSetting();
        }        
    }
}
