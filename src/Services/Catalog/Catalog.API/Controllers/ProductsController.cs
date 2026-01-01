using BuildingBlocks.Core.CQRS;
using Catalog.Application.Products.Commands.CreateProduct;
using Catalog.Application.Products.Queries.GetProducts;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ICommandHandler<CreateProductCommand, CreateProductResult> _createHandler;
    private readonly IQueryHandler<GetProductsQuery, GetProductsResult> _getHandler;

    public ProductsController(
        ICommandHandler<CreateProductCommand, CreateProductResult> createHandler,
        IQueryHandler<GetProductsQuery, GetProductsResult> getHandler)
    {
        _createHandler = createHandler;
        _getHandler = getHandler;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        var result = await _createHandler.Handle(command, CancellationToken.None);
        // Note: Ideally we'd return CreatedAtAction but for now Ok with result is fine or just the ID.
        // Also validation is handled by FluentValidation but we need to hook it up or manually call Validate.
        // FluentValidation.DependencyInjection usually hooks into MVC validation pipeline automatically if configured.
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var query = new GetProductsQuery();
        var result = await _getHandler.Handle(query, CancellationToken.None);
        return Ok(result);
    }
}
