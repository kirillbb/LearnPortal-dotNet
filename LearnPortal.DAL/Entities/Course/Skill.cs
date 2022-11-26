using LearnPortal.DAL.Interfaces;

namespace LearnPortal.DAL.Entities.Course
{
    public class Skill : ISkill
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public Guid OwnerId { get; set; }
    }
}
