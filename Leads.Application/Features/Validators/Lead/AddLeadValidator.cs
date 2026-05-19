using FluentValidation;
using Leads.Application.Features.Commands.Lead;

namespace Leads.Application.Features.Validators.Lead
{
    public class AddLeadValidator : AbstractValidator<AddLeadCommand>
    {
        public AddLeadValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MinimumLength(11)
                .WithMessage("Telefone inválido");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .MinimumLength(11)
                .WithMessage("CPF inválido");
        }
    }
}
