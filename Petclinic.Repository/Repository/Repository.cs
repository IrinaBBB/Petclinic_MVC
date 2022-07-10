using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PetClinic.DataAccess;
using Petclinic.Repository.IRepository;

namespace Petclinic.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ShopDbContext _db;
        internal DbSet<T> DbSet;

        public Repository(ShopDbContext db)
        {
            _db = db;
            DbSet = _db.Set<T>();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = DbSet;
            var queryable = query.Where(filter);
            return queryable.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = DbSet;
            return query.ToList();
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            DbSet.RemoveRange(entities);
        }
    }
}