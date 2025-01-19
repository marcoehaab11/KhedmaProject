using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Khedma.Entites.Repositories
{
    public interface IGenericForAdminRepository<T> where T :class
    { 
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate = null, string? Includeword =null);
        
        T GetFirstorDefault(Expression<Func<T, bool>>? perdicate = null, string? Includeword = null);

        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
        void RemoveRange(IEnumerable<T> entites);

    }
}
