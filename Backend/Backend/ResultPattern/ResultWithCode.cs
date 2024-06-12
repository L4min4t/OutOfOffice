namespace Backend.ResultPattern;

public class ResultWithCode<T> : Result<T>, IResultWithCode<T>
{
    public ResultCode Code { get; }

    private ResultWithCode(bool isSuccess, T? value, string? error, ResultCode code)
        : base(isSuccess, value, error)
    {
        Code = code;
    }

    public static new ResultWithCode<T> Success(T value) => 
        new ResultWithCode<T>(true, value, null, ResultCode.Ok);

    public static ResultWithCode<T> Failure(string error, ResultCode code) =>
        new ResultWithCode<T>(false, default, error, code);
}