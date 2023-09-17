using Category.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Category.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext):base(dbContext)
        {
                
        }
        DbSet<CategoryDomain> CategoryDomains { get; set; }
    }
}
