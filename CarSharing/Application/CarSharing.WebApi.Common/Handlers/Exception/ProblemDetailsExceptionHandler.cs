namespace CarSharing.WebApi.Common.Handlers.Exception
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ProblemDetailsExceptionHandler : IExceptionHandler
    {
        private readonly IProblemDetailsService _problemDetailsService;

        public ProblemDetailsExceptionHandler(IProblemDetailsService problemDetailsService)
        {
            _problemDetailsService = problemDetailsService ?? throw new ArgumentNullException(nameof(problemDetailsService));
        }
        
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            //httpContext.Request.Headers["Accept"] = @"application/json";  // For testing only

            bool handled = await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
            {
                HttpContext    = httpContext,
                ProblemDetails = new ProblemDetails()
                {
                    Status   = StatusCodes.Status500InternalServerError,
                    Title    = "Server Error",
                    Detail   = exception.Message,
                    Instance = httpContext.Request.Path
                }
            });

            return handled;
        }
    }
}
