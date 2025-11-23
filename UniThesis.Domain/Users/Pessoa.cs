using UniThesis.Domain.Common;
using UniThesis.Domain.Users;

public abstract class Pessoa : Entity
{
    public string Nome { get; protected set; } = null!;
    public string Email { get; protected set; } = null!;
    public UserRole Role { get; protected set; }

    protected Pessoa() { }

    protected Pessoa(string nome, string email, UserRole role)
    {
        Nome = nome;
        Email = email;
        Role = role;
    }
}
