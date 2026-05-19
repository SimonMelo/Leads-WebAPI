using Leads.Application.Common;
using Leads.Domain.Enum;
using MediatR;

namespace Leads.Application.Features.Commands.Lead
{
    public class AddLeadCommand : IRequest<ApiResponse<AddLeadResponse>>
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public int? SourceId { get; set; }
        public ELeadStatus? Status { get; set; }
    }

    public record AddLeadResponse(string Name, string Email, ELeadStatus? Status);
}
