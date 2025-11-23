namespace UniThesis.Application.Abstractions;

public interface IJwtTokenService
{
    string GerarToken(Guid userId, string email, string role);
}
