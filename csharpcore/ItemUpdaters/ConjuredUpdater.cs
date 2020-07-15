namespace csharpcore.ItemUpdaters
{
    public class ConjuredUpdater : ItemUpdater
    {
        const string conjured = "Conjured";
        
        public override bool IsThisItem(Item item)
        {
            return item.Name.Contains(conjured);
        }

        public override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality -= 4;
            }
            else
            {
                item.Quality -= 2;
            }
        
            ConstrainQualityToValidRange(item);
        }
    }
}