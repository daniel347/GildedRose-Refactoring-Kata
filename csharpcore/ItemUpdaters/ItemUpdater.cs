using System;

namespace csharpcore
{
    public class ItemUpdater
    {
        protected void ConstrainQualityToValidRange(Item item)
        {
            item.Quality = Math.Max(Math.Min(50, item.Quality), 0);
        }

        public virtual bool IsThisItem(Item item)
        {
            return true;
        }

        public virtual void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality -= 1;
            }
            
            ConstrainQualityToValidRange(item);
        }

        public virtual void UpdateSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }
}