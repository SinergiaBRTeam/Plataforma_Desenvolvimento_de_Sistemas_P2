using UniThesis.Domain.Users;

namespace UniThesis.Application.Auth.DTOs;

public class UsuarioDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = default!;
    public UserRole Role { get; set; } = default!;
}
