namespace csharpcore.ItemUpdaters
{
    public class SulfurasUpdater : ItemUpdater
    {
        const string sulfuras = "Sulfuras";

        public override bool IsThisItem(Item item)
        {
            return item.Name.Contains(sulfuras);
        }

        public override void UpdateQuality(Item item)
        {
            item.Quality = 80;
        }

        public override void UpdateSellIn(Item item)
        {
            //Do not decrement sell in for sulfuras
        }
    }
}