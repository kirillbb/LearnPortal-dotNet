using LearnPortal.DAL.Entities.CourseType;

namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        List<Course> FinishedCourses { get; set; }

        List<Course> InProgressCourses { get; set; }

        List<Skill> Skills { get; set; }
    }
}
