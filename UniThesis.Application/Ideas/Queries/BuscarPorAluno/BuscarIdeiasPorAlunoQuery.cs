using MediatR;
using UniThesis.Application.Ideas.DTOs;

namespace UniThesis.Application.Ideas.Queries.BuscarPorAluno;

public class BuscarIdeiasPorAlunoQuery : IRequest<IEnumerable<IdeiaDto>>
{
    public Guid AlunoId { get; init; }

    public BuscarIdeiasPorAlunoQuery(Guid alunoId)
    {
        AlunoId = alunoId;
    }
}
