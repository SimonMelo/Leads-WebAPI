using Leads.Application.Common;
using Leads.Domain.Errors.Auth;
using Leads.Application.Features.Commands.Auth;
using Leads.Domain.Interfaces.Repositories;
using Leads.Application.Interfaces.Services.Password;
using Leads.Application.Interfaces.Services.Token;
using MediatR;

namespace Leads.Application.Features.Handlers.Auth;

public class AuthHandler(
    IAgentRepository agentRepository,
    IPasswordService passwordService,
    ITokenService tokenService
) : IRequestHandler<AuthCommand, ApiResponse<AuthResponse>>
{
    public async Task<ApiResponse<AuthResponse>> Handle(
        AuthCommand command,
        CancellationToken cancellationToken)
    {
        var agent = await agentRepository
            .ExistAgentAsync(
                command.Email,
                command.Creci);

        Console.WriteLine(
    BCrypt.Net.BCrypt.HashPassword("123456"));

        if (agent is null)
        {
            return ApiResponse<AuthResponse>.Fail(
                AuthErrors.AgentNotRegistered,
                statusCode: 401
            );
        }


        var validPassword = passwordService.VerifyPassword(
            agent.Password,
            command.Password);

        if (!validPassword)
        {
            return ApiResponse<AuthResponse>.Fail(
                AuthErrors.InvalidCredencials,
                statusCode: 401
            );
        }

        if (!agent.IsActive)
        {
            return ApiResponse<AuthResponse>.Fail(
                AuthErrors.AgentNotRegistered,
                statusCode: 403
            );
        }

        var token = tokenService.GenerateToken(agent);

        var response = new AuthResponse(
            token,
            agent.Name
        );

        return ApiResponse<AuthResponse>.Ok(response);
    }
}