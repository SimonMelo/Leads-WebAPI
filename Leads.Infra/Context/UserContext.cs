using Leads.Application.Interfaces.Context;
using Microsoft.AspNetCore.Http;

namespace Leads.Infra.Context
{
    public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public int UserId
        {
            get
            {
                var userId = httpContextAccessor
                    .HttpContext?
                    .User?
                    .FindFirst("Identifier")?
                    .Value;

                return int.Parse(userId!);
            }
        }

        public int OfficeId
        {
            get
            {
                var officeId = httpContextAccessor
                    .HttpContext?
                    .User?
                    .FindFirst("OfficeId")?
                    .Value;

                return int.Parse(officeId!);
            }
        }

        public string Email
        {
            get
            {
                return httpContextAccessor
                    .HttpContext?
                    .User?
                    .FindFirst("Email")?
                    .Value ?? string.Empty;
            }
        }
    }
}