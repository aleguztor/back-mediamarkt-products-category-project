namespace MediaMarktProjectApi.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(ICategoryService categoryService) : ApiControllerBase
{
    /// <summary>
    /// Obtiene un listado de categorias.
    /// </summary>
    /// <returns>Retorna todas las categorias.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var result = await categoryService.GetAllAsync();

        return HandleResult(result);
    }
}