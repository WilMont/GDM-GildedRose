using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }

        [Test]
        public void testQualityIsPositive()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.IsTrue(Items[0].Quality > 0);
        }

        [Test]
        public void testQualityIsInferiorTo50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.IsTrue(Items[0].Quality < 50);
        }

        [Test]
        public void testLegendaryItemNotLosingQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 } };
            Item itemBeforeUpdate = Items[0];
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(itemBeforeUpdate.Quality, Items[0].Quality);
        }

        [Test]
        public void testAgedBrieIncreasingQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            Item itemBeforeUpdate = Items[0];
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.IsTrue(itemBeforeUpdate.Quality < Items[0].Quality);
        }
    }
}
