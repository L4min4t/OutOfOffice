namespace Backend.ResultPattern;

public class Result<T>
{
    public T? Value { get; private set; }
    public bool IsSuccess { get; private set; }
    public HttpStatusCode StatusCode { get; private set; }
    public string? ErrorMessage { get; private set; }

    private Result(T? value, bool isSuccess, HttpStatusCode statusCode, string? errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;
        StatusCode = statusCode;
        ErrorMessage = errorMessage;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, HttpStatusCode.Ok, null);
    }

    public static Result<T> Success()
    {
        return new Result<T>(default, true, HttpStatusCode.Ok, null);
    }

    public static Result<T> Failure(HttpStatusCode statusCode, string errorMessage)
    {
        return new Result<T>(default, false, statusCode, errorMessage);
    }
}

public enum HttpStatusCode
{
    Ok = 200,
    Created = 201,
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    InternalServerError = 500,
}