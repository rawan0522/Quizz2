using Microsoft.EntityFrameworkCore;
using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public class BookRepo : IBookInterface
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context)
        {
            _context = context;
        }
        

        public void ADD(BookDTO dto)
        {
            var b = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
            };
            _context.Books.Add(b);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
           var book = GetById(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            var books = _context.Books.ToList();
               return books;
        }

        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }


        public void Update(BookDTO book, int id)
        {
            var b = GetById(id);
            if(b != null)
            {
                b.Id = book.Id;
                b.Title = book.Title;
                _context.SaveChanges();
            }

        }
        public Book ValidateBook(string title)
        {
            return _context.Books.FirstOrDefault(x => x.Title == title);
        }

    }
}
