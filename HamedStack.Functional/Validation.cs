// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional;

/// <summary>
/// Represents a result of a validation operation that can either be a success or a failure.
/// </summary>
/// <typeparam name="T">The type of the value being validated.</typeparam>
public readonly struct Validation<T>
{
    private readonly T? _value;
    private readonly IReadOnlyList<string>? _errors;

    /// <summary>
    /// Indicates whether the validation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Indicates whether the validation failed.
    /// </summary>
    public bool IsFailure => !IsSuccess;

    /// <summary>
    /// Gets the collection of errors if the validation failed.
    /// If the validation was successful, returns an empty list.
    /// </summary>
    public IReadOnlyList<string> Errors => _errors ?? Array.Empty<string>();

    /// <summary>
    /// Initializes a successful validation with a specified value.
    /// </summary>
    /// <param name="value">The value of the successful validation.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="value"/> is null.</exception>
    private Validation(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value));
        _errors = Array.Empty<string>();
        IsSuccess = true;
    }

    /// <summary>
    /// Initializes a failed validation with a collection of error messages.
    /// </summary>
    /// <param name="errors">The error messages associated with the failed validation.</param>
    private Validation(params string[] errors)
    {
        _errors = errors;
        _value = default;
        IsSuccess = false;
    }

    /// <summary>
    /// Creates a successful validation result with the specified value.
    /// </summary>
    /// <param name="value">The value of the successful validation.</param>
    /// <returns>A successful <see cref="Validation{T}"/> instance.</returns>
    public static Validation<T> Success(T value) => new(value);

    /// <summary>
    /// Creates a failed validation result with the specified error messages.
    /// </summary>
    /// <param name="errors">The error messages describing the failure.</param>
    /// <returns>A failed <see cref="Validation{T}"/> instance.</returns>
    /// <exception cref="ArgumentException">Thrown if no error messages are provided.</exception>
    public static Validation<T> Failure(params string[] errors)
    {
        if (errors is null || errors.Length == 0)
            throw new ArgumentException("At least one error must be provided.", nameof(errors));
        return new Validation<T>(errors);
    }

    /// <summary>
    /// Matches the validation result to one of two functions depending on its success or failure.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the functions.</typeparam>
    /// <param name="success">The function to execute if the validation is successful.</param>
    /// <param name="failure">The function to execute if the validation fails.</param>
    /// <returns>The result of the corresponding function based on the validation's state.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either <paramref name="success"/> or <paramref name="failure"/> is null.</exception>
    public TResult Match<TResult>(Func<T, TResult> success, Func<IReadOnlyList<string>, TResult> failure)
    {
        if (success is null) throw new ArgumentNullException(nameof(success));
        if (failure is null) throw new ArgumentNullException(nameof(failure));
        return IsSuccess ? success(_value!) : failure(Errors);
    }

    /// <summary>
    /// Transforms the value of a successful validation using the specified mapping function.
    /// </summary>
    /// <typeparam name="TResult">The type of the transformed value.</typeparam>
    /// <param name="mapper">The function to apply to the value if the validation is successful.</param>
    /// <returns>A new <see cref="Validation{TResult}"/> instance with the transformed value or the original errors if the validation failed.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="mapper"/> is null.</exception>
    public Validation<TResult> Map<TResult>(Func<T, TResult> mapper)
    {
        if (mapper is null) throw new ArgumentNullException(nameof(mapper));
        return IsSuccess ? Validation<TResult>.Success(mapper(_value!)) : Validation<TResult>.Failure(Errors.ToArray());
    }

    /// <summary>
    /// Applies a binding function to transform the validation result.
    /// </summary>
    /// <typeparam name="TResult">The type of the value in the resulting validation.</typeparam>
    /// <param name="binder">The function to apply to the value if the validation is successful.</param>
    /// <returns>A new <see cref="Validation{TResult}"/> based on the binding function or the original errors if the validation failed.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="binder"/> is null.</exception>
    public Validation<TResult> Bind<TResult>(Func<T, Validation<TResult>> binder)
    {
        if (binder is null) throw new ArgumentNullException(nameof(binder));
        if (IsSuccess)
        {
            var result = binder(_value!);
            return result.IsSuccess
                ? Validation<TResult>.Success(result._value!)
                : Validation<TResult>.Failure(Errors.Concat(result.Errors).ToArray());
        }

        return Validation<TResult>.Failure(Errors.ToArray());
    }

    /// <summary>
    /// Filters the validation value based on a predicate.
    /// </summary>
    /// <param name="predicate">The function to test the validation value.</param>
    /// <returns>A failed validation with a predefined error message if the predicate does not hold; otherwise, the original validation.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="predicate"/> is null.</exception>
    public Validation<T> Where(Func<T, bool> predicate)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));
        if (IsSuccess && !predicate(_value!))
        {
            return Failure("Predicate did not hold.");
        }
        return this;
    }

    /// <summary>
    /// Maps the validation value using the specified selector function.
    /// </summary>
    /// <typeparam name="TResult">The type of the transformed value.</typeparam>
    /// <param name="selector">The function to apply to the value if the validation is successful.</param>
    /// <returns>A new <see cref="Validation{TResult}"/> instance with the transformed value or the original errors if the validation failed.</returns>
    public Validation<TResult> Select<TResult>(Func<T, TResult> selector) => Map(selector);

    /// <summary>
    /// Projects the value of a validation into a new form using the specified selector and result selector functions.
    /// </summary>
    /// <typeparam name="TIntermediate">The type of the intermediate validation value.</typeparam>
    /// <typeparam name="TResult">The type of the final result value.</typeparam>
    /// <param name="selector">The function to apply to the value to obtain the intermediate validation.</param>
    /// <param name="resultSelector">The function to apply to the value and intermediate result to obtain the final result.</param>
    /// <returns>A new <see cref="Validation{TResult}"/> based on the combined selector functions.</returns>
    public Validation<TResult> SelectMany<TIntermediate, TResult>(
        Func<T, Validation<TIntermediate>> selector,
        Func<T, TIntermediate, TResult> resultSelector)
    {
        return Bind(value => selector(value).Map(intermediate => resultSelector(value, intermediate)));
    }
}
