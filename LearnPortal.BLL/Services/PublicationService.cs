using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Publication> _publicationRepo;

        public PublicationService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _publicationRepo = new GenericRepository<Publication>(_context);
        }

        public async Task CreatePublication(PublicationDTO publication)
        {
            await _publicationRepo.CreateAsync(new Publication
            {
                Id = new Guid(),
                Title = publication.Title,
                CreationDate = publication.CreationDate,
                Discriminator = "Publication",
                Description = publication.Description,
                OwnerId = _currentUser.Id,
            });
        }

        public async Task DeletePublication(Guid id)
        {
            await _publicationRepo.DeleteAsync(id);
        }

        public IEnumerable<PublicationDTO> FindPublication(Func<Publication, bool> predicate)
        {
            var publications = _publicationRepo.Find(predicate);
            List<PublicationDTO> publicationDTOs = new List<PublicationDTO>();
            foreach (var publication in publications)
            {
                PublicationDTO publicationDTO = new PublicationDTO
                {
                    Id = publication.Id,
                    Title = publication.Title,
                    CreationDate = publication.CreationDate,
                    Description = publication.Description,
                    OwnerId = publication.OwnerId,
                };

                publicationDTOs.Add(publicationDTO);
            }

            return publicationDTOs;
        }

        public async Task<PublicationDTO> GetPublication(Guid id)
        {
            var publication = await _publicationRepo.GetAsync(id);
            return new PublicationDTO
            {
                Id = publication.Id,
                Title = publication.Title,
                CreationDate = publication.CreationDate,
                Description = publication.Description,
                OwnerId = publication.OwnerId,
            };
        }

        public async Task<IEnumerable<PublicationDTO>> GetPublicationsAsync()
        {
            var publications = await _publicationRepo.GetAllAsync();
            List<PublicationDTO> publicationDTOs = new List<PublicationDTO>();
            foreach (var publication in publications)
            {
                PublicationDTO publicationDTO = new PublicationDTO
                {
                    Id = publication.Id,
                    Title = publication.Title,
                    CreationDate = publication.CreationDate,
                    Description = publication.Description,
                    OwnerId = publication.OwnerId,
                };

                publicationDTOs.Add(publicationDTO);
            }

            return publicationDTOs;
        }

        public async Task UpdatePublication(PublicationDTO publication)
        {
            await _publicationRepo.UpdateAsync(new Publication
            {
                Id = publication.Id,
                Title = publication.Title,
                CreationDate = publication.CreationDate,
                Description = publication.Description,
                OwnerId = publication.OwnerId,
            });
        }
    }
}
