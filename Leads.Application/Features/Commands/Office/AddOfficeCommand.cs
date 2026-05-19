using Leads.Application.Common;
using MediatR;

namespace Leads.Application.Features.Commands.Office
{
    public class AddOfficeCommand : IRequest<ApiResponse<AddOfficeResponse>>
    {
        public required string Name { get; set; }
        public string? CNPJ { get; set; }
        public string? Phone { get; set; }
    }

    public record AddOfficeResponse(string Name);
}
