namespace UniThesis.Application.Projects.DTOs;

public class ProjetoDto
{
    public Guid Id { get; set; }
    public Guid IdeiaId { get; set; }
    public Guid? ProfessorId { get; set; }
    public int QuantidadeDocumentos { get; set; }
}
