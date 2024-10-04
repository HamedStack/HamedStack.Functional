// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional;

/// <summary>
/// Represents a computation that might succeed or fail with an exception.
/// </summary>
/// <typeparam name="T">The type of the result.</typeparam>
public readonly struct Exceptional<T>
{
    private readonly T? _value;
    private readonly Exception? _exception;

    /// <summary>
    /// Indicates whether the computation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Indicates whether the computation failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    private Exceptional(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        _exception = default;
        IsSuccess = true;
    }

    private Exceptional(Exception exception)
    {
        _exception = exception ?? throw new ArgumentNullException(nameof(exception));
        _value = default;
        IsSuccess = false;
    }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <param name="value">The result value.</param>
    /// <returns>An Exceptional containing the value.</returns>
    public static Exceptional<T> Success(T value) => new(value);

    /// <summary>
    /// Creates a failed result.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <returns>An Exceptional containing the exception.</returns>
    public static Exceptional<T> Failure(Exception exception) => new(exception);

    /// <summary>
    /// Matches the Exceptional to a value based on its state.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <param name="success">Function to execute if successful.</param>
    /// <param name="failure">Function to execute if failed.</param>
    /// <returns>The result of the executed function.</returns>
    public TResult Match<TResult>(Func<T, TResult> success, Func<Exception, TResult> failure)
    {
        if (success is null) throw new ArgumentNullException(nameof(success));
        if (failure is null) throw new ArgumentNullException(nameof(failure));
        return IsSuccess ? success(_value!) : failure(_exception!);
    }

    /// <summary>
    /// Transforms the result value if the computation was successful.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <param name="mapper">The transformation function.</param>
    /// <returns>An Exceptional containing the transformed value or the exception.</returns>
    public Exceptional<TResult> Map<TResult>(Func<T, TResult> mapper)
    {
        if (mapper is null) throw new ArgumentNullException(nameof(mapper));
        return IsSuccess ? Exceptional<TResult>.Success(mapper(_value!)) : Exceptional<TResult>.Failure(_exception!);
    }

    /// <summary>
    /// Binds the result value to another Exceptional computation.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <param name="binder">The binding function.</param>
    /// <returns>The result of the binding function or the exception.</returns>
    public Exceptional<TResult> Bind<TResult>(Func<T, Exceptional<TResult>> binder)
    {
        if (binder is null) throw new ArgumentNullException(nameof(binder));
        return IsSuccess ? binder(_value!) : Exceptional<TResult>.Failure(_exception!);
    }

    /// <summary>
    /// Implicitly converts a value to an Exceptional.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator Exceptional<T>(T value) => Success(value);

    /// <summary>
    /// Implicitly converts an Exception to an Exceptional.
    /// </summary>
    /// <param name="exception">The exception.</param>
    public static implicit operator Exceptional<T>(Exception exception) => Failure(exception);

    /// <summary>
    /// Maps the value of a successful computation to a new form using the specified selector function.
    /// </summary>
    /// <typeparam name="TResult">The type of the transformed value.</typeparam>
    /// <param name="selector">The transformation function.</param>
    /// <returns>An <see cref="Exceptional{TResult}"/> with the transformed value or the original exception if the computation failed.</returns>
    public Exceptional<TResult> Select<TResult>(Func<T, TResult> selector) => Map(selector);

    /// <summary>
    /// Projects the value of a successful computation into a new form using the specified selector and result selector functions.
    /// </summary>
    /// <typeparam name="TIntermediate">The type of the intermediate computation value.</typeparam>
    /// <typeparam name="TResult">The type of the final result value.</typeparam>
    /// <param name="selector">The function to apply to the value to obtain the intermediate computation.</param>
    /// <param name="resultSelector">The function to combine the value and intermediate result to obtain the final result.</param>
    /// <returns>An <see cref="Exceptional{TResult}"/> based on the combined selector functions or the original exception if the computation failed.</returns>
    public Exceptional<TResult> SelectMany<TIntermediate, TResult>(
        Func<T, Exceptional<TIntermediate>> selector,
        Func<T, TIntermediate, TResult> resultSelector)
    {
        return Bind(value => selector(value).Map(intermediate => resultSelector(value, intermediate)));
    }
}