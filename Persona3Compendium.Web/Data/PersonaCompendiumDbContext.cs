using Microsoft.EntityFrameworkCore;
using Persona3Compendium.Web.Models;

namespace Persona3Compendium.Web.Data
{
    public class PersonaCompendiumDbContext : DbContext
    {
        public PersonaCompendiumDbContext(DbContextOptions<PersonaCompendiumDbContext> options) : base(options)
        {

        }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Arcana> Arcanas { get; set; }
        public DbSet<Element> Elements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Weakness Relation
            modelBuilder.Entity<PersonaWeakness>()
        .HasKey(pw => new { pw.PersonaId, pw.ElementId });

            modelBuilder.Entity<PersonaWeakness>()
                .HasOne(pw => pw.Persona)
                .WithMany(p => p.Weaknesses)
                .HasForeignKey(pw => pw.PersonaId);

            modelBuilder.Entity<PersonaWeakness>()
                .HasOne(pw => pw.Element)
                .WithMany()
                .HasForeignKey(pw => pw.ElementId);

            //Absorb Relation
            modelBuilder.Entity<PersonaAbsorb>()
        .HasKey(pw => new { pw.PersonaId, pw.ElementId });

            modelBuilder.Entity<PersonaAbsorb>()
                .HasOne(pw => pw.Persona)
                .WithMany(p => p.Absorbs)
                .HasForeignKey(pw => pw.PersonaId);

            modelBuilder.Entity<PersonaAbsorb>()
                .HasOne(pw => pw.Element)
                .WithMany()
                .HasForeignKey(pw => pw.ElementId);

            //Nullifies Relation
            modelBuilder.Entity<PersonaNullify>()
        .HasKey(pw => new { pw.PersonaId, pw.ElementId });

            modelBuilder.Entity<PersonaNullify>()
                .HasOne(pw => pw.Persona)
                .WithMany(p => p.Nullifies)
                .HasForeignKey(pw => pw.PersonaId);

            modelBuilder.Entity<PersonaNullify>()
                .HasOne(pw => pw.Element)
                .WithMany()
                .HasForeignKey(pw => pw.ElementId);

            //Persona Reflect
            modelBuilder.Entity<PersonaReflect>()
        .HasKey(pw => new { pw.PersonaId, pw.ElementId });

            modelBuilder.Entity<PersonaReflect>()
                .HasOne(pw => pw.Persona)
                .WithMany(p => p.Reflects)
                .HasForeignKey(pw => pw.PersonaId);

            modelBuilder.Entity<PersonaReflect>()
                .HasOne(pw => pw.Element)
                .WithMany()
                .HasForeignKey(pw => pw.ElementId);

            //Persona Resists
            modelBuilder.Entity<PersonaResist>()
        .HasKey(pw => new { pw.PersonaId, pw.ElementId });

            modelBuilder.Entity<PersonaResist>()
                .HasOne(pw => pw.Persona)
                .WithMany(p => p.Resists)
                .HasForeignKey(pw => pw.PersonaId);

            modelBuilder.Entity<PersonaResist>()
                .HasOne(pw => pw.Element)
                .WithMany()
                .HasForeignKey(pw => pw.ElementId);
        }
    }
}
