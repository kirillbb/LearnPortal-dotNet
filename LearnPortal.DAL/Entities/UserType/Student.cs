using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.UserType
{
    public class Student : IStudent
    {
        public Guid UserId { get; set; }

        public bool Finished { get; set; } = false;
    }
}
