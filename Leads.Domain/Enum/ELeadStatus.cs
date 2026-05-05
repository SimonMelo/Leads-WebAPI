using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
    public enum ELeadStatus
    {
        [EnumMember(Value = "Novo")] Novo,
        [EnumMember(Value = "Em Contato")] EmContato,
        [EnumMember(Value = "Interessado")] Interessado,
        [EnumMember(Value = "Perdido")] Perdido,
        [EnumMember(Value = "Convertido")] Convertido
    }
}
