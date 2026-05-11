using Leads.Application.Interfaces.Services.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace Leads.Application.Services.Password
{
    public class PasswordService : IPasswordService
    {
        public string HashingPassword(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string passwordHash, string password)
            => BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
