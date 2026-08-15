using Microsoft.EntityFrameworkCore;
using MTLCRISTALVK18BACK.Models.Usersadmin;
using MTLCRISTALVK18BACK.Models.Habitaciones;
using MTLCRISTALVK18BACK.Models.Reservas;

namespace MTLCRISTALVK18BACK.Contexts
{
    public class MTLCRISTALContexts : DbContext
    {
        public MTLCRISTALContexts(DbContextOptions<MTLCRISTALContexts> options) : base(options) { }

        // Tabla de usuarios administrativos
        public DbSet<Usersadmin> Usersadmin { get; set; } = null!;

        // Tabla principal de habitaciones
        public DbSet<Habitaciones> Habitaciones { get; set; } = null!;

        // Tabla de reservas (con listas de clientes y consumos)
        public DbSet<Reservas> Reservas { get; set; } = null!;

        // Tabla de clientes relacionados con reservas
        public DbSet<Tipo1Cliente> Tipo1Cliente { get; set; } = null!;

        // Tabla de consumos relacionados con reservas
        public DbSet<Tipo2Consumos> Tipo2Consumos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación: Reservas → Clientes
            modelBuilder.Entity<Reservas>()
                .HasMany(r => r.Tipo1ResvdCl)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Relación: Reservas → Consumos
            modelBuilder.Entity<Reservas>()
                .HasMany(r => r.Tipo2ResvdCl)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // Puedes configurar nombres de tabla si quieres personalizarlos
            // modelBuilder.Entity<Tipo1Cliente>().ToTable("Clientes");
            // modelBuilder.Entity<Tipo2Consumos>().ToTable("Consumos");
        }
    }
}
