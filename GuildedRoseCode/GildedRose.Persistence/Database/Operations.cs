using Dapper;
using GildedRose.Application.Entities;
using System.Data;

namespace GildedRose.Persistence.Database
{
    public static class Operations
    {
        public static Func<IDbConnection, Task<int>> CreateItems
        {
            get => (connection) => connection.ExecuteAsync(DDL.CREATE_ITEMS);
        }

        public static Func<IDbConnection, Task<IEnumerable<Item>>> SelectItems
        {
            get => (connection) => connection.QueryAsync<Item>(DML.SELECT_ITEMS);
        }

        public static Func<IDbConnection, IList<Item>, Task<int>> InsertItems
        {
            get => (connection, items) => connection.ExecuteAsync(DML.INSERT_ITEMS, items);
        }

        public static Func<IDbConnection, Task<int>> DeleteItems
        {
            get => (connection) => connection.ExecuteAsync(DML.DELETE_ITEMS);
        }
    }
}
