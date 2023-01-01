using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.PL.UI;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class BookController
    {
        private IMapper _mapper;

        public BookController()
        {
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<BookViewModel, BookDTO>()).CreateMapper();
        }

        public BookDTO? CreateBook(UserDTO currentUser)
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
                    OwnerId = currentUser.Id,
                };

                Printer.BreakLine();
                return _mapper.Map<BookDTO>(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void ShowBook(BookDTO book)
        {
            Printer.Print(_mapper.Map<BookViewModel>(book));
        }
    }
}
