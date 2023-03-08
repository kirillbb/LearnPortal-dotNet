using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class CourseService : IService<CourseDTO>
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Course> _courseRepo;

        public CourseService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _courseRepo = new GenericRepository<Course>(_context);
        }

        public IEnumerable<CourseDTO> Find(Func<Course, bool> predicate)
        {
            var courses = _courseRepo.Find(predicate);
            List<CourseDTO> coursesDto = new List<CourseDTO>();
            foreach (var course in courses)
            {
                CourseDTO courseDTO = new CourseDTO
                {
                    Description = course.Description,
                    Id = course.Id,
                    OwnerId = course.OwnerId,
                    Title = course.Title,
                };

                coursesDto.Add(courseDTO);
            }

            return coursesDto;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var courses = await _courseRepo.GetAllAsync();
            List<CourseDTO> coursesDto = new List<CourseDTO>();
            foreach (var course in courses)
            {
                CourseDTO courseDTO = new CourseDTO
                {
                    Id = course.Id,
                    Title = course.Title,
                    Description = course.Description,
                    OwnerId = course.OwnerId,
                };

                coursesDto.Add(courseDTO);
            }

            return coursesDto;
        }

        public async Task CreateAsync(CourseDTO course)
        {
            await _courseRepo.CreateAsync(new Course
            {
                Id = new Guid(),
                Title = course.Title,
                Description = course.Description,
                OwnerId = _currentUser.Id,
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            await _courseRepo.DeleteAsync(id);
        }

        public async Task UpdateAsync(CourseDTO course)
        {
            await _courseRepo.UpdateAsync(new Course
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                OwnerId = course.OwnerId,
            });
        }

        public async Task<CourseDTO> GetAsync(Guid id)
        {
            var course = await _courseRepo.GetAsync(id);
            return new CourseDTO
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
                OwnerId = course.OwnerId,
            };
        }
    }
}