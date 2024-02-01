namespace Domain.Entities;

public class RecoverPassword
{
    public int UserId { get; set; }
    
    public int RecoveryCode { get; set; }
    
    public bool IsUsed { get; set; }
}