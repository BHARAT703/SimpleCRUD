using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleCRUD.Data.Abstract;
using SimpleCRUD.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SimpleCRUD.Data.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IFullAuditedEntity, new()
    {
        private readonly ApplicationContext context;

        public EntityBaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public virtual IEnumerable<T> items => context.Set<T>().AsEnumerable().OrderByDescending(m => m.Id);

        public virtual T this[int id] => context.Set<T>().FirstOrDefault(m => m.Id == id);

        public virtual T GetSingle(int id) => context.Set<T>().FirstOrDefault(x => x.Id == id);

        public virtual T Add(T entity) => Operations(entity: entity, state: EntityState.Added);

        public virtual T Update(T entity) => Operations(entity: entity, state: EntityState.Modified);

        public virtual T Delete(T entity) => Operations(entity: entity, state: EntityState.Deleted);

        public virtual T Operations(T entity, EntityState state)
        {
            EntityEntry dbEntityEntry = context.Entry<T>(entity);

            if (state == EntityState.Added)
            {
                entity.CreationTime = DateTime.UtcNow;
                entity.CreatorUserId = 1;

                context.Set<T>().Add(entity);
                dbEntityEntry.State = EntityState.Added;
            }
            else if (state == EntityState.Modified)
            {
                entity.LastModificationTime = DateTime.UtcNow;
                entity.LastModifierUserId = 1;

                dbEntityEntry.State = EntityState.Modified;
            }
            else if (state == EntityState.Deleted)
            {
                entity.IsDeleted = true;
                entity.DeleterUserId = 1;
                entity.DeletionTime = DateTime.UtcNow;

                dbEntityEntry.State = EntityState.Modified;
            }

            return entity;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = context.Set<T>().Where(predicate);

            foreach (var entity in entities)
            {
                context.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public virtual int Count() => context.Set<T>().Count();

        public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty).AsNoTracking();
            }

            return query.AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate) => context.Set<T>().FirstOrDefault(predicate);

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) => context.Set<T>().Where(predicate);

        public virtual void Commit() => context.SaveChanges();
    }
}
