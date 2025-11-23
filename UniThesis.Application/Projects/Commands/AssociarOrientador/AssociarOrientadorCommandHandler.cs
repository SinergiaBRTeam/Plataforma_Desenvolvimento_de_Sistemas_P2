using MediatR;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Projects.Commands.AssociarOrientador;

public class AssociarOrientadorCommandHandler : IRequestHandler<AssociarOrientadorCommand>
{
    private readonly IUnitOfWork _uow;

    public AssociarOrientadorCommandHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task Handle(AssociarOrientadorCommand request, CancellationToken cancellationToken)
    {
        var projeto = await _uow.Projetos.ObterPorIdAsync(request.ProjetoId);
        if (projeto is null)
            throw new KeyNotFoundException("Projeto não encontrado.");

        projeto.AssociarOrientador(request.ProfessorId);

        await _uow.CompleteAsync(cancellationToken);
    }
}