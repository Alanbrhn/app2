using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementAPI.Server.Commands;
using ProductManagementAPI.Server.Queries;
using System.Linq;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
       
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var productId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = productId }, new { id = productId });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetProductQuery([FromQuery] string name, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
    {
        var query = new GetProductsQuery(name, minPrice, maxPrice);

      
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var products = await _mediator.Send(query);

        if (products == null || !products.Any())
        {
            return NotFound("No products found matching the criteria.");
        }

        return Ok(products);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductCommand command)
    {
        if (id != command.Id) return BadRequest("Product ID mismatch.");

    
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _mediator.Send(command);
        if (!result) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteProductCommand { Id = id });
        if (!result) return NotFound();
        return NoContent();
    }
}
