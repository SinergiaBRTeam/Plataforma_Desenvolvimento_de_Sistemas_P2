using MediatR;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Queries.ObterPorId;

public class ObterIdeiaPorIdQueryHandler
    : IRequestHandler<ObterIdeiaPorIdQuery, IdeiaCompletaDto?>
{
    private readonly IUnitOfWork _uow;

    public ObterIdeiaPorIdQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IdeiaCompletaDto?> Handle(
        ObterIdeiaPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var ideia = await _uow.Ideias.ObterPorIdAsync(request.Id);

        if (ideia is null)
            return null;

        return new IdeiaCompletaDto
        {
            Id = ideia.Id,
            AlunoId = ideia.AlunoId,
            Titulo = ideia.Titulo,
            Resumo = ideia.Resumo,
            Status = ideia.Status, 

            Avaliacoes = ideia.Avaliacoes.Select(a => new AvaliacaoDto
            {
                AvaliadorId = a.ProfessorId,
                Nota = a.Nota,
                Feedback = a.Feedback,
                Data = a.DataAvaliacao
            })
        };
    }
}
