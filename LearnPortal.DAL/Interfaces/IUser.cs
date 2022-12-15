using LearnPortal.DAL.Entities.CourseType;

namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

        //List<Course>? FinishedLearn { get; set; }

        //List<Course>? InProgressCourses { get; set; }

        List<Skill>? ReceivedSkills { get; set; }
    }
}
