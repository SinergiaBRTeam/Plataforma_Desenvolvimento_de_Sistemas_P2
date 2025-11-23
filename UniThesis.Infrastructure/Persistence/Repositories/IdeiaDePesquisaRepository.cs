using Microsoft.EntityFrameworkCore;
using UniThesis.Domain.Ideas;

namespace UniThesis.Infrastructure.Persistence.Repositories;

public class IdeiaDePesquisaRepository : IIdeiaDePesquisaRepository
{
    private readonly UniThesisDbContext _context;

    public IdeiaDePesquisaRepository(UniThesisDbContext context)
    {
        _context = context;
    }

    public async Task<IdeiaDePesquisa?> ObterPorIdAsync(Guid id)
    {
        return await _context.Ideias
            .Include(i => i.Avaliacoes)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task AdicionarAsync(IdeiaDePesquisa ideia)
    {
        await _context.Ideias.AddAsync(ideia);
    }

    public async Task<IEnumerable<IdeiaDePesquisa>> BuscarPorStatusAsync(IdeiaStatusEnum status)
    {
        return await _context.Ideias
            .Where(i => i.Status == status)
            .ToListAsync();
    }

    public async Task<IEnumerable<IdeiaDePesquisa>> BuscarPorAlunoAsync(Guid alunoId)
    {
        return await _context.Ideias
            .Where(i => i.AlunoId == alunoId)
            .ToListAsync();
    }

    public async Task<IEnumerable<IdeiaDePesquisa>> BuscarPorProfessorAsync(Guid professorId)
    {
        return await _context.Ideias
            .Where(i => i.Avaliacoes.Any(a => a.ProfessorId == professorId))
            .ToListAsync();
    }

    public async Task<IEnumerable<IdeiaDePesquisa>> ObterTodasAsync()
    {
        return await _context.Ideias
            .Include(i => i.Avaliacoes)
            .ToListAsync();
    }
}
