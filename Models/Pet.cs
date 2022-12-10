using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoPet.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Size { get; set; } = string.Empty;
        public string Breed { get; set; } = string.Empty;
        [ForeignKey("PetCarerId")]
        public PetCarer? PetCarerId { get; set; }
        public string? HashLocalization { get; set; } = string.Empty;
    }
}