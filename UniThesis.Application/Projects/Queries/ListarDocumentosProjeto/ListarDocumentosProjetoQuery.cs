using MediatR;
using UniThesis.Application.Projects.DTOs;

namespace UniThesis.Application.Projects.Queries.ListarDocumentosProjeto;

public class ListarDocumentosProjetoQuery : IRequest<IEnumerable<DocumentoDto>>
{
    public Guid ProjetoId { get; init; }

    public ListarDocumentosProjetoQuery(Guid projetoId)
    {
        ProjetoId = projetoId;
    }
}
