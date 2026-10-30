namespace CarSharing.Domain.Tools.Result
{
    using System;

    public class Result
    {
        public bool         IsSuccess    { get; }
        public ErrorDetails ErrorDetails { get; }

        protected Result(bool isSuccess, ErrorDetails errorDetails)
        {
            if (isSuccess == true ^ errorDetails == default)
            {
                throw new ArgumentException("Successful result must not have error details. Unsuccessful result must.");
            }

            IsSuccess    = isSuccess;
            ErrorDetails = errorDetails;
        }

        public static Result Success()                          => new Result(true,  default);
        public static Result Error  (ErrorDetails errorDetails) => new Result(false, errorDetails);

        public static implicit operator Result(ErrorDetails errorDetails) => Error(errorDetails);
    }

    public class Result<T> : Result
    {
        public T Value { get; }

        protected Result(bool isSuccess, ErrorDetails errorDetails, T value) : base(isSuccess, errorDetails)
        {
            Value = value;
        }

        public static     Result<T> Success(T value)                   => new Result<T>(true,  default,      value);
        public static new Result<T> Error  (ErrorDetails errorDetails) => new Result<T>(false, errorDetails, default);

        public static implicit operator Result<T>(T value)                   => Success(value);
        public static implicit operator Result<T>(ErrorDetails errorDetails) => Error  (errorDetails);
    }
}
