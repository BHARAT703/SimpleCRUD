using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SimpleCRUD.Data.Abstract
{
    public interface IEntityBaseRepository<T> where T : class, new()
    {
        IEnumerable<T> items { get; }
        T this[int id] { get; }
        T GetSingle(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        T Operations(T entity, EntityState state);
        int Count();
        IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
