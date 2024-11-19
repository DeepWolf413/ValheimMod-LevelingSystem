using BepInEx.Configuration;

namespace LevelingSystemMod
{
	/// <summary>
	/// The <see cref="PluginConfig"/> class is responsible for managing the configuration settings for the mod. 
	/// It sets up initial configuration values, provides access to mod metadata such as the identifier, 
	/// name, description, version, and author, and facilitates reading and updating configuration values 
	/// as needed by the mod.
	/// </summary>
    public sealed class PluginConfig
    {
        /// <summary>
        /// The mod identifier.
        /// </summary>
        public const string Guid = "com.deepwolf413.levelingsystem";

        /// <summary>
        /// The name of the mod.
        /// </summary>
        public const string Name = "LevelingSystem";

        /// <summary>
        /// A short description of the mod.
        /// </summary>
        public const string ShortDescription = "No description.";

        /// <summary>
        /// The version of the mod.
        /// </summary>
        public const string Version = "1.0.0";

        /// <summary>
        /// The author of the mod.
        /// </summary>
        public const string Author = "DeepWolf413";
        
        public ConfigEntry<bool> Enabled { get; set; }
        public ConfigEntry<bool> Debug { get; set; }
        
    }
}