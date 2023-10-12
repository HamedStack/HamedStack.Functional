// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable CS1591

namespace HamedStack.Functional;

public readonly struct Result
{
    private Result(
        object? value,
        ResultStatus status,
        Exception? exception = default,
        string? errorMessage = default,
        Dictionary<string, object?>? metaData = default)
    {
        Value = value;
        HasError = status != ResultStatus.Success;
        IsSuccess = status == ResultStatus.Success;
        IsFailure = status == ResultStatus.Failure;
        IsConflict = status == ResultStatus.Conflict;
        IsInvalid = status == ResultStatus.Invalid;
        IsForbidden = status == ResultStatus.Forbidden;
        IsUnauthorized = status == ResultStatus.Unauthorized;
        IsUnsupported = status == ResultStatus.Unsupported;
        IsNotFound = status == ResultStatus.NotFound;
        Status = status;
        Exception = exception;
        ErrorMessage = errorMessage;
        MetaData = metaData;
    }

    private Result(
        ResultStatus status,
        Exception? exception = default,
        string? errorMessage = default,
        Dictionary<string, object?>? metaData = default)
    {
        HasError = status != ResultStatus.Success;
        IsSuccess = status == ResultStatus.Success;
        IsFailure = status == ResultStatus.Failure;
        IsConflict = status == ResultStatus.Conflict;
        IsInvalid = status == ResultStatus.Invalid;
        IsForbidden = status == ResultStatus.Forbidden;
        IsUnauthorized = status == ResultStatus.Unauthorized;
        IsUnsupported = status == ResultStatus.Unsupported;
        IsNotFound = status == ResultStatus.NotFound;
        Status = status;
        Exception = exception;
        ErrorMessage = errorMessage;
        MetaData = metaData;
        Value = default;
    }

    public string? ErrorMessage { get; }
    public Exception? Exception { get; }
    public bool HasError { get; }
    public bool IsConflict { get; }
    public bool IsFailure { get; }
    public bool IsForbidden { get; }
    public bool IsInvalid { get; }
    public bool IsNotFound { get; }
    public bool IsSuccess { get; }
    public bool IsUnauthorized { get; }
    public bool IsUnsupported { get; }
    public Dictionary<string, object?>? MetaData { get; }
    public ResultStatus Status { get; }
    public object? Value { get; }
    public static Result Conflict(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Conflict, exception, errorMessage, metaData);
    }

    public static Result Conflict(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Conflict, exception, errorMessage, metaData);
    }

    public static Result Failure(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Failure, exception, errorMessage, metaData);
    }

    public static Result Failure(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Failure, exception, errorMessage, metaData);
    }

    public static Result Forbidden(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Forbidden, exception, errorMessage, metaData);
    }

    public static Result Forbidden(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Forbidden, exception, errorMessage, metaData);
    }

    public static Result FromAction(Action action, Func<Exception, Exception> errorMapper)
    {
        try
        {
            action();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(errorMapper(ex));
        }
    }

    public static Result FromAction(Action action, Func<Exception> errorMapper)
    {
        try
        {
            action();
            return Success();
        }
        catch
        {
            return Failure(errorMapper());
        }
    }

    public static Result Invalid(
                string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Invalid, exception, errorMessage, metaData);
    }

    public static Result Invalid(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Invalid, exception, errorMessage, metaData);
    }

    public static Result NotFound(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.NotFound, exception, errorMessage, metaData);
    }

    public static Result NotFound(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.NotFound, exception, errorMessage, metaData);
    }

    public static Result Success(object? value)
    {
        return new Result(value, ResultStatus.Success);
    }

    public static Result Success()
    {
        return new Result(ResultStatus.Success);
    }
    public static Result Unauthorized(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Unauthorized, exception, errorMessage, metaData);
    }
    public static Result Unauthorized(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Unauthorized, exception, errorMessage, metaData);
    }

    public static Result Unsupported(
            string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(ResultStatus.Unsupported, exception, errorMessage, metaData);
    }
    public static Result Unsupported(
        object? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result(value, ResultStatus.Unsupported, exception, errorMessage, metaData);
    }

    public Result AddOrUpdateMetadata(string key, object? value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

        if (MetaData != null) MetaData[key] = value;
        return new Result(Value, Status, Exception, ErrorMessage, MetaData);
    }

    public Result<TResult> Map<TResult>(Func<object?, TResult> mapper)
    {
        return IsSuccess
            ? Result<TResult>.Success(mapper(Value))
            : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public TResult Match<TResult>(Func<object, TResult> success,
                Func<string?, object?, Dictionary<string, object?>?, TResult> failure)
    {
        return IsSuccess
            ? success(Value!)
            : failure(ErrorMessage, Exception, MetaData);
    }
    public Result Recover(Func<Result> recovery)
    {
        return IsSuccess ? this : recovery();
    }

    public Result<TResult> Select<TResult>(Func<object?, TResult> selector)
    {
        return IsSuccess
            ? Result<TResult>.Success(selector(Value))
            : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public Result<TResult> SelectMany<TResult>(Func<object?, Result<TResult>> selector)
    {
        return IsSuccess ? selector(Value) : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public Result Where(Func<object?, bool> predicate, string? errorMessage = default)
    {
        if (!IsSuccess || !predicate(Value))
        {
            return Failure(errorMessage ?? ErrorMessage, Exception, MetaData);
        }

        return this;
    }
}