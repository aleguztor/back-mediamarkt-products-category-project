namespace MediaMarktProjectApi.Api.Controllers;
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return result.Value is null ? NoContent() : Ok(result.Value);
        }

        // Aquí unificamos la lógica de errores para toda la App
        return result.ErrorType switch
        {
            ErrorType.NotFound => NotFound(new { message = result.Error }),
            ErrorType.Validation => BadRequest(new { message = result.Error }),
            ErrorType.Conflict => Conflict(new { message = result.Error }),
            _ => StatusCode(500, new { message = "Error interno inesperado", details = result.Error })
        };
    }
}