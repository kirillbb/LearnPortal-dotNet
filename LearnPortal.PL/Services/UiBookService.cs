using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.UI;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiBookService
    {
        private IMapper _mapper;
        private readonly BookService _bookService;
        public UserDTO CurrentUser { get; private set; }

        public UiBookService(UserDTO currentUser)
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDTO>()).CreateMapper();
            _bookService = new BookService(currentUser);
            CurrentUser = currentUser;
        }

        public async Task CreateBookAsync()
        {
            try
            {
                Printer.Message("Enter a Title of a book:");
                string title = Console.ReadLine();
                Printer.Message("Enter a Author of a book:");
                string author = Console.ReadLine();
                Printer.Message("Enter a count of pages of a book:");
                int pages = int.Parse(Console.ReadLine());
                Printer.Message("Enter a format of a book:");
                string format = Console.ReadLine();
                Printer.Message("Enter a publication date of a book:");
                DateTime date = DateTime.Parse(Console.ReadLine());

                BookViewModel book = new BookViewModel
                {
                    Id = Guid.NewGuid(),
                    Title = title,
                    Author = author,
                    Pages = pages,
                    BookFormat = format,
                    OwnerId = CurrentUser.Id,
                };

                Printer.BreakLine();
                if (book != null)
                {
                    await _bookService.CreateBook(_mapper.Map<BookDTO>(book));
                }
                else
                {
                    Printer.ErrorMsg("Try again");
                }
            }
            catch (Exception ex)
            {
                Printer.ErrorMsg(ex.Message);
            }
        }

        public async Task ShowBookAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var book = await _bookService.GetBook(id);
                Printer.Print(_mapper.Map<BookViewModel>(book));
            }
            else
            {
                Printer.ErrorMsg("Incorrect Id");
            }
        }
    }
}
