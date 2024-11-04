using System.ComponentModel.DataAnnotations;

namespace Rawan_Reda.DTO
{
    public class GenerDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string? Name { get; set; }
    }
}
