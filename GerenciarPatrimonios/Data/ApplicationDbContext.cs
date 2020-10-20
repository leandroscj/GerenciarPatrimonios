using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GerenciarPatrimonios.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Marca.Marca> Marca { get; set; }
        public DbSet<Models.Patrimonio.Patrimonio> Patrimonio { get; set; }
        public DbSet<Models.Usuario.Usuario> Usuario { get; set; }
    }
}