namespace LearnPortal.DAL.Entities.Material
{
    public class Publication : Material
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }
    }
}
