namespace LearnPortal.PL.ViewModels
{
    public class SkillViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<CourseViewModel>? Courses { get; set; }

        public Guid OwnerId { get; set; }

        public List<UserViewModel>? ReceivedUsers { get; set; }
    }
}
