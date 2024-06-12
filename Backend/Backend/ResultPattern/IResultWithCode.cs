namespace Backend.ResultPattern;

public interface IResultWithCode<T> : IResult<T>
{
    ResultCode Code { get; }
}