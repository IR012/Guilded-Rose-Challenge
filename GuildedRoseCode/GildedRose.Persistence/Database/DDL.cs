namespace GildedRose.Persistence.Database
{
    public class DDL
    {
        public const string CREATE_ITEMS = @"
            CREATE TABLE IF NOT EXISTS Items (
                Name TEXT, 
                SellIn INT, 
                Quality INT
            )
        ";
    }
}
