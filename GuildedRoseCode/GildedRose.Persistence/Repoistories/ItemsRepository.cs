using Dapper;
using GildedRose.Application.Entities;
using GildedRose.Application.Interfaces.Repositories;
using GildedRose.Persistence.Connections;
using GildedRose.Persistence.Database;
using GildedRose.Persistence.Initializers;
using System.Data;

namespace GildedRose.Persistence.Repoistories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;
        public ItemsRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            using (IDbConnection connection = _dbConnectionFactory.Connect())
            {
                IEnumerable<Item> items = await Operations.SelectItems(connection);
                return items;
            }
        }

        public async Task<IEnumerable<Item>> ResetItemsAsync()
        {
            using (IDbConnection connection = _dbConnectionFactory.Connect())
            {
                await Operations.DeleteItems(connection);
                await Operations.InsertItems(connection, InitialData.GetItems());
                return await Operations.SelectItems(connection);
            }
        }

        public async Task<int> SaveItemsAsync(IList<Item> items)
        {
            using (IDbConnection connection = _dbConnectionFactory.Connect())
            {
                await Operations.DeleteItems(connection);
                return await Operations.InsertItems(connection, items);
            }
        }
    }
}
