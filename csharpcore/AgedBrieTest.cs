using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace csharpcore
{
    public class AgedBrieTest
    {
        [Fact]
        public void Quality_IncreasesBy1BeforeSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11, "Sell by date has not passed");
        }
        
        [Fact]
        public void Quality_IncreasesBy2AfterSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12, "Sell by date passed today");
        }
        
        [Fact]
        public void Quality_IsNotGreaterThan50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -1, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        [Fact]
        public void Quality_IsNotLessThan0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = -10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
    }
}