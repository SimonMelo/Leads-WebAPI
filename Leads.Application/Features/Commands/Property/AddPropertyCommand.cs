using Leads.Application.Common;
using Leads.Application.Features.Commands.Property.Common;
using Leads.Domain.Enum;
using MediatR;

namespace Leads.Application.Features.Commands.Property
{
    public class AddPropertyCommand : IRequest<ApiResponse<AddPropertyResponse>>
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public decimal? RentPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public EPropertyStatus Status { get; set; }
        public EListingType ListingType { get; set; }
        public required AddressDto Address { get; set; }
        public PropertyPhotoDto? PropertyPhoto { get; set; }
        public required decimal AreaM2 { get; set; }
        public required EPropertyType Type { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }

    }
    
    public record AddPropertyResponse(int PropertyId, string Title);
}
