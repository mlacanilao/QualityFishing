using UnityEngine;

namespace QualityFishing
{
    internal class AI_FishPatch
    {
        internal static void MakefishPostfix(ref Thing __result, Chara c)
        {
            if (c == null ||
                c.IsPC == false ||
                __result?.source?._origin != "fish")
            {
                return;
            }
            
            bool enableQuality = QualityFishingConfig.EnableQuality?.Value ?? true;
            bool enableLevel = QualityFishingConfig.EnableLevel?.Value ?? true;
            bool enableVanillaLevelScaling = QualityFishingConfig.EnableVanillaLevelScaling?.Value ?? false;
            
            int fishingLevel = c.Evalue(ele: 245);
            
            if (enableVanillaLevelScaling == true)
            {
                fishingLevel /= 10;
            }
            
            if (enableQuality == true)
            {
                __result.elements?.SetBase(id: 2, v: fishingLevel, potential: 0);
            }
            
            if (enableLevel == true)
            {
                CraftUtilOmega.Level(t: __result, obj: null, num: fishingLevel);
            }
        }
    }
}