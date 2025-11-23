using System.Security.Cryptography;
using UniThesis.Domain.Common;

namespace UniThesis.Domain.Users;

public class UserAccount : Entity
{
    public string UserName { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string PasswordSalt { get; private set; } = null!;
    public UserRole Role { get; private set; }

    private UserAccount() { } // EF

    private UserAccount(string userName, string passwordHash, string passwordSalt, UserRole role)
    {
        UserName = userName;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        Role = role;
    }

    public static UserAccount Criar(string userName, string password, UserRole role)
    {
        if (string.IsNullOrWhiteSpace(userName))
            throw new ArgumentException("UserName obrigatório", nameof(userName));

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password obrigatório", nameof(password));

        var salt = GerarSalt();
        var hash = HashPassword(password, salt);

        return new UserAccount(userName, hash, salt, role);
    }

    public bool VerificarSenha(string password)
    {
        var hash = HashPassword(password, PasswordSalt);
        return hash == PasswordHash;
    }

    private static string GerarSalt()
    {
        var bytes = new byte[16];
        RandomNumberGenerator.Fill(bytes);
        return Convert.ToBase64String(bytes);
    }

    private static string HashPassword(string password, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            saltBytes,
            100_000,
            HashAlgorithmName.SHA256);

        var hash = pbkdf2.GetBytes(32);
        return Convert.ToBase64String(hash);
    }
}
