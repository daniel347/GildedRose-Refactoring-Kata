using System;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;
        
        const string sulfuras = "Sulfuras, Hand of Ragnaros";
        const string agedBrie = "Aged Brie";
        const string backstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                switch (item.Name)
                {
                    case sulfuras:
                        SetSulfurasQuality(item);
                        break;
                    
                    case agedBrie:
                        SetAgedBrieQuality(item);
                        break;
                    
                    case backstagePasses:
                        SetBackstagePassQuality(item);
                        break;
                    
                    default:
                        SetGeneralItemQuality(item);
                        break;
                }
                
                if (item.Name != sulfuras)
                {
                    item.SellIn -= 1;
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
    }
}
