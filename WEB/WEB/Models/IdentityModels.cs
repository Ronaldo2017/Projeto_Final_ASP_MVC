using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WEB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BaseModel.Ferramenta> Ferramentas { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Manutencao> Manutencaos { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Maquina> Maquinas { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Produto> Produtos { get; set; }

        public System.Data.Entity.DbSet<BaseModel.CriarLote> CriarLotes { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Lote> Lotes { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Producao> Producaos { get; set; }

        public System.Data.Entity.DbSet<BaseModel.Estoque> Estoques { get; set; }
    }
}