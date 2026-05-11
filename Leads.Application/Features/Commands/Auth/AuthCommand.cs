using Leads.Application.Common;
using MediatR;

namespace Leads.Application.Features.Commands.Auth
{
    public class AuthCommand : IRequest<ApiResponse<AuthResponse>>
    {
        public required string Email { get; set; }
        public required string Creci { get; set; }
        public required string Password { get; set; }
    }

    public record AuthResponse(string Token, string User);
}
