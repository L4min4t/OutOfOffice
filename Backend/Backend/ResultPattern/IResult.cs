namespace Backend.ResultPattern;

public interface IResult<T>
{
    bool IsSuccess { get; }
    T? Value { get; }
    string? Error { get; }
}