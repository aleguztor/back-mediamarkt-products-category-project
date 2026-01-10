using MediaMarktProjectApi.Application.Dtos.Product;
using MediaMarktProjectApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MediaMarktProjectApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    /* Summary:
        * This endpoint retrieves a list of products.
        */
    public async Task<IActionResult> GetProducts()
    {
        var result = await productService.GetAllAsync();

        if (result.IsFailure)
        {
            return NotFound(new { error = result.Error });
        }

        return Ok(result.Value);
    }

    [HttpGet]
    [Route("{id}")]
    /* Summary:
    * This endpoint retrieves a product by its ID.
    */
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var result = await productService.GetByIdAsync(id);

        if (result.IsFailure)
        {
            return NotFound(new { error = result.Error });
        }

        return Ok(result.Value);
    }
    [HttpPost]
    /* Summary:
    * This endpoint create a product.
    */
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var result = await productService.CreateProductAsync(request);

        if (result.IsFailure)
        {
            return NotFound(new { error = result.Error });
        }

        return Ok(result.Value);
    }
    [HttpPut]
    /* Summary:
    * This endpoint updates a product.
    */
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        var result = await productService.UpdateProductAsync(request);

        if (result.IsFailure)
        {
            return NotFound(new { error = result.Error });
        }

        return Ok(result.Value);
    }
    [HttpDelete]
    [Route("{id}")]
    /* Summary:
    * This endpoint delete a product.
    */
    public async Task<IActionResult> DeleteProductById(Guid id)
    {
        var result = await productService.DeleteProductByIdAsync(id);

        if (result.IsFailure)
        {
            return NotFound(new { error = result.Error });
        }

        return Ok(result.Value);
    }
}

