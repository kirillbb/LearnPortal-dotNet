using LearnPortal.BLL.DTO;
using LearnPortal.DAL.Entities.Course;
using LearnPortal.DAL.Entities.Material;

namespace LearnPortal.BLL.Interfaces
{
    public interface IBookService
    {
        Task CreateBook(BookDTO book);

        Task DeleteBook(int id);

        Task UpdateBook(BookDTO course);

        IEnumerable<BookDTO> FindBook(Func<Book, bool> predicate);

        Task<BookDTO> GetBook(int id);
    }
}
