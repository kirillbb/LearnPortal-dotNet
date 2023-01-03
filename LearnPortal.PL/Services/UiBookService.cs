using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
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

        public BookViewModel EnteringBookFields()
        {
            PrinterService.Message("Enter a Title of a book:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Author of a book:");
            string author = Console.ReadLine();
            PrinterService.Message("Enter a count of pages of a book:");
            int pages = int.Parse(Console.ReadLine());
            PrinterService.Message("Enter a format of a book:");
            string format = Console.ReadLine();
            PrinterService.Message("Enter a publication date of a book:");
            DateTime date = DateTime.Parse(Console.ReadLine());

            return new BookViewModel
            {
                Title = title,
                Author = author,
                Pages = pages,
                BookFormat = format,
                OwnerId = CurrentUser.Id,
            };
        }

        public async Task CreateBookAsync()
        {
            try
            {
                BookViewModel book = EnteringBookFields();
                book.Id = Guid.NewGuid();

                PrinterService.BreakLine();
                if (book != null)
                {
                    await _bookService.CreateBook(_mapper.Map<BookDTO>(book));
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

        public async Task ShowBookAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var book = await _bookService.GetBook(id);
                PrinterService.Print(_mapper.Map<BookViewModel>(book));
            }
            else
            {
                PrinterService.ErrorMsg("Incorrect Id");
            }
        }

        internal Task UpdateBookAsync()
        {
            throw new NotImplementedException();
        }

        internal Task DeleteBookAsync()
        {
            throw new NotImplementedException();
        }

        internal Task GetAllBooksAsync()
        {
            throw new NotImplementedException();
        }
    }
}
