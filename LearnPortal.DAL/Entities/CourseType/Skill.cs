using LearnPortal.DAL.Entities.UserType;
using LearnPortal.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LearnPortal.DAL.Entities.CourseType
{
    public class Skill : ISkill
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public List<Course>? Courses { get; set; }

        public Guid OwnerId { get; set; }

        public List<User>? ReceivedUsers { get; set; }
    }
}
