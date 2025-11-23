using MediatR;

namespace UniThesis.Application.Projects.Commands.SubmeterDocumento;

public record SubmeterDocumentoCommand(
    Guid ProjetoId,
    string NomeArquivo,
    string Path
) : IRequest;
