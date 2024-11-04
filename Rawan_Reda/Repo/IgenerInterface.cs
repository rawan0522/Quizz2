using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public interface IgenerInterface
    {
        Gener GetById(int id);
        void Update(GenerDTO dto, int id);
        void ADD(GenerDTO dto);
        void Delete(int id);
        IEnumerable<Gener> GetAll();
        Gener ValidateBook(string title);
    }
}
