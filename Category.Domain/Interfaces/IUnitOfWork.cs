namespace Category.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        int Save();
    }
}
