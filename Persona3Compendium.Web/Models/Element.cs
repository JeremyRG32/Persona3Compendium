using System.ComponentModel.DataAnnotations;

namespace Persona3Compendium.Web.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

    }
}
