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

            foreach (Item item in Items)
            {
                if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                    continue;

                isBackstage = item.Name.StartsWith("Backstage passes");
                if (!item.Name.Equals("Aged Brie") && !isBackstage)
                {
                    item.Quality = UsualQualityTreatment(item.Quality, item.Name.StartsWith("Conjured"), item.SellIn < 0);
                }
                else
                {
                    item.Quality = QualityIncrease(item.Quality, item.SellIn, isBackstage);
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

        public int UsualQualityTreatment(int _quality, bool isConjured, bool isSellinPassed)
        {
            _quality--;
            if (isConjured || isSellinPassed)
            {
                _quality--;
            }

            return _quality < 0 ? 0 : _quality;
        }

        private int QualityIncrease(int _quality, int _sellIn, bool isBackstage)
        {
            _quality++;
            if (isBackstage)
            {
                _quality = BackstageQualityTreatment(_quality, _sellIn);
            }
            
            return _quality < 50 ? _quality : 50;
        }

        private int BackstageQualityTreatment(int _quality, int _sellIn)
        {
            if (_sellIn < 0)
            {
                _quality = 0;
            }
            else if (_sellIn < 11)
            {
                _quality++;

                if (_sellIn < 6)
                    _quality++;
            }

            return _quality;
        }

    }
}
