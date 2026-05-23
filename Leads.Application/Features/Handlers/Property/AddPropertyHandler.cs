using Leads.Application.Common;
using Leads.Application.Features.Commands.Property;
using Leads.Application.Interfaces.Context;
using Leads.Application.Interfaces.Repositories;
using Leads.Domain.Entities;
using MediatR;

namespace Leads.Application.Features.Handlers.Property
{
    public class AddPropertyHandler(IUserContext userContext, IPropertyRepository propertyRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddPropertyCommand, ApiResponse<AddPropertyResponse>>
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

            return ApiResponse<AddPropertyResponse>.Ok(new AddPropertyResponse(property.Id, command.Title));
        }
    }
}
