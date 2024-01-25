﻿using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string Middlename { get; set; } = String.Empty;
    
    public string Username { get; set; } = String.Empty;
    
    public HashedPassword Password { get; set; }

    public Role Role { get; set; } = Role.User;
}   