using BuildingBlocks.Core.CQRS;
using Catalog.Domain.Repositories;
using Mapster;

namespace Catalog.Application.Products.Queries.GetProducts;

public class GetProductsHandler : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    private readonly IProductRepository _repository;

    public GetProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync(cancellationToken);
        
        var productDtos = products.Adapt<IEnumerable<ProductDto>>();
        
        return new GetProductsResult(productDtos);
    }
}
