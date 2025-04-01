using Infra.NotificationSystem.NotificationBase;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private INotificableService _notificationService;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            _notificationService = context.RequestServices.GetService<INotificableService>();
#pragma warning restore CS8601 // Possible null reference assignment.

            _notificationService?.AddNotification(ex.Message, ex.GetType().Name);//Adiciona a excessão ao serviço de notificações.

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }
}
