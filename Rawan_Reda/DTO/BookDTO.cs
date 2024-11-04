using Rawan_Reda.Models;
using System.ComponentModel.DataAnnotations;

namespace Rawan_Reda.DTO
{
    public class BookDTO
    {
        [Key] public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        public DateTime PublishedYear { get; set; }
      
      
    }
}
