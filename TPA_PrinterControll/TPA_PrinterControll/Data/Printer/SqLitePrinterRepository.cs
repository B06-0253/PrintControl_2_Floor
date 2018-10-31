using System.IO;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public class SqLitePrinterRepository : SqLiteBaseRepository, IPrinterRepository
    {
        public Printer GetPrinter(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Printer result = cnn.Query<Printer>(
                    @"SELECT *
                    FROM Printer
                    WHERE Id = @ID", new { id }).FirstOrDefault();
                return result;
            }
        }

        public List<Printer> GetAllPrinter()
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<Printer> result = cnn.Query<Printer>(
                    @"SELECT *
                    FROM Printer").ToList();
                return result;
            }
        }

        public void InsertPrinter(Printer Printer)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Printer.ID = cnn.Query<long>(
                    @"INSERT INTO Printer 
                    ( PrinterName, PrinterType ) VALUES 
                    ( @PrinterName, @PrinterType );
                    select last_insert_rowid()", Printer).First();
            }
        }

        public void UpdatePrinter(Printer Printer)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                string sql = string.Format(@"UPDATE Printer SET PrinterName=@PrinterName, PrinterType=@PrinterType WHERE ID = @ID");
                cnn.Query<long>(sql, Printer);
            }
        }
    }
}
