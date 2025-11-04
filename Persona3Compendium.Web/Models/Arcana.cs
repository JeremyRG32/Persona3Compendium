using System.ComponentModel.DataAnnotations;

namespace Persona3Compendium.Web.Models
{
    public class Arcana
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        //Navigation Properties
        public ICollection<Persona> Personas { get; set; } = new List<Persona>();
    }
}
