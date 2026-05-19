using Leads.Application.Common;
using Leads.Application.Errors.Agent;
using Leads.Application.Features.Commands.Agent;
using Leads.Application.Interfaces.Repositories;
using Leads.Application.Interfaces.Services.Password;
using Leads.Domain.Entities;
using MediatR;

namespace Leads.Application.Features.Handlers.Agent
{
    public class AddAgentHandler(IAgentRepository agentRepository, IPasswordService passwordService,
        IUnitOfWork unitOfWork) : IRequestHandler<AddAgentCommand, ApiResponse<AddAgentResponse>>
    {
        public async Task<ApiResponse<AddAgentResponse>> Handle(AddAgentCommand command, CancellationToken cancellationToken)
        {
            var agentExist = await agentRepository.ExistAgentAsync(command.Email, command.Creci);

            if (agentExist != null)
                return ApiResponse<AddAgentResponse>.Fail(AgentErrors.ExistAgent, statusCode: 400);

            var passwordHashed = passwordService.HashingPassword(command.Password);

            var rowsAffected = await unitOfWork.CommitAsync();

            if (rowsAffected <= 0)
            {
                return ApiResponse<AddAgentResponse>.Fail(
                    AgentErrors.ErrorAddAgent,
                    statusCode: 500
                );
            }

            return ApiResponse<AddAgentResponse>.Ok(new AddAgentResponse(command.Name, command.Creci, command.Email), statusCode: 201);
        }
    }
}
