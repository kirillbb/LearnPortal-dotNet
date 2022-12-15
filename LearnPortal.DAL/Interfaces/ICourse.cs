using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Entities.UserType;

namespace LearnPortal.DAL.Interfaces
{
    public interface ICourse
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid OwnerId { get; set; }

        List<User>? FinishedStudents { get; set; }

        List<User>? InProgressStudents { get; set; }

        List<Material>? Materials { get; set; }

        List<Skill>? Skills { get; set; }
    }
}
