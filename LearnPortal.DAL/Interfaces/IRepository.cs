namespace LearnPortal.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);
        
        IEnumerable<T> Find(Func<T, Boolean> predicate);

        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(Guid id);
    }
}
