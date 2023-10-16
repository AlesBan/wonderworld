using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wonderworld.API.Helpers;
using Wonderworld.Application.Interfaces.Exceptions;
using ExceptionContext = Microsoft.AspNetCore.Mvc.Filters.ExceptionContext;

namespace Wonderworld.API.Filters
{
    public class ExceptionFilterAttribute : TypeFilterAttribute
    {
        public ExceptionFilterAttribute() : base(typeof(ExceptionFilterImplementation))
        {
        }

        private class ExceptionFilterImplementation : IAsyncExceptionFilter
        {
            private readonly ILogger<ExceptionFilterImplementation> _logger;

            public ExceptionFilterImplementation(ILogger<ExceptionFilterImplementation> logger)
            {
                _logger = logger;
            }

            public Task OnExceptionAsync(ExceptionContext context)
            {
                var controllerName = context.RouteData.Values["controller"]?.ToString() ?? string.Empty;
                var actionName = context.RouteData.Values["action"]?.ToString() ?? string.Empty;
                var contextType = context.Exception.InnerException?.GetType();

                return contextType!.GetInterfaces().First() switch
                {
                    IUiException => Handle400Exception(context, controllerName, actionName, contextType),
                    IDbException => Handle400Exception(context, controllerName, actionName, contextType),
                    IServerException => Handle500Exception(context, controllerName, actionName, contextType),
                    _ => HandleUnknownException(context, controllerName, actionName, contextType)
                };
            }

            private Task Handle400Exception(ExceptionContext context, object controllerName,
                object actionName, MemberInfo contextType)
            {
                LogException(context, controllerName, actionName, contextType);

                var result = ResponseHelper.GetBadRequest(context.Exception.Message);

                context.HttpContext.Response.StatusCode = 400;

                context.Result = result;
                context.ExceptionHandled = true;

                return Task.CompletedTask;
            }

            private Task Handle500Exception(ExceptionContext context, object controllerName,
                object actionName, MemberInfo contextType)
            {
                LogException(context, controllerName, actionName, contextType);

                context.HttpContext.Response.StatusCode = 500;

                context.Result = new StatusCodeResult(500);
                context.ExceptionHandled = true;

                return Task.CompletedTask;
            }

            private Task HandleUnknownException(ExceptionContext context, object controllerName,
                object actionName, MemberInfo contextType)
            {
                context.HttpContext.Response.StatusCode = 500;

                context.Result = new StatusCodeResult(500);
                
                _logger.LogError("Unhandled exception\n");
                LogException(context, controllerName, actionName, contextType);

                context.ExceptionHandled = true;

                return Task.CompletedTask;
            }

            private void LogException(ExceptionContext context, object controllerName,
                object actionName, MemberInfo contextType)
            {
                _logger.LogError($"\tController: {controllerName}\n" +
                                 $"\tAction: {actionName}\n" +
                                 $"\tExceptionName: {contextType.Name}\n" +
                                 $"\tMessage: {context.Exception.Message}");
            }
        }
    }
}