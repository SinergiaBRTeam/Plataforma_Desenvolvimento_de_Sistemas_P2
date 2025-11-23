using MediatR;
using UniThesis.Application.Projects.DTOs;

namespace UniThesis.Application.Projects.Queries.ListarTodos;

public class ListarTodosProjetosQuery : IRequest<IEnumerable<ProjetoDto>>
{
}
