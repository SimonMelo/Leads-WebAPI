using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leads.Application.Interfaces.Services.Password
{
    public interface IPasswordService
    {
        string HashingPassword(string password);
        bool VerifyPassword(string passwordHash, string password);
    }
}
