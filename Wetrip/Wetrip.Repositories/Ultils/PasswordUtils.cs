using BCrypt.Net;

namespace Wetrip.Services.Ultils;

public class PasswordUtils
{
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password, HashType.SHA256);
    }
    public static bool VerifyPassword(string password, string hashPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword, HashType.SHA256);
    }
}