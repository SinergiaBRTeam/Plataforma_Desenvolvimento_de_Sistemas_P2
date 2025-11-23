using MediatR;
using UniThesis.Application.Ideas.DTOs;

namespace UniThesis.Application.Ideas.Queries.BuscarPorProfessor;

public class BuscarIdeiasPorProfessorQuery : IRequest<IEnumerable<IdeiaDto>>
{
    public Guid ProfessorId { get; init; }

    public BuscarIdeiasPorProfessorQuery(Guid professorId)
    {
        ProfessorId = professorId;
    }
}