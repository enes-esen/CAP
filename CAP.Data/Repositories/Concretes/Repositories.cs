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
    public class Repositories<T> : IRepositories<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;

        public Repositories(AppDbContext dbContext) 
        {
            this._dbContext = dbContext;
        }

        // DbSet T tipinden tanımlandı.
        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        // Table'ı _dbContext ile set ediyoruz.
        // Böylece her yerde _dbContext'i kullanmayız.

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
            //AWAIT: Çağırdıktan sonra beklemesi için kullanılır.
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, 
            params Expression<Func<T, object>>);

    }
}
