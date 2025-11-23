using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Ideas.Queries.BuscarPorProfessor;

public class BuscarIdeiasPorProfessorQueryHandler
    : IRequestHandler<BuscarIdeiasPorProfessorQuery, IEnumerable<IdeiaDto>>
{
    private readonly IUnitOfWork _uow;

    public BuscarIdeiasPorProfessorQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<IdeiaDto>> Handle(
        BuscarIdeiasPorProfessorQuery request,
        CancellationToken cancellationToken)
    {
        var ideias = await _uow.Ideias.BuscarPorProfessorAsync(request.ProfessorId);

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
