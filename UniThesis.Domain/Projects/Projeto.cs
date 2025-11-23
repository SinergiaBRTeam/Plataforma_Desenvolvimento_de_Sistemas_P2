using UniThesis.Domain.Common;

namespace UniThesis.Domain.Projects;

public class Projeto : Entity
{
    private readonly List<DocumentoVersionado> _documentos = new();

    public Guid IdeiaId { get; private set; }
    public Guid? OrientadorId { get; private set; }
    public ProjetoStatusEnum Status { get; private set; } = ProjetoStatusEnum.EmAndamento;
    public IReadOnlyCollection<DocumentoVersionado> Documentos => _documentos.AsReadOnly();

    private Projeto() { }

    private Projeto(Guid ideiaId)
    {
        IdeiaId = ideiaId;
    }

    public static Projeto Criar(Guid ideiaId)
    {
        if (ideiaId == Guid.Empty)
            throw new ArgumentException("IdeiaId inválido", nameof(ideiaId));

        return new Projeto(ideiaId);
    }

    public void AssociarOrientador(Guid professorId)
    {
        if (professorId == Guid.Empty)
            throw new ArgumentException("ProfessorId inválido", nameof(professorId));

        OrientadorId = professorId;
    }

    public DocumentoVersionado SubmeterDocumento(string nomeArquivo, string path)
    {
        var novaVersao = _documentos.Count == 0
            ? 1
            : _documentos.Max(d => d.Versao) + 1;

        var doc = DocumentoVersionado.Criar(novaVersao, nomeArquivo, path);
        _documentos.Add(doc);

        return doc;
    }

    public void AlterarStatus(ProjetoStatusEnum novoStatus)
    {
        Status = novoStatus;
    }
}
