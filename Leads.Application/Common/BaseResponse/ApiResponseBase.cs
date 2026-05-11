using Leads.Application.Errors.Base;

namespace Leads.Application.Common.BaseResponse;

public abstract class ApiResponseBase
{
    public bool Success { get; init; }

    public int StatusCode { get; init; }

    public string? Message { get; init; }

    public string TraceId { get; init; } = Guid.NewGuid().ToString();

    public DateTime Timestamp { get; init; } = DateTime.UtcNow;

    public IReadOnlyCollection<BaseErrorApi> Errors { get; init; }
        = [];
}