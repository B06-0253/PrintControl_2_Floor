using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InControls.PLC.FX;
using InControls.Common;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;
using System.Management;
using System.Security.Principal;
using System.Configuration;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml;


namespace TPA_PrinterControll
{
    public partial class frmPrintMatrixNew : Form
    {
        private FxSerialDeamon _FxSerial;
        string _cmd;
        FxCommandResponse _res;
        bool _oldStatusOK = false;
        bool _oldStatusNG = false;

        DateTime _starTurnOn = DateTime.Now;
        bool _pinTurnOn = false;

        ConfigSetting _oConfigSetting = null;
        List<Model> _lstModel = null;
        List<Printer> _lstPrinter = null;
        List<PrinterSetting> _lstPrinterSetting = null;

        public frmPrintMatrixNew()
        {
            InitializeComponent();          

            loadConfig();
            loadModel();

            timerAutoPrint.Interval = 100;

            OpenPort(_oConfigSetting.PortCom);
            changeMode();                     

            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(btnSaveData, "Click to save all value.");
        }

        void loadConfig()
        {
            //Lấy ra danh sách cài đặt chung
            IConfigSettingRepository repConfigSetting = new SqLiteConfigSettingRepository();
            _oConfigSetting = repConfigSetting.GetConfigSetting(1);

            //Lấy ra danh sách model
            IModelRepository repModel = new SqLiteModelRepository();
            _lstModel = repModel.GetAllModel();

            //Lấy ra danh sách máy in
            IPrinterRepository repPrinter = new SqLitePrinterRepository();
            _lstPrinter = repPrinter.GetAllPrinter();

            IPrinterSettingRepository repPrinterSetting = new SqLitePrinterSettingRepository();
            _lstPrinterSetting = repPrinterSetting.GetAllPrinterSetting();
            
        }
        void loadModel()
        {
            cboModel.DisplayMember = "ModelCode";
            cboModel.ValueMember = "ID";
            cboModel.DataSource = _lstModel;
            
        }

        /// <summary>
        /// Kiêm tra xem máy in có hoạt động không?
        /// </summary>
        /// <param name="printerToCheck">tên máy in</param>
        /// <returns></returns>
        public bool CheckExistPrinter(string printerToCheck)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM  Win32_Printer");
            searcher.Options.Timeout = new TimeSpan(0, 0, 1);
            bool IsReady = false;
            try
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["Name"].ToString().Equals(printerToCheck))
                    {
                        if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                        {
                            IsReady = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return IsReady;
        }

        public bool CheckTowExistPrinter(string printerToCheck, string printerToCheckNG)
        {
            ManagementObjectSearcher searcher = new
                ManagementObjectSearcher("SELECT * FROM   Win32_Printer");
            searcher.Options.Timeout = new TimeSpan(0, 0, 1);
            bool IsReady = false;
            bool IsReadyNG = false;
            try
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    if (printer["Name"].ToString().Equals(printerToCheck))
                    {
                        if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                        {
                            IsReady = true;
                            break;
                        }
                    }

                    if (printer["Name"].ToString().Equals(printerToCheckNG))
                    {
                        if (printer["WorkOffline"].ToString().ToLower().Equals("false"))
                        {
                            IsReadyNG = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return IsReady && IsReadyNG;
        }

        /// <summary>
        /// Cấu hình nội dụng trên tem
        /// </summary>
        void ShowInView(int printID)
        {
            lblDate1.Text = lblDate.Text = string.IsNullOrEmpty(_currentModel.MatrixCode) ? DateTime.Now.ToString("dd MMM yy").ToUpper() : DateTime.Now.ToString("yyMMdd");
            lblCustomerPart1.Text = lblCustomerPart.Text = txtCustomerPartNo.Text.Trim() + "-" + txtChangeIndexNo.Text.Trim();
            lblSupplierCode1.Text = lblSupplierCode.Text = txtSupplierCode.Text.Trim() + "-" + txtPlantCode.Text.Trim() + (string.IsNullOrEmpty(_currentModel.MatrixCode) ? "" : " FOSTER");
            lblFosterPart1.Text = lblFosterPart.Text = txtFosterPartNo.Text.Trim();
            lblCountryOfProduct1.Text = lblCountryOfProduct.Text = txtCountryOfProduction.Text.Trim();            
            lblMatrix.Text = txtMatrixData.Text.Trim();
            if (printID == 1)
            {
                lblSerialNumber1.Text = lblSerialNumber.Text = String.Format("{0:D4}", string.IsNullOrEmpty(txtSerialNumberOK.Text.Trim()) ? 0 : int.Parse(txtSerialNumberOK.Text.Trim()));
            }
            if (printID == 2)
            {
                lblSerialNumber1.Text = lblSerialNumber.Text = String.Format("{0:D4}", string.IsNullOrEmpty(txtSerialNumberNG.Text.Trim()) ? 0 : int.Parse(txtSerialNumberNG.Text.Trim()));
            }            
        }       

        public void OpenPort(int port)
        {
            if (_FxSerial == null)
            {
                _FxSerial = new FxSerialDeamon();
                _FxSerial.Start(port);
            }
        }

        public void ClosePort()
        {
            if (_FxSerial != null)
            {
                _FxSerial.Dispose();
            }
            _FxSerial = null;
        }

        private void tbxSupplier_TextChanged(object sender, EventArgs e)
        {
            ShowInView(0);
        }

        private void nudSerial_KeyUp(object sender, KeyEventArgs e)
        {
            ShowInView(0);
        }

        private void rbtAuto_CheckedChanged(object sender, EventArgs e)
        {
            changeMode();
        }

        /// <summary>
        /// Hàm xử lý khi thay đổi chế độ
        /// </summary>
        void changeMode()
        {
            if (rbtAuto.Checked)
            {
                buttonSetting.Visible = btnSaveData.Visible = cboPrinter.Visible = labelPrinter.Visible = btnPrint.Visible = false;
                timerAutoPrint.Enabled = true;
            }
            else
            {
                buttonSetting.Visible = btnSaveData.Visible = cboPrinter.Visible = labelPrinter.Visible = btnPrint.Visible = true;
                timerAutoPrint.Enabled = false;
            }
        }

        /// <summary>
        /// Xử lý khi có lỗi
        /// </summary>
        void handleError()
        {
            btnPrint.Visible = true;
            timerAutoPrint.Enabled = false;
            rbtAuto.Checked = false;
            rbtManual.Checked = true;
        }

        /// <summary>
        /// Hàm xử lý in
        /// </summary>
        /// <param name="printName">Tên máy in</param>
        void print(string printName, int printID)
        {
            if (rbtAuto.Checked)
            {
                if (printID == 1)
                {
                    txtSerialNumberOK.Text = (string.IsNullOrEmpty(txtSerialNumberOK.Text) ? 0 : int.Parse(txtSerialNumberOK.Text) + 1).ToString();
                }
                if (printID == 2)
                {
                    txtSerialNumberNG.Text = (string.IsNullOrEmpty(txtSerialNumberNG.Text) ? 0 : int.Parse(txtSerialNumberNG.Text) + 1).ToString();
                }

                ShowInView(printID);
            }
            else
            {
                ShowInView(printID);
            }
            XtraReport report = null;

            if (string.IsNullOrEmpty(_currentModel.MatrixCode))
            {
                List<PrinterSetting> lstPrinterSetting = _lstPrinterSetting.Where(o => o.PrinterID == printID && o.HasMatrix == 0).ToList();

                report = new XtraReport1(lblCustomerPart1.Text.Trim(), lblSupplierCode1.Text, lblCountryOfProduct1.Text,
                    lblDate1.Text, lblFosterPart1.Text, lblSerialNumber1.Text, lstPrinterSetting);
            }
            else
            {
                List<PrinterSetting> lstPrinterSetting = _lstPrinterSetting.Where(o => o.PrinterID == printID && o.HasMatrix == 1).ToList();

                report = new XtraReport2(lblCustomerPart1.Text.Trim(), lblSupplierCode1.Text, lblCountryOfProduct1.Text,
                    lblDate1.Text, lblFosterPart1.Text, lblSerialNumber1.Text, lblMatrix.Text, lstPrinterSetting);
            }            

            //report.ShowPreview();
            report.ShowPrintMarginsWarning = false;
            if (!CheckExistPrinter(printName))
            {
                //write chân out
                _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn,
                                            new FxAddress(string.Format("Y{0}", Convert.ToString(_oConfigSetting.PinOut, 8)), FxAddressLayoutType.AddressLayoutByte));// tắt
                _res = _FxSerial.Send(0, _cmd);
                handleError();
                _pinTurnOn = true;
                _starTurnOn = DateTime.Now;
                MessageBox.Show("Lỗi : mất kết nối máy in");
            }
            else
            {
                report.Print(printName);
            }
        }

        /// <summary>
        /// Khai báo sự kiện timer xử lý in khi trong mode auto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        bool _isPrint = false;
        private void timerAutoPrint_Tick(object sender, EventArgs e)
        {
            // read chân in
            _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("X0", ControllerTypeConst.ctPLC_Fx), 16);
            _res = _FxSerial.Send(0, _cmd);
            //System.Threading.Thread.Sleep(100);
            if (_res.ResultCode == ResultCodeConst.rcFailt || _res.ResultCode == ResultCodeConst.rcNotSettting || _res.ResultCode == ResultCodeConst.rcTimeout)
            {
                // lỗi đọc tín hiệu
                handleError();
                MessageBox.Show("Lỗi giao tiếp PLC: không đọc được tín hiệu");
            }
            else
            {
                bool isPrint = convertIntToBools(_res.ResponseValue[0])[2];

                if (_isPrint == isPrint)
                {
                    return;
                }
                else
                {
                    _isPrint = isPrint;
                }

                bool portOK_Status = convertIntToBools(_res.ResponseValue[0])[_oConfigSetting.PinIn];
                bool portNG_Status = convertIntToBools(_res.ResponseValue[0])[_oConfigSetting.PinInNG];

                if (portOK_Status == portNG_Status)
                {
                    //_oldStatusOK = portOK_Status;
                    //_oldStatusNG = portNG_Status;
                    return;
                }

                if (isPrint && portOK_Status && (_oConfigSetting.PrinterActiveType == 1 || _oConfigSetting.PrinterActiveType == 0))// chân OK on
                {                    
                    print(_lstPrinter.FirstOrDefault(o => o.ID == 1).PrinterName, 1);                    
                }

                if (isPrint && portNG_Status && (_oConfigSetting.PrinterActiveType == 2 || _oConfigSetting.PrinterActiveType == 0))// chân NG on
                {                    
                    print(_lstPrinter.FirstOrDefault(o => o.ID == 2).PrinterName, 2);                    
                }
                
                //_oldStatusOK = portOK_Status;
                //_oldStatusNG = portNG_Status;
            }           
        }

        /// <summary>
        /// Khai báo sự kiện in trên mode bằng tay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printName = "";
            int printID = 0;
            switch (cboPrinter.SelectedIndex)
            {
                case 0:
                    printName = _lstPrinter.FirstOrDefault(o=>o.ID == 1).PrinterName;
                    printID = 1;
                    break;
                case 1:
                    printName = _lstPrinter.FirstOrDefault(o => o.ID == 2).PrinterName;
                    printID = 2;
                    break;
                default:
                    MessageBox.Show("Please choose a printer.");
                    return;
                //break;
            }
            print(printName, printID);
        }

        /// <summary>
        /// Hàm convert kiểu số về dạng bool
        /// </summary>
        /// <param name="num">giá trị số</param>
        /// <returns></returns>
        bool[] convertIntToBools(int num)
        {
            bool[] bools = new bool[16];
            for (int i = 15; i >= 0; i--)
            {
                if (num >= (1 << i))
                {
                    bools[i] = true;
                    num = num - (1 << i);
                }
                else
                {
                    bools[i] = false;
                }
            }
            return bools;
        }

        

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClosePort();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            frmComfirmPass frm = new frmComfirmPass();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                frmSetting frmSetting = new frmSetting();
                if (frmSetting.ShowDialog() == DialogResult.OK)
                {
                    loadConfig();
                    ShowInView(0);
                }
            }
        }

        private void timerTurnPinOut_Tick(object sender, EventArgs e)
        {
            //tắt pin báo mất kết nối máy in
            if (_pinTurnOn)
            {
                if ((DateTime.Now - _starTurnOn).TotalMilliseconds >= _oConfigSetting.PinOnTime)
                {
                    _pinTurnOn = false;
                    //write chân out
                    _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff,
                                                new FxAddress(string.Format("Y{0}", Convert.ToString(_oConfigSetting.PinOut, 8)), FxAddressLayoutType.AddressLayoutByte));// tắt
                    _res = _FxSerial.Send(0, _cmd);
                }
            }
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a Model!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmComfirmPass frm = new frmComfirmPass();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                long id = (long)cboModel.SelectedValue;
                IModelRepository repM = new SqLiteModelRepository();
                Model oModel = repM.GetModel(id);
                
                oModel.ChangeIndexNo = txtChangeIndexNo.Text.Trim();
                oModel.CountryOfProduction = txtCountryOfProduction.Text.Trim();
                oModel.CustomerPartNo = txtCustomerPartNo.Text.Trim();
                oModel.FosterPartNo = txtFosterPartNo.Text.Trim();
                oModel.MatrixCode = txtMatrixData.Text.Trim();
                oModel.PlantCode = txtPlantCode.Text.Trim();
                oModel.SupplierCode = txtSupplierCode.Text.Trim();

                repM.UpdateModel(oModel);

                ShowInView(0);

                MessageBox.Show("Save all data success.");
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            frm.Show();
        }

        Model _currentModel = null;

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModel.SelectedIndex >= 0)
            {
                long id = (long)cboModel.SelectedValue;
                IModelRepository repM = new SqLiteModelRepository();
                Model oModel = repM.GetModel(id);

                _currentModel = oModel;

                txtFosterPartNo.Text = oModel.FosterPartNo;
                txtCustomerPartNo.Text = oModel.CustomerPartNo;
                txtSupplierCode.Text = oModel.SupplierCode;                
                txtChangeIndexNo.Text = oModel.ChangeIndexNo;
                txtCountryOfProduction.Text = oModel.CountryOfProduction;
                txtPlantCode.Text = oModel.PlantCode;
                txtMatrixData.Text = oModel.MatrixCode;

                panelMatrixTem.Visible = !string.IsNullOrEmpty(oModel.MatrixCode);
            }            

            ShowInView(0);
        }
    }
}
