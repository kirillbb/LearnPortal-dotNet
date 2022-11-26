namespace LearnPortal.DAL.Interfaces
{
    public interface IMaterial
    {
        Guid Id { get; set; }

        string Title { get; set; }

        string Description { get; set; }

        string Discriminator { get; set; }

        Guid OwnerId { get; set; }
    }
}
