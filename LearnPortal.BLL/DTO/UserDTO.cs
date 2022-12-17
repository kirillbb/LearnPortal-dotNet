using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearnPortal.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<CourseDTO>? FinishedCourses { get; set; }

        public List<CourseDTO>? InProgressCourses { get; set; }

        public List<SkillDTO>? ReceivedSkills { get; set; }

        public List<MaterialDTO>? FinishedMaterials { get; set; }
    }
}
