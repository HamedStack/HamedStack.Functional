// ReSharper disable UnusedMember.Global
// ReSharper disable GrammarMistakeInComment
// ReSharper disable ConvertClosureToMethodGroup
namespace HamedStack.Functional.Extensions;
/// <summary>
/// Extension methods for converting between Either, Exceptional, Option, and Validation types.
/// </summary>
public static class FunctionalExtensions
{
    /// <summary>
    /// Converts an <see cref="Either{TLeft, TRight}"/> instance to an <see cref="Exceptional{T}"/> instance.
    /// </summary>
    /// <typeparam name="TLeft">The type of the Left value.</typeparam>
    /// <typeparam name="TRight">The type of the Right value.</typeparam>
    /// <param name="either">The Either instance to convert.</param>
    /// <returns>An Exceptional instance that is successful if the Either was a Right, or failed if it was a Left.</returns>
    public static Exceptional<TRight> ToExceptional<TLeft, TRight>(this Either<TLeft, TRight> either)
    {
        return either.Match<Exceptional<TRight>>(
            left => new ArgumentException($"Expected Right but got Left: {left}"),
            right => Exceptional<TRight>.Success(right)
        );
    }

    /// <summary>
    /// Converts an <see cref="Exceptional{T}"/> instance to an <see cref="Either{TLeft, TRight}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the successful value.</typeparam>
    /// <param name="exceptional">The Exceptional instance to convert.</param>
    /// <returns>An Either instance where Left represents the exception and Right represents a successful value.</returns>
    public static Either<Exception, T> ToEither<T>(this Exceptional<T> exceptional)
    {
        return exceptional.Match(
            success => Either<Exception, T>.Right(success),
            failure => Either<Exception, T>.Left(failure)
        );
    }

    /// <summary>
    /// Converts an <see cref="Option{T}"/> instance to an <see cref="Either{TLeft, TRight}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Option.</typeparam>
    /// <param name="option">The Option instance to convert.</param>
    /// <param name="noneMessage">The message to use if the Option is None.</param>
    /// <returns>An Either instance with a Left containing the specified message or a Right containing the value.</returns>
    public static Either<string, T> ToEither<T>(this Option<T> option, string noneMessage = "None value")
    {
        return option.Match(
            some => Either<string, T>.Right(some),
            () => Either<string, T>.Left(noneMessage)
        );
    }

    /// <summary>
    /// Converts an <see cref="Either{TLeft, TRight}"/> instance to an <see cref="Option{T}"/> instance.
    /// </summary>
    /// <typeparam name="TLeft">The type of the Left value.</typeparam>
    /// <typeparam name="TRight">The type of the Right value.</typeparam>
    /// <param name="either">The Either instance to convert.</param>
    /// <returns>An Option instance with Some if the Either was Right, or None if the Either was Left.</returns>
    public static Option<TRight> ToOption<TLeft, TRight>(this Either<TLeft, TRight> either)
    {
        return either.Match(
            left => Option<TRight>.None,
            right => Option<TRight>.Some(right)
        );
    }

    /// <summary>
    /// Converts a <see cref="Validation{T}"/> instance to an <see cref="Either{TLeft, TRight}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the successful value in Validation.</typeparam>
    /// <param name="validation">The Validation instance to convert.</param>
    /// <returns>An Either instance with Left containing the errors or Right containing the successful value.</returns>
    public static Either<IReadOnlyList<string>, T> ToEither<T>(this Validation<T> validation)
    {
        return validation.Match(
            success => Either<IReadOnlyList<string>, T>.Right(success),
            errors => Either<IReadOnlyList<string>, T>.Left(errors)
        );
    }

    /// <summary>
    /// Converts an <see cref="Either{TLeft, TRight}"/> instance to a <see cref="Validation{T}"/> instance.
    /// </summary>
    /// <typeparam name="TLeft">The type of the Left value in Either.</typeparam>
    /// <typeparam name="TRight">The type of the Right value in Either.</typeparam>
    /// <param name="either">The Either instance to convert.</param>
    /// <returns>A Validation instance with a successful value if the Either was Right, or failure if it was Left.</returns>
    public static Validation<TRight> ToValidation<TLeft, TRight>(this Either<TLeft, TRight> either)
    {
        return either.Match(
            left => Validation<TRight>.Failure(left?.ToString() ?? "Left value"),
            right => Validation<TRight>.Success(right)
        );
    }

    /// <summary>
    /// Converts an <see cref="Option{T}"/> instance to a <see cref="Validation{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Option.</typeparam>
    /// <param name="option">The Option instance to convert.</param>
    /// <param name="noneMessage">The message to use if the Option is None.</param>
    /// <returns>A Validation instance representing success or failure based on the Option value.</returns>
    public static Validation<T> ToValidation<T>(this Option<T> option, string noneMessage = "None value")
    {
        return option.Match(
            some => Validation<T>.Success(some),
            () => Validation<T>.Failure(noneMessage)
        );
    }

    /// <summary>
    /// Converts a <see cref="Validation{T}"/> instance to an <see cref="Option{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the successful value in Validation.</typeparam>
    /// <param name="validation">The Validation instance to convert.</param>
    /// <returns>An Option instance representing Some if Validation is successful, otherwise None.</returns>
    public static Option<T> ToOption<T>(this Validation<T> validation)
    {
        return validation.Match(
            success => Option<T>.Some(success),
            errors => Option<T>.None
        );
    }

    /// <summary>
    /// Converts an <see cref="Exceptional{T}"/> instance to an <see cref="Option{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Exceptional.</typeparam>
    /// <param name="exceptional">The Exceptional instance to convert.</param>
    /// <returns>An Option instance representing Some if the Exceptional is successful, otherwise None.</returns>
    public static Option<T> ToOption<T>(this Exceptional<T> exceptional)
    {
        return exceptional.Match(
            success => Option<T>.Some(success),
            failure => Option<T>.None
        );
    }

    /// <summary>
    /// Converts an <see cref="Option{T}"/> instance to an <see cref="Exceptional{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Option.</typeparam>
    /// <param name="option">The Option instance to convert.</param>
    /// <param name="exception">The exception to use if Option is None.</param>
    /// <returns>An Exceptional instance representing success or failure based on the Option value.</returns>
    public static Exceptional<T> ToExceptional<T>(this Option<T> option, Exception exception)
    {
        return option.Match(
            some => Exceptional<T>.Success(some),
            () => Exceptional<T>.Failure(exception)
        );
    }

    /// <summary>
    /// Converts a <see cref="Validation{T}"/> instance to an <see cref="Exceptional{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the successful value in Validation.</typeparam>
    /// <param name="validation">The Validation instance to convert.</param>
    /// <returns>An Exceptional instance representing success or failure based on the Validation value.</returns>
    public static Exceptional<T> ToExceptional<T>(this Validation<T> validation)
    {
        return validation.Match(
            success => Exceptional<T>.Success(success),
            errors => Exceptional<T>.Failure(new AggregateException(errors.Select(e => new Exception(e))))
        );
    }

    /// <summary>
    /// Converts an <see cref="Exceptional{T}"/> instance to a <see cref="Validation{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Exceptional.</typeparam>
    /// <param name="exceptional">The Exceptional instance to convert.</param>
    /// <returns>A Validation instance representing success or failure based on the Exceptional value.</returns>
    public static Validation<T> ToValidation<T>(this Exceptional<T> exceptional)
    {
        return exceptional.Match(
            success => Validation<T>.Success(success),
            failure => Validation<T>.Failure(failure.Message)
        );
    }
}
