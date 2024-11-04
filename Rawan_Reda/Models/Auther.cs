using System.ComponentModel.DataAnnotations;

namespace Rawan_Reda.Models
{
    public class Auther
    {
        [Key] public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public List<Book>? Books { get; set; }
    }
}
