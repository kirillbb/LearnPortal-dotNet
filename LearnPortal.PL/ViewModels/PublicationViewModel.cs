namespace LearnPortal.PL.ViewModels
{
    public class PublicationViewModel : MaterialViewModel
    {
        public DateTime CreationDate { get; set; }

        public string? Source { get; set; }

        public override string ToString()
        {
            return $"{Id} - Title: {Title} - Description: {Description} - /{Source}/ - ({CreationDate})";
        }
    }
}
