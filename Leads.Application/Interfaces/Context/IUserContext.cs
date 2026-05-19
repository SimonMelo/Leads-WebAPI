namespace Leads.Application.Interfaces.Context
{
    public interface IUserContext
    {
        int UserId { get; }
        string Email { get; }
    }
}
