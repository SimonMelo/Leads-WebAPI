using FluentValidation;
using Leads.Application.Features.Commands.Agent;
using Leads.Application.Features.Commands.Property;
using Leads.Application.Features.Validators.Property.Common;
using Leads.Domain.Enum;

namespace Leads.Application.Features.Validators.Property
{
    public class AddPropertyValidator : AbstractValidator<AddPropertyCommand>
    {
        public AddPropertyValidator() 
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .WithMessage("Título é obrigatório")
                .MinimumLength(10)
                .WithMessage("Título no mínimo tem que ter 10 caracteres");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("Descrição é obrigatória")
                .MaximumLength(500)
                .WithMessage("Descrição só pode ter no máximo 500 caracteres");

            RuleFor(p => p.Status)
                .IsInEnum();

            RuleFor(p => p.Type)
                .IsInEnum();

            RuleFor(p => p.ListingType)
                .IsInEnum();

            RuleFor(p => p.AreaM2)
                .NotEmpty()
                .WithMessage("Area é obrigatória");

            RuleFor(p => p.RentPrice)
                .NotEmpty()
                .When(x => x.ListingType == Domain.Enum.EListingType.Alugar || x.ListingType == EListingType.Ambos)
                .WithMessage("RentPrice é obrigatório para imóveis de aluguel.");

            RuleFor(p => p.SalePrice)
                .NotEmpty()
                .When(x => x.ListingType == Domain.Enum.EListingType.Venda || x.ListingType == EListingType.Ambos)
                .WithMessage("SalePrice é obrigatório para imóveis de venda.");

            RuleFor(p => p.Address) 
                .NotEmpty()
                .WithMessage("Endereço é obrigatório.")
                .SetValidator(new AddressDtoValidator());
        }
    }
}
