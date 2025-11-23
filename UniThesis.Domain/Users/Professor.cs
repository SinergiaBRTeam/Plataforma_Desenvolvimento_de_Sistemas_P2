namespace UniThesis.Domain.Users;

public class Professor : Pessoa
{
    public string AreaAtuacao { get; private set; } = null!;

    private Professor() { }

    private Professor(string nome, string email, string areaAtuacao)
        : base(nome, email, UserRole.Professor)
    {
        AreaAtuacao = areaAtuacao;
    }

    public static Professor Criar(string nome, string email, string areaAtuacao)
        => new(nome, email, areaAtuacao);
}
