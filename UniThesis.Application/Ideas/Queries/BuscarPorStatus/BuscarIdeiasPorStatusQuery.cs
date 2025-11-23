using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Queries.BuscarPorStatus;

public record BuscarIdeiasPorStatusQuery(IdeiaStatusEnum Status)
    : IRequest<IEnumerable<IdeiaDto>>;
