using MediatR;
using UniThesis.Application.Projects.DTOs;

namespace UniThesis.Application.Projects.Queries.ListarDocumentos;

public record ListarDocumentosProjetoQuery(Guid ProjetoId)
    : IRequest<IEnumerable<DocumentoDto>>;
