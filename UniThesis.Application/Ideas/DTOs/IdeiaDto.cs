using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.DTOs;

public class IdeiaDto
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public IdeiaStatusEnum Status { get; set; }
}
