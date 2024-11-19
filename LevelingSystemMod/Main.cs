using BepInEx;
using Jotunn.Utils;

namespace Valheim.LevelingSystem
{
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    [BepInPlugin(ModConfiguration.Guid, ModConfiguration.Name, ModConfiguration.Version)]
    public class Main : BaseUnityPlugin
    {
        public static ModConfiguration Configuration { get; } = new ModConfiguration();

        private void Awake()
        {
            Configuration.Initialize(Config);
        }

        private void OnDestroy()
        {
            Configuration.Save(Config);
        }
    }
}