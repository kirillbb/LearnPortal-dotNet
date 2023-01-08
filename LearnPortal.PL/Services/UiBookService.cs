using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiBookService
    {
        private readonly BookService _bookService;
        public UserDTO CurrentUser { get; private set; }

        public UiBookService(UserDTO currentUser)
        {
            _bookService = new BookService(currentUser);
            CurrentUser = currentUser;
        }

        public BookViewModel EnteringBookFields()
        {
            PrinterService.Message("Enter a Title of a book:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a book:");
            string description = Console.ReadLine();
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
                Description = description,
                Author = author,
                Pages = pages,
                BookFormat = format,
                PublicationDate = date,
            };
        }

        public async Task CreateBookAsync()
        {
            try
            {
                BookViewModel book = EnteringBookFields();

                PrinterService.BreakLine();
                if (book != null)
                {
                    await _bookService.CreateBook(new BookDTO
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        BookFormat = book.BookFormat,
                        Pages = book.Pages,
                        PublicationDate = book.PublicationDate,
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

        public async Task ShowBookAsync()
        {
            var id = UserInputService.GetId();
            if (id != Guid.Empty)
            {
                var book = await _bookService.GetBook(id);
                PrinterService.Print(new BookViewModel
                {
                    Id = book.Id,
                    OwnerId = book.Id,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    BookFormat = book.BookFormat,
                    Pages = book.Pages,
                    PublicationDate = book.PublicationDate,
                });
            }
            else
            {
                PrinterService.ErrorMsg("Incorrect Id");
            }
        }

        public async Task UpdateBookAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                BookViewModel book = EnteringBookFields();
                book.Id = id;

                PrinterService.BreakLine();
                if (book != null)
                {
                    await _bookService.UpdateBook(new BookDTO
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        BookFormat = book.BookFormat,
                        Pages = book.Pages,
                        PublicationDate = book.PublicationDate,
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

        public async Task DeleteBookAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                await _bookService.DeleteBook(id);
            }
            catch (Exception ex)
            {
                PrinterService.ErrorMsg(ex.Message);
            }
        }

        public async Task GetAllBooksAsync()
        {
            try
            {
                var books = await _bookService.GetBooksAsync();
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        PrinterService.Print(new BookViewModel
                        {
                            Id = book.Id,
                            OwnerId = book.Id,
                            Author = book.Author,
                            Title = book.Title,
                            Description = book.Description,
                            BookFormat = book.BookFormat,
                            Pages = book.Pages,
                            PublicationDate = book.PublicationDate,
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
