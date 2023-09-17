using Category.DataAccess.Repository;
using Category.Domain.Interfaces;
using Category.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Category.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(opt => opt
                .UseSqlServer("Server=NARENDER\\SQL2019; Database=Category;user Id=sa;Password=12345678;Trusted_Connection=True;TrustServerCertificate=True;"));
            return services;
        }
    }
}
