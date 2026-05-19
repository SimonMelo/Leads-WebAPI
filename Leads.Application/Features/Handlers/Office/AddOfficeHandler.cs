using Leads.Application.Common;
using Leads.Application.Features.Commands.Office;
using Leads.Application.Interfaces.Repositories;
using MediatR;

namespace Leads.Application.Features.Handlers.Office
{
    public class AddOfficeHandler(IOfficeRepository officeRepository, IUnitOfWork unitOfWork) : IRequestHandler<AddOfficeCommand, ApiResponse<AddOfficeResponse>>
    {
        public async Task<ApiResponse<AddOfficeResponse>> Handle(AddOfficeCommand command, CancellationToken cancellationToken)
        {
            var office = new Domain.Entities.Office(command.Name, command.CNPJ, command.Phone);

            await officeRepository.AddAsync(office);

            await unitOfWork.CommitAsync();

            return ApiResponse<AddOfficeResponse>.Ok(new AddOfficeResponse(command.Name), statusCode: 201);
        }
    }
}
