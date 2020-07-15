using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace csharpcore
{
    public class ConjuredTest
    {
        [Fact]
        public void Quality_IsNotGreaterThan50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Foo", SellIn = -1, Quality = 60 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        [Fact]
        public void Quality_IsNotLessThan0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Bar", SellIn = 10, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }

        [Fact]
        public void Quality_DecreasesBy2BeforeSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 1, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(18);
        }
        
        [Fact]
        public void Quality_DecreasesBy4AfterSellByDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 36 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(32);
        }
    }
}