namespace TestMicro.UserManagement.Common;

public class JwtConfig
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public int Expire { get; set; } = 30;
}