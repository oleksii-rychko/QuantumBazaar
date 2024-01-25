namespace Domain.ValueObjects;

public record HashedPassword
{
    public string Password { get; private set; }
    public string Salt { get; private set; }

    private HashedPassword(string password, string salt)
    {
        Password = password;
        Salt = salt;
    }   
}