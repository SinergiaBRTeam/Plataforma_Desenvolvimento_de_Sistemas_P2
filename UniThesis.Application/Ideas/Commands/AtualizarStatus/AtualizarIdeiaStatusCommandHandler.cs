using MediatR;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Commands.AtualizarStatus;

public class AtualizarIdeiaStatusCommandHandler : IRequestHandler<AtualizarIdeiaStatusCommand>
{
    private readonly IUnitOfWork _uow;

    public AtualizarIdeiaStatusCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(AtualizarIdeiaStatusCommand request, CancellationToken cancellationToken)
    {
        var ideia = await _uow.Ideias.ObterPorIdAsync(request.IdeiaId);

        if (ideia is null)
            throw new KeyNotFoundException("Ideia não encontrada.");

        ideia.AtualizarStatus(request.NovoStatus);

        // (Opcional futuro: disparar DomainEvent quando status == Aceita)

        await _uow.CompleteAsync(cancellationToken);
    }
}
