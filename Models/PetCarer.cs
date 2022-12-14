using System.ComponentModel.DataAnnotations;

namespace GeoPet.Models
{
    public class PetCarer
    {
        [Key]
        public int PetCarerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ZipCode { get; set; }
        public string Password { get; set; } = string.Empty;
        public ICollection<Pet>? Pets { get; set; } = default!;
    }
}