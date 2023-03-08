using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class BookService : IService<BookDTO>
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Book> _bookRepo;

        public BookService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _bookRepo = new GenericRepository<Book>(_context);
        }

        public IEnumerable<BookDTO> Find(Func<Book, bool> predicate)
        {
            var books = _bookRepo.Find(predicate);
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (var book in books)
            {
                BookDTO bookDTO = new BookDTO
                {
                    Id = book.Id,
                    OwnerId = book.Id,
                    Discriminator = book.Discriminator,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    BookFormat = book.BookFormat,
                    Pages = book.Pages,
                    PublicationDate = book.PublicationDate,
                };

                bookDTOs.Add(bookDTO);
            }

            return bookDTOs;
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (var book in books)
            {
                BookDTO bookDTO = new BookDTO
                {
                    Id = book.Id,
                    OwnerId = book.Id,
                    Discriminator = book.Discriminator,
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    BookFormat = book.BookFormat,
                    Pages = book.Pages,
                    PublicationDate = book.PublicationDate,
                };

                bookDTOs.Add(bookDTO);
            }

            return bookDTOs;
        }

        public async Task CreateAsync(BookDTO book)
        {
            await _bookRepo.CreateAsync(new Book
            {
                Id = Guid.NewGuid(),
                OwnerId = _currentUser.Id,
                Discriminator = "Book",
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                BookFormat = book.BookFormat,
                Pages = book.Pages,
                PublicationDate = book.PublicationDate,
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            await _bookRepo.DeleteAsync(id);
        }

        public async Task UpdateAsync(BookDTO book)
        {
            await _bookRepo.UpdateAsync(new Book
            {
                Id = book.Id,
                OwnerId = book.Id,
                Discriminator = book.Discriminator,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                BookFormat = book.BookFormat,
                Pages = book.Pages,
                PublicationDate = book.PublicationDate,
            });
        }

        public async Task<BookDTO> GetAsync(Guid id)
        {
            var book = await _bookRepo.GetAsync(id);
            return new BookDTO
            {
                Id = book.Id,
                OwnerId = book.Id,
                Discriminator = book.Discriminator,
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                BookFormat = book.BookFormat,
                Pages = book.Pages,
                PublicationDate = book.PublicationDate,
            };
        }
    }
}
