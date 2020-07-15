using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace csharpcore
{
    public class BackstagePassTest
    {
        [Fact]
        public void Quality_IncreasesBy1Before10Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(11, "Sell in is greater than 10");
        }

        [Fact]
        public void Quality_IncreasesBy210DaysBeforeConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(12, "SellIn is between 10 and 5");
        }
        
        [Fact]
        public void Quality_IncreasesBy35DaysBeforeConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 27 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(30, "SellIn is between 5 and 0");
        }
        
        [Fact]
        public void Quality_Is0AfterConcert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 45 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0, "SellIn is less than 0");
        }
        
        [Fact]
        public void Quality_IsNotGreaterThan50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 49 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(50);
        }
        [Fact]
        public void Quality_IsNotLessThan0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = -10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Items[0].Quality.Should().Be(0);
        }
    }
}