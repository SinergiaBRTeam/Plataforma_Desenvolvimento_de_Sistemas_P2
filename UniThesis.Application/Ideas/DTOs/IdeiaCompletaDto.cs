using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.DTOs;

public class IdeiaCompletaDto
{
    public Guid Id { get; set; }
    public Guid AlunoId { get; set; }
    public string Titulo { get; set; } = null!;
    public string Resumo { get; set; } = null!;
    public IdeiaStatusEnum Status { get; set; }

    public IEnumerable<AvaliacaoDto> Avaliacoes { get; set; } = Enumerable.Empty<AvaliacaoDto>();
}

public class AvaliacaoDto
{
    public Guid AvaliadorId { get; set; }
    public int Nota { get; set; }
    public string Feedback { get; set; } = null!;
    public DateTime Data { get; set; }
}
