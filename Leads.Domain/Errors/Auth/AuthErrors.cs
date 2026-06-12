using Leads.Domain.Errors.Base;

namespace Leads.Domain.Errors.Auth
{
    public static class AuthErrors
    {
        public static readonly BaseErrorApi InvalidCredencials =
            new("INVALID_CREDENTIALS", "Senha inválida.");

        public static readonly BaseErrorApi AgentNotRegistered =
            new("AGENT_NOT_REGISTERED", "Corretor não cadastrado ou desativado");
    }
}
