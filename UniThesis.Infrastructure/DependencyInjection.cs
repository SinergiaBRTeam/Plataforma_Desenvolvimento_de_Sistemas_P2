using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniThesis.Application.Abstractions;
using UniThesis.Domain.Common;
using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;
using UniThesis.Domain.Users;
using UniThesis.Infrastructure.Auth;
using UniThesis.Infrastructure.Persistence;
using UniThesis.Infrastructure.Persistence.Repositories;

namespace UniThesis.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UniThesisDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IIdeiaDePesquisaRepository, IdeiaDePesquisaRepository>();
        services.AddScoped<IProjetoRepository, ProjetoRepository>();
        services.AddScoped<IUserAccountRepository, UserAccountRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IJwtTokenService, JwtTokenService>();

        return services;
    }
}
