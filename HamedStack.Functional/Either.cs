// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional;

public readonly struct Either<TLeft, TRight>
{
    public Either(TLeft? left, TRight? right)
    {
        if (left is not null && right is not null)
            throw new ArgumentException("Either can have a Left or Right value, but not both.");
        Left = left;
        Right = right;
    }
    public bool IsLeft => Left is not null;

    public bool IsRight => Right is not null;

    public TLeft? Left { get; }

    public TRight? Right { get; }

    public static implicit operator Either<TLeft, TRight>(TLeft left)
    {
        return new Either<TLeft, TRight>(left, default);
    }

    public static implicit operator Either<TLeft, TRight>(TRight right)
    {
        return new Either<TLeft, TRight>(default, right);
    }

    public static bool operator !=(Either<TLeft, TRight> left, Either<TLeft, TRight> right)
    {
        return !(left == right);
    }

    public static bool operator ==(Either<TLeft, TRight> left, Either<TLeft, TRight> right)
    {
        return left.Equals(right);
    }

    public Either<T, TRight> BindLeft<T>(Func<TLeft, Either<T, TRight>> func)
    {
        return IsLeft ? func(Left!) : new Either<T, TRight>(default, Right);
    }

    public Either<TLeft, T> BindRight<T>(Func<TRight, Either<TLeft, T>> func)
    {
        return IsRight ? func(Right!) : new Either<TLeft, T>(Left, default);
    }

    public void Deconstruct(out TLeft? left, out TRight? right)
    {
        left = Left;
        right = Right;
    }

    public void Deconstruct(out object? leftOrRight, out bool isLeft)
    {
        leftOrRight = IsLeft ? Left : Right;
        isLeft = IsLeft;
    }

    public override bool Equals(object? obj)
    {
        return obj is Either<TLeft, TRight> other &&
               EqualityComparer<TLeft?>.Default.Equals(Left, other.Left) &&
               EqualityComparer<TRight?>.Default.Equals(Right, other.Right);
    }

    public T Fold<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight)
    {
        return IsLeft ? onLeft(Left!) : onRight(Right!);
    }

    public override int GetHashCode()
    {
        return (Left?.GetHashCode() ?? 0) ^ (Right?.GetHashCode() ?? 0);
    }

    public void IfLeft(Action<TLeft> action)
    {
        if (IsLeft) action(Left!);
    }

    public void IfRight(Action<TRight> action)
    {
        if (IsRight) action(Right!);
    }

    public Either<TResult, TRight> MapLeft<TResult>(Func<TLeft, TResult> func)
    {
        return IsLeft ? new Either<TResult, TRight>(func(Left!), default) : new Either<TResult, TRight>(default, Right);
    }

    public T Match<T>(Func<TLeft, T> onLeft, Func<TRight, T> onRight)
    {
        return IsLeft ? onLeft(Left!) : onRight(Right!);
    }

    public async Task<TResult> MatchAsync<TResult>(
        Func<TLeft, Task<TResult>> onLeftFunc,
        Func<TRight, Task<TResult>> onRightFunc)
    {
        return IsLeft ? await onLeftFunc(Left!) : await onRightFunc(Right!);
    }

    public Either<TLeft, TRight> OrElse(Func<TRight> fallbackFunc)
    {
        return IsRight ? this : new Either<TLeft, TRight>(default, fallbackFunc());
    }

    public Either<TLeft, TResult> Select<TResult>(Func<TRight, TResult> selector)
    {
        return IsRight
            ? new Either<TLeft, TResult>(default, selector(Right!))
            : new Either<TLeft, TResult>(Left, default);
    }

    public override string ToString()
    {
        return IsLeft ? $"Left: {Left}" : $"Right: {Right}";
    }
}