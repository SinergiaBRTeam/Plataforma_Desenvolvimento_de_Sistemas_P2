namespace UniThesis.Domain.Users;

public class Aluno : Pessoa
{
    public string Matricula { get; private set; } = null!;

    private Aluno() { } 

    private Aluno(string nome, string email, string matricula)
        : base(nome, email, UserRole.Aluno)
    {
        Matricula = matricula;
    }

    public static Aluno Criar(string nome, string email, string matricula)
    {
        if (string.IsNullOrWhiteSpace(matricula))
            throw new ArgumentException("Matrícula obrigatória", nameof(matricula));

        return new Aluno(nome, email, matricula);
    }
}
