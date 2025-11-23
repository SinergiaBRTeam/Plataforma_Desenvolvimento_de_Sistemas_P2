namespace UniThesis.Application.Projects.DTOs;

public class DocumentoDto
{
    public Guid Id { get; set; }
    public int Versao { get; set; }
    public string NomeArquivo { get; set; } = null!;
    public string Path { get; set; } = null!;
    public DateTime DataSubmissao { get; set; }
}
