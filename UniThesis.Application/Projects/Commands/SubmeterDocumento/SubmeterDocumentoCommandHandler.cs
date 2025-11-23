using MediatR;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Projects.Commands.SubmeterDocumento;

public class SubmeterDocumentoCommandHandler : IRequestHandler<SubmeterDocumentoCommand>
{
    private readonly IUnitOfWork _uow;

    public SubmeterDocumentoCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(SubmeterDocumentoCommand request, CancellationToken cancellationToken)
    {
        var projeto = await _uow.Projetos.ObterPorIdAsync(request.ProjetoId);
        if (projeto is null)
            throw new KeyNotFoundException("Projeto não encontrado.");

        projeto.SubmeterDocumento(request.NomeArquivo, request.Path);

        await _uow.CompleteAsync(cancellationToken);
    }
}
