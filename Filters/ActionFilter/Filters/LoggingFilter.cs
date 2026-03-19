using Microsoft.AspNetCore.Mvc.Filters;

namespace ActionFilter.Filters.LogginFilter;


public class LoggingFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        Console.WriteLine("Before Action");
        context.HttpContext.Items["StartTime"] = DateTime.UtcNow;

        var resultContext = await next();

        var startTime = (DateTime)context.HttpContext.Items["StartTime"]!;
        var duration = DateTime.UtcNow - startTime;
        context.HttpContext.Response.Headers.Append("X-Action-Duration-ms", duration.TotalMilliseconds.ToString());

        Console.WriteLine("After Action");
    }
}