namespace LearnPortal.BLL.DTO
{
    public class SkillDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<CourseDTO>? Courses { get; set; }

        public Guid OwnerId { get; set; }

        public List<UserDTO>? ReceivedUsers { get; set; }
    }
}
