using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Services;
using LearnPortal.PL.Interfaces;
using LearnPortal.PL.ViewModels;

namespace LearnPortal.PL.Services
{
    public class UiBookService : IUiService<BookViewModel>
    {
        private readonly BookService _bookService;

        public UserDTO CurrentUser { get; private set; }

        public UiBookService(UserDTO currentUser)
        {
            _bookService = new BookService(currentUser);
            CurrentUser = currentUser;
        }

        public BookViewModel EnteringFields()
        {
            PrinterService.Message("Enter a Title of a book:");
            string title = Console.ReadLine();
            PrinterService.Message("Enter a Description of a book:");
            string description = Console.ReadLine();
            PrinterService.Message("Enter an Author of a book:");
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

        public async Task CreateAsync()
        {
            try
            {
                BookViewModel book = EnteringFields();

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

        public async Task GetAsync()
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

        public async Task UpdateAsync()
        {
            try
            {
                var id = UserInputService.GetId();
                BookViewModel book = EnteringFields();
                book.Id = id;

                PrinterService.BreakLine();
                if (book != null)
                {
                    await _bookService.UpdateBook(new BookDTO
                    {
                        Author = book.Author,
                        //OwnerId = book.OwnerId, check,i need that or not?
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

        public async Task DeleteAsync()
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

        public async Task GetAllAsync()
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