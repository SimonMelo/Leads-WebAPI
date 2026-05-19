using Leads.Application.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Infra.Persistence;

namespace Leads.Infra.Repositories
{
    public class PropertyPhotoRepository(AppDbContext context) : Repository<PropertyPhotos>(context), IPropertyPhotoRepository
    {
    }
}
