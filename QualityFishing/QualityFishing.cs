using BepInEx;
using HarmonyLib;

namespace QualityFishing
{
    internal static class ModInfo
    {
        internal const string Guid = "omegaplatinum.elin.qualityfishing";
        internal const string Name = "Quality Fishing";
        internal const string Version = "1.0.0.2";
    }

    [BepInPlugin(GUID: ModInfo.Guid, Name: ModInfo.Name, Version: ModInfo.Version)]
    internal class QualityFishing : BaseUnityPlugin
    {
        internal static QualityFishing Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            QualityFishingConfig.LoadConfig(config: Config);
        }

        private void Start()
        {
            Harmony.CreateAndPatchAll(type: typeof(Patcher), harmonyInstanceId: ModInfo.Guid);
        }
        
        internal static void Log(object payload)
        {
            Instance?.Logger.LogInfo(data: payload);
        }
    }
}