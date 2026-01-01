using BuildingBlocks.Core.CQRS;
using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;

namespace Catalog.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product(command.Name, command.Description, command.Price, command.Category, command.ImageUrl);

        await _repository.AddAsync(product, cancellationToken);
        
        return new CreateProductResult(product.Id);
    }
}
