namespace LearnPortal.PL.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<CourseViewModel>? FinishedCourses { get; set; }

        public List<CourseViewModel>? InProgressCourses { get; set; }

        public List<SkillViewModel>? ReceivedSkills { get; set; }

        public List<MaterialViewModel>? FinishedMaterials { get; set; }

        public override string ToString()
        {
            return $"{Id} - Name: {Name} - {UserName} ({Email})";
        }
    }
}