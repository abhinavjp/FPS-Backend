using System.Data.Entity;

namespace FPS.Service.Repository.Interface
{
    public interface IUnitOfWork<T> where T: DbContext
    {
        IGenericRepository<TEntity, TContext> GetRepository<TEntity, TContext>() where TEntity : class where TContext : DbContext;
        void Commit();
    }
}
