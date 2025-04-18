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
            List<Element> foodElements = new List<Element>();

            foreach (Element element in t.elements.dict.Values)
            {
                if (element.IsFoodTrait)
                {
                    foodElements.Add(item: element);
                }
            }
            
            if (foodElements.Count == 0)
            {
                return;
            }
            
            foreach (Element element in foodElements)
            {
                t.elements.ModBase(ele: element.id, v: 6);
            }
        }
    }
}