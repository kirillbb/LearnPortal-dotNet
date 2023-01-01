﻿using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.UI;

namespace LearnPortal.PL.Services
{
    public class UiService
    {
        private readonly BookService _bookService;
        private readonly VideoService _videoService;
        private readonly PublicationService _publicationService;
        private readonly CourseService _courseService;
        private readonly SkillService _skillService;
        public UserDTO CurrentUser { get; private set; }

        public UiService(UserDTO currentUser)
        {
            CurrentUser = currentUser;
            _bookService = new BookService(currentUser);
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
            Printer.GeneralMenu();
            int menuItem = MenuController();
            switch (menuItem)
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
            Printer.ChooseMaterialTypeMenu();
            int menuItem = MenuController();
            switch (menuItem)
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
            Printer.CrudMenu("book");
            int menuItem = MenuController();
            BookController bookController = new BookController();
            switch (menuItem)
            {
                case 1:
                    {
                        var book = bookController.CreateBook(CurrentUser);
                        if (book != null)
                        {
                            await _bookService.CreateBook(book);
                        }
                        else
                        {
                            Printer.ErrorMsg("Try again");
                            await BookOperationMenuAsync();
                        }

                        break;
                    }
                case 2:
                    {
                        var id = GetId();
                        if (id != Guid.Empty)
                        {
                            bookController.ShowBook(await _bookService.GetBook(id));
                        }
                        else
                        {
                            Printer.ErrorMsg("Incorrect Id");
                            await BookOperationMenuAsync();
                        }

                        break;
                    }
                case 3:
                    //await _bookService.UpdateBook(newBook);
                    break;
                case 4:
                    //await _bookService.DeleteBook(id);
                    break;
                case 5:
                    //await _bookService.GetBooksAsync();
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
            Printer.CrudMenu("video");
            int menuItem = MenuController();
            switch (menuItem)
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
            Printer.CrudMenu("publication");
            int menuItem = MenuController();
            switch (menuItem)
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

        public Guid GetId()
        {
            Printer.Message("Enter id:");
            Guid id = Guid.Empty;
            Guid.TryParse(Console.ReadLine(), out id);

            Printer.BreakLine();
            Printer.BreakLine();
            return id;
        }

        private int MenuController()
        {
            int menuItem;
            while (!int.TryParse(Console.ReadLine(), out menuItem))
            {
            }

            Printer.BreakLine();
            Printer.BreakLine();
            return menuItem;
        }
    }
}
