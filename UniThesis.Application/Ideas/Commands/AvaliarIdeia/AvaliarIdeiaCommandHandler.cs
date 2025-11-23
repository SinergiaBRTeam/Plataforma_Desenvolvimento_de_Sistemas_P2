using MediatR;
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
        var ideia = await _uow.Ideias.ObterPorIdAsync(request.IdeiaId);

        if (ideia is null)
            throw new KeyNotFoundException("Ideia não encontrada");

        var avaliacao = Avaliacao.Criar(request.ProfessorId, request.Nota, request.Feedback);
        ideia.AdicionarAvaliacao(avaliacao);

        await _uow.CompleteAsync(cancellationToken);
    }
}
