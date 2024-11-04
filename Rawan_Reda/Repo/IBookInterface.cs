using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public interface IBookInterface
    {
        Book GetById(int id);
        void Update(BookDTO dto, int id);
        void ADD(BookDTO dto);
        void Delete(int id);
        IEnumerable<Book> GetAll();
        Book ValidateBook(string title);
    }
}
