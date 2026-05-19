using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Leads.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EPropertyStatus
    {
        [EnumMember(Value = "Disponível")] Disponível,
        [EnumMember(Value = "Alugado")] Alugado,
        [EnumMember(Value = "Indisponível")] Indisponível,
        [EnumMember(Value = "Vendido")] Vendido,
        [EnumMember(Value = "Reservado")] Reservado
    }
}
