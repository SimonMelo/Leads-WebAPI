using Microsoft.AspNetCore.Http;

namespace Leads.Application.Features.Commands.Property.Common
{
    public class PropertyPhotoDto
    {
        public List<byte[]>? Files { get; set; }
    }
}
