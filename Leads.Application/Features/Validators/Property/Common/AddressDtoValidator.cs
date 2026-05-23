using FluentValidation;
using Leads.Application.Features.Commands.Property.Common;

namespace Leads.Application.Features.Validators.Property.Common
{
        public class AddressDtoValidator : AbstractValidator<AddressDto>
        {
            public AddressDtoValidator()
            {
                RuleFor(a => a.Street)
                    .NotEmpty()
                    .WithMessage("Rua é obrigatória")
                    .MaximumLength(200)
                    .WithMessage("Rua pode ter no máximo 200 caracteres");

                RuleFor(a => a.Number)
                    .NotEmpty()
                    .WithMessage("Número é obrigatório");

                RuleFor(a => a.Neighborhood)
                    .NotEmpty()
                    .WithMessage("Bairro é obrigatório");

                RuleFor(a => a.City)
                    .NotEmpty()
                    .WithMessage("Cidade é obrigatória");

                RuleFor(a => a.State)
                    .NotEmpty()
                    .WithMessage("Estado é obrigatório")
                    .Length(2)
                    .WithMessage("Estado deve ter 2 caracteres (ex: SP, RJ)");

                RuleFor(a => a.ZipCode)
                    .NotEmpty()
                    .WithMessage("CEP é obrigatório")
                    .Matches(@"^\d{5}-?\d{3}$")
                    .WithMessage("CEP inválido (ex: 01310-100)");
            }
    }
}
