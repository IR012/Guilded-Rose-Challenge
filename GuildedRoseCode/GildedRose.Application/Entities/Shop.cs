using GildedRose.Application.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace GildedRose.Application.Entities
{
    public class Shop : IShop
    {
        public IList<Item> Items { get; set; }

        private void QualityIncrease(Item item, Action<Item> callback)
        {
            if (item.Quality < 50)
                item.Quality++;

            callback(item);
        }

        private void QualityDecrease(Item item, int amount)
        {
            if (item.Quality > 0)
                item.Quality -= amount;

            if (--item.SellIn < 0 && item.Quality > 0)
                item.Quality -= amount;
        }

        private void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case Names.SULFURAS:
                    break;

                case Names.AGED_BRIE:
                    QualityIncrease(item, (item) =>
                    {
                        if (--item.SellIn < 0 && item.Quality < 50)
                            item.Quality++;
                    });
                    break;

                case Names.BACKSTAGE_PASSES:
                    QualityIncrease(item, (item) =>
                    {
                        if (item.Quality < 50)
                        {
                            if (item.SellIn < 11)
                                item.Quality++;

                            if (item.SellIn < 6)
                                item.Quality++;
                        }
                        if (--item.SellIn < 0)
                            item.Quality -= item.Quality;
                    });
                    break;

                case Names.CONJURED_MANA_CAKE:
                    QualityDecrease(item, 2);
                    break;

                default:
                    QualityDecrease(item, 1);
                    break;
            }
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
                UpdateItemQuality(item);
        }

        public Shop(IList<Item> items) => Items = items;

        public Shop() => Items = new List<Item>();
    }
}
