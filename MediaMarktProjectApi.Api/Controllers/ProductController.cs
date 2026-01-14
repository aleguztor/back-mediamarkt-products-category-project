namespace MediaMarktProjectApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(IProductService productService) : ApiControllerBase
{
    /// <summary>
    /// Obtiene un listado de productos.
    /// </summary>
    /// <param name="productsFilterRequest">Filtros para los productos</param>
    /// <returns>Retorna todos los productos.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts([FromQuery]ProductsFilterRequest productsFilterRequest)
    {
        var result = await productService.GetAllAsync(productsFilterRequest);

        return HandleResult(result);
    }

    /// <summary>
    /// Obtiene un producto por su ID.
    /// </summary>
    /// <param name="id">ID del producto</param>
    /// <returns>Retorna el producto si lo encuentra.</returns>
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var result = await productService.GetByIdAsync(id);

        return HandleResult(result);
    }

    /// <summary>
    /// Crea un nuevo producto en el sistema.
    /// </summary>
    /// <remarks>
    /// **Reglas de negocio:**
    /// 1. Si no se proporciona un CategoryId, este quedará sin categoría.
    /// 2. El precio debe ser estrictamente mayor que 0.
    /// 3. La descripción puede ser nula.
    /// </remarks>
    /// <param name="request">Objeto JSON con los datos del nuevo producto.</param>
    /// <returns>Retorna el producto recién creado.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var result = await productService.CreateProductAsync(request);

        return HandleResult(result);
    }

    /// <summary>
    /// Actualiza un producto en el sistema.
    /// </summary>
    /// <remarks>
    /// **Reglas de negocio:**
    /// 1. Si no se proporciona un CategoryId, este quedará sin categoría.
    /// 2. El precio debe ser estrictamente mayor que 0.
    /// 3. La descripción puede ser nula.
    /// </remarks>
    /// <param name="request">Objeto JSON con los datos del producto a actualizar.</param>
    /// <returns>Retorna true si se ha actualizdo correctamente.</returns>
    [HttpPut]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
    {
        var result = await productService.UpdateProductAsync(request);

        return HandleResult(result);
    }

    /// <summary>
    /// Eliminar un producto por su ID.
    /// </summary>
    /// <param name="id">ID del producto</param>
    /// <returns>Retorna true si se ha eliminado correctamente.</returns>
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProductById(Guid id)
    {
        var result = await productService.DeleteProductByIdAsync(id);

        return HandleResult(result);
    }
}