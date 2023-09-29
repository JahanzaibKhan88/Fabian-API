using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using Fabian.Infrastructure.Models;
using Fabian.Infrastructure.Validators;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Product>,  ProductValidator>();
            services.AddAutoMapper(config =>
            {
                config.CreateMap<Product, Fabian.Domain.Entities.Product>();
                config.CreateMap<Fabian.Domain.Entities.Product, Product>();
            });
            services.AddDbContext<FabianContext>();
            return services;
        }
    }
}
