using BepInEx.Configuration;

namespace QualityFishing
{
    internal static class QualityFishingConfig
    {
        internal static ConfigEntry<bool> EnableQuality;
        internal static ConfigEntry<bool> EnableLevel;

        internal static void LoadConfig(ConfigFile config)
        {
            EnableQuality = config.Bind(
                section: ModInfo.Name,
                key: "EnableQuality",
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
                key: "EnableLevel",
                defaultValue: true,
                description: "Enable or disable leveling up fish based on player's fishing level.\n" +
                             "Set to 'true' to enable leveling, or 'false' to disable it.\n" +
                             "プレイヤーレベルに基づいて魚をレベルアップする機能を有効または無効にします。\n" +
                             "'true' に設定するとレベルアップが有効になり、'false' に設定すると無効になります。\n" +
                             "启用或禁用根据玩家等级提升鱼的等级。\n" +
                             "设置为 'true' 启用等级调整，或设置为 'false' 禁用此功能。"
            );
        }
    }
}