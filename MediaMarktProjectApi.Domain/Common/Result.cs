namespace MediaMarktProjectApi.Domain.Common;
public class Result<T>
{
    public bool IsSuccess { get; }
    public SuccessType SuccessType { get; }
    public T Value { get; }
    public string Error { get; }
    public ErrorType ErrorType { get; }

    protected Result(T value, bool isSuccess, string error, ErrorType errorType = ErrorType.Validation, SuccessType successType = SuccessType.Ok)
    {
        Value = value;
        IsSuccess = isSuccess;
        Error = error;
        ErrorType = errorType;
        SuccessType = successType;
    }

    public static Result<T> Success(T value, SuccessType successType = SuccessType.Ok) => new(value, true, string.Empty, successType: successType);
    public static Result<T> Failure(string error, ErrorType errortype = ErrorType.Validation) => new(default!, false, error, errorType: errortype);
}

