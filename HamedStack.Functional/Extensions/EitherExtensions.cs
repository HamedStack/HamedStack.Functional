// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional.Extensions;

public static class EitherExtensions
{
    public static Either<TLeft, TResult> Bind<TLeft, TRight, TResult>(
        this Either<TLeft, TRight> either,
        Func<TRight, Either<TLeft, TResult>> binder)
    {
        return either.IsRight ? binder(either.Right!) : new Either<TLeft, TResult>(either.Left, default);
    }
    public static void ForEachLeft<TLeft, TRight>(
        this Either<TLeft, TRight> either,
        Action<TLeft> action)
    {
        if (either.IsLeft)
        {
            action(either.Left!);
        }
    }

    public static void ForEachRight<TLeft, TRight>(
        this Either<TLeft, TRight> either,
        Action<TRight> action)
    {
        if (either.IsRight)
        {
            action(either.Right!);
        }
    }

    public static TLeft GetLeftOr<TLeft, TRight>(this Either<TLeft, TRight> either, TLeft defaultValue)
    {
        return either.IsLeft ? either.Left! : defaultValue;
    }

    public static TRight GetRightOr<TLeft, TRight>(this Either<TLeft, TRight> either, TRight defaultValue)
    {
        return either.IsRight ? either.Right! : defaultValue;
    }

    public static Option<TLeft> LeftProjection<TLeft, TRight>(this Either<TLeft, TRight> either) where TLeft : notnull
    {
        return either.Left is not null ? new Option<TLeft>(either.Left) : Option<TLeft>.None;
    }

    public static Either<TResult, TRight> MapLeft<TLeft, TRight, TResult>(
        this Either<TLeft, TRight> either,
        Func<TLeft, TResult> func)
    {
        return either.IsLeft
            ? new Either<TResult, TRight>(func(either.Left!), default)
            : new Either<TResult, TRight>(default, either.Right);
    }

    public static Either<TLeft, TResult> MapRight<TLeft, TRight, TResult>(
        this Either<TLeft, TRight> either,
        Func<TRight, TResult> func)
    {
        return either.IsRight
            ? new Either<TLeft, TResult>(default, func(either.Right!))
            : new Either<TLeft, TResult>(either.Left, default);
    }

    public static Option<TRight> RightProjection<TLeft, TRight>(this Either<TLeft, TRight> either) where TRight : notnull
    {
        return either.Right is not null ? new Option<TRight>(either.Right) : Option<TRight>.None;
    }

    public static Either<TRight, TLeft> Swap<TLeft, TRight>(this Either<TLeft, TRight> either)
    {
        return either.IsRight
            ? new Either<TRight, TLeft>(either.Right, default)
            : new Either<TRight, TLeft>(default, either.Left);
    }
    public static Exceptional<TRight> ToExceptional<TLeft, TRight>(this Either<TLeft, TRight> either, Exception fallbackException) where TRight : notnull
    {
        return either.IsRight
            ? new Exceptional<TRight>(either.Right, null)
            : new Exceptional<TRight>(default, fallbackException);
    }
    public static Option<TRight> ToOption<TLeft, TRight>(this Either<TLeft, TRight> either) where TRight : notnull
    {
        return either.IsRight ? new Option<TRight>(either.Right) : Option<TRight>.None;
    }
}