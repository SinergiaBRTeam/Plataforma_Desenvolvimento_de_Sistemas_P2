using MediatR;

namespace UniThesis.Application.Ideas.Commands.SubmeterIdeia;

public record SubmeterIdeiaCommand(
    Guid AlunoId,
    string Titulo,
    string Resumo
) : IRequest<Guid>;
