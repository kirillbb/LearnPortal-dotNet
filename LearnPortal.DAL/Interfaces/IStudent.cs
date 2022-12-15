namespace LearnPortal.DAL.Interfaces
{
    public interface IStudent
    {
        Guid UserId { get; set; }

        bool Finished { get; set; }
    }
}
