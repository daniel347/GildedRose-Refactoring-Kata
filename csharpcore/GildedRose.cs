using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (ItemClassifier.ClassifyItemByName(item))
                {
                    case ItemType.Sulfuras:
                        SetSulfurasQuality(item);
                        break;

                    case ItemType.AgedBrie:
                        SetAgedBrieQuality(item);
                        item.SellIn -= 1;
                        break;

                    case ItemType.BackstagePasses:
                        SetBackstagePassQuality(item);
                        item.SellIn -= 1;
                        break;
                    
                    case ItemType.Conjured:
                        

                    default:
                        SetGeneralItemQuality(item);
                        item.SellIn -= 1;
                        break;
                }
            }
        }

        public void ConstrainQualityToValidRange(Item item)
        {
            item.Quality = Math.Max(Math.Min(50, item.Quality), 0);
        }

        public void SetGeneralItemQuality(Item item)
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

        public void SetAgedBrieQuality(Item item)
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

        public void SetSulfurasQuality(Item item)
        {
            item.Quality = 80;
        }

        public void SetBackstagePassQuality(Item item)
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

        public void SetConjuredQuality(Item item)
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
