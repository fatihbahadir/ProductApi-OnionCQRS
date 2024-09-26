using Microsoft.Extensions.DependencyInjection;
using ProductApi.Application.Exceptions;
using FluentValidation;
using System.Reflection;
using MediatR;
using ProductApi.Application.Behaviours;
using System.Globalization;
using ProductApi.Application.Features.Products.Rules;
using ProductApi.Application.Bases;


namespace ProductApi.Application
{
    public static class Registiration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();
            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en-US");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));

        }

        private static IServiceCollection AddRulesFromAssemblyContaining(this IServiceCollection services, Assembly assembly, Type type)
        {
            var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type !=t).ToList();

            foreach (var item in types)
            {
                services.AddTransient(item);
            }
            return services;
        }
    }
}
