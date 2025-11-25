using MediatR;
using UniThesis.Application.Auth.DTOs;
using UniThesis.Domain.Common;

namespace UniThesis.Application.Auth.Queries.ListarUsuarios
{
    public class ListarUsuariosQueryHandler
        : IRequestHandler<ListarUsuariosQuery, IEnumerable<UsuarioDto>>
    {
        private readonly IUnitOfWork _uow;

        public ListarUsuariosQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _uow.Users.BuscarTodosAsync();

            return usuarios.Select(u => new UsuarioDto
            {
                Id = u.Id,
                UserName = u.UserName,
                Role = u.Role
            });
        }
    }
}
