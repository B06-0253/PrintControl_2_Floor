using System;

namespace TPA_PrinterControll
{
    public class Model
    {
        public long ID { get; set; }
        public string ModelCode { get; set; }
        public string SupplierCode { get; set; }
        public string CustomerPartNo { get; set; }
        public string CountryOfProduction { get; set; }
        public string FosterPartNo { get; set; }
        public string PlantCode { get; set; }
        public string ChangeIndexNo { get; set; }
        public string MatrixCode { get; set; }
    }
}