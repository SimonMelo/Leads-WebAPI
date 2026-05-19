using Leads.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Domain.Entities
{
    public class Office : BaseEntity
    {
        public string Name { get; private set; }
        public string? CNPJ { get; private set; }
        public string? Phone { get; private set; }
        public string? LogoUrl { get; private set; }
        public bool IsActive { get; private set; } = true;
        public List<Agent>? Agents { get; private set; }

        protected Office() { }

        public Office(string name, string? cnpj, string? phone)
        {
            Name = name;
            CNPJ = cnpj;
            Phone = phone;
            Agents = new List<Agent>();
        }

        public void UpdateLogo(string url) => LogoUrl = url;
        public void Deactivate() => IsActive = false;
    }
}
