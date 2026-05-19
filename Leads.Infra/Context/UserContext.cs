using Leads.Application.Interfaces.Context;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
                    .FindFirst(ClaimTypes.NameIdentifier)?
                    .Value;

                return int.Parse(userId!);
            }
        }

        public string Email
        {
            get
            {
                return httpContextAccessor
                    .HttpContext?
                    .User?
                    .FindFirst(ClaimTypes.Email)?
                    .Value ?? string.Empty;
            }
        }
    }
}