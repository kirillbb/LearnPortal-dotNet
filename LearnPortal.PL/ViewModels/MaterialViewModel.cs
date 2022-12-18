namespace LearnPortal.PL.ViewModels
{
    public class MaterialViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Discriminator { get; set; }

        public List<CourseViewModel>? Courses { get; set; }

        public Guid OwnerId { get; set; }

        public override string ToString()
        {
            return $"{Id} - Title: {Title} - Description: {Description} - [{Discriminator}]";
        }
    }
}
