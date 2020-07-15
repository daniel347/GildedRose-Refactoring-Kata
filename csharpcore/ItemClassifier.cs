using System.Threading;

namespace csharpcore
{
    public class ItemClassifier
    {
        const string sulfuras = "Sulfuras";
        const string agedBrie = "Aged Brie";
        const string backstagePasses = "Backstage passes";
        const string conjured = "Conjured";

        static public ItemType ClassifyItemByName(Item item)
        {
            if (item.Name.Contains(sulfuras))
            {
                return ItemType.Sulfuras;
            }
            if (item.Name.Contains(agedBrie))
            {
                return ItemType.AgedBrie;
            }
            if (item.Name.Contains(backstagePasses))
            {
                return ItemType.BackstagePasses;
            }
            if (item.Name.Contains(conjured))
            {
                return ItemType.Conjured;
            }
            return ItemType.Other;
        }
    }

    public enum ItemType
    {
        Sulfuras,
        AgedBrie,
        BackstagePasses,
        Conjured,
        Other
    }
}