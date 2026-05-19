using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Leads.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ELeadStatus
    {
        [EnumMember(Value = "Novo")] Novo,
        [EnumMember(Value = "Em Contato")] EmContato,
        [EnumMember(Value = "Interessado")] Interessado,
        [EnumMember(Value = "Perdido")] Perdido,
        [EnumMember(Value = "Convertido")] Convertido
    }
}
