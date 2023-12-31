﻿// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

#pragma warning disable CS1591

namespace HamedStack.Functional;

public readonly struct Result<T>
{
    private Result(
        T? value,
        ResultStatus status,
        Exception? exception = default,
        string? errorMessage = default,
        Dictionary<string, object?>? metaData = default)
    {
        HasError = status != ResultStatus.Success;
        Value = value;
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
    public T? Value { get; }

    public static Result<T> Conflict(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Conflict, exception, errorMessage, metaData);
    }

    public static Result<T> Conflict(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Conflict, exception, errorMessage, metaData);
    }

    public static Result<T> Failure(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Failure, exception, errorMessage, metaData);
    }

    public static Result<T> Failure(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Failure, exception, errorMessage, metaData);
    }

    public static Result<T> Forbidden(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Forbidden, exception, errorMessage, metaData);
    }

    public static Result<T> Forbidden(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Forbidden, exception, errorMessage, metaData);
    }

    public static Result<T> FromAction(Action action, Func<Exception, Exception> errorMapper)
    {
        try
        {
            action();
            return Success();
        }
        catch (Exception ex)
        {
            return Failure(exception: errorMapper(ex));
        }
    }

    public static Result<T> FromAction(Action action, Func<Exception> errorMapper)
    {
        try
        {
            action();
            return Success();
        }
        catch
        {
            return Failure(exception: errorMapper());
        }
    }

    public static Result<T> Invalid(
                string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Invalid, exception, errorMessage, metaData);
    }

    public static Result<T> Invalid(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Invalid, exception, errorMessage, metaData);
    }

    public static Result<T> NotFound(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.NotFound, exception, errorMessage, metaData);
    }

    public static Result<T> NotFound(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.NotFound, exception, errorMessage, metaData);
    }

    public static Result<T> Success(T? value)
    {
        return new Result<T>(value, ResultStatus.Success);
    }

    public static Result<T> Success()
    {
        return new Result<T>(ResultStatus.Success);
    }

    public static Result<T> Unauthorized(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Unauthorized, exception, errorMessage, metaData);
    }

    public static Result<T> Unauthorized(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Unauthorized, exception, errorMessage, metaData);
    }

    public static Result<T> Unsupported(
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(ResultStatus.Unsupported, exception, errorMessage, metaData);
    }

    public static Result<T> Unsupported(
        T? value,
        string? errorMessage = default,
        Exception? exception = default,
        Dictionary<string, object?>? metaData = default)
    {
        return new Result<T>(value, ResultStatus.Unsupported, exception, errorMessage, metaData);
    }

    public Result<T> AddOrUpdateMetadata(string key, object? value)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

        if (MetaData != null) MetaData[key] = value;
        return new Result<T>(Value, Status, Exception, ErrorMessage, MetaData);
    }

    public Result<TResult> Cast<TResult>()
    {
        if (!IsSuccess)
            return Status switch
            {
                ResultStatus.Conflict => Result<TResult>.Conflict(ErrorMessage, Exception, MetaData),
                ResultStatus.Failure => Result<TResult>.Failure(ErrorMessage, Exception, MetaData),
                ResultStatus.Forbidden => Result<TResult>.Forbidden(ErrorMessage, Exception, MetaData),
                ResultStatus.Invalid => Result<TResult>.Invalid(ErrorMessage, Exception, MetaData),
                ResultStatus.NotFound => Result<TResult>.NotFound(ErrorMessage, Exception, MetaData),
                ResultStatus.Unauthorized => Result<TResult>.Unauthorized(ErrorMessage, Exception, MetaData),
                ResultStatus.Unsupported => Result<TResult>.Unsupported(ErrorMessage, Exception, MetaData),
                _ => throw new InvalidOperationException($"Unknown status: {Status}")
            };

        if (Value is TResult v)
        {
            return Result<TResult>.Success(v);
        }

        return Result<TResult>.Failure($"Failed to cast from type {typeof(T)} to {typeof(TResult)}");
    }

    public Result<TResult> Map<TResult>(Func<T?, TResult> mapper)
    {
        return IsSuccess
            ? Result<TResult>.Success(mapper(Value))
            : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public TResult Match<TResult>(Func<T, TResult> success,
        Func<string?, object?, Dictionary<string, object?>?, TResult> failure)
    {
        return IsSuccess
            ? success(Value!)
            : failure(ErrorMessage, Exception, MetaData);
    }

    public Result<T> Recover(Func<T?, Result<T>> recovery)
    {
        return IsSuccess ? this : recovery(Value);
    }

    public Result<TResult> Select<TResult>(Func<T?, TResult> selector)
    {
        return IsSuccess
            ? Result<TResult>.Success(selector(Value))
            : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public Result<TResult> SelectMany<TResult>(Func<T?, Result<TResult>> selector)
    {
        return IsSuccess ? selector(Value) : Result<TResult>.Failure(ErrorMessage, Exception, MetaData);
    }

    public T? UnwrapOrDefault()
    {
        return IsSuccess ? Value : default;
    }

    public T? UnwrapOrDefault(T? defaultValue)
    {
        return IsSuccess ? Value : defaultValue;
    }

    public T UnwrapOrThrow()
    {
        if (IsSuccess) return Value!;

        throw new InvalidOperationException("Cannot unwrap a failed result.");
    }

    public T UnwrapOrThrow(Func<Exception> exceptionProvider)
    {
        if (IsSuccess)
        {
            return Value!;
        }
        throw exceptionProvider();
    }

    public Result<T> Where(Func<T?, bool> predicate, string? errorMessage = default)
    {
        if (!IsSuccess || !predicate(Value))
        {
            return Failure(ErrorMessage ?? errorMessage, Exception, MetaData);
        }

        return this;
    }
}
