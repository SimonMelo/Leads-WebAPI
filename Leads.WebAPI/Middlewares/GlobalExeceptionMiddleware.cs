using Leads.Application.Common;
using Leads.Domain.Errors.Base;

namespace Leads.WebAPI.Middlewares;

public class GlobalExceptionMiddleware(
        RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(
                ApiResponse<string>.Fail(
                    new BaseErrorApi(
                        "INTERNAL_SERVER_ERROR",
                        ex.Message
                    ),
                    statusCode: 500
                ));
        }
    }
}