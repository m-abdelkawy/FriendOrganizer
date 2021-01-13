using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Update(T entity);
        Task<T> GetByIdAsync(params Object[] id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        //Task<int> SaveChanges();
        void Delete(T entity);
        void DeleteById(params Object[] id);
    }
}
