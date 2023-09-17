using Category.Domain.Interfaces;

namespace Category.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context,ICategoryRepository CategoryRepository)
        {
            _context = context;
            this.CategoryRepository = CategoryRepository;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
