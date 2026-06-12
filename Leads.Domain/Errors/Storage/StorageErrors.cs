using Leads.Domain.Errors.Base;

namespace Leads.Domain.Errors.Storage;

public static class StorageErrors
{
    public static readonly BaseErrorApi InvalidBucket =
        new("INVALID_BUCKET", "Bucket não encontrado");
}