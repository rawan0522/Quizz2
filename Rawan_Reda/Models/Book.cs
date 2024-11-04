using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Rawan_Reda.Models
{
    public class Book
    {

        [Key]        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        public DateTime PublishedYear { get; set; }
        public List<Auther>? Authers { get; set; }
        public List<Gener>? Geners { get; set; }
    }
}
