namespace CarSharing.WebApi.Common.Mappers
{
    using System;
    using CarSharing.Domain.Tools.Result;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public static class ActionResultMapper
    {
        public static IActionResult ToActionResult(this Result result)
        {
            ArgumentNullException.ThrowIfNull(result);

            return result.IsSuccess ? new OkResult()
                                    : CreateObjectResult(result.ErrorDetails);
        }
        
        public static ActionResult<TResponseMessage> ToActionResult<T, TResponseMessage>(this Result<T> result, Func<T, TResponseMessage> mapperFunc)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(mapperFunc);

            return result.IsSuccess
                ? new OkObjectResult(mapperFunc(result.Value))
                : CreateObjectResult(result.ErrorDetails);
        }

        private static ObjectResult CreateObjectResult(ErrorDetails errorDetails)
        {
            ProblemDetails problemDetails = CreateProblemDetails(errorDetails);

            return new ObjectResult(problemDetails)
            {
                StatusCode = problemDetails.Status
            };
        }
        
        private static ProblemDetails CreateProblemDetails(ErrorDetails errorDetails)
        {
            ArgumentNullException.ThrowIfNull(errorDetails);
            
            int status = errorDetails.ErrorType switch
            {
                ErrorType.Unknown      => StatusCodes.Status400BadRequest,
                ErrorType.Validation   => StatusCodes.Status422UnprocessableEntity,
                ErrorType.NotFound     => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Conflict     => StatusCodes.Status409Conflict,
                _                      => throw new ArgumentOutOfRangeException(nameof(errorDetails.ErrorType))
            };

            return new ProblemDetails()
            {
                Status = errorDetails.ErrorType.ToStatusCode(),
                Title  = errorDetails.ErrorType.ToTitle(),
                Detail = errorDetails.Message
            };
        }

        private static int ToStatusCode(this ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Unknown      => StatusCodes.Status400BadRequest,
                ErrorType.Validation   => StatusCodes.Status422UnprocessableEntity,
                ErrorType.NotFound     => StatusCodes.Status404NotFound,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Conflict     => StatusCodes.Status409Conflict,
                _                      => throw new ArgumentOutOfRangeException(nameof(errorType))
            };
        }

        private static string ToTitle(this ErrorType errorType)
        {
            return errorType switch
            {
                ErrorType.Unknown      => "Unknown Error",
                ErrorType.Validation   => "Validation Error",
                ErrorType.NotFound     => "Resource Not Found",
                ErrorType.Unauthorized => "Unauthorized",
                ErrorType.Conflict     => "Conflict",
                _                      => throw new ArgumentOutOfRangeException(nameof(errorType))
            };
        }
    }
}
