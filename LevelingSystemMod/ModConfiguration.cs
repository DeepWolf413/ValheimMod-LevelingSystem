using BepInEx.Configuration;

namespace Valheim.LevelingSystem
{
	/// <summary>
	/// The <see cref="ModConfiguration"/> class is responsible for managing the configuration settings for the mod. 
	/// It sets up initial configuration values, provides access to mod metadata such as the identifier, 
	/// name, description, version, and author, and facilitates reading and updating configuration values 
	/// as needed by the mod.
	/// </summary>
    public sealed class ModConfiguration
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
        
        public ConfigEntry<bool> Enabled { get; private set; }
        public ConfigEntry<bool> Debug { get; private set; }
        public ConfigEntry<bool> UseCustomLevelTable { get; private set; }
		public ConfigEntry<int> MaxLevel { get; private set; }
		public ConfigEntry<int> TotalExperience { get; private set; }
		
		
        internal void Initialize(ConfigFile configFile)
        {
	        var generalAcceptableValueRange = new AcceptableValueRange<int>(0, int.MaxValue);
	        
	        Enabled = configFile.Bind("General", "Enabled", true, "Enable the mod.");
	        Debug = configFile.Bind("General", "Debug", false, "Enable debug logging.");
	        UseCustomLevelTable = configFile.Bind("General", "UseCustomLevelTable", false, "Whether to use a custom level table. If false, uses the procedural level table.");
	        MaxLevel = configFile.Bind("General", "MaxLevel", 20, new ConfigDescription("The highest level a character can reach. Ignored if UseCustomLevelTable is true.", generalAcceptableValueRange));
	        TotalExperience = configFile.Bind("General", "TotalExperience", 100000, new ConfigDescription("The total amount of experience a character needs to reach the max level. Ignored if UseCustomLevelTable is true.", generalAcceptableValueRange));
	        
	        Jotunn.Logger.LogInfo("Successfully loaded config.");
	        Save(configFile);
        }
        
        internal void Save(ConfigFile configFile)
		{
			if (configFile == null)
			{
				Jotunn.Logger.LogError("Failed to save config. Config file is null.");
				return;
			}
			
			configFile.Save();
		}
    }
}