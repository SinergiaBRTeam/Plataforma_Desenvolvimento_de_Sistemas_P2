using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Ideas.Queries.ListarTodas;

public class ListarTodasIdeiasQueryHandler
    : IRequestHandler<ListarTodasIdeiasQuery, IEnumerable<IdeiaDto>>
{
    private readonly IUnitOfWork _uow;

    public ListarTodasIdeiasQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<IdeiaDto>> Handle(
        ListarTodasIdeiasQuery request,
        CancellationToken cancellationToken)
    {
        var ideias = await _uow.Ideias.ObterTodasAsync();

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
