using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;
using UniThesis.Domain.Users;

namespace UniThesis.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly UniThesisDbContext _context;

    public IIdeiaDePesquisaRepository Ideias { get; }
    public IProjetoRepository Projetos { get; }
    public IUserAccountRepository Users { get; }

    public UnitOfWork(
        UniThesisDbContext context,
        IIdeiaDePesquisaRepository ideias,
        IProjetoRepository projetos,
        IUserAccountRepository users)
    {
        _context = context;
        Ideias = ideias;
        Projetos = projetos;
        Users = users;
    }

    public Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        => _context.SaveChangesAsync(cancellationToken);
}
