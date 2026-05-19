using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public ELeadStatus? Status { get; private set; } = ELeadStatus.Novo;
        public int? InterestedPropertyId { get; private set; }
        public Agent Agent { get; private set; }
        public int? SourceId { get; private set; }
        public LeadSource Source { get; private set; }
        public Property InterestedProperty { get; private set; }
        public int AgentId { get; private set; }
        public List<LeadNote> Notes { get; private set; }

        protected Lead() { }

        public Lead(string name, string email, string phone, int agentId, ELeadStatus? status = ELeadStatus.Novo, int? interestedPropertyId = null, int? sourceId = null)
        {
            Name = name;
            Email = email;
            Phone = phone;
            SourceId = sourceId;
            Status = status;
            InterestedPropertyId = interestedPropertyId;
            AgentId = agentId;
            Notes = new List<LeadNote>();
        }

        public void UpdateStatusLead(ELeadStatus newStatus) => Status = newStatus;
        
        public void AssignAgent(int agentId) => AgentId = agentId;

        public void SetSource(int sourceId) => SourceId = sourceId;

    }
}
