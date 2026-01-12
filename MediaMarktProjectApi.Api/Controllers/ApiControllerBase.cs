namespace MediaMarktProjectApi.Api.Controllers;
public abstract class ApiControllerBase : ControllerBase
{
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            if (result.Value is null)
                return NoContent();

            return result.SuccessType switch
            {
                SuccessType.Ok => Ok(result.Value),
                SuccessType.Created => Created(string.Empty, result.Value),
                _ => Ok(result.Value)
            };
        }

        return result.ErrorType switch
        {
            ErrorType.NotFound => NotFound(new { message = result.Error }),
            ErrorType.Validation => BadRequest(new { message = result.Error }),
            ErrorType.Conflict => Conflict(new { message = result.Error }),
            _ => StatusCode(500, new { message = "Error interno inesperado", details = result.Error })
        };
    }
}