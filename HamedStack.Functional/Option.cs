// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional;

/// <summary>
/// Represents an optional value that can be in one of two states: Some or None.
/// </summary>
/// <typeparam name="T">The type of the contained value.</typeparam>
public readonly struct Option<T> : IEquatable<Option<T>>
{
    private readonly T? _value;

    private Option(T value)
    {
        _value = value ?? throw new ArgumentNullException(nameof(value), "Cannot assign null to Some.");
        IsSome = true;
    }

    /// <summary>
    /// Represents an Option with no value.
    /// </summary>
    public static Option<T> None { get; } = new();

    /// <summary>
    /// Gets a value indicating whether the Option does not contain a value.
    /// </summary>
    public bool IsNone => !IsSome;

    /// <summary>
    /// Gets a value indicating whether the Option contains a value.
    /// </summary>
    public bool IsSome { get; }

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="T"/> to an Option.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    public static implicit operator Option<T>(T value) => value is null ? None : Some(value);

    /// <summary>
    /// Determines whether two specified Option instances have different values.
    /// </summary>
    /// <param name="left">The first Option to compare.</param>
    /// <param name="right">The second Option to compare.</param>
    /// <returns>True if the Options are not equal; otherwise, false.</returns>
    public static bool operator !=(Option<T> left, Option<T> right) => !(left == right);

    /// <summary>
    /// Compares two Options using the less than operator.
    /// </summary>
    /// <param name="left">The left Option to compare.</param>
    /// <param name="right">The right Option to compare.</param>
    /// <returns>True if the left Option is less than the right Option; otherwise, false.</returns>
    public static bool operator <(Option<T> left, Option<T> right)
    {
        if (left.IsNone && right.IsSome) return true;
        if (left.IsSome && right.IsSome) return Comparer<T>.Default.Compare(left._value, right._value) < 0;
        return false;
    }

    /// <summary>
    /// Compares two Options using the less than or equal operator.
    /// </summary>
    /// <param name="left">The left Option to compare.</param>
    /// <param name="right">The right Option to compare.</param>
    /// <returns>True if the left Option is less than or equal to the right Option; otherwise, false.</returns>
    public static bool operator <=(Option<T> left, Option<T> right) => !(left > right);

    /// <summary>
    /// Determines whether two specified Option instances have the same value.
    /// </summary>
    /// <param name="left">The first Option to compare.</param>
    /// <param name="right">The second Option to compare.</param>
    /// <returns>True if the Options are equal; otherwise, false.</returns>
    public static bool operator ==(Option<T> left, Option<T> right) => left.Equals(right);

    /// <summary>
    /// Compares two Options using the greater than operator.
    /// </summary>
    /// <param name="left">The left Option to compare.</param>
    /// <param name="right">The right Option to compare.</param>
    /// <returns>True if the left Option is greater than the right Option; otherwise, false.</returns>
    public static bool operator >(Option<T> left, Option<T> right)
    {
        if (left.IsSome && right.IsNone) return true;
        if (left.IsSome && right.IsSome) return Comparer<T>.Default.Compare(left._value, right._value) > 0;
        return false;
    }

    /// <summary>
    /// Compares two Options using the greater than or equal operator.
    /// </summary>
    /// <param name="left">The left Option to compare.</param>
    /// <param name="right">The right Option to compare.</param>
    /// <returns>True if the left Option is greater than or equal to the right Option; otherwise, false.</returns>
    public static bool operator >=(Option<T> left, Option<T> right) => !(left < right);

    /// <summary>
    /// Creates an Option containing a value.
    /// </summary>
    /// <param name="value">The value to wrap in an Option.</param>
    /// <returns>An Option containing the specified value.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided value is null.</exception>
    public static Option<T> Some(T value) => new(value);

    /// <summary>
    /// Converts the Option to an enumerable containing either zero or one element.
    /// </summary>
    /// <returns>An enumerable containing the value if present, or an empty enumerable otherwise.</returns>
    public IEnumerable<T> AsEnumerable()
    {
        if (IsSome) yield return _value!;
    }

    /// <summary>
    /// Projects the value inside the Option into a new Option using the specified binder function.
    /// </summary>
    /// <typeparam name="TResult">The type of the result Option.</typeparam>
    /// <param name="binder">The function to transform the value if present.</param>
    /// <returns>The transformed Option if the original Option has a value, otherwise an empty Option.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided binder function is null.</exception>
    public Option<TResult> Bind<TResult>(Func<T, Option<TResult>> binder)
    {
        if (binder is null) throw new ArgumentNullException(nameof(binder));
        return IsSome ? binder(_value!) : Option<TResult>.None;
    }

    /// <summary>
    /// Deconstructs the Option into its value.
    /// </summary>
    /// <param name="value">The value contained in the Option if present, otherwise the default value.</param>
    public void Deconstruct(out T? value)
    {
        value = _value;
    }

    /// <summary>
    /// Deconstructs the Option into its state and value.
    /// </summary>
    /// <param name="isSome">True if the Option has a value, otherwise false.</param>
    /// <param name="value">The value contained in the Option if present, otherwise the default value.</param>
    public void Deconstruct(out bool isSome, out T? value)
    {
        isSome = IsSome;
        value = _value;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Option<T> other && Equals(other);

    /// <summary>
    /// Indicates whether the current Option is equal to another Option of the same type.
    /// </summary>
    /// <param name="other">An Option to compare with this Option.</param>
    /// <returns>True if the current Option is equal to the other Option; otherwise, false.</returns>
    public bool Equals(Option<T> other)
    {
        if (IsNone && other.IsNone) return true;
        if (IsSome && other.IsSome) return EqualityComparer<T>.Default.Equals(_value, other._value);
        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode() => IsSome ? _value?.GetHashCode() ?? 0 : 0;

    /// <summary>
    /// Transforms the value inside the Option using the specified mapping function.
    /// </summary>
    /// <typeparam name="TResult">The type of the resulting Option.</typeparam>
    /// <param name="map">The function to transform the value.</param>
    /// <returns>The transformed Option if the original Option has a value, otherwise an empty Option.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided mapping function is null.</exception>
    public Option<TResult> Map<TResult>(Func<T, TResult> map)
    {
        if (map is null) throw new ArgumentNullException(nameof(map));
        return IsSome ? Option<TResult>.Some(map(_value!)) : Option<TResult>.None;
    }

    /// <summary>
    /// Matches the Option to a value based on the specified functions.
    /// </summary>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="some">The function to execute if the Option has a value.</param>
    /// <param name="none">The function to execute if the Option does not have a value.</param>
    /// <returns>The result of either some or none function.</returns>
    /// <exception cref="ArgumentNullException">Thrown if either function is null.</exception>
    public TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none)
    {
        if (some is null) throw new ArgumentNullException(nameof(some));
        if (none is null) throw new ArgumentNullException(nameof(none));
        return IsSome ? some(_value!) : none();
    }

    /// <summary>
    /// Returns this Option if it has a value, otherwise returns the specified other Option.
    /// </summary>
    /// <param name="other">The Option to return if this Option has no value.</param>
    /// <returns>The current Option if it has a value, otherwise the specified other Option.</returns>
    public Option<T> OrElse(Option<T> other)
    {
        return IsSome ? this : other;
    }

    /// <summary>
    /// Returns this Option if it has a value, otherwise returns the Option produced by the specified function.
    /// </summary>
    /// <param name="otherFactory">The function to produce an Option if this Option has no value.</param>
    /// <returns>The current Option if it has a value, otherwise the Option produced by the function.</returns>
    public Option<T> OrElse(Func<Option<T>> otherFactory)
    {
        if (otherFactory is null) throw new ArgumentNullException(nameof(otherFactory));
        return IsSome ? this : otherFactory();
    }

    /// <summary>
    /// Applies the specified mapping function to transform the value inside the Option.
    /// </summary>
    /// <typeparam name="TResult">The type of the resulting Option.</typeparam>
    /// <param name="map">The function to transform the value.</param>
    /// <returns>The transformed Option if the original Option has a value, otherwise an empty Option.</returns>
    public Option<TResult> Select<TResult>(Func<T, TResult> map)
    {
        return Map(map);
    }

    /// <summary>
    /// Projects the Option into a new form using the specified functions.
    /// </summary>
    /// <typeparam name="TIntermediate">The intermediate type.</typeparam>
    /// <typeparam name="TResult">The resulting type.</typeparam>
    /// <param name="binder">The function to map the value to an intermediate Option.</param>
    /// <param name="resultSelector">The function to select the final result from the intermediate value.</param>
    /// <returns>A new Option with the projected value.</returns>
    public Option<TResult> SelectMany<TIntermediate, TResult>(
        Func<T, Option<TIntermediate>> binder,
        Func<T, TIntermediate, TResult> resultSelector)
    {
        return Bind(value =>
            binder(value).Map(intermediate => resultSelector(value, intermediate))
        );
    }

    /// <summary>
    /// Returns a string representation of the Option.
    /// </summary>
    /// <returns>"Some(value)" if the Option has a value, otherwise "None".</returns>
    public override string ToString() => IsSome ? $"Some({_value})" : "None";

    /// <summary>
    /// Returns the value of the Option if present, otherwise the specified default value.
    /// </summary>
    /// <param name="otherValue">The default value to return if the Option has no value.</param>
    /// <returns>The value of the Option if present, otherwise the specified default value.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the specified default value is null.</exception>
    public T ValueOr(T otherValue)
    {
        if (otherValue == null) throw new ArgumentNullException(nameof(otherValue));
        return IsSome ? _value! : otherValue;
    }

    /// <summary>
    /// Returns the value of the Option if present, otherwise the value produced by the specified function.
    /// </summary>
    /// <param name="otherFactory">The function to produce a default value if the Option has no value.</param>
    /// <returns>The value of the Option if present, otherwise the value produced by the function.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the specified function is null.</exception>
    public T ValueOr(Func<T> otherFactory)
    {
        if (otherFactory is null) throw new ArgumentNullException(nameof(otherFactory));
        return IsSome ? _value! : otherFactory();
    }

    /// <summary>
    /// Returns the value of the Option if present, otherwise throws an exception.
    /// </summary>
    /// <returns>The value of the Option if present.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the Option has no value.</exception>
    public T ValueOrThrow()
    {
        return _value ?? throw new InvalidOperationException("The value is not present");
    }

    /// <summary>
    /// Returns the value of the Option if present, otherwise throws the specified exception.
    /// </summary>
    /// <param name="exception">The exception to throw if the Option has no value.</param>
    /// <returns>The value of the Option if present.</returns>
    public T ValueOrThrow(Exception exception)
    {
        return _value ?? throw exception;
    }

    /// <summary>
    /// Returns the value of the Option if present, otherwise throws the exception produced by the specified function.
    /// </summary>
    /// <param name="exceptionFactory">The function to produce an exception if the Option has no value.</param>
    /// <returns>The value of the Option if present.</returns>
    public T ValueOrThrow(Func<Exception> exceptionFactory)
    {
        return _value ?? throw exceptionFactory();
    }

    /// <summary>
    /// Filters the Option based on the specified predicate.
    /// </summary>
    /// <param name="predicate">The function to test the value.</param>
    /// <returns>The Option if the predicate returns true, otherwise None.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided predicate is null.</exception>
    public Option<T> Where(Func<T, bool> predicate)
    {
        if (predicate is null) throw new ArgumentNullException(nameof(predicate));
        return IsSome && predicate(_value!) ? this : None;
    }
}