namespace Domain.Shared;

public sealed record Error(string Code, string Description)
{
    public static Error None => new(String.Empty, String.Empty);
    
    public static Error NoRowsAffected => 
        new("NoRowsAffected", "No rows were affected while executing database query.");
    
    public static Error NotFound => new("NotFound", "Entity not found.");
}