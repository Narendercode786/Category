using Category.Domain.Interfaces;
using Category.Domain.Models;

namespace Category.DataAccess.Repository
{
    public class CategoryRepository:GenericRepository<CategoryDomain>,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext option):base(option)
        {
                
        }
    }
}
