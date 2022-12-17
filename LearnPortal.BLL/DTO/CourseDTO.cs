namespace LearnPortal.BLL.DTO
{
    public class CourseDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public List<UserDTO>? FinishedStudents { get; set; }

        public List<UserDTO>? InProgressStudents { get; set; }

        public List<MaterialDTO>? Materials { get; set; }

        public List<SkillDTO>? Skills { get; set; }
    }
}
