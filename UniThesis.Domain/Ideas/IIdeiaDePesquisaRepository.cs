namespace UniThesis.Domain.Ideas;

public interface IIdeiaDePesquisaRepository
{
    Task<IdeiaDePesquisa?> ObterPorIdAsync(Guid id);
    Task AdicionarAsync(IdeiaDePesquisa ideia);
    Task<IEnumerable<IdeiaDePesquisa>> BuscarPorStatusAsync(IdeiaStatusEnum status);
    Task<IEnumerable<IdeiaDePesquisa>> BuscarPorAlunoAsync(Guid alunoId);
    Task<IEnumerable<IdeiaDePesquisa>> BuscarPorProfessorAsync(Guid professorId);
    Task<IEnumerable<IdeiaDePesquisa>> ObterTodasAsync();
}
