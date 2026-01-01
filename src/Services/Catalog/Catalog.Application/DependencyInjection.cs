using BuildingBlocks.Core.CQRS;
using Catalog.Application.Products.Commands.CreateProduct;
using Catalog.Application.Products.Queries.GetProducts;
using FluentValidation;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Register FluentValidation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Register Mapster
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton(config);

        // Register Manual CQRS Handlers
        services.AddScoped<ICommandHandler<CreateProductCommand, CreateProductResult>, CreateProductHandler>();
        services.AddScoped<IQueryHandler<GetProductsQuery, GetProductsResult>, GetProductsHandler>();
        
        // We will add Query Handlers here as we implement them.
        
        return services;
    }
}
