using Leads.Application.Common;
using Leads.Domain.Enum;
using MediatR;

namespace Leads.Application.Features.Commands.Agents
{
    public class AddAgentCommand : IRequest<ApiResponse<AddAgentResponse>>
    {
        public required string Name { get; set; }
        public required string Password { get; set; }
        public required string Creci { get; set; }
        public required string CPF { get; set; }
        public required string Phone { get; set; }
        public required int OfficeId { get; set; }
        public required EAgentRole Role { get; set; }
        public required string Email { get; set; }
    }

    public record AddAgentResponse(string Name, string Creci, string Email);
}
