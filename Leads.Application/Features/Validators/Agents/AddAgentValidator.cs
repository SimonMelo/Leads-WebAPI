using FluentValidation;
using Leads.Application.Features.Commands.Agents;
using Leads.Domain.Interfaces.Repositories;
using Leads.Application.Services.Validators;

namespace Leads.Application.Features.Validators.Agents
{
    public class AddAgentCommandValidator : AbstractValidator<AddAgentCommand>
    {
        private readonly IAgentRepository _agentRepository;
        private readonly IOfficeRepository _officeRepository;

        public AddAgentCommandValidator(IAgentRepository agentRepository, IOfficeRepository officeRepository)
        {
            _agentRepository = agentRepository;
            _officeRepository = officeRepository;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("E-mail inválido.")
                .MustAsync(EmailNotTakenAsync)
                .WithMessage("E-mail já cadastrado.");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MinimumLength(11)
                .WithMessage("Telefone inválido.");

            RuleFor(x => x.CPF)
                .NotEmpty()
                .WithMessage("CPF é obrigatório.")
                .MinimumLength(11)
                .WithMessage("CPF inválido.");

            RuleFor(x => x.Role)
                .IsInEnum()
                .WithMessage("Cargo é obrigatório.");

            RuleFor(x => x.OfficeId)
                .NotEmpty()
                .WithMessage("Escritório é obrigatório.")
                .MustAsync(OfficeExistAsync)
                .WithMessage("Escritório não cadastrado no sistema.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Senha deve ter pelo menos 8 caracteres.");

            RuleFor(x => x.Creci)
                .NotEmpty()
                .WithMessage("CRECI é obrigatório.")
                .Must(CreciValidator.IsValid)
                .WithMessage("CRECI inválido.")
                .MustAsync(CreciNotTakenAsync)
                .WithMessage("CRECI já cadastrado");
        }
        private Task<bool> EmailNotTakenAsync(string email, CancellationToken cancellationToken)
            => _agentRepository.NotExistsAsync(a => a.Email == email, cancellationToken);

        private Task<bool> CreciNotTakenAsync(string creci, CancellationToken cancellationToken)
            => _agentRepository.NotExistsAsync(a => a.CRECI == creci, cancellationToken);

        private Task<bool> OfficeExistAsync(int officeId, CancellationToken cancellationToken)
            => _officeRepository.ExistsAsync(a => a.Id == officeId, cancellationToken);

    }
}