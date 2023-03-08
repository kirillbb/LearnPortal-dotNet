using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class VideoService : IService<VideoDTO>
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Video> _videoRepo;

        public VideoService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _videoRepo = new GenericRepository<Video>(_context);
        }

        public async Task CreateAsync(VideoDTO video)
        {
            await _videoRepo.CreateAsync(new Video
            {
                Id = new Guid(),
                Title = video.Title,
                Discriminator = "Video",
                Description = video.Description,
                OwnerId = _currentUser.Id,
                Duration = video.Duration,
                Resolution = video.Resolution,
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            await _videoRepo.DeleteAsync(id);
        }

        public IEnumerable<VideoDTO> FindVideo(Func<Video, bool> predicate)
        {
            var videos = _videoRepo.Find(predicate);
            List<VideoDTO> videoDTOs = new List<VideoDTO>();
            foreach (var video in videos)
            {
                VideoDTO videoDTO = new VideoDTO
                {
                    Id = video.Id,
                    Title = video.Title,
                    Discriminator = video.Discriminator,
                    Description = video.Description,
                    OwnerId = video.OwnerId,
                    Duration = video.Duration,
                    Resolution = video.Resolution,
                };

                videoDTOs.Add(videoDTO);
            }

            return videoDTOs;
        }

        public async Task<VideoDTO> GetAsync(Guid id)
        {
            var video = await _videoRepo.GetAsync(id);
            return new VideoDTO
            {
                Id = video.Id,
                Title = video.Title,
                Discriminator = video.Discriminator,
                Description = video.Description,
                OwnerId = video.OwnerId,
                Duration = video.Duration,
                Resolution = video.Resolution,
            };
        }

        public async Task<IEnumerable<VideoDTO>> GetAllAsync()
        {
            var videos = await _videoRepo.GetAllAsync();
            List<VideoDTO> videoDTOs = new List<VideoDTO>();
            foreach (var video in videos)
            {
                VideoDTO videoDTO = new VideoDTO
                {
                    Id = video.Id,
                    Title = video.Title,
                    Discriminator = video.Discriminator,
                    Description = video.Description,
                    OwnerId = video.OwnerId,
                    Duration = video.Duration,
                    Resolution = video.Resolution,
                };

                videoDTOs.Add(videoDTO);
            }

            return videoDTOs;
        }

        public async Task UpdateAsync(VideoDTO video)
        {
            await _videoRepo.UpdateAsync(new Video
            {
                Id = video.Id,
                Title = video.Title,
                Discriminator = video.Discriminator,
                Description = video.Description,
                OwnerId = video.OwnerId,
                Duration = video.Duration,
                Resolution = video.Resolution,
            });
        }
    }
}