using Rawan_Reda.DTO;
using Rawan_Reda.Models;

namespace Rawan_Reda.Repo
{
    public interface IAutherInterface
    {
        Auther GetById(int id);
        void Update(AutherDTO dto, int id);
        void ADD(AutherDTO dto);
        void Delete(int id);
        IEnumerable<Auther> GetAll();
        Auther ValidateStudent(string title);
    }
}
