// ReSharper disable UnusedMember.Global

namespace HamedStack.Functional;

/// <summary>
/// Represents a value that can be either of two possible types: <typeparamref name="TLeft"/> (Left) or <typeparamref name="TRight"/> (Right).
/// </summary>
/// <typeparam name="TLeft">The type of the left value.</typeparam>
/// <typeparam name="TRight">The type of the right value.</typeparam>
public readonly struct Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>
{
    private readonly TLeft? _left;
    private readonly TRight? _right;

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TL, TR}"/> struct with a left value.
    /// </summary>
    /// <param name="left">The left value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="left"/> value is null.</exception>
    private Either(TLeft left)
    {
        _left = left ?? throw new ArgumentNullException(nameof(left));
        _right = default;
        IsLeft = true;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Either{TL, TR}"/> struct with a right value.
    /// </summary>
    /// <param name="right">The right value.</param>
    /// <exception cref="ArgumentNullException">Thrown if the <paramref name="right"/> value is null.</exception>
    private Either(TRight right)
    {
        _right = right ?? throw new ArgumentNullException(nameof(right));
        _left = default;
        IsLeft = false;
    }

    /// <summary>
    /// Gets a value indicating whether the instance contains a left value.
    /// </summary>
    public bool IsLeft { get; }

    /// <summary>
    /// Gets a value indicating whether the instance contains a right value.
    /// </summary>
    public bool IsRight => !IsLeft;

    /// <summary>
    /// Implicitly converts a left value to an <see cref="Either{TL, TR}"/> instance.
    /// </summary>
    /// <param name="left">The left value.</param>
    public static implicit operator Either<TLeft, TRight>(TLeft left) => Left(left);

    /// <summary>
    /// Implicitly converts a right value to an <see cref="Either{TL, TR}"/> instance.
    /// </summary>
    /// <param name="right">The right value.</param>
    public static implicit operator Either<TLeft, TRight>(TRight right) => Right(right);

    /// <summary>
    /// Creates an <see cref="Either{TL, TR}"/> instance containing a left value.
    /// </summary>
    /// <param name="left">The left value.</param>
    /// <returns>An <see cref="Either{TL, TR}"/> instance containing the specified left value.</returns>
    public static Either<TLeft, TRight> Left(TLeft left) => new(left);

    /// <summary>
    /// Determines whether two <see cref="Either{TL, TR}"/> instances are not equal.
    /// </summary>
    public static bool operator !=(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => !(left == right);

    /// <summary>
    /// Determines whether two <see cref="Either{TL, TR}"/> instances are equal.
    /// </summary>
    public static bool operator ==(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => left.Equals(right);

    /// <summary>
    /// Creates an <see cref="Either{TL, TR}"/> instance containing a right value.
    /// </summary>
    /// <param name="right">The right value.</param>
    /// <returns>An <see cref="Either{TL, TR}"/> instance containing the specified right value.</returns>
    public static Either<TLeft, TRight> Right(TRight right) => new(right);

    /// <summary>
    /// Indicates whether the current <see cref="Either{TL, TR}"/> instance is equal to another instance of the same type.
    /// </summary>
    /// <param name="other">An instance to compare with this instance.</param>
    /// <returns><c>true</c> if the current instance is equal to the <paramref name="other"/> parameter; otherwise, <c>false</c>.</returns>
    public bool Equals(Either<TLeft, TRight> other) =>
        EqualityComparer<TLeft?>.Default.Equals(_left, other._left) &&
        EqualityComparer<TRight?>.Default.Equals(_right, other._right);

    /// <summary>
    /// Determines whether the specified object is equal to the current <see cref="Either{TL, TR}"/> instance.
    /// </summary>
    /// <param name="obj">The object to compare with the current instance.</param>
    /// <returns><c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.</returns>
    public override bool Equals(object? obj) =>
        obj is Either<TLeft, TRight> other && Equals(_left, other._left) && Equals(_right, other._right);

    /// <summary>
    /// Returns a hash code for the current <see cref="Either{TL, TR}"/> instance.
    /// </summary>
    /// <returns>A hash code for the current instance.</returns>
    public override int GetHashCode() => HashCode.Combine(_left, _right);

    /// <summary>
    /// Executes the specified action if this instance contains a left value.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    public void IfLeft(Action<TLeft> action)
    { if (IsLeft) action(_left!); }

    /// <summary>
    /// Executes the specified action if this instance contains a right value.
    /// </summary>
    /// <param name="action">The action to execute.</param>
    public void IfRight(Action<TRight> action)
    { if (IsRight) action(_right!); }

    /// <summary>
    /// Gets the left value or returns a specified fallback value if this is a right instance.
    /// </summary>
    /// <param name="fallback">The fallback left value to return if this is a right instance.</param>
    /// <returns>The left value or the fallback value.</returns>
    public TLeft LeftOrElse(TLeft fallback) => IsLeft ? _left! : fallback;

    /// <summary>
    /// Matches the current <see cref="Either{TL, TR}"/> instance with one of the provided functions based on its value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by the matching function.</typeparam>
    /// <param name="leftFunc">The function to execute if the value is a left value.</param>
    /// <param name="rightFunc">The function to execute if the value is a right value.</param>
    /// <returns>The result of the executed function.</returns>
    public TResult Match<TResult>(Func<TLeft, TResult> leftFunc, Func<TRight, TResult> rightFunc) =>
        IsLeft ? leftFunc(_left!) : rightFunc(_right!);

    /// <summary>
    /// Gets the right value or returns a specified fallback value if this is a left instance.
    /// </summary>
    /// <param name="fallback">The fallback right value to return if this is a left instance.</param>
    /// <returns>The right value or the fallback value.</returns>
    public TRight RightOrElse(TRight fallback) => IsLeft ? fallback : _right!;

    /// <summary>
    /// Projects the right value of the current <see cref="Either{TL, TR}"/> using the specified selector function.
    /// </summary>
    /// <typeparam name="TResult">The type of the projected right value.</typeparam>
    /// <param name="selector">The function to transform the right value.</param>
    /// <returns>An <see cref="Either{TL, TResult}"/> with the projected right value if this is a right instance; otherwise, an <see cref="Either{TL, TResult}"/> with the original left value.</returns>
    public Either<TLeft, TResult> Select<TResult>(Func<TRight, TResult> selector) =>
        IsLeft ? Either<TLeft, TResult>.Left(_left!) : Either<TLeft, TResult>.Right(selector(_right!));

    /// <summary>
    /// Projects and flattens the right value of the current <see cref="Either{TL, TR}"/> using the specified binder and projector functions.
    /// </summary>
    /// <typeparam name="TMiddle">The type of the intermediate right value.</typeparam>
    /// <typeparam name="TResult">The type of the projected value.</typeparam>
    /// <param name="binder">The function to transform the right value into another <see cref="Either{TL, TMiddle}"/>.</param>
    /// <param name="projector">The function to combine the original right value and the intermediate value.</param>
    /// <returns>An <see cref="Either{TL, TResult}"/> with the projected value if both transformations are successful; otherwise, an <see cref="Either{TL, TResult}"/> with the original or intermediate left value.</returns>
    public Either<TLeft, TResult> SelectMany<TMiddle, TResult>(
        Func<TRight, Either<TLeft, TMiddle>> binder,
        Func<TRight, TMiddle, TResult> projector)
    {
        if (IsLeft) return Either<TLeft, TResult>.Left(_left!);

        var middle = binder(_right!);
        return middle.IsLeft
            ? Either<TLeft, TResult>.Left(middle._left!)
            : Either<TLeft, TResult>.Right(projector(_right!, middle._right!));
    }

    /// <summary>
    /// Returns a string representation of the current <see cref="Either{TL, TR}"/> instance.
    /// </summary>
    /// <returns>A string that represents the current <see cref="Either{TL, TR}"/>.</returns>
    public override string ToString() => IsLeft ? $"Left({_left})" : $"Right({_right})";

    /// <summary>
    /// Deconstructs the current <see cref="Either{TLeft, TRight}"/> instance into its left and right values.
    /// </summary>
    /// <param name="left">The left value if this instance is a Left; otherwise, <c>null</c>.</param>
    /// <param name="right">The right value if this instance is a Right; otherwise, <c>null</c>.</param>
    public void Deconstruct(out TLeft? left, out TRight? right)
    {
        left = _left;
        right = _right;
    }

    /// <summary>
    /// Deconstructs the current <see cref="Either{TLeft, TRight}"/> instance into a single value and a flag indicating its type.
    /// </summary>
    /// <param name="leftOrRight">
    /// The value contained in the instance, which can be either a left or right value depending on the type of the current instance.
    /// </param>
    /// <param name="isLeft">
    /// A boolean flag indicating whether the instance is a Left or a Right. If <c>true</c>, <paramref name="leftOrRight"/> is a Left value;
    /// otherwise, it is a Right value.
    /// </param>
    public void Deconstruct(out object leftOrRight, out bool isLeft)
    {
        leftOrRight = IsLeft ? _left! : _right!;
        isLeft = IsLeft;
    }
}