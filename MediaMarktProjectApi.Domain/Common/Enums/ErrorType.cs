namespace MediaMarktProjectApi.Domain.Common.Enums;
public enum ErrorType
{
    Validation, // Para 400 Bad Request
    NotFound,   // Para 404 Not Found
    Conflict,   // Para 409 Conflict
    Failure     // Para 500 o errores genéricos
}
