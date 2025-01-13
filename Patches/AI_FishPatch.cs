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
            
            int fishingLevel = c.Evalue(ele: 245);
            bool enableQuality = QualityFishingConfig.EnableQuality?.Value ?? true;
            bool enableLevel = QualityFishingConfig.EnableLevel?.Value ?? true;

            if (enableQuality == true)
            {
                int quality = Mathf.Min(a: fishingLevel, b: 50);
                __result.elements?.SetBase(id: 2, v: quality, potential: 0);
            }

            if (enableLevel == true)
            {
                TraitSeed.LevelSeed(t: __result, obj: null, num: fishingLevel);
            }
        }
    }
}