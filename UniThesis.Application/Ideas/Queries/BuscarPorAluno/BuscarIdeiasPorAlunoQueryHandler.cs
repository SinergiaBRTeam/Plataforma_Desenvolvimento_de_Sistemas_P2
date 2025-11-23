using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Ideas.Queries.BuscarPorAluno;

public class BuscarIdeiasPorAlunoQueryHandler
    : IRequestHandler<BuscarIdeiasPorAlunoQuery, IEnumerable<IdeiaDto>>
{
    private readonly IUnitOfWork _uow;

    public BuscarIdeiasPorAlunoQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<IdeiaDto>> Handle(
        BuscarIdeiasPorAlunoQuery request,
        CancellationToken cancellationToken)
    {
        var ideias = await _uow.Ideias.BuscarPorAlunoAsync(request.AlunoId);

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
