
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPA_PrinterControll
{
    public static class MyConfig
    {
        public static Configuration _Config;
        public static int _PortComPLC = 1;
        public static int _PinIn = 5;
        public static int _PinInNG = 7;
        public static int _PinOut = 3;
        public static int _PinOnTime = 1000;
        public static string _PrinterName = "POSTEK G-3106";
        public static string _PrinterNameNG = "POSTEK G-3106(1)";

        //public static string _SupplierCode = "FEV/01F";
        //public static string _CustomerPartNumber = "";
        //public static string _Country = "VIET NAM";
        //public static string _Power = "";
        //public static string _Supplier="FOSTER";
        //public static decimal _SerialNumber = 0;
        //public static DateTime _ProductionDate = DateTime.Now;

        public static string _PassWord = "MQAyADMANAA1ADYA";        

        //lblDate.Location = new Point(10, 54);
        //    lblSerialNumber.Location = new Point(68, 54);
        //    lblCustomerPart.Location = new Point(9, 33);
        //    lblSupplierCode.Location = new Point(9, 24);
        //    lblFosterPart.Location = new Point(68, 45);
        //    lblCountryOfProduct.Location = new Point(10, 45);
        //    xrBarCode1.Location = new Point(37, 49);

        public static int _X_CustomerPartNumber = 9;
        public static int _Y_CustomerPartNumber = 33;

        public static int _X_Date = 10;
        public static int _Y_Date = 54;

        public static int _X_Country = 10;//13, 70
        public static int _Y_Country = 45;

        public static int _X_FosterNo = 68;//13, 61
        public static int _Y_FosterNo = 45;

        public static int _X_SupplierCode = 9;//13, 53
        public static int _Y_SupplierCode = 24;

        public static int _X_Serial = 68;
        public static int _Y_Serial = 54;

        public static int _X_Matrix = 37;
        public static int _Y_Matrix = 49;

        public static int Read()
        {
            try
            {
                _PortComPLC = int.Parse(_Config.AppSettings.Settings["PortComPLC"].Value);
                _PinIn = int.Parse(_Config.AppSettings.Settings["PinIn"].Value);
                _PinInNG = int.Parse(_Config.AppSettings.Settings["PinInNG"].Value);
                _PinOut = int.Parse(_Config.AppSettings.Settings["PinOut"].Value);
                _PinOnTime = int.Parse(_Config.AppSettings.Settings["PinOnTime"].Value);
                _PrinterName = _Config.AppSettings.Settings["PrinterName"].Value.ToString();
                _PrinterNameNG = _Config.AppSettings.Settings["PrinterNameNG"].Value.ToString();

                //_SupplierCode = _Config.AppSettings.Settings["SupplierCode"].Value.ToString();
                //_CustomerPartNumber = _Config.AppSettings.Settings["CustomerPartNumber"].Value.ToString();
                //_Country = _Config.AppSettings.Settings["Country"].Value.ToString();
                //_Power = _Config.AppSettings.Settings["Power"].Value.ToString();
                //_Supplier = _Config.AppSettings.Settings["Supplier"].Value.ToString();
                //_SerialNumber = decimal.Parse(_Config.AppSettings.Settings["SerialNumber"].Value);
                //_ProductionDate = _Config.AppSettings.Settings["SupplierCode"].Value.ToString();

                _X_CustomerPartNumber = int.Parse(_Config.AppSettings.Settings["_X_CustomerPartNumber"].Value);
                _Y_CustomerPartNumber = int.Parse(_Config.AppSettings.Settings["_Y_CustomerPartNumber"].Value);

                _X_Date = int.Parse(_Config.AppSettings.Settings["_X_Date"].Value);
                _Y_Date = int.Parse(_Config.AppSettings.Settings["_Y_Date"].Value);


                _X_Country = int.Parse(_Config.AppSettings.Settings["_X_Country"].Value);
                _Y_Country = int.Parse(_Config.AppSettings.Settings["_Y_Country"].Value);

                _X_FosterNo = int.Parse(_Config.AppSettings.Settings["_X_FosterNo"].Value);
                _Y_FosterNo = int.Parse(_Config.AppSettings.Settings["_Y_FosterNo"].Value);

                _X_SupplierCode = int.Parse(_Config.AppSettings.Settings["_X_SupplierCode"].Value);
                _Y_SupplierCode = int.Parse(_Config.AppSettings.Settings["_Y_SupplierCode"].Value);


                _X_Serial = int.Parse(_Config.AppSettings.Settings["_X_Serial"].Value);
                _Y_Serial = int.Parse(_Config.AppSettings.Settings["_Y_Serial"].Value);

                _X_Matrix = int.Parse(_Config.AppSettings.Settings["_X_Matrix"].Value);
                _Y_Matrix = int.Parse(_Config.AppSettings.Settings["_Y_Matrix"].Value);

                _PassWord = _Config.AppSettings.Settings["_PassWord"].Value;
            }
            catch (Exception ex)
            {
                return 0;
            }

            return 1;
        }

        public static int Write()
        {
            _Config.AppSettings.Settings.Remove("PortComPLC");
            _Config.AppSettings.Settings.Add("PortComPLC", "" + _PortComPLC);

            _Config.AppSettings.Settings.Remove("PinIn");
            _Config.AppSettings.Settings.Add("PinIn", "" + _PinIn);

            _Config.AppSettings.Settings.Remove("PinInNG");
            _Config.AppSettings.Settings.Add("PinInNG", "" + _PinInNG);

            _Config.AppSettings.Settings.Remove("PinOut");
            _Config.AppSettings.Settings.Add("PinOut", "" + _PinOut);

            _Config.AppSettings.Settings.Remove("PinOnTime");
            _Config.AppSettings.Settings.Add("PinOnTime", "" + _PinOnTime);

            _Config.AppSettings.Settings.Remove("PrinterName");
            _Config.AppSettings.Settings.Add("PrinterName", "" + _PrinterName);

            _Config.AppSettings.Settings.Remove("PrinterNameNG");
            _Config.AppSettings.Settings.Add("PrinterNameNG", "" + _PrinterNameNG);

            //_Config.AppSettings.Settings.Remove("SupplierCode");
            //_Config.AppSettings.Settings.Add("SupplierCode", "" + _SupplierCode);

            //_Config.AppSettings.Settings.Remove("CustomerPartNumber");
            //_Config.AppSettings.Settings.Add("CustomerPartNumber", "" + _CustomerPartNumber);

            //_Config.AppSettings.Settings.Remove("Country");
            //_Config.AppSettings.Settings.Add("Country", "" + _Country);

            //_Config.AppSettings.Settings.Remove("Power");
            //_Config.AppSettings.Settings.Add("Power", "" + _Power);

            //_Config.AppSettings.Settings.Remove("Supplier");
            //_Config.AppSettings.Settings.Add("Supplier", "" + _Supplier);

            //_Config.AppSettings.Settings.Remove("SerialNumber");
            //_Config.AppSettings.Settings.Add("SerialNumber", "" + _SerialNumber);

            _Config.AppSettings.Settings.Remove("_X_CustomerPartNumber");
            _Config.AppSettings.Settings.Add("_X_CustomerPartNumber", "" + _X_CustomerPartNumber);
            _Config.AppSettings.Settings.Remove("_Y_CustomerPartNumber");
            _Config.AppSettings.Settings.Add("_Y_CustomerPartNumber", "" + _Y_CustomerPartNumber);

            _Config.AppSettings.Settings.Remove("_X_Date");
            _Config.AppSettings.Settings.Add("_X_Date", "" + _X_Date);
            _Config.AppSettings.Settings.Remove("_Y_Date");
            _Config.AppSettings.Settings.Add("_Y_Date", "" + _Y_Date);

            _Config.AppSettings.Settings.Remove("_X_Country");
            _Config.AppSettings.Settings.Add("_X_Country", "" + _X_Country);
            _Config.AppSettings.Settings.Remove("_Y_Country");
            _Config.AppSettings.Settings.Add("_Y_Country", "" + _Y_Country);

            _Config.AppSettings.Settings.Remove("_X_FosterNo");
            _Config.AppSettings.Settings.Add("_X_FosterNo", "" + _X_FosterNo);
            _Config.AppSettings.Settings.Remove("_Y_FosterNo");
            _Config.AppSettings.Settings.Add("_Y_FosterNo", "" + _Y_FosterNo);

            _Config.AppSettings.Settings.Remove("_X_SupplierCode");
            _Config.AppSettings.Settings.Add("_X_SupplierCode", "" + _X_SupplierCode);
            _Config.AppSettings.Settings.Remove("_Y_SupplierCode");
            _Config.AppSettings.Settings.Add("_Y_SupplierCode", "" + _Y_SupplierCode);

            _Config.AppSettings.Settings.Remove("_X_Serial");
            _Config.AppSettings.Settings.Add("_X_Serial", "" + _X_Serial);
            _Config.AppSettings.Settings.Remove("_Y_Serial");
            _Config.AppSettings.Settings.Add("_Y_Serial", "" + _Y_Serial);

            _Config.AppSettings.Settings.Remove("_X_Matrix");
            _Config.AppSettings.Settings.Add("_X_Matrix", "" + _X_Matrix);
            _Config.AppSettings.Settings.Remove("_Y_Matrix");
            _Config.AppSettings.Settings.Add("_Y_Matrix", "" + _Y_Matrix);

            _Config.AppSettings.Settings.Remove("_PassWord");
            _Config.AppSettings.Settings.Add("_PassWord", "" + _PassWord);

            _Config.Save(ConfigurationSaveMode.Minimal);
            return 1;
        }

        
    }
}
