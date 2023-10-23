using CAP.Core.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP.Data.Repositories.Abstractions
{
    public interface IRepositories<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
    }
}