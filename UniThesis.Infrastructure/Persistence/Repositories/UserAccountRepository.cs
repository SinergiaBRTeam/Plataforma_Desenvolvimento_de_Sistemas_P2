using Microsoft.EntityFrameworkCore;
using UniThesis.Domain.Users;

namespace UniThesis.Infrastructure.Persistence.Repositories;

public class UserAccountRepository : IUserAccountRepository
{
    private readonly UniThesisDbContext _context;

    public UserAccountRepository(UniThesisDbContext context)
    {
        _context = context;
    }

    public async Task<UserAccount?> ObterPorUserNameAsync(string userName)
    {
        return await _context.UserAccounts
            .FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task AdicionarAsync(UserAccount user)
    {
        await _context.UserAccounts.AddAsync(user);
    }

    public async Task<IEnumerable<UserAccount>> BuscarTodosAsync()
    {
        return await _context.UserAccounts
            .AsNoTracking()
            .ToListAsync();
    }
}
