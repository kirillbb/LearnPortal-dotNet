using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;

namespace LearnPortal.DAL.Interfaces
{
    public interface ICourse
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid OwnerId { get; set; }

        //public List<Course>? InProgressUsers { get; set; }

        List<Material>? Materials { get; set; }

        List<Skill>? Skills { get; set; }
    }
}
