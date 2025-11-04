namespace Persona3Compendium.Web.Models
{
    public class PersonaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Arcana { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Strength { get; set; }
        public int Magic { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }
        public string Weak { get; set; }
        public string Resists { get; set; }
        public string Reflects { get; set; }
        public string Absorbs { get; set; }
        public string Nullifies { get; set; }
        public int Dlc { get; set; }
        public string Query { get; set; }
    }
}
