using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AplicativoSeguridad.Models;

namespace AplicativoSeguridad.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AplicativoSeguridad.Models.Activo>? Activo { get; set; }
        public DbSet<AplicativoSeguridad.Models.Control>? Control { get; set; }
        public DbSet<AplicativoSeguridad.Models.Amenaza>? Amenaza { get; set; }
        public DbSet<AplicativoSeguridad.Models.Vulnerabilidad>? Vulnerabilidad { get; set; }
    }
}