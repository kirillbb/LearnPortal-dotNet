using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.CourseType
{
    public class Course : ICourse
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Guid OwnerId { get; set; }
        
        public List<Material> Materials { get; set; }
        
        public List<Skill> Skills { get; set; }
    }
}
