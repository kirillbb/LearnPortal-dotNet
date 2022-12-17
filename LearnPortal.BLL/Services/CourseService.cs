using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Course> _courseRepo;
        private IMapper _mapper;

        public CourseService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _courseRepo = new GenericRepository<Course>(_context);
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseDTO>()).CreateMapper();
        }

        public IEnumerable<CourseDTO> FindCourse(Func<Course, bool> predicate)
        {
            return _mapper.Map<IEnumerable<Course>, List<CourseDTO>>( _courseRepo.Find(predicate));
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesAsync()
        {
            return _mapper.Map<IEnumerable<Course>, List<CourseDTO>>(await _courseRepo.GetAllAsync());
        }

        public async Task CreateCourse(CourseDTO course)
        {
            course.Id = new Guid();
            course.OwnerId = _currentUser.Id;
            await _courseRepo.CreateAsync(_mapper.Map<Course>(course));
        }

        public async Task DeleteCourse(int id)
        {
            await _courseRepo.DeleteAsync(id);
        }

        public async Task UpdateCourse(CourseDTO course)
        {
            await _courseRepo.UpdateAsync(_mapper.Map<Course>(course));
        }

        public async Task<CourseDTO> GetCourse(int id)
        {
            return _mapper.Map<CourseDTO>( await _courseRepo.GetAsync(id));
        }
    }
}
