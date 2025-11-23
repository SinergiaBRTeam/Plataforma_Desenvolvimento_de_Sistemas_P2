using MediatR;
using UniThesis.Application.Projects.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Projects.Queries.ObterPorId;

public class ObterProjetoPorIdQueryHandler
    : IRequestHandler<ObterProjetoPorIdQuery, ProjetoCompletoDto?>
{
    private readonly IUnitOfWork _uow;

    public ObterProjetoPorIdQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ProjetoCompletoDto?> Handle(
        ObterProjetoPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var projeto = await _uow.Projetos.ObterPorIdAsync(request.Id);

        if (projeto is null)
            return null;

        return new ProjetoCompletoDto
        {
            Id = projeto.Id,
            IdeiaId = projeto.IdeiaId,
            ProfessorId = projeto.OrientadorId,
            Documentos = projeto.Documentos
                .OrderBy(d => d.Versao)
                .Select(d => new DocumentoDto
                {
                    Id = d.Id,
                    NomeArquivo = d.NomeArquivo,
                    Path = d.Path,
                    Versao = d.Versao,
                    DataSubmissao = d.DataSubmissao
                })
        };
    }
}
