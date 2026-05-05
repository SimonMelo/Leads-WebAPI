using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
    public enum EPropertyType
    {
        [EnumMember(Value = "Apartamento")] Apartamento,
        [EnumMember(Value = "Casa")] Casa,
        [EnumMember(Value = "Comercial")] Comercial,
        [EnumMember(Value = "Terreno")] Terreno,
        [EnumMember(Value = "Outros")] Outros
    }
}
