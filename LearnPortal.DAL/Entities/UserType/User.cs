using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnPortal.DAL.Entities.UserType
{
    public class User : IUser
    {
        [Key]
        public Guid Id { get; set; }
        
        public string UserName { get; set; }

        public string Name { get; set; }
        
        public string Email { get; set; }

        [InverseProperty("FinishedStudents")]
        public List<Course>? FinishedCourses { get; set; }

        [InverseProperty("InProgressStudents")]
        public List<Course>? InProgressCourses { get; set; }

        public List<Skill>? ReceivedSkills { get; set; }

        public List<Material>? FinishedMaterials { get; set; }
    }
}
