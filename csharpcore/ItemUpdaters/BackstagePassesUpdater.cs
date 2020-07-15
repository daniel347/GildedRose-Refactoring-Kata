namespace csharpcore.ItemUpdaters
{
    public class BackstagePassesUpdater : ItemUpdater
    {
        const string backstagePasses = "Backstage passes";
        
        public override bool IsThisItem(Item item)
        {
            return item.Name.Contains(backstagePasses);
        }
        
        public override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                item.Quality += 3;
            }
            else if (item.SellIn <= 10)
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