using LearnPortal.DAL.Entities.Course;

namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        IEnumerable<Course> FinishedCourses { get; set; }

        IEnumerable<Course> InProgressCourses { get; set; }

        IEnumerable<Skill> Skills { get; set; }
    }
}
