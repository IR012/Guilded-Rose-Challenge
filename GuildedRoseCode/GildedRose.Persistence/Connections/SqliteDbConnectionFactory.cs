using Microsoft.Data.Sqlite;
using System.Data;

namespace GildedRose.Persistence.Connections
{
    public class SqliteDbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqliteDbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection Connect()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
