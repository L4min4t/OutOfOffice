namespace Backend.ResultPattern;

public class Result
{
    protected Result(bool isSuccess, List<string> errorMessages = null)
    {
        (IsSuccess, ErrorMessages) =
            (isSuccess, errorMessages ?? new List<string>());
    }
    
    public bool IsSuccess { get; protected set; }
    public List<string> ErrorMessages { get; protected set; }
    
    public static Result Success()
    {
        return new Result(true);
    }
    
    public static Result Fail(string errorMessage)
    {
        return new Result(false, new List<string> { errorMessage });
    }
    
    public static Result Fail(List<string> errorMessages)
    {
        return new Result(false, errorMessages);
    }
    
    public static Result<T> Success<T>(T value)
    {
        return Result<T>.Success(value);
    }
}

public class Result<T> : Result
{
    private Result
        (bool isSuccess, T value = default, List<string> errorMessages = null)
        : base(isSuccess, errorMessages)
    {
        Value = value;
    }
    
    public T Value { get; }
    
    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value);
    }
    
    public new static Result<T> Success()
    {
        return new Result<T>(true);
    }
    
    public new static Result<T> Fail(string errorMessage)
    {
        return new Result<T>(false, default, new List<string> { errorMessage });
    }
    
    public new static Result<T> Fail(List<string> errorMessages)
    {
        return new Result<T>(false, default, errorMessages);
    }
    
    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }
}
