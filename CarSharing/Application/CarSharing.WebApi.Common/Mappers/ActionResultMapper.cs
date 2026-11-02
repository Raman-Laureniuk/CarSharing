namespace CarSharing.WebApi.Common.Mappers
{
    using System;
    using CarSharing.Domain.Tools.Result;
    using Microsoft.AspNetCore.Mvc;

    public static class ActionResultMapper
    {
        public static ActionResult<TResponseMessage> ToActionResult<T, TResponseMessage>(this Result<T> result, Func<T, TResponseMessage> mapperFunc)
        {
            ArgumentNullException.ThrowIfNull(result);
            ArgumentNullException.ThrowIfNull(mapperFunc);

            return result.IsSuccess
                ? new OkObjectResult(mapperFunc(result.Value))
                : result.ErrorDetails.ErrorType switch
                {
                    ErrorType.Unknown      => new BadRequestObjectResult         (result.ErrorDetails.Message),
                    ErrorType.Validation   => new UnprocessableEntityObjectResult(result.ErrorDetails.Message),
                    ErrorType.NotFound     => new NotFoundObjectResult           (result.ErrorDetails.Message),
                    ErrorType.Unauthorized => new UnauthorizedObjectResult       (result.ErrorDetails.Message),
                    ErrorType.Conflict     => new ConflictObjectResult           (result.ErrorDetails.Message),

                    _                      => throw new ArgumentOutOfRangeException(nameof(result.ErrorDetails.ErrorType))
                };
        }

    }
}
