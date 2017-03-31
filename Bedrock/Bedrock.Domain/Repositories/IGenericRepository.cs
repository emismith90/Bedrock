using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bedrock.Domain.Repositories
{
    public interface IGenericRepository<TEntity, TEntityKey> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(TEntityKey id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntityKey id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}
