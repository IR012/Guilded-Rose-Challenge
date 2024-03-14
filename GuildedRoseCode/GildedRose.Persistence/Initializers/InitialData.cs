using GildedRose.Application.Entities;

namespace GildedRose.Persistence.Initializers
{
    public static class InitialData
    {
        private static List<Item> _items = new List<Item>
        {
            new Item { Name = Names.DEXTERITY_VEST, SellIn = 10, Quality = 20 },
            new Item { Name = Names.AGED_BRIE, SellIn = 2, Quality = 0 },
            new Item { Name = Names.ELIXIR, SellIn = 5, Quality = 7 },
            new Item { Name = Names.SULFURAS, SellIn = 0, Quality = 80 },
            new Item { Name = Names.BACKSTAGE_PASSES, SellIn = 15, Quality = 20 },
            new Item { Name = Names.CONJURED_MANA_CAKE, SellIn = 3, Quality = 6 }
        };
        public static List<Item> GetItems()
        {
            return _items;
        }
    }
}
