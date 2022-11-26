namespace LearnPortal.DAL.Interfaces
{
    public interface ICourse
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        Guid OwnerId { get; set; }

        IEnumerable<IMaterial> Materials { get; set; }

        IEnumerable<ISkill> Skills { get; set; }
    }
}
