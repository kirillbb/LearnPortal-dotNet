using AutoMapper;
using LearnPortal.BLL.DTO;
using LearnPortal.BLL.Interfaces;
using LearnPortal.DAL.Data;
using LearnPortal.DAL.Entities.MaterialType;
using LearnPortal.DAL.Interfaces;
using LearnPortal.DAL.Repository;

namespace LearnPortal.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly UserDTO _currentUser;
        private readonly ApplicationContext _context;
        private IRepository<Book> _bookRepo;
        private IMapper _mapper;

        public BookService(UserDTO currentUser)
        {
            _currentUser = currentUser;
            DbContextFactory contextFactory = new DbContextFactory();
            _context = contextFactory.CreateDbContext();
            _bookRepo = new GenericRepository<Book>(_context);
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>()).CreateMapper();
        }

        public IEnumerable<BookDTO> FindBook(Func<Book, bool> predicate)
        {
            return _mapper.Map<IEnumerable<Book>, List<BookDTO>>(_bookRepo.Find(predicate));
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            return _mapper.Map<IEnumerable<Book>, List<BookDTO>>(await _bookRepo.GetAllAsync());
        }

        public async Task CreateBook(BookDTO book)
        {
            book.Id = new Guid();
            book.OwnerId = _currentUser.Id;
            await _bookRepo.CreateAsync(_mapper.Map<Book>(book));
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepo.DeleteAsync(id);
        }

        public async Task UpdateBook(BookDTO book)
        {
            await _bookRepo.UpdateAsync(_mapper.Map<Book>(book));
        }

        public async Task<BookDTO> GetBook(int id)
        {
            return _mapper.Map<BookDTO>(await _bookRepo.GetAsync(id));
        }
    }
}
