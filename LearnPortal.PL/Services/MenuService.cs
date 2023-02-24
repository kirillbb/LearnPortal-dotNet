using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;

namespace LearnPortal.PL.Services
{
    public class MenuService
    {
        private readonly VideoService _videoService;
        private readonly PublicationService _publicationService;
        private readonly CourseService _courseService;
        private readonly SkillService _skillService;
        public UserDTO CurrentUser { get; private set; }

        public MenuService(UserDTO currentUser)
        {
            CurrentUser = currentUser;

            _videoService = new VideoService(currentUser);
            _publicationService = new PublicationService(currentUser);
            _courseService = new CourseService(currentUser);
            _skillService = new SkillService(currentUser);
        }

        public async Task Start()
        {
            await GeneralMenuAsync();
        }

        private async Task GeneralMenuAsync()
        {
            PrinterService.GeneralMenu();
            switch (UserInputService.GetMenuItemNumber())
            {
                case 1:
                    ChooseMaterialMenuAsync();
                    break;

                case 2:
                    //await _courseOperationService.StarterAsync();
                    break;

                case 3:
                    //await _skillOperationService.StarterAsync();
                    break;

                case 4:
                    //await _userOperationService.StarterAsync();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    await GeneralMenuAsync();
                    break;
            }

            await GeneralMenuAsync();
        }

        private async Task ChooseMaterialMenuAsync()
        {
            PrinterService.ChooseMaterialTypeMenu();
            switch (UserInputService.GetMenuItemNumber())
            {
                case 1:
                    BookOperationMenuAsync();
                    break;

                case 2:
                    VideoOperationMenuAsync();
                    break;

                case 3:
                    PublicationOperationMenuAsync();
                    break;

                case 9:
                    await GeneralMenuAsync();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    await ChooseMaterialMenuAsync();
                    break;
            }
        }

        private async Task BookOperationMenuAsync()
        {
            PrinterService.CrudMenu("book");
            UiBookService bookService = new UiBookService(CurrentUser);
            switch (UserInputService.GetMenuItemNumber())
            {
                case 1:
                    await bookService.CreateAsync();
                    await BookOperationMenuAsync();
                    break;

                case 2:
                    await bookService.GetAsync();
                    await BookOperationMenuAsync();
                    break;

                case 3:
                    await bookService.UpdateAsync();
                    await BookOperationMenuAsync();
                    break;

                case 4:
                    await bookService.DeleteAsync();
                    await BookOperationMenuAsync();
                    break;

                case 5:
                    await bookService.GetAllAsync();
                    await BookOperationMenuAsync();
                    break;

                case 9:
                    await ChooseMaterialMenuAsync();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    await BookOperationMenuAsync();
                    break;
            }
        }

        private async Task VideoOperationMenuAsync()
        {
            PrinterService.CrudMenu("video");
            switch (UserInputService.GetMenuItemNumber())
            {
                case 1:
                    //await _videoService.CreateVideo();
                    break;

                case 2:
                    //_videoService.GetVideo();
                    break;

                case 3:
                    //await _videoService.UpdateVideo();
                    break;

                case 4:
                    //await _videoService.DeleteVideo();
                    break;

                case 5:
                    //await _videoService.GetVideosAsync();
                    break;

                case 9:
                    await ChooseMaterialMenuAsync();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    await BookOperationMenuAsync();
                    break;
            }
        }

        private async Task PublicationOperationMenuAsync()
        {
            PrinterService.CrudMenu("publication");
            switch (UserInputService.GetMenuItemNumber())
            {
                case 1:
                    //await _publicationService.CreatePublication();
                    break;

                case 2:
                    //_publicationService.GetPublication();
                    break;

                case 3:
                    //await _publicationService.UpdatePublication();
                    break;

                case 4:
                    //await _publicationService.DeletePublication();
                    break;

                case 5:
                    //await _publicationService.GetPublicationsAsync();
                    break;

                case 9:
                    await ChooseMaterialMenuAsync();
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    await BookOperationMenuAsync();
                    break;
            }
        }
    }
}