using MediatR;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Commands.SubmeterIdeia;

public class SubmeterIdeiaCommandHandler
    : IRequestHandler<SubmeterIdeiaCommand, Guid>
{
    private readonly IUnitOfWork _uow;

    public SubmeterIdeiaCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(SubmeterIdeiaCommand request, CancellationToken cancellationToken)
    {
        var ideia = IdeiaDePesquisa.Criar(request.AlunoId, request.Titulo, request.Resumo);

        await _uow.Ideias.AdicionarAsync(ideia);
        await _uow.CompleteAsync(cancellationToken);

        return ideia.Id;
    }
}
