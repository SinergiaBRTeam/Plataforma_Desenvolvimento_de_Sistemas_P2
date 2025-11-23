namespace UniThesis.Application.Projects.DTOs;

public class ProjetoCompletoDto
{
    public Guid Id { get; set; }
    public Guid IdeiaId { get; set; }
    public Guid? ProfessorId { get; set; }

    public IEnumerable<DocumentoDto> Documentos { get; set; } = Enumerable.Empty<DocumentoDto>();
}
