using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class Property : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal RentPrice { get; private set; }
        public EPropertyStatus Status { get; private set; } 
        public Address Address { get; private set; }
        public EPropertyType Type { get; private set; } 
        // public List<PropertyImage> Images { get; private set; }
        public int? AgentId { get; private set; }

        protected Property() { }

        public Property(string title, string description, decimal rentPrice, EPropertyStatus status, Address address, EPropertyType type, int? agentId)
        {
            Title = title;
            Description = description;
            RentPrice = rentPrice;
            Status = status;
            Address = address;
            Type = type;
            AgentId = agentId;
        }
    }
}
