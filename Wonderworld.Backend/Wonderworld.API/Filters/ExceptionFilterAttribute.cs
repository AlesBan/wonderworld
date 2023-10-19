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
                var contextType = context.Exception.InnerException?.GetType() ?? context.Exception.GetType();

                try
                {
                    if (contextType.GetInterfaces().Contains(typeof(IUiException)))
                    {
                        return Handle400Exception(context, controllerName, actionName, contextType);
                    }

                    if (contextType.GetInterfaces().Contains(typeof(IDbException)))
                    {
                        return Handle400Exception(context, controllerName, actionName, contextType);
                    }

                    if (contextType.GetInterfaces().Contains(typeof(IUiForbiddenException)))
                    {
                        return Handle403Exception(context, controllerName, actionName, contextType);
                    }

                    if (contextType.GetInterfaces().Contains(typeof(IServerException)))
                    {
                        return Handle500Exception(context, controllerName, actionName, contextType);
                    }

                    return HandleUnknownException(context, controllerName, actionName, contextType);
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception.Message);
                    return Task.CompletedTask;
                }
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

            private Task Handle403Exception(ExceptionContext context, object controllerName,
                object actionName, MemberInfo contextType)
            {
                LogException(context, controllerName, actionName, contextType);

                var result = ResponseHelper.GetBadRequest(context.Exception.Message);

                context.HttpContext.Response.StatusCode = 403;
                    
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