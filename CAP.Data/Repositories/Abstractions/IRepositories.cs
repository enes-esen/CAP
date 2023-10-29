using CAP.Core.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CAP.Data.Repositories.Abstractions
{
    public interface IRepositories<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        //Tek bir veri dönmesi için aşağıdaki işlem yapılır.
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        // 
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        //Tablonun içinde kaç adet nesne olduğunu belirtmek için.
        //Mesela kaç tane müşteri var.
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);

        // Yukarıdaki eklemelerden sonra Repository'nin somut sınıfına geçilir.
        // Eklediğimiz alanları somut sınıfta implemente etmemiz gerekmektedir.

    }
}