using FluentValidation;
using Leads.Application.Features.Commands.Lead;
using Leads.Application.Interfaces.Context;
using Leads.Application.Interfaces.Repositories;

namespace Leads.Application.Features.Validators.Lead
{
    public class AddLeadValidator : AbstractValidator<AddLeadCommand>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IUserContext _userContext;
        public AddLeadValidator(ILeadRepository leadRepository, IUserContext userContext)
        {
            _leadRepository = leadRepository;
            _userContext = userContext;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(x => x)
                .MustAsync(EmailNotTakenInOfficeAsync)
                .WithMessage("Cliente já cadastrado neste escritório.")
                .When(x => !string.IsNullOrEmpty(x.Email));

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MinimumLength(11)
                .WithMessage("Telefone inválido");
        }

        private Task<bool> EmailNotTakenInOfficeAsync(AddLeadCommand cmd, CancellationToken cancellationToken)
            => _leadRepository.NotExistsAsync(a => a.Email == cmd.Email && a.OfficeId == _userContext.OfficeId, cancellationToken);
    }
}
