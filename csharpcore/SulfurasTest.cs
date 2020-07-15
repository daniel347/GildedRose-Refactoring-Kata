using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace csharpcore
{
    public class SulfurasTest
    {
        [Fact]
        public void Quality_IsAlways80()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(80);
            
            Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 80 } };
            app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(80);
        }

        [Fact]
        public void SellIn_DoesNotChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].SellIn.Should().Be(-3);
            
            Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -3, Quality = 80 } };
            app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].SellIn.Should().Be(-3);

        }
    }
}