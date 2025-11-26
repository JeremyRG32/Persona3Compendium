namespace Persona3Compendium.Web.Models
{
        public class PersonaViewModel
    {
        public required Persona Persona { get; set; }
        public required IList<Element> Weaknesses { get; set; }
        public required IList<Element> Absorbs { get; set; }
        public required IList<Element> Resists { get; set; }
        public required IList<Element> Reflects { get; set; }
        public required IList<Element> Nullifies { get; set; }
    }
}

