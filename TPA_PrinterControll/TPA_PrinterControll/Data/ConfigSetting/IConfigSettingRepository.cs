using System.Collections.Generic;

namespace TPA_PrinterControll
{
    public interface IConfigSettingRepository
    {
        ConfigSetting GetConfigSetting(long id);

        List<ConfigSetting> GetAllConfigSetting();
        void InsertConfigSetting(ConfigSetting ConfigSetting);

        void UpdateConfigSetting(ConfigSetting ConfigSetting);
    }
}