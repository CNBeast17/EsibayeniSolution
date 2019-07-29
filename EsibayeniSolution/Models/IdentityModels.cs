using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EsibayeniSolution.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            Database.SetInitializer<ApplicationDbContext>( new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.Batch> Batches { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.LivesStock> LivesStocks { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.LivestockImage> LivestockImages { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.MaintainanceProcess> MaintainanceProcesses { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.MaintainanceStock> MaintainanceStocks { get; set; }

        public System.Data.Entity.DbSet<EsibayeniSolution.Models.ProductCategory> ProductCategories { get; set; }

        // public System.Data.Entity.DbSet<EsibayeniSolution.Models.LivestockImagesVM> LivestockImagesVMs { get; set; }
    }
}