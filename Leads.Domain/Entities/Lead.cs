using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }
        public ELeadStatus Status { get; private set; }
        public int? InterestedPropertyId { get; private set; }
        public int AgentId { get; private set; }

        protected Lead() { }

        public Lead(string name, string email, string phone, string cpf, ELeadStatus status, int? interestedPropertyId, int agentId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cpf;
            Status = status;
            InterestedPropertyId = interestedPropertyId;
            AgentId = agentId;
        }
    }
}
