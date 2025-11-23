using UniThesis.Domain.Common;

namespace UniThesis.Domain.Ideas;

public class IdeiaDePesquisa : Entity
{
    private readonly List<Avaliacao> _avaliacoes = new();

    public Guid AlunoId { get; private set; }
    public string Titulo { get; private set; } = null!;
    public string Resumo { get; private set; } = null!;
    public IdeiaStatusEnum Status { get; private set; } = IdeiaStatusEnum.Pendente;

    public IReadOnlyCollection<Avaliacao> Avaliacoes => _avaliacoes.AsReadOnly();

    private IdeiaDePesquisa() { }

    private IdeiaDePesquisa(Guid alunoId, string titulo, string resumo)
    {
        AlunoId = alunoId;
        Titulo = titulo;
        Resumo = resumo;
        Status = IdeiaStatusEnum.Pendente;
    }

    public static IdeiaDePesquisa Criar(Guid alunoId, string titulo, string resumo)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("Título obrigatório", nameof(titulo));

        return new IdeiaDePesquisa(alunoId, titulo, resumo);
    }
    public void AdicionarAvaliacao(Guid avaliadorId, int nota, string feedback)
    {
        if (nota is < 0 or > 10)
            throw new ArgumentOutOfRangeException(nameof(nota), "A nota deve estar entre 0 e 10.");

        var avaliacao = new Avaliacao(
            avaliadorId,
            nota,
            feedback
        );

        _avaliacoes.Add(avaliacao);
    }

    public void AdicionarAvaliacao(Avaliacao avaliacao)
    {
        _avaliacoes.Add(avaliacao);
    }

    public void AtualizarStatus(IdeiaStatusEnum novoStatus)
    {
        if (Status == IdeiaStatusEnum.Pendente)
        {
            Status = novoStatus;
        }
        else
        {
            throw new InvalidOperationException("Status já definido, simplificação do MVP.");
        }
    }
}
