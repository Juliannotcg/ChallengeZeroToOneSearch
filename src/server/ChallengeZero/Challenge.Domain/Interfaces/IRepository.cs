using Challenge.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Challenge.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Identity<TEntity>
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void UpDate(TEntity obj);
        void Remove(Guid id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        int SaveChanges();
    }
}