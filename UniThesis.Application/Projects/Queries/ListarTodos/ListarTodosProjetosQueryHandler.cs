// UniThesis.Application/Projects/Queries/ListarTodos/ListarTodosProjetosQueryHandler.cs
using MediatR;
using UniThesis.Application.Projects.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Projects.Queries.ListarTodos;

public class ListarTodosProjetosQueryHandler
    : IRequestHandler<ListarTodosProjetosQuery, IEnumerable<ProjetoDto>>
{
    private readonly IUnitOfWork _uow;

    public ListarTodosProjetosQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<ProjetoDto>> Handle(
        ListarTodosProjetosQuery request,
        CancellationToken cancellationToken)
    {
        var projetos = await _uow.Projetos.ObterTodosAsync();

        return projetos.Select(p => new ProjetoDto
        {
            Id = p.Id,
            IdeiaId = p.IdeiaId,
            ProfessorId = p.OrientadorId,
            QuantidadeDocumentos = p.Documentos.Count
        });
    }
}
