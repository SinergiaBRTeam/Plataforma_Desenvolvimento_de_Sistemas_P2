using MediatR;

namespace UniThesis.Application.Projects.Commands.AssociarOrientador;
public record AssociarOrientadorCommand(
    Guid ProjetoId,
    Guid ProfessorId
) : IRequest;
