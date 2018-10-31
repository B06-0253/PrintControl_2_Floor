using System;

namespace TPA_PrinterControll
{
    public class ConfigSetting
    {
        public long ID { get; set; }
        public int PortCom { get; set; }
        public long PinIn { get; set; }
        public long PinInNG { get; set; }
        public long PinOut { get; set; }
        public long PinOnTime { get; set; }
        public long PrinterActiveType { get; set; }
        public string Password { get; set; }
    }
}