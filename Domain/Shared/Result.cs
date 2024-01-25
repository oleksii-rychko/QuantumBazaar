namespace Domain.Shared;

public class Result
{
    private Result(bool success, Error error)
    {
        if (success && error == Error.None || !success && error != Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSuccess = success;
        Error = error;
    }

    public bool IsSuccess { get; private set; }
    
    public Error Error { get; private set; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);
}