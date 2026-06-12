using Leads.Application.Common;
using Leads.Application.Features.Commands.Property;
using Leads.Application.Interfaces.Context;
using Leads.Domain.Interfaces.Repositories;
using Leads.Domain.Entities;
using Leads.Domain.Interfaces.Services;
using MediatR;

namespace Leads.Application.Features.Handlers.Property
{
    public class AddPropertyHandler(IUserContext userContext, IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork, IStorageService storageService) : IRequestHandler<AddPropertyCommand, ApiResponse<AddPropertyResponse>>
    {
        public async Task<ApiResponse<AddPropertyResponse>> Handle(AddPropertyCommand command, CancellationToken cancellationToken)
        {
            var agentId = userContext.UserId;

            var address = new Address(
                command.Address.Street,
                command.Address.Number,
                command.Address.Complement,
                command.Address.Neighborhood,
                command.Address.City,
                command.Address.State,
                command.Address.ZipCode,
                command.Address.Country
            );

            var property = new Domain.Entities.Property(command.Title, command.Description, command.RentPrice, command.SalePrice, command.Bedrooms,
                command.Bathrooms, command.AreaM2, command.ListingType, command.Status, address, command.Type, agentId);

            await propertyRepository.AddAsync(property);
            await unitOfWork.CommitAsync();

            if (command.Photos != null && command.Photos.Any())
            {
                var folder = $"properties/{property.Id}";
                var isPrimary = true;

                foreach (var file in command.Photos)
                {
                    await using var stream = file.OpenReadStream();

                    var storagePath = await storageService.UploadAsync(
                        stream,
                        file.FileName,
                        file.ContentType,
                        folder);
                    
                    var photo = new PropertyPhotos(storagePath, order: 0, isPrimary, property.Id);
                    property.Photos.Add(photo);
                    
                    isPrimary = false;
                }
                
                await unitOfWork.CommitAsync();
            }

            return ApiResponse<AddPropertyResponse>.Ok(new AddPropertyResponse(property.Id, command.Title));
        }
    }
}
