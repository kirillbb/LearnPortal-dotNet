using AutoMapper;
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
        private IMapper _mapper;

        public PublicationService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _publicationRepo = new GenericRepository<Publication>(_context);
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Publication, PublicationDTO>()).CreateMapper();
        }

        public async Task CreatePublication(PublicationDTO publication)
        {
            publication.Id = new Guid();
            publication.OwnerId = _currentUser.Id;
            await _publicationRepo.CreateAsync(_mapper.Map<Publication>(publication));
        }

        public async Task DeletePublication(int id)
        {
            await _publicationRepo.DeleteAsync(id);
        }

        public IEnumerable<PublicationDTO> FindPublication(Func<Publication, bool> predicate)
        {
            return _mapper.Map<IEnumerable<Publication>, List<PublicationDTO>>(_publicationRepo.Find(predicate));
        }

        public async Task<PublicationDTO> GetPublication(int id)
        {
            return _mapper.Map<PublicationDTO>(await _publicationRepo.GetAsync(id));
        }

        public async Task<IEnumerable<PublicationDTO>> GetPublicationsAsync()
        {
            return _mapper.Map<IEnumerable<Publication>, List<PublicationDTO>>(await _publicationRepo.GetAllAsync());
        }

        public async Task UpdatePublication(PublicationDTO publication)
        {
            await _publicationRepo.UpdateAsync(_mapper.Map<Publication>(publication));
        }
    }
}
