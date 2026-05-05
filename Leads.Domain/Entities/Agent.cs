using Leads.Domain.Entities.Base;

namespace Leads.Domain.Entities
{
    public class Agent : BaseEntity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string CPF { get; private set; }
        public string CRECI { get; private set; }
        public List<Property> Properties { get; private set; }
        public List<Lead> Leads { get; private set; }

        protected Agent() { }

        public Agent(string name, string email, string phone, string cpf, string creci)
        {
            Name = name;
            Email = email;
            Phone = phone;
            CPF = cpf;
            CRECI = creci;
            Properties = new List<Property>();
            Leads = new List<Lead>();
        }
    }
}
