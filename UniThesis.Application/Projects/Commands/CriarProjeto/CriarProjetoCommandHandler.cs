using MediatR;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;

namespace UniThesis.Application.Projects.Commands.CriarProjeto;

public class CriarProjetoCommandHandler : IRequestHandler<CriarProjetoCommand, Guid>
{
    private readonly IUnitOfWork _uow;

    public CriarProjetoCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(CriarProjetoCommand request, CancellationToken cancellationToken)
    {
        var ideia = await _uow.Ideias.ObterPorIdAsync(request.IdeiaId);
        if (ideia is null)
            throw new KeyNotFoundException("Ideia não encontrada.");

        if (ideia.Status != IdeiaStatusEnum.Aceita)
            throw new InvalidOperationException("Só é possível criar projeto de ideia aceita.");

        var projetoExistente = await _uow.Projetos.ObterPorIdeiaIdAsync(request.IdeiaId);
        if (projetoExistente is not null)
            throw new InvalidOperationException("Projeto já existe para esta ideia.");

        var projeto = Projeto.Criar(request.IdeiaId);

        await _uow.Projetos.AdicionarAsync(projeto);
        await _uow.CompleteAsync(cancellationToken);

        return projeto.Id;
    }
}
