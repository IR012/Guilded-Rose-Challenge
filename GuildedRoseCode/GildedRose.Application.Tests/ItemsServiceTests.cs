using GildedRose.Application.Entities;
using GildedRose.Application.Interfaces.Entities;
using GildedRose.Application.Interfaces.Repositories;
using GildedRose.Application.Services;
using GildedRose.Application.Tests.Fixtures;
using Moq;
using Xunit;

namespace GildedRose.Application.Tests
{
    public class ItemsServiceTests
    {
        [Fact]
        public void ItemsService_GetUpdatedQuality_UpdateQualityOnce()
        {
            // Arrange
            var mockShop = new Mock<IShop>();
            mockShop.Setup(s => s.UpdateQuality());

            var mockItemsRepository = new Mock<IItemsRepository>();

            var sut = new ItemsService(mockShop.Object, mockItemsRepository.Object);

            // Act
            sut.GetUpdatedQuality();

            // Assert 
            mockShop.Verify(s => s.UpdateQuality(), Times.Once);
        }

        [Fact]
        public void ItemsService_GetUpdatedQuality_ReturnsList()
        {
            // Arrange
            var mockShop = new Mock<IShop>();
            mockShop.Setup(s => s.Items).Returns(TestFixtures.InitialItems);

            var mockItemsRepository = new Mock<IItemsRepository>();

            var sut = new ItemsService(mockShop.Object, mockItemsRepository.Object);

            // Act
            var result = sut.GetUpdatedQuality();

            // Assert 
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public async void ItemsService_GetItemsAsync_ReturnsList()
        {
            // Arrange
            var mockShop = new Mock<IShop>();

            var mockItemsRepository = new Mock<IItemsRepository>();
            mockItemsRepository.Setup(s => s.GetItemsAsync()).ReturnsAsync(TestFixtures.InitialItems);

            var sut = new ItemsService(mockShop.Object, mockItemsRepository.Object);

            // Act
            var result = await sut.GetItemsAsync();

            // Assert 
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public async Task ItemsService_ResetItemsAsync_ReturnsList()
        {
            // Arrange
            var mockShop = new Mock<IShop>();

            var mockItemsRepository = new Mock<IItemsRepository>();
            mockItemsRepository.Setup(s => s.ResetItemsAsync()).ReturnsAsync(TestFixtures.InitialItems);

            var sut = new ItemsService(mockShop.Object, mockItemsRepository.Object);

            // Act
            var result = await sut.ResetItemsAsync();

            // Assert 
            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public async Task ItemsService_SaveItemsAsync_AcceptsListArgument()
        {
            // Arrange
            var mockShop = new Mock<IShop>();

            var mockItemsRepository = new Mock<IItemsRepository>();
            mockItemsRepository.Setup(s => s.SaveItemsAsync(It.IsAny<List<Item>>()));

            var sut = new ItemsService(mockShop.Object, mockItemsRepository.Object);

            // Act
            await sut.SaveItemsAsync(TestFixtures.OnSellInDate);

            // Assert 
            mockItemsRepository.Verify(s => s.SaveItemsAsync(It.IsAny<List<Item>>()), Times.Once);
        }

    }
}
