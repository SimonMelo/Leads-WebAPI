using Leads.Domain.Errors.Base;

namespace Leads.Domain.Errors.Agents
{
    public static class AgentErrors
    {
        public static readonly BaseErrorApi ExistAgent =
            new("EXIST_AGENT", "Corretor já cadastrado no sistema.");

        public static readonly BaseErrorApi ErrorAddAgent =
            new("ERROR_ADD_AGENT", "Houve um erro ao tentar cadastrar no sistema");
    }
}
