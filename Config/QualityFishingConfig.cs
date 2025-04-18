using System.IO;
using BepInEx.Configuration;

namespace QualityFishing
{
    internal static class QualityFishingConfig
    {
        internal static ConfigEntry<bool> EnableQuality;
        internal static ConfigEntry<bool> EnableLevel;
        internal static ConfigEntry<bool> EnableVanillaLevelScaling;
        public static string XmlPath { get; private set; }
        public static string TranslationXlsxPath { get; private set; }

        internal static void LoadConfig(ConfigFile config)
        {
            EnableQuality = config.Bind(
                section: ModInfo.Name,
                key: "Enable Quality",
                defaultValue: true,
                description: "Enable or disable adjusting the quality of fish based on player's fishing level.\n" +
                             "Set to 'true' to enable quality adjustment, or 'false' to disable it.\n" +
                             "プレイヤーレベルに基づいて魚の品質を調整する機能を有効または無効にします。\n" +
                             "'true' に設定すると品質調整が有効になり、'false' に設定すると無効になります。\n" +
                             "启用或禁用根据玩家等级调整鱼的品质。\n" +
                             "设置为 'true' 启用质量调整，或设置为 'false' 禁用此功能。"
            );

            EnableLevel = config.Bind(
                section: ModInfo.Name,
                key: "Enable Level",
                defaultValue: true,
                description: "Enable or disable leveling up fish based on player's fishing level.\n" +
                             "Set to 'true' to enable leveling, or 'false' to disable it.\n" +
                             "プレイヤーレベルに基づいて魚をレベルアップする機能を有効または無効にします。\n" +
                             "'true' に設定するとレベルアップが有効になり、'false' に設定すると無効になります。\n" +
                             "启用或禁用根据玩家等级提升鱼的等级。\n" +
                             "设置为 'true' 启用等级调整，或设置为 'false' 禁用此功能。"
            );
            
            EnableVanillaLevelScaling = config.Bind(
                section: ModInfo.Name,
                key: "Enable Vanilla Level Scaling",
                defaultValue: false,
                description: "Enable or disable vanilla-style scaling for fishing level.\n" +
                             "When enabled, fishing level is divided by 10 for more balanced quality and level adjustments.\n" +
                             "釣りレベルのスケーリングをバニラ風に調整する機能を有効または無効にします。\n" +
                             "有効にすると、釣りレベルは10で割られ、品質やレベルの上昇がより抑えられます。\n" +
                             "启用或禁用类似原版的钓鱼等级缩放。\n" +
                             "启用后，钓鱼等级将除以10，以实现更平衡的质量和等级调整。"
            );
        }
        
        public static void InitializeXmlPath(string xmlPath)
        {
            if (File.Exists(path: xmlPath))
            {
                XmlPath = xmlPath;
            }
            else
            {
                XmlPath = string.Empty;
            }
        }
        
        public static void InitializeTranslationXlsxPath(string xlsxPath)
        {
            if (File.Exists(path: xlsxPath))
            {
                TranslationXlsxPath = xlsxPath;
            }
            else
            {
                TranslationXlsxPath = string.Empty;
            }
        }
    }
}