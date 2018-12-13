using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);
        }

        [Test]
        public void AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateSellIn();
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }

        [Test]
        public void QualityNotNeg()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Product 1", SellIn = 10, Quality = 0 },
                new Item { Name = "Product 2", SellIn = -1, Quality = 1 },
                new Item { Name = "Product 3", SellIn = 0, Quality = -3 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateSellIn();
            app.UpdateQuality();
            foreach (Item item in Items)
            {
                Assert.GreaterOrEqual(item.Quality, 0);
            }
        }

        [Test]
        public void QualityLess50()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Aged Brie", SellIn = -1, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 8, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 2, Quality = 49 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateSellIn();
            app.UpdateQuality();
            foreach (Item item in Items)
            {
                Assert.LessOrEqual(item.Quality, 50);
            }
        }

        [Test]
        public void Backstage()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 49 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 48 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 47 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality =  30},
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateSellIn();
            app.UpdateQuality();
            foreach (Item item in Items)
            {
                if (item.SellIn <= 0)
                {
                    Assert.AreEqual(0, item.Quality);
                }
                else
                {
                    Assert.AreEqual(50, item.Quality);
                }
            }
        }

        [Test]
        public void Conjured()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Conjured", SellIn = 10, Quality = 4 },
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateSellIn();
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
        }
    }
}
