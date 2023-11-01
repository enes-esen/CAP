using CAP.Data.Repositories.Abstractions;
using CAP.Data.Repositories.Concretes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAP.Data.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration configuration) 
        {
            /*Scope eklenir.
             * Örnek olarak IRepository nesnesi çağrıldığında Repository'nin dönmesi-oluşturulması gerektiğinin belirtilmesi
            */

            services.AddScoped(typeof(IRepositories<>), typeof(Repositories<>));

            return services;
        }
    }
}
