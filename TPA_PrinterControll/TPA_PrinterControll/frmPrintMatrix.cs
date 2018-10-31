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
    public partial class frmPrintMatrix : Form
    {
        private FxSerialDeamon _FxSerial;
        string _cmd;
        FxCommandResponse _res;
        bool _oldStatusOK = false;
        bool _oldStatusNG = false;

        DateTime _starTurnOn = DateTime.Now;
        bool _pinTurnOn = false;
        string _matrixText = "";

        bool _isConnected = false;
        
        public frmPrintMatrix()
        {
            InitializeComponent();

            MyConfig._Config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            try
            {
                MyConfig.Read();
            }
            catch (Exception ex)
            {
                MyConfig.Write();
            }

            timerAutoPrint.Interval = 100;

            _isConnected = OpenPort(MyConfig._PortComPLC);
            changeMode();

            AddModelsToSearchLookUpEdit();            

            var toolTip1 = new System.Windows.Forms.ToolTip();
            toolTip1.SetToolTip(btnSaveData, "Click to save all value.");
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
        void ShowInView()
        {
            _matrixText = txtDataMatrix.Text.Trim();

            lblMatrix.Text = _matrixText;

            lblDate1.Text = lblDate.Text = string.IsNullOrEmpty(_matrixText) ? DateTime.Now.ToString("dd MMM yy").ToUpper() : DateTime.Now.ToString("yyMMdd");
            lblSerialNumber1.Text = lblSerialNumber.Text = String.Format("{0:D4}", string.IsNullOrEmpty(txtSerialNumber.Text) ? 0 : int.Parse(txtSerialNumber.Text.Trim()));
            lblCustomerPart1.Text = lblCustomerPart.Text = txtCustomerPartNo.Text.Trim() + "-" + txtChangeIndexNo.Text.Trim();
            lblSupplierCode1.Text = lblSupplierCode.Text = txtSupplierCode.Text.Trim() + "-" + txtPlantCode.Text.Trim() + (string.IsNullOrEmpty(_matrixText) ? "" : " FOSTER");
            lblFosterPart1.Text = lblFosterPart.Text = txtFosterPartNo.Text.Trim();
            lblCountryOfProduct1.Text = lblCountryOfProduct.Text = txtCountryOfProduction.Text.Trim();           
            
        }

        void AddModelsToSearchLookUpEdit()
        {
            string pathXML = Application.StartupPath + "\\Model.xml";
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(pathXML);

            XmlNodeList lstNode = xDoc.GetElementsByTagName("Model");
            List<string> lstModel = new List<string>();
            foreach (XmlNode item in lstNode)
            {
                lstModel.Add(item.InnerText);
            }
            cboModel.DataSource = lstModel;
        }

        public bool OpenPort(int port)
        {
            bool isConnect = false;
            if (_FxSerial == null)
            {
                _FxSerial = new FxSerialDeamon();
                isConnect = _FxSerial.Start(port);
            }
            return isConnect;
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
            ShowInView();
        }

        private void nudSerial_KeyUp(object sender, KeyEventArgs e)
        {
            ShowInView();
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
                btnChangePass.Visible = buttonSetting.Visible = btnSaveData.Visible = cboPrinter.Visible = labelPrinter.Visible = btnPrint.Visible = false;
                timerAutoPrint.Enabled = true;
            }
            else
            {
                btnChangePass.Visible = buttonSetting.Visible = btnSaveData.Visible = cboPrinter.Visible = labelPrinter.Visible = btnPrint.Visible = true;
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
        void print(string printName)
        {
            if (rbtAuto.Checked)
            {
                //txtDate.Text = DateTime.Now.ToString("dd MMM yy").ToUpper();
                txtSerialNumber.Text = (string.IsNullOrEmpty(txtSerialNumber.Text) ? 0 : int.Parse(txtSerialNumber.Text) + 1).ToString();
                ShowInView();
            }
            XtraReport report = new XtraReport();
            if (string.IsNullOrEmpty(_matrixText))
            {
                report = new XtraReport1(lblCustomerPart.Text.Trim(), lblSupplierCode.Text, lblCountryOfProduct.Text,
                lblDate.Text, lblFosterPart.Text, lblSerialNumber.Text);
            }
            else
            {
                report = new XtraReport3(lblCustomerPart.Text.Trim(), lblSupplierCode.Text, lblCountryOfProduct.Text,
                lblDate.Text, lblFosterPart.Text, lblSerialNumber.Text, lblMatrix.Text);
            }           

            //report.ShowPreview();
            report.ShowPrintMarginsWarning = false;
            if (!CheckExistPrinter(printName))
            {
                //write chân out
                _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOn,
                                            new FxAddress(string.Format("Y{0}", Convert.ToString(MyConfig._PinOut, 8)), FxAddressLayoutType.AddressLayoutByte));// tắt
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
        private void timerAutoPrint_Tick(object sender, EventArgs e)
        {
            // read toàn bộ các chân in
            _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdRead, new FxAddress("X0", ControllerTypeConst.ctPLC_Fx), 16);
            _res = _FxSerial.Send(0, _cmd);
            System.Threading.Thread.Sleep(100);
            if (_res.ResultCode == ResultCodeConst.rcFailt || _res.ResultCode == ResultCodeConst.rcNotSettting || _res.ResultCode == ResultCodeConst.rcTimeout)
            {
                // lỗi đọc tín hiệu
                handleError();
                MessageBox.Show("Lỗi giao tiếp PLC: không đọc được tín hiệu");
            }
            else
            {
                bool portOK_Status = convertIntToBools(_res.ResponseValue[0])[MyConfig._PinIn];
                bool portNG_Status = convertIntToBools(_res.ResponseValue[0])[MyConfig._PinInNG];

                bool isPrint = convertIntToBools(_res.ResponseValue[0])[2];
                
                //Nếu 2 tín hiệu ok và NG giống nhau thì không in
                if (portOK_Status == portNG_Status)
                {
                    _oldStatusOK = portOK_Status;
                    _oldStatusNG = portNG_Status;
                    return;
                }

                if (isPrint && portOK_Status)// chân OK on
                {
                    //if (portOK_Status != _oldStatusOK)
                    //{
                        print(MyConfig._PrinterName);
                    //}
                }

                //if (isPrint && portNG_Status)// chân NG on
                //{
                //    //if (portNG_Status != _oldStatusNG)
                //    //{
                //        print(MyConfig._PrinterNameNG);
                //    //}
                //}

                _oldStatusOK = portOK_Status;
                _oldStatusNG = portNG_Status;
            }           
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

        /// <summary>
        /// Khai báo sự kiện in trên mode bằng tay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string printName = "";
            switch (cboPrinter.SelectedIndex)
            {
                case 0:
                    printName = MyConfig._PrinterName;
                    break;
                case 1:
                    printName = MyConfig._PrinterNameNG;
                    break;
                default:
                    MessageBox.Show("Please choose a printer.");
                    return;
                //break;
            }
            print(printName);           
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
                    //txtSupplierCode.Text = MyConfig._SupplierCode;
                    ShowInView();
                }
            }
        }

        private void timerTurnPinOut_Tick(object sender, EventArgs e)
        {
            //tắt pin báo mất kết nối máy in
            if (_pinTurnOn)
            {
                if ((DateTime.Now - _starTurnOn).TotalMilliseconds >= MyConfig._PinOnTime)
                {
                    _pinTurnOn = false;
                    //write chân out
                    _cmd = FxCommandHelper.Make(FxCommandConst.FxCmdForceOff,
                                                new FxAddress(string.Format("Y{0}", Convert.ToString(MyConfig._PinOut, 8)), FxAddressLayoutType.AddressLayoutByte));// tắt
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
                string modelCode = cboModel.SelectedValue.ToString();

                ShowInView();

                string pathXML = Application.StartupPath + "\\Model.xml";
                XElement allModel = XElement.Load(pathXML);

                IEnumerable<XElement> lstElement = allModel.Elements().Where(o => o.Name == "Item");

                IEnumerable<XElement> curent = (from c in lstElement
                                                where
                                                    (string)c.Element("Model").Value == modelCode
                                                select c);

                if (curent.Count() > 0)
                {
                    var x = curent.First();
                    x.Element("Model").Value = modelCode;
                    x.Element("FosterPartNo").Value = txtFosterPartNo.Text.Trim();
                    x.Element("CountryOfProduction").Value = txtCountryOfProduction.Text.Trim();
                    x.Element("PlantCode").Value = txtPlantCode.Text.Trim();
                    x.Element("SupplierCode").Value = txtSupplierCode.Text.Trim();
                    //x.Element("SerialNumber").Value = txtSerialNumber.Text;
                    x.Element("CustomerPartNo").Value = txtCustomerPartNo.Text;
                    x.Element("ChangeIndexNo").Value = txtChangeIndexNo.Text;
                }
                //else
                //{
                //    XElement xelement = new XElement("Item");
                //    xelement.Add(new XElement("Model", modelCode));
                //    xelement.Add(new XElement("FosterPartNo", txtFosterPartNo.Text.Trim()));
                //    xelement.Add(new XElement("CountryOfProduction", txtCountryOfProduction.Text.Trim()));
                //    xelement.Add(new XElement("PlantCode", txtPlantCode.Text.Trim()));
                //    xelement.Add(new XElement("SupplierCode", txtSupplierCode.Text.Trim()));
                //    xelement.Add(new XElement("CustomerPartNo", txtCustomerPartNo.Text));
                //    xelement.Add(new XElement("ChangeIndexNo", txtChangeIndexNo.Text));
                //    allModel.Add(xelement);
                //}
                allModel.Save(pathXML);

                ShowInView();

                MessageBox.Show("Save all data success.");
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frm = new frmChangePass();
            frm.Show();
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {           
            if (cboModel.SelectedIndex >= 0)
            {
                string pathXML = Application.StartupPath + "\\Model.xml";
                XElement allModel = XElement.Load(pathXML);

                IEnumerable<XElement> lstElement = allModel.Elements().Where(o => o.Name == "Item");

                IEnumerable<XElement> curent = (from c in lstElement
                                                where
                                                    (string)c.Element("Model").Value == cboModel.SelectedItem.ToString()
                                                select c);
                if (curent.Count() > 0)
                {
                    var x = curent.First();

                    _matrixText = x.Element("MatrixCode") == null ? "" : x.Element("MatrixCode").Value;

                    txtFosterPartNo.Text = x.Element("FosterPartNo").Value;
                    txtCustomerPartNo.Text = x.Element("CustomerPartNo").Value;
                    txtSupplierCode.Text = x.Element("SupplierCode").Value;                    
                    txtChangeIndexNo.Text = x.Element("ChangeIndexNo").Value;
                    txtCountryOfProduction.Text = x.Element("CountryOfProduction").Value;
                    txtPlantCode.Text = x.Element("PlantCode").Value;

                    txtDataMatrix.Text = x.Element("MatrixCode") == null ? "" : x.Element("MatrixCode").Value;
                }                
            }
            else
            {                
                txtFosterPartNo.Text = "";
                txtCustomerPartNo.Text = "";
                txtSupplierCode.Text = "";
                txtSerialNumber.Text = "";
                txtChangeIndexNo.Text = "";
                txtCountryOfProduction.Text = "";
                txtPlantCode.Text = "";
            }

            panelMatrixTem.Visible = !string.IsNullOrEmpty(_matrixText);

            ShowInView();
        }
    }
}
