using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.MaterialType;

namespace LearnPortal.BLL.Interfaces
{
    public interface IVideoService
    {
        Task CreateVideo(VideoDTO video);

        Task DeleteVideo(int id);

        Task UpdateVideo(VideoDTO video);

        IEnumerable<VideoDTO> FindVideo(Func<Video, bool> predicate);

        Task<VideoDTO> GetVideo(int id);

        Task<IEnumerable<VideoDTO>> GetVideosAsync();
    }
}
