using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using ProductApi.Persistence.Context;
using ProductApi.Application.Interfaces.Repositories;
using ProductApi.Persistence.Repositories;
using ProductApi.Application.Interfaces.UnitOfWorks;
using ProductApi.Persistence.UnitOfWorks;

namespace ProductApi.Persistence
{
    public static class Registiration{
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
