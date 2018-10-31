using System.IO;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public class SqLitePrinterSettingRepository : SqLiteBaseRepository, IPrinterSettingRepository
    {
        public PrinterSetting GetPrinterSetting(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                PrinterSetting result = cnn.Query<PrinterSetting>(
                    @"SELECT *
                    FROM PrinterSetting
                    WHERE ID = @ID", new { id }).FirstOrDefault();
                return result;
            }
        }

        public List<PrinterSetting> GetPrinterSettingByPrinter(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<PrinterSetting> result = cnn.Query<PrinterSetting>(
                    @"SELECT *
                    FROM PrinterSetting
                    WHERE PrinterID = " + id).ToList();
                return result;
            }
        }

        public List<PrinterSetting> GetPrinterSettingByPrinter(long printID, int hasMatrix)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<PrinterSetting> result = cnn.Query<PrinterSetting>(string.Format(
                                                        @"SELECT * FROM PrinterSetting 
                                                        WHERE PrinterID = {0} and HasMatrix = {1}", printID,hasMatrix)).ToList();
                return result;
            }
        }

        public List<PrinterSetting> GetAllPrinterSetting()
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<PrinterSetting> result = cnn.Query<PrinterSetting>(
                    @"SELECT *
                    FROM PrinterSetting").ToList();
                return result;
            }
        }

        public void InsertPrinterSetting(PrinterSetting PrinterSetting)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                PrinterSetting.ID = cnn.Query<long>(
                    @"INSERT INTO PrinterSetting 
                    ( PrinterID, OptionCode, PX,PY,FontSize,Width,Height,HasMatrix ) VALUES 
                    ( @PrinterID,@OptionCode,@PX,@PY,@FontSize,@Width,@Height,@HasMatrix );
                    select last_insert_rowid()", PrinterSetting).First();
            }
        }

        public void UpdatePrinterSetting(PrinterSetting PrinterSetting)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                string sql = string.Format(@"UPDATE PrinterSetting SET PrinterID=@PrinterID,OptionCode=@OptionCode,PX=@PX,PY=@PY,FontSize=@FontSize,
                                                                        Width=@Width,Height=@Height,HasMatrix=@HasMatrix 
                                                                        WHERE ID = @ID");
                cnn.Query<long>(sql, PrinterSetting);
            }
        }
    }
}
