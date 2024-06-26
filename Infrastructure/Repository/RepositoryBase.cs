using System.Linq.Expressions;
using Domain.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public abstract class RepositoryBase<T>(RepositoryContext repositoryContext) : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext = repositoryContext;

        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _repositoryContext.Set<T>().AsNoTracking() : _repositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _repositoryContext.Set<T>().Where(expression).AsNoTracking() : _repositoryContext.Set<T>().Where(expression);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
    }
}