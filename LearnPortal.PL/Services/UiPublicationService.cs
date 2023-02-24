using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.Interfaces;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    internal class UiPublicationService : IUiService<PublicationViewModel>
    {
        private readonly PublicationService _publicationService;

        public UserDTO CurrentUser { get; private set; }

        public UiPublicationService(UserDTO currentUser)
        {
            _publicationService = new PublicationService(currentUser);
            CurrentUser = currentUser;
        }

        public PublicationViewModel EnteringFields()
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

        public async Task CreateAsync()
        {
            try
            {
                PublicationViewModel publication = EnteringFields();

                PrinterService.BreakLine();
                if (publication != null)
                {
                    await _publicationService.CreateAsync(new PublicationDTO
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

        public async Task GetAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var publication = await _publicationService.GetAsync(id);
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

        public async Task UpdateAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                PublicationViewModel publication = EnteringFields();
                publication.Id = id;

                PrinterService.BreakLine();
                if (publication != null)
                {
                    await _publicationService.UpdateAsync(new PublicationDTO
                    {
                        //OwnerId = book.OwnerId, check,i need that or not?
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

        public async Task DeleteAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                await _publicationService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }

        public async Task GetAllAsync()
        {
            try
            {
                var publications = await _publicationService.GetAllAsync();
                if (publications != null)
                {
                    foreach (var publication in publications)
                    {
                        PrinterService.Print(new PublicationViewModel
                        {
                            Id = publication.Id,
                            Title = publication.Title,
                            Description = publication.Description,
                            CreationDate = publication.CreationDate,
                            Source = publication.Source,
                            OwnerId = publication.OwnerId,
                        });
                    }
                }
                else
                {
                    PrinterService.ErrorMsg("Empty List!");
                }
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }
    }
}