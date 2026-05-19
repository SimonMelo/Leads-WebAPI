using Leads.Application.Common;
using Leads.Application.Errors.Agent;
using Leads.Application.Features.Commands.Agent;
using Leads.Application.Interfaces.Repositories;
using Leads.Application.Interfaces.Services.Password;
using MediatR;

namespace Leads.Application.Features.Handlers.Agent
{
    public class AddAgentHandler(IAgentRepository agentRepository, IPasswordService passwordService,
        IUnitOfWork unitOfWork) : IRequestHandler<AddAgentCommand, ApiResponse<AddAgentResponse>>
    {
        public async Task<ApiResponse<AddAgentResponse>> Handle(AddAgentCommand command, CancellationToken cancellationToken)
        {
            var passwordHashed = passwordService.HashingPassword(command.Password);

            var agent = new Domain.Entities.Agent(command.Name, command.Email, command.Phone, command.CPF, command.Creci, passwordHashed, command.Role, command.OfficeId);

            Console.WriteLine(command.Role);
            Console.WriteLine(agent.Role);
            await agentRepository.AddAsync(agent);

            Console.WriteLine(command.Role.CompareTo(agent.Role));

            var rowsAffected = await unitOfWork.CommitAsync();
            Console.WriteLine(command.Role);
            Console.WriteLine(agent.Role);

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
