// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional.Extensions;

public static class ExceptionalExtensions
{
    public static Exceptional<TResult> Bind<T, TResult>(
        this Exceptional<T> exceptional,
        Func<T, Exceptional<TResult>> func)
    {
        return exceptional.HasValue ? func(exceptional.Value!) : new Exceptional<TResult>(exceptional.Exception!);
    }
    public static Exceptional<TResult> Bind<T, TResult>(
        this Exceptional<T> exceptional,
        Option<TResult> optionResult) where TResult : notnull
    {
        if (!exceptional.HasValue) return new Exceptional<TResult>(exceptional.Exception!);

        return optionResult.IsSome
            ? new Exceptional<TResult>(optionResult.Value!)
            : new Exceptional<TResult>(new InvalidOperationException("The provided Option is None"));
    }

    public static Exceptional<TResult> Bind<T, TResult>(
        this Exceptional<T> exceptional,
        Func<T, Option<TResult>> func) where TResult : notnull
    {
        if (!exceptional.HasValue) return new Exceptional<TResult>(exceptional.Exception!);

        var optionResult = func(exceptional.Value!);

        return optionResult.IsSome
            ? new Exceptional<TResult>(optionResult.Value!)
            : new Exceptional<TResult>(new InvalidOperationException("The function returned None"));
    }

    public static Exceptional<TRight> Flatten<TRight>(this Exceptional<Exceptional<TRight>> exceptional)
    {
        return exceptional.HasException ? new Exceptional<TRight>(exceptional.Exception!) : exceptional.Value;
    }

    public static void ForEach<T>(
        this Exceptional<T> exceptional,
        Action<T> action)
    {
        if (exceptional.HasValue)
        {
            action(exceptional.Value!);
        }
    }
    public static Exceptional<TResult> Map<T, TResult>(
        this Exceptional<T> exceptional,
        Func<T, TResult> func)
    {
        return exceptional.HasValue
            ? new Exceptional<TResult>(func(exceptional.Value!))
            : new Exceptional<TResult>(exceptional.Exception!);
    }


    public static Exceptional<T> MapException<T>(this Exceptional<T> exceptional, Func<Exception, Exception> func)
    {
        return exceptional.HasException ? new Exceptional<T>(func(exceptional.Exception!)) : exceptional;
    }

    public static TResult Match<T, TResult>(
        this Exceptional<T> exceptional,
        Func<T, TResult> onSuccess,
        Func<Exception, TResult> onError)
    {
        return exceptional.HasValue ? onSuccess(exceptional.Value!) : onError(exceptional.Exception!);
    }

    public static Exceptional<T> Recover<T>(this Exceptional<T> exceptional, Func<Exception, T> recoveryFunc)
    {
        if (exceptional.HasValue)
            return exceptional;
        if (exceptional.Exception is not null)
            return new Exceptional<T>(recoveryFunc(exceptional.Exception), null);
        throw new InvalidOperationException("The exceptional neither has a value nor an exception.");
    }

    public static Exceptional<TResult> Select<T, TResult>(this Exceptional<T> exp, Func<T, TResult> f)
        => exp.Map(f);
    public static Either<Exception, T> ToEither<T>(this Exceptional<T> exceptional)
    {
        return exceptional.HasValue
            ? new Either<Exception, T>(null, exceptional.Value)
            : new Either<Exception, T>(exceptional.Exception, default);
    }

    public static Option<T> ToOption<T>(this Exceptional<T> exceptional) where T : notnull
    {
        return exceptional.HasValue ? new Option<T>(exceptional.Value) : Option<T>.None;
    }
}