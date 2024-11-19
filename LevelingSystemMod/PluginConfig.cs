using BepInEx.Configuration;

namespace LevelingSystemMod
{
    public sealed class PluginConfig
    {
        public const string Guid = "com.deepwolf413.levelingsystem";
        public const string Name = "LevelingSystem";
        public const string Version = "1.0.0";
        
        public ConfigEntry<bool> Enabled { get; set; }
        public ConfigEntry<bool> Debug { get; set; }
        
    }
}