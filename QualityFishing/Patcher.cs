using HarmonyLib;

namespace QualityFishing
{
    internal class Patcher
    {
        [HarmonyPostfix]
        [HarmonyPatch(declaringType: typeof(AI_Fish), methodName: nameof(AI_Fish.Makefish))]
        internal static void AI_FishMakefish(ref Thing __result, Chara c)
        {
            AI_FishPatch.MakefishPostfix(__result: ref __result, c: c);
        }
    }
}