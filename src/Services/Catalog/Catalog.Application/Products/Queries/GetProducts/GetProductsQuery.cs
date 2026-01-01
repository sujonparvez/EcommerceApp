using BuildingBlocks.Core.CQRS;

namespace Catalog.Application.Products.Queries.GetProducts;

public record GetProductsQuery : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<ProductDto> Products);
public record ProductDto(Guid Id, string Name, string Description, decimal Price, string Category, string ImageUrl);
