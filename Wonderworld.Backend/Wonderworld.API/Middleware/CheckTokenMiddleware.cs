namespace Wonderworld.API.Middleware;

public class CheckTokenMiddleware:IMiddleware
{
    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        throw new NotImplementedException();
    }
}