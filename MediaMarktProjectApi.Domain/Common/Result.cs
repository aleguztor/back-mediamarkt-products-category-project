namespace MediaMarktProjectApi.Domain.Common;
public class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }
    public bool IsFailure => !IsSuccess;
    public ErrorType ErrorType { get; }

    protected Result(T value, bool isSuccess, string error, ErrorType type = ErrorType.Validation)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
        ErrorType = ErrorType;
    }

    public static Result<T> Success(T value) => new(value, true, string.Empty);
    public static Result<T> Failure(string error, ErrorType type) => new(default!, false, error, type);
}

