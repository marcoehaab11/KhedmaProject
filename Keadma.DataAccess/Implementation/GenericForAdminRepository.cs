using Microsoft.EntityFrameworkCore;

using Khedma.Entites.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Keadma.DataAccess.Data;

namespace Keadma.DataAccess.Implementation
{
    public class GenericForAdminRepository<T> : IGenericForAdminRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericForAdminRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _context.Set<T>().Any(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate, string? Includeword)
        {
            IQueryable<T> query = _dbSet;
            if(perdicate != null)
            {
                query = query.Where(perdicate);
            }
            if(Includeword != null) 
            {
                foreach (var item in Includeword.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries) )
                {
                    query = query.Include(item);
                }
            }
            return query.ToList();
        }

        public T GetFirstorDefault(Expression<Func<T, bool>>? perdicate=null, string? Includeword = null)
        {

            IQueryable<T> query = _dbSet;
            if (perdicate != null)
            {
                query = query.Where(perdicate);
            }
            if (Includeword != null)
            {
                foreach (var item in Includeword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
           _dbSet.RemoveRange(entites);
        }
    }
}
