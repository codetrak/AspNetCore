using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AspNetCore.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Read(int id);
        IEnumerable<T> ReadAll();     
        T Update(T entity);
        T Delete(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void SaveChanges();

    }
}