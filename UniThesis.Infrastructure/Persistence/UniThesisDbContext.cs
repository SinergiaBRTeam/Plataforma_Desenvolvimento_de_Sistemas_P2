using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;
using UniThesis.Domain.Users;

namespace UniThesis.Infrastructure.Persistence;

public class UniThesisDbContext : DbContext
{
    public UniThesisDbContext(DbContextOptions<UniThesisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Professor> Professores => Set<Professor>();
    public DbSet<Coordenador> Coordenadores => Set<Coordenador>();
    public DbSet<IdeiaDePesquisa> Ideias => Set<IdeiaDePesquisa>();
    public DbSet<Projeto> Projetos => Set<Projeto>();
    public DbSet<UserAccount> UserAccounts => Set<UserAccount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Herança Pessoa
        modelBuilder.Entity<Pessoa>()
            .HasDiscriminator<string>("TipoPessoa")
            .HasValue<Aluno>("Aluno")
            .HasValue<Professor>("Professor")
            .HasValue<Coordenador>("Coordenador");

        // IdeiaDePesquisa
        modelBuilder.Entity<IdeiaDePesquisa>(builder =>
        {
            builder.OwnsMany(i => i.Avaliacoes, av =>
            {
                av.WithOwner().HasForeignKey("IdeiaId");
                av.Property<Guid>("Id");
                av.HasKey("Id");
            });
        });

        modelBuilder.Entity<Projeto>(builder =>
        {
            builder.OwnsMany(p => p.Documentos, docs =>
            {
                docs.WithOwner().HasForeignKey("ProjetoId");
                docs.Property<Guid>("Id");
                docs.HasKey("Id");
            });
        });

        base.OnModelCreating(modelBuilder);
    }
}
