using Leads.Domain.Entities.Base;

namespace Leads.Domain.Entities
{
    public class LeadNote : BaseEntity
    {
        public string? Content { get; private set; }
        public int LeadId { get; private set; }
        public Lead Lead { get; private set; }
        public int? AgentId { get; private set; }
        public Agent Agent { get; private set; }

        protected LeadNote() { }

        public LeadNote(string content, int leadId, int? agentId = null)
        {
            Content = content;
            LeadId = leadId;
            AgentId = agentId;
        }
    }
}
