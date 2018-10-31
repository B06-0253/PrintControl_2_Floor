using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public interface IPrinterSettingRepository
    {
        PrinterSetting GetPrinterSetting(long id);

        List<PrinterSetting> GetPrinterSettingByPrinter(long id);
        List<PrinterSetting> GetPrinterSettingByPrinter(long id, int type);

        List<PrinterSetting> GetAllPrinterSetting();
        void InsertPrinterSetting(PrinterSetting PrinterSetting);

        void UpdatePrinterSetting(PrinterSetting PrinterSetting);
    }
}