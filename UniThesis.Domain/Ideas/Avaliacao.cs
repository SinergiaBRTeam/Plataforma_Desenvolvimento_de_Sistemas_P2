namespace UniThesis.Domain.Ideas;

public class Avaliacao
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid ProfessorId { get; private set; }
    public int Nota { get; private set; }
    public string Feedback { get; private set; } = null!;
    public DateTime DataAvaliacao { get; private set; }

    private Avaliacao() { }

    internal Avaliacao(Guid professorId, int nota, string feedback)
    {
        ProfessorId = professorId;
        Nota = nota;
        Feedback = feedback;
        DataAvaliacao = DateTime.UtcNow;
    }

    public static Avaliacao Criar(Guid professorId, int nota, string feedback)
    {
        if (nota < 0 || nota > 10)
            throw new ArgumentException("Nota deve ser entre 0 e 10", nameof(nota));

        return new Avaliacao(professorId, nota, feedback);
    }
}
