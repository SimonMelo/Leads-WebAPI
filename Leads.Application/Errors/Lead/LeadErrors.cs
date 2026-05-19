using Leads.Application.Errors.Base;

namespace Leads.Application.Errors.Lead
{
    public static class LeadErrors
    {
        public static BaseErrorApi LeadExist =
            new("LEAD_EXIST", "Cliente já cadastrado");
    }
}
