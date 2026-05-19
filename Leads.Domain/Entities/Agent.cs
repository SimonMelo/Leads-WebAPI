using Leads.Domain.Entities.Base;
using Leads.Domain.Enum;

namespace Leads.Domain.Entities
{
    public class Agent : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }
        public string CRECI { get; private set; }
        public EAgentRole Role { get; private set; }
        public bool IsActive { get; private set; }
        public int OfficeId { get; private set; }
        public Office Office { get; private set; }
        public List<Property> Properties { get; private set; }
        public List<Lead> Leads { get; private set; }

        protected Agent() { }

        public Agent(string name, string email, string phone, string cpf, string creci, string password, EAgentRole role, int officeId)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cpf;
            Password = password;
            CRECI = creci;
            Role = role;
            OfficeId = officeId;
            Properties = new List<Property>();
            Leads = new List<Lead>();
            IsActive = true;
        }
        public void ChangeRole(EAgentRole newRole) => Role = newRole;

        public void Deactivate() => IsActive = false;

        public void AssignToOffice(int officeId) => OfficeId = officeId;

    }

}
