using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class Property : BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal? RentPrice { get; private set; }
        public decimal? SalePrice { get; private set; }
        public EPropertyStatus Status { get; private set; }
        public EListingType ListingType { get; private set; }
        public Address Address { get; private set; }
        public decimal AreaM2 { get; private set; }
        public EPropertyType Type { get; private set; }
        public int? Bedrooms { get; private set; }
        public int? Bathrooms { get; private set; }
        public List<PropertyPhotos> Photos { get; private set; }
        public Agent Agent { get; private set; }
        public int? AgentId { get; private set; }

        protected Property() { }

        public Property(string title, string description, decimal? rentPrice, decimal? salePrice,
            int? bedrooms, int? bathrooms, decimal aream2,
            EListingType eListingType,
            EPropertyStatus status, Address address, EPropertyType type, int? agentId)
        {
            Title = title;
            Description = description;
            RentPrice = rentPrice;
            SalePrice = salePrice;
            ListingType = eListingType;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            AreaM2 = aream2;
            Status = status;
            Address = address;
            Type = type;
            AgentId = agentId;
            Photos = new List<PropertyPhotos>();
        }
    }
}
