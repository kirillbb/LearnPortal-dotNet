using LearnPortal.DAL.Entities.CourseType;

namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        Guid? FinishedCourseId { get; set; }

        Guid? InProgressCoursesId { get; set; }

        Guid? ReceivedSkills { get; set; }
    }
}
