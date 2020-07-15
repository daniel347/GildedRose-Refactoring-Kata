namespace csharpcore.ItemUpdaters
{
    public class AgedBrieUpdater : ItemUpdater
    {
        const string agedBrie = "Aged Brie";

        public override bool IsThisItem(Item item)
        {
            return item.Name.Contains(agedBrie);
        }

        public override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality += 2;
            }
            else
            {
                item.Quality += 1;
            }
            
            ConstrainQualityToValidRange(item);
        }
    }
}