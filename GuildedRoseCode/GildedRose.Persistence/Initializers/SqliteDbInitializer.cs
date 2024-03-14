using GildedRose.Application.Entities;
using GildedRose.Persistence.Connections;
using GildedRose.Persistence.Database;
using System.Data;

namespace GildedRose.Persistence.Initializers
{
    public class SqliteDbInitializer : IDbInitializer<Item>
    {
        private readonly IDbConnectionFactory _dbConnectionFactory;

        public SqliteDbInitializer(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IList<Item>> InitializeAsync()
        {
            using (IDbConnection connection = _dbConnectionFactory.Connect())
            {
                await Operations.CreateItems(connection);

                IEnumerable<Item> items = await Operations.SelectItems(connection);

                if (items.Any())
                    return items.ToList();
                else
                {
                    await Operations.InsertItems(connection, InitialData.GetItems());
                    return InitialData.GetItems(); 
                }
                    
            }
        }
    }
}
