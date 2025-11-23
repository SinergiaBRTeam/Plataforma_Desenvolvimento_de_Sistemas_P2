using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Ideas.Queries.BuscarPorStatus;

public class BuscarIdeiasPorStatusQueryHandler
    : IRequestHandler<BuscarIdeiasPorStatusQuery, IEnumerable<IdeiaDto>>
{
    private readonly IUnitOfWork _uow;

    public BuscarIdeiasPorStatusQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<IdeiaDto>> Handle(
        BuscarIdeiasPorStatusQuery request,
        CancellationToken cancellationToken)
    {
        var ideias = await _uow.Ideias.BuscarPorStatusAsync(request.Status);

        return ideias.Select(i => new IdeiaDto
        {
            Id = i.Id,
            AlunoId = i.AlunoId,
            Titulo = i.Titulo,
            Resumo = i.Resumo,
            Status = i.Status
        });
    }
}
