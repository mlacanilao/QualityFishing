using System.Collections.Generic;

namespace QualityFishing
{
    internal class CraftUtilOmega
    {
        internal static void Level(Thing t, SourceObj.Row obj, int num)
        {
            for (int i = 0; i < num; i++)
            {
                if (obj == null || obj.objType == "crop")
                {
                    CraftUtilOmega.ModRandomFoodEnc(t: t);
                }
                t.ModEncLv(a: 1);
            }
        }

        private static void ModRandomFoodEnc(Thing t)
        {
            Element foodElement = null;
            foreach (Element element in t.elements.dict.Values)
            {
                if (element.IsFoodTrait)
                {
                    foodElement = element;
                }
            }
            if (foodElement == null)
            {
                return;
            }
            t.elements.ModBase(ele: foodElement.id, v: 6);
            if (foodElement.Value > 60)
            {
                t.elements.SetTo(foodElement.id, 60);
            }
        }
    }
}