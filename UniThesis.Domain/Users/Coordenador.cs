namespace UniThesis.Domain.Users;

public class Coordenador : Pessoa
{
    private Coordenador() { }

    private Coordenador(string nome, string email)
        : base(nome, email, UserRole.Coordenador)
    {
    }

    public static Coordenador Criar(string nome, string email)
        => new(nome, email);
}
