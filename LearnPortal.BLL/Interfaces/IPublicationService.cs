using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.Material;

namespace LearnPortal.BLL.Interfaces
{
    public interface IPublicationService
    {
        Task CreatePublication(PublicationDTO publication);

        Task DeletePublication(int id);

        Task UpdatePublication(PublicationDTO publication);

        IEnumerable<PublicationDTO> FindPublication(Func<Publication, bool> predicate);

        Task<PublicationDTO> GetPublication(int id);

        Task<IEnumerable<PublicationDTO>> GetPublicationsAsync();
    }
}
