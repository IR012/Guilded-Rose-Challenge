using GildedRose.Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GildedRose.Application.Interfaces.Services
{
    public interface IItemsService
    {
        public IList<Item> GetUpdatedQuality();

        public Task<IList<Item>> GetItemsAsync();

        public Task<IList<Item>> ResetItemsAsync();

        public Task SaveItemsAsync(IList<Item> items);
    }
}
