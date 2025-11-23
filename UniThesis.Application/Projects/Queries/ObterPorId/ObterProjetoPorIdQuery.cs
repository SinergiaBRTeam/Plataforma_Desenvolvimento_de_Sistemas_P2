using MediatR;
using UniThesis.Application.Projects.DTOs;

namespace UniThesis.Application.Projects.Queries.ObterPorId;

public class ObterProjetoPorIdQuery : IRequest<ProjetoCompletoDto?>
{
    public Guid Id { get; }

    public ObterProjetoPorIdQuery(Guid id)
    {
        Id = id;
    }
}
