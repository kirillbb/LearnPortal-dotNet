using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;

namespace LearnPortal.DAL.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        string UserName { get; set; }

        string Email { get; set; }

         List<Course>? FinishedCourses { get; set; }

        List<Course>? InProgressCourses { get; set; }

        List<Skill>? ReceivedSkills { get; set; }

        List<Material>? FinishedMaterials { get; set; }
    }
}
