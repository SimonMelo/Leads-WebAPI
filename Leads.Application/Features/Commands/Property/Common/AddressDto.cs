
namespace Leads.Application.Features.Commands.Property.Common
{
    public class AddressDto
    {
        public required string Street { get; set; }
        public required string Number { get; set; }
        public string? Complement { get; set; } = string.Empty;
        public required string Neighborhood { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
