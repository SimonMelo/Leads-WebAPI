using FluentValidation;
using Leads.Application.Features.Commands.Auth;
using Leads.Application.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Features.Validators.Auth
{
    public class AuthValidator : AbstractValidator<AuthCommand>
    {
        public AuthValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(x => x.Creci)
                .NotEmpty()
                .WithMessage("CRECI é obrigatório.")
                .Must(CreciValidator.IsValid)
                .WithMessage("Creci inválido.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Senha deve ter pelo menos 8 caracteres.");
        }
    }
}
