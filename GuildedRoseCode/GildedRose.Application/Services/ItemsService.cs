using GildedRose.Application.Entities;
using GildedRose.Application.Interfaces.Entities;
using GildedRose.Application.Interfaces.Repositories;
using GildedRose.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GildedRose.Application.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IShop _shop;
        private readonly IItemsRepository _itemsRepository;
        public ItemsService(IShop shop, IItemsRepository itemsRepository)
        {
            _shop = shop;
            _itemsRepository = itemsRepository;
        }

        public IList<Item> GetUpdatedQuality()
        {
            _shop.UpdateQuality();
            return _shop.Items;
        }

        public async Task<IList<Item>> GetItemsAsync()
        {
            var items = await _itemsRepository.GetItemsAsync();
            return items.ToList();
        }

        public async Task<IList<Item>> ResetItemsAsync()
        {
            var items = await _itemsRepository.ResetItemsAsync();
            return items.ToList();
        }

        public async Task SaveItemsAsync(IList<Item> items)
        {
            await _itemsRepository.SaveItemsAsync(items);
        }
    }
}
