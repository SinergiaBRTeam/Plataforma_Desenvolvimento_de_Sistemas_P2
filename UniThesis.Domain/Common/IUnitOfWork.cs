using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;
using UniThesis.Domain.Users;

namespace UniThesis.Domain.Common;

public interface IUnitOfWork
{
    IIdeiaDePesquisaRepository Ideias { get; }
    IProjetoRepository Projetos { get; }
    IUserAccountRepository Users { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
}
