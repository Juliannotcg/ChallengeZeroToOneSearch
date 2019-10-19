using Challenge.Domain.Core.Models;
using Challenge.Domain.Interfaces;
using Challenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Challenge.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : 
        IRepository<TEntity> where TEntity :
        Identity<TEntity>
    {
        protected ContextEntity Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(ContextEntity context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpDate(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}