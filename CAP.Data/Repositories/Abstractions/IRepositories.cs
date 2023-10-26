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
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);

        // 
        Task<T> GetByGuidAsync(Guid id);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<T> HardDeleteAsync();
    }
}
// https://www.youtube.com/watch?v=Yn4TaQ3ws_M&list=PLrSCwxkucNmxFrrAsGm14Z-5Cu52MKrNr&index=14&t=639s