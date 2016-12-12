using FPS.Service.Repository.Interface;
using StructureMap.Pipeline;
using System;
using System.Data.Entity;
using static FPS.Service.Infrastructure.StructureMapConfigurator;

namespace FPS.Service.Repository.Service
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T: DbContext
    {
        private readonly T _context;
        public UnitOfWork(T context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            _context = context;
        }
        public IGenericRepository<TEntity, TContext> GetRepository<TEntity, TContext>() where TEntity : class where TContext: DbContext
        {
            var args = new ExplicitArguments();
            args.Set(_context);
            return GetInstance<IGenericRepository<TEntity, TContext>>(args);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
