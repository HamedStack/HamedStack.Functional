// ReSharper disable UnusedMember.Global
namespace HamedStack.Functional;

public readonly struct Exceptional<T>
{
    public Exceptional(T value) : this(value, default) { }

    public Exceptional(Exception exception) : this(default, exception) { }

    public Exceptional(T? value, Exception? exception)
    {
        Value = value;
        Exception = exception;
    }
    public Exception? Exception { get; }

    public bool HasException => Exception is not null;

    public bool HasValue => Exception is null;

    public T? Value { get; }

    public static implicit operator Exceptional<T>(T value)
    {
        return new Exceptional<T>(value, null);
    }

    public static implicit operator Exceptional<T>(Exception ex)
    {
        return new Exceptional<T>(default, ex);
    }

    public static bool operator !=(Exceptional<T> left, Exceptional<T> right)
    {
        return !(left == right);
    }

    public static bool operator ==(Exceptional<T> left, Exceptional<T> right)
    {
        return left.Equals(right);
    }

    public static Exceptional<T> TryCatch(Func<T?> func)
    {
        try
        {
            return new Exceptional<T>(func(), null);
        }
        catch (Exception ex)
        {
            return new Exceptional<T>(default, ex);
        }
    }

    public void Deconstruct(out T? value, out Exception? exception)
    {
        value = Value;
        exception = Exception;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Exceptional<T> otherExceptional) return false;

        if (HasException && otherExceptional.HasException && Exception != null)
        {
            return Exception.Equals(otherExceptional.Exception);
        }

        if (!HasException && !otherExceptional.HasException)
        {
            return EqualityComparer<T>.Default.Equals(Value, otherExceptional.Value);
        }
        return false;
    }

    public override int GetHashCode()
    {
        if (HasException && Exception != null)
        {
            return Exception.GetHashCode();
        }
        return Value != null ? Value.GetHashCode() : 0;
    }

    public T GetValueOrThrow()
    {
        if (HasValue) return Value!;
        throw new InvalidOperationException($"No value present. Exception: {Exception?.Message}");
    }

    public void IfException(Action<Exception> action)
    {
        if (Exception is not null) action(Exception);
    }

    public void IfValue(Action<T> action)
    {
        if (HasValue) action(Value!);
    }

    public TResult Match<TResult>(Func<T, TResult> onValue, Func<Exception, TResult> onException)
    {
        return HasValue ? onValue(Value!) : onException(Exception!);
    }

    public Exceptional<T> Tap(Action<T> action)
    {
        if (HasValue) action(Value!);
        return this;
    }
    public override string ToString()
    {
        return HasException ? $"Exception: {Exception?.Message}" : $"Value: {Value}";
    }

    public Exceptional<TResult> Transform<TResult>(
        Func<T, TResult> transformValue,
        Func<Exception, Exception> transformException)
    {
        return HasValue
            ? new Exceptional<TResult>(transformValue(Value!))
            : new Exceptional<TResult>(transformException(Exception!));
    }
}