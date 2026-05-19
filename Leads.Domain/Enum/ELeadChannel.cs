using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Leads.Domain.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ELeadChannel
    {
        [EnumMember(Value = "Portal")] Portal,
        [EnumMember(Value = "SocialAds")] SocialAds,
        [EnumMember(Value = "Organic")] Organic,
        [EnumMember(Value = "Referral")] Referral,
        [EnumMember(Value = "WhatsApp")] WhatsApp,
        [EnumMember(Value = "Others")] Others
    }
}
