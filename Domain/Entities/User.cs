using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = String.Empty;
    
    public string Surname { get; set; } = String.Empty;
    
    public string? Middlename { get; set; }
    
    public string Username { get; set; } = String.Empty;
    
    public HashedPassword Password { get; set; }

    public Role Role { get; set; } = Role.User;
}   