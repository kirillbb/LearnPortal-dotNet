using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.Material;

namespace LearnPortal.DAL.Interfaces
{
    public interface ICourse
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid OwnerId { get; set; }

        IEnumerable<Material> Materials { get; set; }

        IEnumerable<Skill> Skills { get; set; }
    }
}
