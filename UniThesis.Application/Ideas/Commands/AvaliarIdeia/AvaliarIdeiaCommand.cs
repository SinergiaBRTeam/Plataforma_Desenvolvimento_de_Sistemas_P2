using MediatR;

namespace UniThesis.Application.Ideas.Commands.AvaliarIdeia;

public record AvaliarIdeiaCommand(
    Guid IdeiaId,
    Guid ProfessorId,
    int Nota,
    string Feedback
) : IRequest;
