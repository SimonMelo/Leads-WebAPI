using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
    public enum EListingType
    {
        [EnumMember(Value = "Alugar")] Alugar,
        [EnumMember(Value = "Venda")] Venda,
        [EnumMember(Value = "Ambos")] Ambos
    }
}
