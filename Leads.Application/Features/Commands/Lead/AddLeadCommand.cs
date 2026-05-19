using Leads.Application.Common;
using Leads.Domain.Enum;
using MediatR;

namespace Leads.Application.Features.Commands.Lead
{
    public class AddLeadCommand : IRequest<ApiResponse<AddLeadResponse>>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ELeadStatus? Status { get; set; }
    }

    public record AddLeadResponse(string Name, string Email, ELeadStatus? Status);
}
