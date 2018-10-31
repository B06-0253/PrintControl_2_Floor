using System;

namespace TPA_PrinterControll
{
    public class PrinterSetting
    {
        public long ID { get; set; }
        public long PrinterID { get; set; }
        public string OptionCode { get; set; }
        public float PX { get; set; }
        public float PY { get; set; }
        public float FontSize { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public int HasMatrix { get; set; }
    }
}