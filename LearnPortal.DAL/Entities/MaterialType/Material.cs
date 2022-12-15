using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LearnPortal.DAL.Entities.MaterialType
{
    public class Material : IMaterial
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public string Discriminator { get; set; }

        public List<Course>? Courses { get; set; }

        public Guid OwnerId { get; set; }
    }
}
