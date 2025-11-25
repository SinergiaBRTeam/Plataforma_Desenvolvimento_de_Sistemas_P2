using MediatR;
using UniThesis.Application.Auth.DTOs;

namespace UniThesis.Application.Auth.Queries.ListarUsuarios;

public class ListarUsuariosQuery : IRequest<IEnumerable<UsuarioDto>>
{
}
