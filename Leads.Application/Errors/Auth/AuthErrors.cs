using Leads.Application.Errors.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Errors.Auth
{
    public static class AuthErrors
    {
        public static readonly BaseErrorApi InvalidCredencials =
            new("INVALID_CREDENTIALS", "Senha inválida.");

        public static readonly BaseErrorApi AgentNotRegistered =
            new("AGENT_NOT_REGISTERED", "Corretor não cadastrado ou desativado");
    }
}
