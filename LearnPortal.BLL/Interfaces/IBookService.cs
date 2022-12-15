using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.CourseType;
using LearnPortal.DAL.Entities.MaterialType;

namespace LearnPortal.BLL.Interfaces
{
    public interface IBookService
    {
        Task CreateBook(BookDTO book);

        Task DeleteBook(int id);

        Task UpdateBook(BookDTO book);

        IEnumerable<BookDTO> FindBook(Func<Book, bool> predicate);

        Task<BookDTO> GetBook(int id);

        Task<IEnumerable<BookDTO>> GetBooksAsync();
    }
}
