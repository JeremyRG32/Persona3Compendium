using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persona3Compendium.Web.Data;
using Persona3Compendium.Web.Models;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string dbpath = "\"C:\\Projects\\Persona3Compendium\\Persona3Compendium.Web\\Persona.db\"";
        static async Task Main(string[] args)
        {
            int count = 0;
            var options = new DbContextOptionsBuilder<PersonaCompendiumDbContext>()
                .UseSqlite($"Data Source={dbpath}")
                .Options;

            using var db = new PersonaCompendiumDbContext(options);


            //Load Json with all personas
            var json = File.ReadAllText("personas.json");
            var personas = JsonConvert.DeserializeObject<List<PersonaDTO>>(json);

            //Dictionary to keep track of Arcanas and elements for their table
            var arcanaDict = new Dictionary<string, Arcana>(); // String = Arcana name, and value Arcana object with ID
            var elementDict = new Dictionary<string, Element>(); //
            foreach (var p in personas)
            {
                //Add arcana to database if doesn't exist 
                if (!arcanaDict.ContainsKey(p.Arcana))
                {
                    var arcana = new Arcana()
                    {
                        Name = p.Arcana
                    };

                    db.Arcanas.Add(arcana);
                    await db.SaveChangesAsync();
                    arcanaDict[p.Arcana] = arcana;
                }

                //Add persona after arcana to have arcana id relation
                //Persona added before element to add element relation after
                var persona = new Persona
                {
                    Name = p.Name,
                    Level = p.Level,
                    Description = p.Description,
                    Image = p.Image,
                    Strength = p.Strength,
                    Magic = p.Magic,
                    Endurance = p.Endurance,
                    Agility = p.Agility,
                    Luck = p.Luck,
                    Dlc = p.Dlc,
                    ArcanaId = arcanaDict[p.Arcana].Id
                };

                db.Personas.Add(persona);
                await db.SaveChangesAsync();


                var weaks = p.Weak.Split(",");
                var resist = p.Resists.Split(",");
                var reflect = p.Reflects.Split(",");
                var absorb = p.Absorbs.Split(",");
                var nullify = p.Nullifies.Split(",");

                //Add element to database if doesn't exist and add Element Persona Relation
                //Weakness
                foreach (var w in weaks)
                {
                    if (!elementDict.ContainsKey(w))
                    {
                        var element = new Element()
                        {
                            Name = w
                        };
                        db.Elements.Add(element);
                        await db.SaveChangesAsync();
                        elementDict[w] = element;
                    }
                    var weakness = new PersonaWeakness
                    {
                        PersonaId = persona.Id,
                        ElementId = elementDict[w].Id
                    };
                    db.Set<PersonaWeakness>().Add(weakness);
                }
                //Resist
                foreach (var r in resist)
                {
                    if (!elementDict.ContainsKey(r))
                    {
                        var element = new Element()
                        {
                            Name = r
                        };
                        db.Elements.Add(element);
                        await db.SaveChangesAsync();
                        elementDict[r] = element;
                    }
                    var resists = new PersonaResist
                    {
                        PersonaId = persona.Id,
                        ElementId = elementDict[r].Id
                    };
                    db.Set<PersonaResist>().Add(resists);
                }
                //Reflect
                foreach (var re in reflect)
                {
                    if (!elementDict.ContainsKey(re))
                    {
                        var element = new Element()
                        {
                            Name = re
                        };
                        db.Elements.Add(element);
                        await db.SaveChangesAsync();
                        elementDict[re] = element;
                    }
                    var reflects = new PersonaReflect
                    {
                        PersonaId = persona.Id,
                        ElementId = elementDict[re].Id
                    };
                    db.Set<PersonaReflect>().Add(reflects);
                }
                //Absorb
                foreach (var a in absorb)
                {
                    if (!elementDict.ContainsKey(a))
                    {
                        var element = new Element()
                        {
                            Name = a
                        };
                        db.Elements.Add(element);
                        await db.SaveChangesAsync();
                        elementDict[a] = element;
                    }
                    var absorbs = new PersonaAbsorb
                    {
                        PersonaId = persona.Id,
                        ElementId = elementDict[a].Id
                    };
                    db.Set<PersonaAbsorb>().Add(absorbs);
                }
                //Nullify
                foreach (var n in nullify)
                {
                    if (!elementDict.ContainsKey(n))
                    {
                        var element = new Element()
                        {
                            Name = n
                        };
                        db.Elements.Add(element);
                        await db.SaveChangesAsync();
                        elementDict[n] = element;
                    }
                    var nullifies = new PersonaNullify
                    {
                        PersonaId = persona.Id,
                        ElementId = elementDict[n].Id
                    };
                    db.Set<PersonaNullify>().Add(nullifies);
                }

                await db.SaveChangesAsync();

                count++;
                Console.WriteLine($"-{count} Added: {persona.Name} ");
            }
            await db.SaveChangesAsync();
            Console.WriteLine($"All personas imported successfully!\n Persona count: {count}");
        }

    }
}