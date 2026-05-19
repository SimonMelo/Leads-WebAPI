using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class LeadSource : BaseEntity
    {
        public string Name { get; private set; }
        public ELeadChannel Channel { get; private set; }
        public List<Lead> Leads { get; private set; }

        protected LeadSource() { }

        public LeadSource(string name, ELeadChannel channel)
        {
            Name = name;
            Channel = channel;
            Leads = new List<Lead>();
        }
    }
}
