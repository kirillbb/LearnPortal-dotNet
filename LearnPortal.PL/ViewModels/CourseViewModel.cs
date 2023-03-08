namespace LearnPortal.PL.ViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Guid OwnerId { get; set; }

        public List<UserViewModel>? FinishedStudents { get; set; }

        public List<UserViewModel>? InProgressStudents { get; set; }

        public List<MaterialViewModel>? Materials { get; set; }

        public List<SkillViewModel>? Skills { get; set; }

        public override string ToString()
        {
            return $"{Id} - Title: {Title} - Description: {Description} - OwnerId: {OwnerId}";
        }
    }
}
