using Challenge.Domain.Core.Models;
using Challenge.Domain.Interfaces;
using Challenge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(t => t.Id == id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual void UpDate(TEntity obj)
        {
            DbSet.Update(obj);
        }
        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}