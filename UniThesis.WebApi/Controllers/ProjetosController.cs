using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniThesis.Application.Projects.Commands.AssociarOrientador;
using UniThesis.Application.Projects.Commands.CriarProjeto;
using UniThesis.Application.Projects.Commands.SubmeterDocumento;
using UniThesis.Application.Projects.DTOs;
using UniThesis.Application.Projects.Queries.ListarDocumentosProjeto;
using UniThesis.Application.Projects.Queries.ListarTodos;
using UniThesis.Application.Projects.Queries.ObterPorId;

namespace UniThesis.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjetosController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjetosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(Roles = "Coordenador,Professor")]
    public async Task<IActionResult> CriarProjeto([FromBody] CriarProjetoCommand command)
    {
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(ObterPorId), new { id }, null);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id)
    {
        var result = await _mediator.Send(new ObterProjetoPorIdQuery(id));

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPut("{id:guid}/orientador")]
    [Authorize(Roles = "Coordenador")]
    public async Task<IActionResult> AssociarOrientador(Guid id, [FromBody] AssociarOrientadorCommand command)
    {
        if (id != command.ProjetoId)
            return BadRequest("Id de rota difere do corpo.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPost("{id:guid}/documentos")]
    [Authorize]
    public async Task<IActionResult> SubmeterDocumento(Guid id, [FromBody] SubmeterDocumentoCommand command)
    {
        if (id != command.ProjetoId)
            return BadRequest("Id de rota difere do corpo.");

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id:guid}/documentos")]
    [Authorize]
    public async Task<IEnumerable<DocumentoDto>> ListarDocumentos(Guid id)
        => await _mediator.Send(new ListarDocumentosProjetoQuery(id));

    [HttpGet]
    public async Task<IEnumerable<ProjetoDto>> GetAll()
        => await _mediator.Send(new ListarTodosProjetosQuery());
}
