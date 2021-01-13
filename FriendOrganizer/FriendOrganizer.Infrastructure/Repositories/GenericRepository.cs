using FriendOrganizer.DataAcess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected FriendOrganizerDbContext _ctx;

        public GenericRepository(FriendOrganizerDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual T Add(T entity)
        {
            return _ctx.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);
        }

        public virtual void DeleteById(params object[] id)
        {
            T entity = GetByIdAsync(id).Result;
            Delete(entity);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _ctx.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _ctx.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(params object[] id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        //public virtual async Task<int> SaveChanges()
        //{
        //    return await _ctx.SaveChangesAsync();
        //}

        public virtual void Update(T entity)
        {
            _ctx.Set<T>().Attach(entity);
            _ctx.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;

        }
    }
}
