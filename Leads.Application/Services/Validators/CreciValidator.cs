using System.Text.RegularExpressions;

namespace Leads.Application.Services.Validators
{
    public static class CreciValidator
    {
        public static bool IsValid(string creci)
        {
            if (string.IsNullOrWhiteSpace(creci))
                return false;

            creci = Normalize(creci);

            var pattern = @"^\d{2,6}(-?[FJ])?(\/[A-Z]{2})?$";

            return Regex.IsMatch(creci, pattern);
        }

        private static string Normalize(string creci)
        {
            return creci
                .Trim()
                .ToUpper()
                .Replace(" ", "");
        }
    }
}