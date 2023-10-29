using CAP.Core.Abstract.Interfaces;
using CAP.Data.Context;
using CAP.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CAP.Data.Repositories.Concretes
{
    // T'nin bir class olduğunun belirtilmesi gerekiyor.
    public class Repositories<T> : IRepositories<T> where T : class, IEntityBase, new()
    {
        // asing field
        private readonly AppDbContext _dbContext;

        // constructer
        public Repositories(AppDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        // DbSet T tipinden tanımlandı.
        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        /* Table'ı _dbContext ile set ediyoruz.
         * Böylece her yerde _dbContext'i kullanmayız.
         * T nesnesi oluşturulan entity'leri kapsıyor.
         */

        public async Task AddAsync(T entity)
        {
            // Task = Void, Void'in asekron olarak kodlamada kullanılan isimdir.
            await Table.AddAsync(entity);
            // AWAIT: Çağırdıktan sonra beklemesi için kullanılır.

            // Bu metodun Interface'ini yazmamız gerekiyor bunun için IRepository'de metod oluşturulur.
        }

        /* Expression metod
         * params, tekrar expression oluşturmak için kullanılır.
         */
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, 
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            return await query.ToListAsync();
            // Interface'i fonksiyonun ismini alırız.
        }

        /* Soyut sınıftan implemente etme
         * Bu metodların düzenlenmesi yapılır. 
         * 
         * Bu metotta predicate'teki null kaldırılır. Aynı zamanda interface'de de kaldırılır.
         * public Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
         */
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            query = query.Where(predicate);
            if (includeProperties.Any())
            {
                foreach (var item in includeProperties)
                {
                    query = query.Include(item);
                }
            }
            /* return await query.FirstAsync(); Bu metot 10 tane değer varsa bile bir tane getirir.
             * Aşağıdaki metot ise istenen değerin %100 gelmesi beklenir.
             */
            return await query.SingleAsync();
            
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}

/* 42. DK da kalındı.
 * https://www.youtube.com/watch?v=Yn4TaQ3ws_M&list=PLrSCwxkucNmxFrrAsGm14Z-5Cu52MKrNr&index=6&t=1925s
 */