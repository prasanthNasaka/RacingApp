namespace infinitemoto.BusinessServices
{
    public interface IJwtService
    {
       string GenerateToken (string username);
    }
}
