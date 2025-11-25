using MediatR;
using Microsoft.EntityFrameworkCore;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Commands.AvaliarIdeia;

public class AvaliarIdeiaCommandHandler : IRequestHandler<AvaliarIdeiaCommand>
{
    private readonly IUnitOfWork _uow;

    public AvaliarIdeiaCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(AvaliarIdeiaCommand request, CancellationToken cancellationToken)
    {
        var ideia = await _uow.Ideias.ObterPorIdAsync(request.IdeiaId, cancellationToken);

        if (ideia is null)
            throw new KeyNotFoundException("Ideia não encontrada");

        if (ideia.Avaliacoes.Any(a => a.ProfessorId == request.ProfessorId))
            throw new InvalidOperationException("O professor já avaliou esta ideia.");

        if (string.IsNullOrWhiteSpace(request.Feedback))
            throw new ArgumentException("Feedback obrigatório", nameof(request.Feedback));

        var avaliacao = Avaliacao.Criar(request.ProfessorId, request.Nota, request.Feedback);
        ideia.AdicionarAvaliacao(avaliacao);

        try
        {
            await _uow.CompleteAsync(cancellationToken);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new InvalidOperationException(
                "Não foi possível salvar a avaliação porque a ideia foi alterada ou removida. Tente novamente.",
                ex);
        }
    }
}
