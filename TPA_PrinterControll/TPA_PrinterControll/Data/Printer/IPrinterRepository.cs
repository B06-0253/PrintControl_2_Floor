using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public interface IPrinterRepository
    {
        Printer GetPrinter(long id);

        List<Printer> GetAllPrinter();
        void InsertPrinter(Printer Printer);

        void UpdatePrinter(Printer Printer);
    }
}