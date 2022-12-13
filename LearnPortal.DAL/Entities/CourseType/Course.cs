using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.CourseType
{
    public class Course : ICourse
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Guid OwnerId { get; set; }
        
        public IEnumerable<Material.Material> Materials { get; set; }
        
        public IEnumerable<Skill> Skills { get; set; }
    }
}
