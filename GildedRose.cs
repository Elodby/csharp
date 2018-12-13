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
            bool isConjuredOrPassed;
            foreach (Item item in Items)
            {
                if (item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                    continue;

                isBackstage = item.Name.StartsWith("Backstage passes");
                if (!item.Name.Equals("Aged Brie") && !isBackstage)
                {
                    isConjuredOrPassed = item.Name.StartsWith("Conjured") || item.SellIn < 0;
                    item.Quality = UsualQualityTreatment(item.Quality, isConjuredOrPassed);
                }
                else
                {
                    item.Quality = QualityIncrease(item, isBackstage);
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

        public int UsualQualityTreatment(int _quality, bool _isConjuredOrPassed)
        {
            _quality--;
            if (_isConjuredOrPassed)
                _quality--;

            return _quality < 0 ? 0 : _quality;
        }

        private int QualityIncrease(Item _item, bool _isBackstage)
        {
            _item.Quality++;
            if (_isBackstage)
                _item.Quality = BackstageQualityTreatment(_item.Quality, _item.SellIn);
            
            return _item.Quality < 50 ? _item.Quality : 50;
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
