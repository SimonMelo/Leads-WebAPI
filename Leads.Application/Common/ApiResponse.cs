using Leads.Application.Common.BaseResponse;
using Leads.Domain.Errors.Base;

namespace Leads.Application.Common;

public sealed class ApiResponse<T> : ApiResponseBase
{
    public T? Data { get; init; }

    public static ApiResponse<T> Ok(
        T data,
        string? message = null,
        int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Success = true,
            Data = data,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static ApiResponse<T> Fail(
        IEnumerable<BaseErrorApi> errors,
        string? message = null,
        int statusCode = 400)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Errors = errors.ToList(),
            Message = message,
            StatusCode = statusCode
        };
    }

    public static ApiResponse<T> Fail(
        BaseErrorApi error,
        string? message = null,
        int statusCode = 400)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Errors = [error],
            Message = message,
            StatusCode = statusCode
        };
    }
}