namespace UniThesis.Domain.Projects;

public interface IProjetoRepository
{
    Task<Projeto?> ObterPorIdAsync(Guid id);
    Task<Projeto?> ObterPorIdeiaIdAsync(Guid ideiaId);
    Task AdicionarAsync(Projeto projeto);
    Task<IEnumerable<Projeto>> ObterTodosAsync();
}
