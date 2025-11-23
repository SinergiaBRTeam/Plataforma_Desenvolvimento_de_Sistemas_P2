namespace UniThesis.Domain.Users;

public interface IUserAccountRepository
{
    Task<UserAccount?> ObterPorUserNameAsync(string userName);
    Task AdicionarAsync(UserAccount user);
}
