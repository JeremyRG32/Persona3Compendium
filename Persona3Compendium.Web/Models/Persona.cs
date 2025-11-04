using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persona3Compendium.Web.Models
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public int Dlc { get; set; }

        //Foreign Keys
        [ForeignKey(nameof(Arcana))]
        public int ArcanaId { get; set; }

        //Nav Properties
        public Arcana Arcana { get; set; }
        public ICollection<PersonaWeakness> Weaknesses { get; set; } = new List<PersonaWeakness>();
        public ICollection<PersonaResist> Resists { get; set; } = new List<PersonaResist>();
        public ICollection<PersonaReflect> Reflects { get; set; } = new List<PersonaReflect>();
        public ICollection<PersonaAbsorb> Absorbs { get; set; } = new List<PersonaAbsorb>();
        public ICollection<PersonaNullify> Nullifies { get; set; } = new List<PersonaNullify>();

    }
}
