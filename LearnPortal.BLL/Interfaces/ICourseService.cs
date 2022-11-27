using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.Course;

namespace LearnPortal.BLL.Interfaces
{
    public interface ICourseService
    {
        Task CreateCourse(CourseDTO course);

        Task DeleteCourse(int id);

        Task UpdateCourse(CourseDTO course);

        IEnumerable<CourseDTO> FindCourse(Func<Course, bool> predicate);

        Task<CourseDTO> GetCourse(int id);
    }
}
