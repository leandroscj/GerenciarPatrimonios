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

        public DbSet<Models.Marca.MarcaModel> Marca { get; set; }
        public DbSet<Models.Patrimonio.PatrimonioModel> Patrimonio { get; set; }
        public DbSet<Models.Usuario.UsuarioModel> Usuario { get; set; }
    }
}