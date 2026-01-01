using BuildingBlocks.Core.CQRS;

namespace Catalog.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, string Description, decimal Price, string Category, string ImageUrl) 
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
