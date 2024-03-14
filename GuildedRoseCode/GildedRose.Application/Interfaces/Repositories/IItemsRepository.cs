using GildedRose.Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GildedRose.Application.Interfaces.Repositories
{
    public interface IItemsRepository
    {
        public Task<IEnumerable<Item>> GetItemsAsync();

        public Task<IEnumerable<Item>> ResetItemsAsync();

        public Task<int> SaveItemsAsync(IList<Item> items);
    }
}
