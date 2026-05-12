using FluentValidation;
using Leads.Application.Features.Commands.Agent;
using Leads.Application.Services.Validators;

namespace Leads.Application.Features.Validators.Agent
{
    public class AddAgentCommandValidator : AbstractValidator<AddAgentCommand>
    {
        public AddAgentCommandValidator()
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
                .WithMessage("Telefone é obrigatório.");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.")
                .MinimumLength(11)
                .WithMessage("CPF inválido");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Senha deve ter pelo menos 8 caracteres.");

            RuleFor(x => x.Creci)
                .NotEmpty()
                .WithMessage("CRECI é obrigatório.")
                .Must(CreciValidator.IsValid)
                .WithMessage("CRECI inválido.");
        }
    }
}