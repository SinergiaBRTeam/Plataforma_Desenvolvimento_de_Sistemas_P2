using MediatR;
using UniThesis.Domain.Ideas;

namespace UniThesis.Application.Ideas.Commands.AtualizarStatus;

public record AtualizarIdeiaStatusCommand(
    Guid IdeiaId,
    IdeiaStatusEnum NovoStatus
) : IRequest;
