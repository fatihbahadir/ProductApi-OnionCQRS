using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Interfaces.AutoMapper;


namespace ProductApi.Mapper
{
    public static class Registiration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
