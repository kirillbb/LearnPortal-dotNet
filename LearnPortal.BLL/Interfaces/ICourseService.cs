using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.CourseType;

namespace LearnPortal.BLL.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CourseDTO course);

        Task DeleteCourse(Guid id);

        Task UpdateCourse(CourseDTO course);

        IEnumerable<CourseDTO> FindCourse(Func<Course, bool> predicate);

        Task<CourseDTO> GetCourse(Guid id);

        Task<IEnumerable<CourseDTO>> GetCoursesAsync();
    }
}
