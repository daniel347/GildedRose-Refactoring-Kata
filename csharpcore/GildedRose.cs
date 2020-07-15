using System;
using System.Collections.Generic;
using System.Linq;
using csharpcore.ItemUpdaters;

namespace csharpcore
{
    public class GildedRose
    {
        IList<Item> Items;

        private List<ItemUpdater> updaters = new List<ItemUpdater>()
        {
            new SulfurasUpdater(),
            new AgedBrieUpdater(),
            new BackstagePassesUpdater(),
            new ConjuredUpdater(),
            new ItemUpdater()
        };

        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updater = updaters.First(u => u.IsThisItem(item));
                updater.UpdateQuality(item);
                updater.UpdateSellIn(item);
            }
        }
    }
}

       