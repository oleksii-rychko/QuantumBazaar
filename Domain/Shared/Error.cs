namespace Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static Error None => new(String.Empty, String.Empty);
}