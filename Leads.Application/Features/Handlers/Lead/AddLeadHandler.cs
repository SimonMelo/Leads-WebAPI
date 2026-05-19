using Leads.Application.Common;
using Leads.Application.Errors.Lead;
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
            var leadExist = await leadRepository.ExistLeadAsync(request.Email, request.CPF);

            if (leadExist)
                return ApiResponse<AddLeadResponse>.Fail(LeadErrors.LeadExist, statusCode: 400);

            var agentId = userContext.UserId;


            await unitOfWork.CommitAsync();

            return ApiResponse<AddLeadResponse>.Ok(new AddLeadResponse(request.Name, request.Email, request.Status), statusCode: 201);
        }
    }
}
