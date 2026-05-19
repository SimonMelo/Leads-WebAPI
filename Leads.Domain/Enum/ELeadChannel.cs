using System.Runtime.Serialization;

namespace Leads.Domain.Enum
{
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
