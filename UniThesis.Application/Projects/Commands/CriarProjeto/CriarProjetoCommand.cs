using MediatR;

namespace UniThesis.Application.Projects.Commands.CriarProjeto;

public record CriarProjetoCommand(Guid IdeiaId) : IRequest<Guid>;
