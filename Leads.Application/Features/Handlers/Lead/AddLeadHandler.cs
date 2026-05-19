using Leads.Application.Common;
using Leads.Application.Features.Commands.Lead;
using Leads.Application.Interfaces.Context;
using Leads.Application.Interfaces.Repositories;
using MediatR;

namespace Leads.Application.Features.Handlers.Lead
{
    public class AddLeadHandler(IUnitOfWork unitOfWork, IUserContext userContext, ILeadRepository leadRepository) : IRequestHandler<AddLeadCommand, ApiResponse<AddLeadResponse>>
    {
        public async Task<ApiResponse<AddLeadResponse>> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            var agentId = userContext.UserId;

            var officeId = userContext.OfficeId;

            var lead = new Domain.Entities.Lead(request.Name, request.Email, request.Phone, agentId, officeId, sourceId: request.SourceId);

            await leadRepository.AddAsync(lead);

            await unitOfWork.CommitAsync();

            return ApiResponse<AddLeadResponse>.Ok(new AddLeadResponse(request.Name, request.Email, request.Status), statusCode: 201);
        }
    }
}
