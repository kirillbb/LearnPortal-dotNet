namespace LearnPortal.BLL.DTO
{
    public class MaterialDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Discriminator { get; set; }

        public Guid OwnerId { get; set; }
    }
}
