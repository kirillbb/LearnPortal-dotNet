using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    internal class UiPublicationService
    {
        private readonly PublicationService _publicationService;

        public UserDTO CurrentUser { get; private set; }

        public UiPublicationService(UserDTO currentUser)
        {
            _publicationService = new PublicationService(currentUser);
            CurrentUser = currentUser;
        }

        public PublicationViewModel EnteringPublicationFields()
        {
            Console.WriteLine("Enter a Title of a publication:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a publication:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter a publication date:");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter a sourse of a publication:");
            string source = Console.ReadLine();

            return new PublicationViewModel
            {
                Title = title,
                Description = description,
                CreationDate = date,
                Source = source,
            };
        }

        public async Task CreatePublicationAsync()
        {
            try
            {
                PublicationViewModel publication = EnteringPublicationFields();

                PrinterService.BreakLine();
                if (publication != null)
                {
                    await _publicationService.CreatePublication(new PublicationDTO
                    {
                        Title = publication.Title,
                        Description = publication.Description,
                        CreationDate = publication.CreationDate,
                        Source = publication.Source,
                    });
                }
                else
                {
                    PrinterService.ErrorMsg("Try again");
                }
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }

        public async Task ShowPublicationAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var publication = await _publicationService.GetPublication(id);
                PrinterService.Print(new PublicationViewModel
                {
                    Id = publication.Id,
                    OwnerId = publication.Id,
                    CreationDate = publication.CreationDate,
                    Source = publication.Source,
                    Title = publication.Title,
                    Description = publication.Description,
                });
            }
            else
            {
                PrinterService.ErrorMsg("Incorrect Id");
            }
        }
    }
}