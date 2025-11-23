namespace UniThesis.Domain.Projects;

public class DocumentoVersionado
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public int Versao { get; private set; }
    public string NomeArquivo { get; private set; } = null!;
    public string Path { get; private set; } = null!;
    public DateTime DataSubmissao { get; private set; }

    private DocumentoVersionado() { }

    private DocumentoVersionado(int versao, string nomeArquivo, string path)
    {
        Versao = versao;
        NomeArquivo = nomeArquivo;
        Path = path;
        DataSubmissao = DateTime.UtcNow;
    }

    public static DocumentoVersionado Criar(int versao, string nomeArquivo, string path)
        => new(versao, nomeArquivo, path);
}
