using Microsoft.EntityFrameworkCore;
using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public class AutherRepo : IAutherInterface
    {
        private readonly AppDbContext _context;
        public AutherRepo(AppDbContext context)
        {
            _context = context;
        }
        public void ADD(AutherDTO dto)
        {
            var b = new Auther
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            _context.Authers.Add(b);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Authers.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Auther> GetAll()
        {
            var books = _context.Authers.ToList();
            return books;
        }

        public Auther GetById(int id)
        {
            return _context.Authers.FirstOrDefault(x => x.Id == id);

        }

        public void Update(AutherDTO dto, int id)
        {
            var b = GetById(id);
            if (b != null)
            {
                b.Id = dto.Id;
                b.Name = dto.Name;
                _context.SaveChanges();
            }
        }

        public Auther ValidateStudent(string name)
        {
            return _context.Authers.FirstOrDefault(x => x.Name == name);
        }
    }
}
