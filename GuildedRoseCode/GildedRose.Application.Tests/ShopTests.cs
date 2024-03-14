using GildedRose.Application.Entities;
using GildedRose.Application.Tests.Fixtures;
using Xunit;

namespace GildedRose.Application.Tests
{
    public class ShopTests
    {
        [Fact]
        public void Shop_UpdateQuality_DecrementSellIn()
        {
            // Arrange
            var sut = new Shop(TestFixtures.InitialItems);

            // Act
            sut.UpdateQuality();

            // Assert 
            for (int i = 0; i < sut.Items.Count; i++)
            {
                if (sut.Items[i].Name == Names.SULFURAS)
                    Assert.Equal(TestFixtures.InitialItems[i].SellIn, sut.Items[i].SellIn);
                else
                    Assert.Equal(TestFixtures.InitialItems[i].SellIn - 1, sut.Items[i].SellIn);
            }
        }

        [Fact]
        public void Shop_UpdateQuality_QualityChangesCorreclty()
        {
            // Arrange
            var sut = new Shop(TestFixtures.InitialItems);

            // Act
            sut.UpdateQuality();

            // Assert 
            for (int i = 0; i < sut.Items.Count; i++)
            {
                if (sut.Items[i].Name == Names.SULFURAS)
                    Assert.Equal(TestFixtures.InitialItems[i].Quality, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.AGED_BRIE || sut.Items[i].Name == Names.BACKSTAGE_PASSES)
                    Assert.Equal(TestFixtures.InitialItems[i].Quality + 1, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.DEXTERITY_VEST|| sut.Items[i].Name == Names.ELIXIR)
                    Assert.Equal(TestFixtures.InitialItems[i].Quality - 1, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.CONJURED_MANA_CAKE)
                    Assert.Equal(TestFixtures.InitialItems[i].Quality - 2, sut.Items[i].Quality);
            }
        }

        [Fact]
        public void Shop_UpdateQualityOnSellInDate_QualityChangeRateDoubled()
        {
            // Arrange
            var sut = new Shop(TestFixtures.OnSellInDate);

            // Act
            sut.UpdateQuality();

            // Assert 
            for (int i = 0; i < sut.Items.Count; i++)
            {
                if (sut.Items[i].Name == Names.SULFURAS)
                    Assert.Equal(TestFixtures.OnSellInDate[i].Quality, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.AGED_BRIE)
                    Assert.Equal(TestFixtures.OnSellInDate[i].Quality + 2, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.DEXTERITY_VEST || sut.Items[i].Name == Names.ELIXIR)
                    Assert.Equal(TestFixtures.OnSellInDate[i].Quality - 2, sut.Items[i].Quality);

                else if (sut.Items[i].Name == Names.CONJURED_MANA_CAKE)
                    Assert.Equal(TestFixtures.OnSellInDate[i].Quality - 4, sut.Items[i].Quality);
            }
        }
    }
}
