namespace Domain.Shared;

public class Result<TValue>
{
    private Result(bool success, Error error, TValue? value = default)
    {
        if (success && error == Error.None || !success && error != Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = success;
        Error = error;
        Value = value;
    }

    public bool IsSuccess { get; private set; }
    
    public TValue? Value { get; private set; }
    
    public Error Error { get; private set; }

    public static Result<TValue> Success() => new(true, Error.None);
    public Result<TValue> Success(TValue value) => new(true, Error.None, value);
    public static Result<TValue> Failure(Error error) => new(false, error);
}

