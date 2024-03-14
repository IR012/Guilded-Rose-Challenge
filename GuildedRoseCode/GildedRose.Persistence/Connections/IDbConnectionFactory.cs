using System.Data;

namespace GildedRose.Persistence.Connections
{
    public interface IDbConnectionFactory
    {
        public IDbConnection Connect();
    }
}
