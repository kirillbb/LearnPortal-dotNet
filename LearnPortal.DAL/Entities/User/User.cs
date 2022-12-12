using LearnPortal.DAL.Entities.Course;
using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.User
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public IEnumerable<Course.Course> FinishedCourses { get; set; }
        
        public IEnumerable<Course.Course> InProgressCourses { get; set; }
        
        public IEnumerable<Skill> Skills { get; set; }
    }
}
