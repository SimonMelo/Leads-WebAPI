namespace Leads.Application.Interfaces.Context
{
    public interface IUserContext
    {
        int UserId { get; }
        int OfficeId { get; }
        string Email { get; }
    }
}
