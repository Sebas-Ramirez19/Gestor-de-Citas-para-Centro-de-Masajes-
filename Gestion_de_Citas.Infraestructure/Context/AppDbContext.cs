using Microsoft.EntityFrameworkCore;
using Gestion_de_Citas.domain;
using System.Reflection.Emit;
using Gestion_de_Citas.Infraestructure;
namespace Gestion_de_Citas.Infraestructure.Context

{

    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(

            DbContextOptions<ApplicationDbContext> options)

            : base(options)

        {

        }


        public DbSet<ModeloDoctor> Doctor { get; set; }

        public DbSet<ModeloEspecialidad> Especialidad{ get; set; }

        public DbSet<ModeloCita> Cita { get; set; }

        public DbSet<ModeloPaciente> Pacientes { get; set; }


        protected override void OnModelCreating(

            ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ModeloDoctor>()

                .Property(d => d.Nombre)

                .HasPrecision(10, 2);


            modelBuilder.Entity<ModeloEspecialidad>()

                .Property(e => e.Nombre)

                .HasPrecision(10, 2);


            modelBuilder.Entity<ModeloPaciente>()

                .Property(p => p.Nombre)

                .HasPrecision(10, 2);



            modelBuilder.Entity<ModeloCita>()
                .Property(c => c.Fecha)
                .HasPrecision(10, 2);

        }

    }
}