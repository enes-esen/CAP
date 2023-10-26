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
        // Table'ı _dbContext ile set ediyoruz.
        // Böylece her yerde _dbContext'i kullanmayız.
        // T nesnesi oluşturulan entity'leri kapsıyor.

        // Expression metod
        // params, tekrar expression oluşturmak için kullanılır.
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

        public async Task AddAsync(T entity)
        {
            // Task = Void, Void'in asekron olarak kodlamada kullanılan isimdir.
            await Table.AddAsync(entity);
            //AWAIT: Çağırdıktan sonra beklemesi için kullanılır.

            // Bu metodun Interface'ini yazmamız gerekiyor bunun için IRepository'de metod oluşturulur.
        }




    }
}
