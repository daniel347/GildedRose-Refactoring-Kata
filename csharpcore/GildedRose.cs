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
        
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != sulfuras)
                {
                    item.SellIn -= 1;
                }
                
                if (item.Name != agedBrie && item.Name != backstagePasses)
                {
                    item.Quality -= 1;
                }
                else
                {
                    item.Quality += 1;

                    if (item.Name == backstagePasses)
                    {
                        if (item.SellIn < 11)
                        {
                            item.Quality += 1;
                        }

                        if (item.SellIn < 6)
                        {
                            item.Quality += 1;
                        }
                    }
                }
                
                // updating sellin was here
                
                if (item.SellIn < 0)
                {
                    if (item.Name != agedBrie && item.Name != backstagePasses && item.Name != sulfuras)
                    {
                        item.Quality -= 1;
                    }
                    else
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality += 1;
                        }
                    }
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
            if (item.SellIn <= 10)
            {
                item.Quality += 2;
            }            
            
            if (item.SellIn <= 5)
            {
                item.Quality += 3;
            }            
            
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            
            ConstrainQualityToValidRange(item);
        }
    }
}
