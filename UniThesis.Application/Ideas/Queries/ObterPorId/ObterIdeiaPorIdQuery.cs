using MediatR;
using UniThesis.Application.Ideas.DTOs;

namespace UniThesis.Application.Ideas.Queries.ObterPorId;

public class ObterIdeiaPorIdQuery : IRequest<IdeiaCompletaDto?>
{
    public Guid Id { get; }

    public ObterIdeiaPorIdQuery(Guid id)
    {
        Id = id;
    }
}
