// ReSharper disable UnusedMember.Global
// ReSharper disable InvalidXmlDocComment
namespace HamedStack.Functional;


/// <summary>
/// Represents the possible status outcomes for a result.
/// </summary>
public enum ResultStatus
{
    /// <summary>
    /// Represents a successful operation.
    /// </summary>
    Ok,

    /// <summary>
    /// Represents a generic error outcome.
    /// </summary>
    Error,

    /// <summary>
    /// Indicates that the operation is forbidden.
    /// </summary>
    Forbidden,

    /// <summary>
    /// Indicates that the operation is unauthorized.
    /// </summary>
    Unauthorized,

    /// <summary>
    /// Indicates invalid input or state.
    /// </summary>
    Invalid,

    /// <summary>
    /// Indicates that a resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    /// Indicates that there's a conflict with the requested operation.
    /// </summary>
    Conflict,

    /// <summary>
    /// Indicates that the operation is unsupported.
    /// </summary>
    Unsupported
}

public class Result
{
    protected Result() { }

    public object? ErrorData { get; protected set; }
    public string ErrorMessage { get; protected set; } = string.Empty;
    public Dictionary<string, object?> Metadata { get; } = new();
    public bool IsFailure => !IsSuccess;
    public bool IsSuccess => Status == ResultStatus.Ok;
    public ResultStatus Status { get; protected set; }
    public static Result Conflict(string message, object? errorData = null) => From(ResultStatus.Conflict, message, errorData);

    public static Result Error(string message, object? errorData = null) => From(ResultStatus.Error, message, errorData);

    public static Result Forbidden(string message, object? errorData = null) => From(ResultStatus.Forbidden, message, errorData);

    public static Result From(ResultStatus status, string errorMessage = "", object? errorData = null)
    {
        return new Result
        {
            Status = status,
            ErrorMessage = errorMessage,
            ErrorData = errorData
        };
    }
    public Result AddOrUpdateMetadata(string key, object? value)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        Metadata[key] = value;
        return this;
    }
    public static Result Invalid(string message, object? errorData = null) => From(ResultStatus.Invalid, message, errorData);

    public static Result NotFound(string message, object? errorData = null) => From(ResultStatus.NotFound, message, errorData);

    public static Result Ok() => From(ResultStatus.Ok);
    public static Result Unauthorized(string message, object? errorData = null) => From(ResultStatus.Unauthorized, message, errorData);
    public static Result Unsupported(string message, object? errorData = null) => From(ResultStatus.Unauthorized, message, errorData);
}


public class Result<T> : Result
{
    public T Value { get; private set; } = default!;

    public new static Result<T> Conflict(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Conflict,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public new static Result<T> Error(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Error,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public new static Result<T> Forbidden(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Forbidden,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public static Result<T> From(T value)
    {
        return new Result<T>
        {
            Status = ResultStatus.Ok,
            Value = value
        };
    }
    public new static Result<T> Invalid(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Invalid,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public new static Result<T> NotFound(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.NotFound,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public static Result<T> Ok(T value)
    {
        return Result<T>.From(value);
    }

    public new static Result<T> Unauthorized(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Unauthorized,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }

    public new static Result<T> Unsupported(string message, object? errorData = null)
    {
        return new Result<T>
        {
            Status = ResultStatus.Unsupported,
            ErrorMessage = message,
            ErrorData = errorData
        };
    }
}

public static class ResultExtensions
{
    public static Result<IEnumerable<T>> Aggregate<T>(this IEnumerable<Result<T>> results)
    {
        var resultArray = results.ToArray();
        foreach (var result in resultArray)
        {
            if (result.IsFailure)
            {
                return Result<IEnumerable<T>>.Error(result.ErrorMessage);
            }
        }
        return Result<IEnumerable<T>>.Ok(resultArray.Select(r => r.Value));
    }

    public static Result AsVoid<T>(this Result<T> result)
    {
        return result.IsSuccess ? Result.Ok() : Result.Error(result.ErrorMessage, result.ErrorData);
    }

    public static Result<U> Bind<T, U>(this Result<T> result, Func<T, Result<U>> func)
    {
        if (result.IsFailure) return Result<U>.Error(result.ErrorMessage, result.ErrorData);
        return func(result.Value);
    }

    public static Result Combine(this IEnumerable<Result> results, string separator = ", ")
    {
        var failures = results.Where(r => r.IsFailure).ToList();
        if (!failures.Any()) return Result.Ok();

        var combinedMessage = string.Join(separator, failures.Select(f => f.ErrorMessage));
        return Result.Error(combinedMessage);
    }

    public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
    {
        if (result.IsFailure) return result;
        if (!predicate(result.Value)) return Result<T>.Error(errorMessage);
        return result;
    }

    public static Result<T> Finally<T>(this Result<T> result, Action<Result<T>> action)
    {
        action(result);
        return result;
    }
    public static Result Flatten(this Result<Result> result)
    {
        return result.IsFailure ? result : result.Value;
    }

    public static T GetValueOrDefault<T>(this Result<T> result, T defaultValue = default!)
    {
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<T2> Join<T1, T2>(this Result<T1> first, Result<T2> second)
    {
        if (first.IsFailure) return Result<T2>.Error(first.ErrorMessage, first.ErrorData);
        if (second.IsFailure) return Result<T2>.Error(second.ErrorMessage, second.ErrorData);
        return second;
    }

    public static Result<U> Map<T, U>(this Result<T> result, Func<T, U> func)
    {
        if (result.IsFailure) return Result<U>.Error(result.ErrorMessage, result.ErrorData);
        return Result<U>.From(func(result.Value));
    }

    public static Result<T> MapError<T>(this Result<T> result, Func<string, string> func)
    {
        if (result.IsSuccess) return result;
        return Result<T>.Error(func(result.ErrorMessage), result.ErrorData);
    }

    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn, TOut> onSuccess, Func<string, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.ErrorMessage);
    }

    public static Result<T> OnFailure<T>(this Result result, Func<T> func)
    {
        if (result.IsSuccess) return Result<T>.From(func());
        return Result<T>.Error(result.ErrorMessage, result.ErrorData);
    }

    public static Result OnFailure(this Result result, Action action)
    {
        if (result.IsSuccess) return result;
        action();
        return result;
    }

    public static Result<T> OnSuccess<T>(this Result result, Func<T> func)
    {
        if (result.IsFailure) return Result<T>.Error(result.ErrorMessage, result.ErrorData);
        return Result<T>.From(func());
    }

    public static Result OnSuccess(this Result result, Action action)
    {
        if (result.IsFailure) return result;
        action();
        return Result.Ok();
    }
    public static Result<T> Switch<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> ifTrue, Func<T, Result<T>> ifFalse)
    {
        if (result.IsFailure) return result;

        return predicate(result.Value) ? ifTrue(result.Value) : ifFalse(result.Value);
    }

    public static Result<T> Tap<T>(this Result<T> result, Action<Result<T>> action)
    {
        action(result);
        return result;
    }

    public static Result<T> Tee<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess) action(result.Value);
        return result;
    }

    public static Result Tee(this Result result, Action action)
    {
        action();
        return result;
    }
    public static Result<TOut> Then<TIn, TOut>(this Result<TIn> result, Func<TIn, Result<TOut>> thenFunc)
    {
        return result.Bind(thenFunc);
    }

    public static Option<T> ToOption<T>(this Result<T> result) where T : notnull
    {
        return result.IsSuccess
            ? Option<T>.Some(result.Value)
            : Option<T>.None;
    }

    public static Result<T> ToResult<T>(this Result result, T defaultValue)
    {
        if (result.IsFailure) return Result<T>.Error(result.ErrorMessage, result.ErrorData);
        return Result<T>.From(defaultValue);
    }

    public static T? ToValueOrDefault<T>(this Result<T> result, T? defaultValue = default)
    {
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<T> Unwrap<T>(this Result<Result<T>> result)
    {
        if (result.IsFailure) return Result<T>.Error(result.ErrorMessage, result.ErrorData);
        return result.Value;
    }
    public static T UnwrapOr<T>(this Result<T> result, T alternative)
    {
        return result.IsSuccess ? result.Value : alternative;
    }

    public static Result<T> WithValue<T>(this Result result, T value)
    {
        return result.IsSuccess ? Result<T>.Ok(value) : Result<T>.Error(result.ErrorMessage, result.ErrorData);
    }

    public static Result<T> WrapErrorWith<T>(this Result result, Func<string, T> wrapFunc)
    {
        return result.IsFailure
            ? Result<T>.Error(result.ErrorMessage, wrapFunc(result.ErrorMessage))
            : Result<T>.Error(result.ErrorMessage);
    }
}