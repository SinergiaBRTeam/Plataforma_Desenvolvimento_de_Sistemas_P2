using Microsoft.EntityFrameworkCore;
using UniThesis.Domain.Ideas;
using UniThesis.Domain.Projects;
using UniThesis.Domain.Users;

namespace UniThesis.Infrastructure.Persistence;

public static class UniThesisDbSeeder
{
    public static async Task SeedAsync(UniThesisDbContext context)
    {
        if (await context.Ideias.AnyAsync())
            return;

        var coordenador = UserAccount.Criar("coord1", "Senha123!", UserRole.Coordenador);
        var professor = UserAccount.Criar("prof1", "Senha123!", UserRole.Professor);
        var aluno = UserAccount.Criar("aluno1", "Senha123!", UserRole.Aluno);

        await context.UserAccounts.AddRangeAsync(coordenador, professor, aluno);
        await context.SaveChangesAsync();

        var ideia = IdeiaDePesquisa.Criar(
            aluno.Id,
            "Detecção de neutrinos estéreis em feixes de neutrinos de alta energia",
            """
            Este projeto investiga a possível existência de neutrinos estéreis
            por meio da análise de eventos em um experimento de feixe de neutrinos
            de longa distância, utilizando técnicas de reconstrução de vértices
            e classificação de eventos com algoritmos de aprendizado de máquina.
            """
        );

        ideia.AdicionarAvaliacao(
            professor.Id,
            nota: 9,
            feedback: "Tema atual na física de partículas, boa justificativa fenomenológica e viabilidade experimental."
        );

        ideia.AtualizarStatus(IdeiaStatusEnum.Aceita);

        await context.Ideias.AddAsync(ideia);
        await context.SaveChangesAsync();

        var projeto = Projeto.Criar(ideia.Id);
        projeto.AssociarOrientador(professor.Id);

        projeto.SubmeterDocumento(
            nomeArquivo: "proposta_inicial_neutrinos_esteris.pdf",
            path: "docs/projetos/neutrinos_esteris/proposta_inicial_neutrinos_esteris.pdf"
        );

        await context.Projetos.AddAsync(projeto);
        await context.SaveChangesAsync();
    }
}
