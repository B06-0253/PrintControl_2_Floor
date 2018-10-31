using System.IO;
using System.Linq;
using Dapper;
using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public class SqLiteConfigSettingRepository : SqLiteBaseRepository, IConfigSettingRepository
    {
        public ConfigSetting GetConfigSetting(long id)
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                ConfigSetting result = cnn.Query<ConfigSetting>(
                    @"SELECT *
                    FROM ConfigSetting
                    WHERE Id = @ID", new { id }).FirstOrDefault();
                return result;
            }
        }

        public List<ConfigSetting> GetAllConfigSetting()
        {
            if (!File.Exists(DbFile)) return null;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                List<ConfigSetting> result = cnn.Query<ConfigSetting>(
                    @"SELECT *
                    FROM ConfigSetting").ToList();
                return result;
            }
        }

        public void InsertConfigSetting(ConfigSetting ConfigSetting)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                ConfigSetting.ID = cnn.Query<long>(
                    @"INSERT INTO ConfigSetting 
                    (PortCom, PinIn,PinInNG,PinOut,PinOnTime,PrinterActiveType,Password ) VALUES 
                    ( @PortCom, @PinIn,@PinInNG,@PinOut,@PinOnTime,@PrinterActiveType,@Password );
                    select last_insert_rowid()", ConfigSetting).First();
            }
        }

        public void UpdateConfigSetting(ConfigSetting ConfigSetting)
        {
            if (!File.Exists(DbFile)) return;

            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                string sql = string.Format(@"UPDATE ConfigSetting SET PortCom=@PortCom, PinIn=@PinIn,PinInNG=@PinInNG,PinOut=@PinOut,PinOnTime=@PinOnTime,PrinterActiveType=@PrinterActiveType,Password=@Password WHERE ID = @ID");

                cnn.Query<long>(sql, ConfigSetting);
            }
        }
    }
}
