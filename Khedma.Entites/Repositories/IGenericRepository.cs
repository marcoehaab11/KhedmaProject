using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Repositories
{
    public interface IGenericRepository<T> where T :class
    { 
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate = null, string? Includeword =null);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        

        T GetFirstorDefault(Expression<Func<T, bool>>? perdicate = null, string? Includeword = null);

        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void RemoveRange(IEnumerable<T> entites);
        Task UpdatePointsAsync(int id, int points);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);


    }
}
