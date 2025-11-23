using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniThesis.Application.Ideas.Commands.AtualizarStatus;
using UniThesis.Application.Ideas.Commands.AvaliarIdeia;
using UniThesis.Application.Ideas.Commands.SubmeterIdeia;
using UniThesis.Application.Ideas.DTOs;
using UniThesis.Application.Ideas.Queries.BuscarPorAluno;
using UniThesis.Application.Ideas.Queries.BuscarPorProfessor;
using UniThesis.Application.Ideas.Queries.BuscarPorStatus;
using UniThesis.Application.Ideas.Queries.ListarTodas;
using UniThesis.Application.Ideas.Queries.ObterPorId;
using UniThesis.Domain.Ideas;

namespace UniThesis.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IdeiasController : ControllerBase
{
    private readonly IMediator _mediator;

    public IdeiasController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Aluno")]
    public async Task<IActionResult> SubmeterIdeia([FromBody] SubmeterIdeiaCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, null);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var result = await _mediator.Send(new ObterIdeiaPorIdQuery(id));

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("{id:guid}/avaliacoes")]
    [Authorize(Roles = "Professor,Coordenador")]
    public async Task<IActionResult> Avaliar(Guid id, [FromBody] AvaliarIdeiaCommand command)
    {
        if (id != command.IdeiaId)
            return BadRequest("Id de rota difere do corpo.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPatch("{id:guid}/status")]
    [Authorize(Roles = "Professor,Coordenador")]
    public async Task<IActionResult> AtualizarStatus(Guid id, [FromBody] AtualizarIdeiaStatusCommand command)
    {
        if (id != command.IdeiaId)
            return BadRequest("Id de rota difere do corpo.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("status/{status}")]
    public async Task<IEnumerable<IdeiaDto>> BuscarPorStatus(IdeiaStatusEnum status)
        => await _mediator.Send(new BuscarIdeiasPorStatusQuery(status));

    [HttpGet("aluno/{alunoId:guid}")]
    public async Task<IEnumerable<IdeiaDto>> BuscarPorAluno(Guid alunoId)
        => await _mediator.Send(new BuscarIdeiasPorAlunoQuery(alunoId));

    [HttpGet("professor/{professorId:guid}")]
    public async Task<IEnumerable<IdeiaDto>> BuscarPorProfessor(Guid professorId)
        => await _mediator.Send(new BuscarIdeiasPorProfessorQuery(professorId));

    [HttpGet]
    public async Task<IEnumerable<IdeiaDto>> GetAll()
        => await _mediator.Send(new ListarTodasIdeiasQuery());
}
