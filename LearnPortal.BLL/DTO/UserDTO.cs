using LearnPortal.DAL.Interfaces;

namespace LearnPortal.BLL.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IEnumerable<ICourse> FinishedCourses { get; set; }

        public IEnumerable<ICourse> InProgressCourses { get; set; }

        public IEnumerable<ISkill> Skills { get; set; }
    }
}
