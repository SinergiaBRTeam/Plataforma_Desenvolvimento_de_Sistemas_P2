using MediatR;
using UniThesis.Application.Projects.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Projects.Queries.ListarDocumentos;

public class ListarDocumentosProjetoQueryHandler
    : IRequestHandler<ListarDocumentosProjetoQuery, IEnumerable<DocumentoDto>>
{
    private readonly IUnitOfWork _uow;

    public ListarDocumentosProjetoQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<DocumentoDto>> Handle(
        ListarDocumentosProjetoQuery request,
        CancellationToken cancellationToken)
    {
        var projeto = await _uow.Projetos.ObterPorIdAsync(request.ProjetoId);
        if (projeto is null)
            throw new KeyNotFoundException("Projeto não encontrado.");

        return projeto.Documentos
            .OrderBy(d => d.Versao)
            .Select(d => new DocumentoDto
            {
                Id = d.Id,
                Versao = d.Versao,
                NomeArquivo = d.NomeArquivo,
                Path = d.Path,
                DataSubmissao = d.DataSubmissao
            });
    }
}
