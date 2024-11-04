using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public class GenerRepo : IgenerInterface
    {
        private readonly AppDbContext _context;
        public GenerRepo(AppDbContext context)
        {
            _context = context;
        }
        public void ADD(GenerDTO dto)
        {
            var b = new Gener
            {
                Id = dto.Id,
                Name = dto.Name,
            };
            _context.Geners.Add(b);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Geners.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Gener> GetAll()
        {
            var books = _context.Geners.ToList();
            return books;
        }

        public Gener GetById(int id)
        {
            return _context.Geners.FirstOrDefault(x => x.Id == id);
        }

        public void Update(GenerDTO dto, int id)
        {
            var b = GetById(id);
            if (b != null)
            {
                b.Id = dto.Id;
                b.Name = dto.Name;
                _context.SaveChanges();
            }
        }

        public Gener ValidateBook(string name)
        {
            return _context.Geners.FirstOrDefault(x => x.Name == name);
        }
    }
}
