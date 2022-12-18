namespace LearnPortal.PL.ViewModels
{
    public class BookViewModel : MaterialViewModel
    {
        public string? Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int Pages { get; set; }

        public string BookFormat { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Author} - Title: {Title}{BookFormat} - Description: {Description} - ({PublicationDate}) - {Pages} pages";
        }
    }
}
