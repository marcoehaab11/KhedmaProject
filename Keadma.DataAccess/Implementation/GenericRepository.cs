using Microsoft.EntityFrameworkCore;

using Khedma.Entites.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Keadma.DataAccess.Data;
using Khedma.Entites.Models;

namespace Keadma.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
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
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,string? includeProperties = null)
        {
            // بدء استعلام باستخدام DbSet
            IQueryable<T> query = _dbSet;

            // إذا تم توفير شرط (predicate)، قم بتطبيقه
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            // إذا تم توفير includeProperties، قم بإضافة الخصائص المحددة للاستعلام
            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            // تنفيذ الاستعلام وإرجاع النتيجة كقائمة
            return await query.ToListAsync();
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _dbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
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
        public async Task UpdatePointsAsync(int id, int points)
        {
            // البحث عن الشخص بناءً على ID
            var entity = await _dbSet.FindAsync(id);

            if (entity != null)
            {
                // الوصول إلى خاصية النقاط باستخدام Reflection
                var propertyInfo = typeof(T).GetProperty("Points");
                if (propertyInfo != null)
                {
                    // قراءة القيمة الحالية للنقاط
                    var currentPoints = (int?)propertyInfo.GetValue(entity) ?? 0;


                    // تحديث النقاط
                    propertyInfo.SetValue(entity, currentPoints + points);
                }

                // حفظ التغييرات في قاعدة البيانات
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Entity with ID {id} not found.");
            }
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }


    }
}
