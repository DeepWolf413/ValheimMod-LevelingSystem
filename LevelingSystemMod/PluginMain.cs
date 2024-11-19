using System;
using BepInEx;
using Jotunn.Utils;

namespace LevelingSystemMod
{
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    [BepInPlugin(PluginConfig.Guid, PluginConfig.Name, PluginConfig.Version)]
    public class PluginMain : BaseUnityPlugin
    {
        private void Awake()
        {
            
        }
    }
}