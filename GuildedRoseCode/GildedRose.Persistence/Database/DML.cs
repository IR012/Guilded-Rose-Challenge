namespace GildedRose.Persistence.Database
{
    public static class DML
    {
        public const string SELECT_ITEMS = @"
            SELECT 
                Name, SellIn, Quality 
            FROM Items
        ";

        public const string INSERT_ITEMS = @"
            INSERT INTO Items 
                (Name, SellIn, Quality) 
            VALUES
                (@Name, @SellIn, @Quality)
        ";

        public const string DELETE_ITEMS = @"
            DELETE 
            FROM Items
        ";
    }
}
