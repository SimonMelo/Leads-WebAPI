using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Leads.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EPropertyType
    {
        [EnumMember(Value = "Apartamento")] Apartamento,
        [EnumMember(Value = "Casa")] Casa,
        [EnumMember(Value = "Comercial")] Comercial,
        [EnumMember(Value = "Terreno")] Terreno,
        [EnumMember(Value = "Outros")] Outros
    }
}
