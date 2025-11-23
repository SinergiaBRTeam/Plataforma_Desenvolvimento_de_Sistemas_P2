using MediatR;
using UniThesis.Application.Ideas.DTOs;

namespace UniThesis.Application.Ideas.Queries.ListarTodas;

public class ListarTodasIdeiasQuery : IRequest<IEnumerable<IdeiaDto>>
{
}
