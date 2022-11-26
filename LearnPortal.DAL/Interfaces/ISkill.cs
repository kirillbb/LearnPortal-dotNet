namespace LearnPortal.DAL.Interfaces
{
    public interface ISkill
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid OwnerId { get; set; }
    }
}
