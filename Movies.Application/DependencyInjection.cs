using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Movies.Application.Mappings;
using Mapster;
 using FluentValidation;
 using Movies.Application.Behaviors;

namespace Movies.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cf =>
            {
                cf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cf.AddOpenBehavior(typeof(ValidationBehabiors<,>));
            });
            MappingConfig.Configure();
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly()); 
            services.AddSingleton(config); 

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
