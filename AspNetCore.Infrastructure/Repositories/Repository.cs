using AspNetCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AspNetCore.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext context;
        protected Repository(AppDbContext context)
        {
            this.context = context;
        }

        public virtual T Create(T entity)
        {
            return context.Add(entity).Entity;
        }

        public T Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>()
                .AsQueryable()
                .Where(predicate)
                .ToList();
        }

        public virtual T Read(int id)
        {
            return context.Find<T>(id);
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return context.Set<T>().ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public T Update(T entity)
        {
            return context.Update(entity).Entity;
        }
    }
}