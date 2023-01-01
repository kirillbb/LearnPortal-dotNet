namespace LearnPortal.PL.ViewModels
{
    public class VideoViewModel : MaterialViewModel
    {
        public int Resolution { get; set; }

        public int Duration { get; set; }

        public override string ToString()
        {
            return $"{Id} - Title: {Title} - Description: {Description} - ({Resolution}p) - {Duration}min";
        }
    }
}
