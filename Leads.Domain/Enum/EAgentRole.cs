using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
    public enum EAgentRole
    {
        [EnumMember(Value = "SystemAdmin")] SystemAdmin,
        [EnumMember(Value = "OfficeOwner")] OfficeOwner,
        [EnumMember(Value = "Agent")] Agent
    }
}
