//using AdmImpuestos.Models;
using adm_impuestos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace adm_impuestos.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Tipo_Identificacion> Tipo_Identificacion { get; set; }
        public DbSet<Tipo_Contribuyente> TipoContribuyente { get; set; }
        public DbSet<Persona> persona { get; set; }
        public DbSet<Contribuyente> Contribuyentes { get; set; }
        public DbSet<EventoContribuyente> EventosContribuyente { get; set; }
        public DbSet<SerieNcf> SerieNcf { get; set; }
        public DbSet<VersionNcf> VersionNcf { get; set; }
        public DbSet<Tipo_Ncf> TipoNcfs { get; set; }
        public DbSet<SecuenciaNcf> SecuenciaNcf { get; set; }

        // Agrega DbSet para otras tablas si es necesario

        // Constructor que acepta opciones de DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Sobrescribe OnModelCreating para configurar la clave compuesta
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tipo_Ncf>()
                .HasKey(t => new { t.TipoNcf, t.Serie, t.CodVersion });

            modelBuilder.Entity<EventoContribuyente>()
                .HasKey(t => new { t.CodContrib, t.NcfUsado });

        }

        // Sobrescribe OnConfiguring si es necesario
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                // Configura la cadena de conexión a la base de datos desde appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            }*/
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=dgii_contrib;User Id=postgres;Password=antena123;");
                /*IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();*/
            }
        }
    }
}
