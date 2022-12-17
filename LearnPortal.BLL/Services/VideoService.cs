using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class VideoService : IVideoService
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Video> _videoRepo;
        private IMapper _mapper;

        public VideoService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _videoRepo = new GenericRepository<Video>(_context);
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Video, VideoDTO>()).CreateMapper();
        }

        public async Task CreateVideo(VideoDTO video)
        {
            video.Id = new Guid();
            video.OwnerId = _currentUser.Id;
            await _videoRepo.CreateAsync(_mapper.Map<Video>(video));
        }

        public async Task DeleteVideo(int id)
        {
            await _videoRepo.DeleteAsync(id);
        }

        public IEnumerable<VideoDTO> FindVideo(Func<Video, bool> predicate)
        {
            return _mapper.Map<IEnumerable<Video>, List<VideoDTO>>(_videoRepo.Find(predicate));
        }

        public async Task<VideoDTO> GetVideo(int id)
        {
            return _mapper.Map<VideoDTO>(await _videoRepo.GetAsync(id));
        }

        public async Task<IEnumerable<VideoDTO>> GetVideosAsync()
        {
            return _mapper.Map<IEnumerable<Video>, List<VideoDTO>>(await _videoRepo.GetAllAsync());
        }

        public async Task UpdateVideo(VideoDTO video)
        {
            await _videoRepo.UpdateAsync(_mapper.Map<Video>(video));
        }
    }
}
