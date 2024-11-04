using System.ComponentModel.DataAnnotations;

namespace Rawan_Reda.Models
{
    public class Gener
    {
        [Key] public int Id { get; set; }
        [Required] public string? Name { get; set; }
        public List<Book>? Books { get; set; }
    }
}
