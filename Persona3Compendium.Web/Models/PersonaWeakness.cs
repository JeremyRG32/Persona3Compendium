namespace Persona3Compendium.Web.Models
{
    public class PersonaWeakness
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        public int ElementId { get; set; }
        public Element Element { get; set; }
    }
}
