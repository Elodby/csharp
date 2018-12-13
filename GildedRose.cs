using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> _items)
        {
            this.Items = _items;
        }

        public void UpdateQuality()
        {
            bool isBackstage;
            bool isSellinPassed;

            foreach (Item item in Items)
            {
                if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                    continue;

                isBackstage = item.Name.StartsWith("Backstage passes");
                isSellinPassed = item.SellIn < 0;
                if (!item.Name.Equals("Aged Brie") && !isBackstage)
                {
                    item.Quality--;
                    if (item.Name.StartsWith("Conjured") || isSellinPassed)
                    {
                        item.Quality--;
                    }

                    item.Quality = item.Quality < 0 ? 0 : item.Quality;
                }
                else
                {
                    item.Quality = item.Quality < 50 ? item.Quality++ : 50;
                    if (isBackstage)
                    {
                        if (isSellinPassed)
                        {
                            item.Quality = 0;
                        }
                        else if (item.SellIn < 11 && item.Quality < 50)
                        {
                            item.Quality++;

                            if (item.SellIn < 6 && item.Quality < 50)
                            {
                                item.Quality++;
                            }
                        }
                    }
                }
            }
        }

        public void UpdateSellIn()
        {
            foreach (Item item in Items)
            {
                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    item.SellIn--;
                }
            }
        }

    }
}
