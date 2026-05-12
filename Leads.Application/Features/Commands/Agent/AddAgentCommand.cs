using Leads.Application.Common;
using MediatR;

namespace Leads.Application.Features.Commands.Agent
{
    public class AddAgentCommand : IRequest<ApiResponse<AddAgentResponse>>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Creci { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public record AddAgentResponse(string Name, string Creci, string Email);
}
