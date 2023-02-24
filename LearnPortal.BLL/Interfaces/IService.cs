using LearnPortal.BLL.DTO;

namespace LearnPortal.BLL.Interfaces
{
    internal interface IService<T>
    {
        Task CreateAsync(T item);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(T item);

        IEnumerable<VideoDTO> Find(Func<T, bool> predicate);

        Task<VideoDTO> GetAsync(Guid id);

        Task<IEnumerable<T>> GetAsync();
    }
}