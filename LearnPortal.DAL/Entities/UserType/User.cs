using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.UserType
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public Guid? FinishedCourseId { get; set; }
        
        public Guid? InProgressCoursesId { get; set; }
        
        public List<Skill>? Skills { get; set; }
    }
}
