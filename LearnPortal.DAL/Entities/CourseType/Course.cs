using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Entities.UserType;
using LearnPortal.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnPortal.DAL.Entities.CourseType
{
    public class Course : ICourse
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Guid OwnerId { get; set; }

        public List<User>? FinishedStudents { get; set; }

        public List<User>? InProgressStudents { get; set; }

        public List<Material>? Materials { get; set; }
        
        public List<Skill>? Skills { get; set; }
    }
}
