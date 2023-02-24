using LearnPortal.BLL.DTO;

namespace LearnPortal.PL.Interfaces
{
    internal interface IUiService<T>
    {
        UserDTO CurrentUser { get; }

        T EnteringFields();

        Task CreateAsync();

        Task GetAsync();

        Task UpdateAsync();

        Task DeleteAsync();

        Task GetAllAsync();
    }
}
