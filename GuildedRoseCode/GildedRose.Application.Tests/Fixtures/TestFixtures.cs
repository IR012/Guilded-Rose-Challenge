using GildedRose.Application.Entities;

namespace GildedRose.Application.Tests.Fixtures
{
    internal static class TestFixtures
    {
        public static List<Item> InitialItems => new List<Item>
        {
            new Item { Name = Names.DEXTERITY_VEST, SellIn = 10, Quality = 20 },
            new Item { Name = Names.AGED_BRIE, SellIn = 2, Quality = 0 },
            new Item { Name = Names.ELIXIR, SellIn = 5, Quality = 7 },
            new Item { Name = Names.SULFURAS, SellIn = 0, Quality = 80 },
            new Item { Name = Names.BACKSTAGE_PASSES, SellIn = 15, Quality = 20 },
            new Item { Name = Names.CONJURED_MANA_CAKE, SellIn = 3, Quality = 6 }
        };

        public static List<Item> OnSellInDate => new List<Item>
        {
            new Item { Name = Names.DEXTERITY_VEST, SellIn = 0, Quality = 20 },
            new Item { Name = Names.AGED_BRIE, SellIn = 0, Quality = 0 },
            new Item { Name = Names.ELIXIR, SellIn = 0, Quality = 7 },
            new Item { Name = Names.SULFURAS, SellIn = 0, Quality = 80 },
            new Item { Name = Names.BACKSTAGE_PASSES, SellIn = 0, Quality = 0 },
            new Item { Name = Names.CONJURED_MANA_CAKE, SellIn = 0, Quality = 6 }
        };
    }
}
