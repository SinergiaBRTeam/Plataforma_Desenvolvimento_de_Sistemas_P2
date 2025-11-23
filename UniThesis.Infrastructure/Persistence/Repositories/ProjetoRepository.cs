using Microsoft.EntityFrameworkCore;
using UniThesis.Domain.Projects;

namespace UniThesis.Infrastructure.Persistence.Repositories;

public class ProjetoRepository : IProjetoRepository
{
    private readonly UniThesisDbContext _context;

    public ProjetoRepository(UniThesisDbContext context)
    {
        _context = context;
    }

    public async Task<Projeto?> ObterPorIdAsync(Guid id)
    {
        return await _context.Projetos
            .Include(p => p.Documentos)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Projeto?> ObterPorIdeiaIdAsync(Guid ideiaId)
    {
        return await _context.Projetos
            .Include(p => p.Documentos)
            .FirstOrDefaultAsync(p => p.IdeiaId == ideiaId);
    }

    public async Task AdicionarAsync(Projeto projeto)
    {
        await _context.Projetos.AddAsync(projeto);
    }

    public async Task<IEnumerable<Projeto>> ObterTodosAsync()
    {
        return await _context.Projetos
            .Include(p => p.Documentos)
            .ToListAsync();
    }
}
