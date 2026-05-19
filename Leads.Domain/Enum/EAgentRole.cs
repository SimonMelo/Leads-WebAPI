using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Leads.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EAgentRole
    {
        [EnumMember(Value = "SystemAdmin")] SystemAdmin,
        [EnumMember(Value = "OfficeOwner")] OfficeOwner,
        [EnumMember(Value = "Agent")] Agent
    }
}
