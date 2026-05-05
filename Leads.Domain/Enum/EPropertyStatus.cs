using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
    public enum EPropertyStatus
    {
        [EnumMember(Value = "Disponível")] Disponível,
        [EnumMember(Value = "Alugado")] Alugado,
        [EnumMember(Value = "Indisponível")] Indisponível,
        [EnumMember(Value = "Vendido")] Vendido,
        [EnumMember(Value = "Reservado")] Reservado
    }
}
