namespace GildedRose.Persistence.Initializers
{
    public interface IDbInitializer<T>
    {
        public Task<IList<T>> InitializeAsync();
    }
}
