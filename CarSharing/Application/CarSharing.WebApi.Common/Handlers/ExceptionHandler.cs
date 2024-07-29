namespace CarSharing.WebApi.Common.Handlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;

    public class ExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var error = new
            {
                Exception = exception.Message
            };

            await httpContext.Response.WriteAsJsonAsync(error, cancellationToken);
            
            return true;
        }
    }
}
