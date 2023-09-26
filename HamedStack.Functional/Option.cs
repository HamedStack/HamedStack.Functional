// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.Functional;

public readonly struct Option<T> where T : notnull
{
    public Option(T? value)
    {
        Value = value;
    }
    [JsonIgnore]
    public static Option<T> None => new(default);

    public bool IsSome => Value is not null;
    public bool IsNone => !IsSome;
    internal T? Value { get; }

    public static Option<TValue> Combine<TValue>(params Option<TValue>[] options) where TValue : notnull
    {
        return options.Any(option => option.IsNone) ? Option<TValue>.None : options.Last();
    }

    public static Option<T> Some(T value) => new Option<T>(value);

    public static implicit operator Option<T>(T value)
    {
        return new(value);
    }

    public static bool operator !=(Option<T> left, Option<T> right)
    {
        return !(left == right);
    }

    public static bool operator ==(Option<T> left, Option<T> right)
    {
        return left.Equals(right);
    }

    public IEnumerable<T> AsEnumerable()
    {
        if (IsSome)
        {
            yield return Value!;
        }
    }

    public Option<TResult> Bind<TResult>(Func<T, Option<TResult>> func) where TResult : notnull
    {
        return IsSome ? func(Value!) : Option<TResult>.None;
    }

    public async Task<Option<TResult>> BindAsync<TResult>(Func<T, Task<Option<TResult>>> func) where TResult : notnull
    {
        if (IsNone) return Option<TResult>.None;
        return await func(Value!);
    }

    public void Deconstruct(out T? value)
    {
        value = Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Option<T> other && EqualityComparer<T?>.Default.Equals(Value, other.Value);
    }

    public Option<T> Filter(Func<T, bool> predicate)
    {
        return IsSome && predicate(Value!) ? this : None;
    }

    public override int GetHashCode()
    {
        return Value?.GetHashCode() ?? 0;
    }

    public void IfSome(Action<T> action)
    {
        if (IsSome) action(Value!);
    }

    public async Task IfSomeAsync(Func<T, Task> action)
    {
        if (IsSome) await action(Value!);
    }

    public void IfNone(Action action)
    {
        if (IsNone) action();
    }

    public async Task IfNoneAsync(Func<Task> action)
    {
        if (IsNone) await action();
    }
    public Option<TResult> Map<TResult>(Func<T, TResult> func) where TResult : notnull
    {
        return IsSome ? new Option<TResult>(func(Value!)) : Option<TResult>.None;
    }

    public async Task<Option<TResult>> MapAsync<TResult>(Func<T, Task<TResult>> func) where TResult : notnull
    {
        if (IsNone) return Option<TResult>.None;
        var result = await func(Value!);
        return new Option<TResult>(result);
    }

    public TResult Match<TResult>(Func<T, TResult> someFunc, Func<TResult> noneFunc)
    {
        return IsSome ? someFunc(Value!) : noneFunc();
    }

    public async Task<TResult> MatchAsync<TResult>(
        Func<T, Task<TResult>> someFunc,
        Func<Task<TResult>> noneFunc)
    {
        return IsSome ? await someFunc(Value!) : await noneFunc();
    }

    public Option<T> OrElse(Func<Option<T>> fallbackFunc)
    {
        return IsSome ? this : fallbackFunc();
    }

    public T OrElse(T fallbackValue)
    {
        return IsSome ? Value! : fallbackValue;
    }

    public T OrElseGet(Func<T> fallbackFunc)
    {
        return IsSome ? Value! : fallbackFunc();
    }

    public T OrElseThrow(Exception ex)
    {
        return IsSome ? Value! : throw ex;
    }

    public Option<TResult> Select<TResult>(Func<T, TResult> selector) where TResult : notnull
    {
        return IsSome ? new Option<TResult>(selector(Value!)) : Option<TResult>.None;
    }

    public Option<TResult> SelectMany<TResult>(Func<T, Option<TResult>> binder) where TResult : notnull
    {
        return IsSome ? binder(Value!) : Option<TResult>.None;
    }

    public override string ToString()
    {
        return IsSome ? $"Some: {Value}" : "None";
    }

    public Option<TResult> Transform<TResult>(Func<T, TResult> transformFunc, Func<TResult> defaultFunc) where TResult : notnull
    {
        return IsSome ? new Option<TResult>(transformFunc(Value!)) : new Option<TResult>(defaultFunc());
    }

    public T Unwrap()
    {
        if (IsNone)
            throw new InvalidOperationException("Attempted to unwrap an Option.None.");

        return Value!;
    }

    public T Unwrap(T defaultValue)
    {
        return IsSome ? Value! : defaultValue;
    }

    public T Unwrap(Func<T> defaultValueFunc)
    {
        return IsSome ? Value! : defaultValueFunc();
    }

    public Option<T> Where(Func<T, bool> predicate)
    {
        return IsSome && predicate(Value!) ? this : None;
    }

    public T[] ToArray()
    {
        return IsSome ? new[] { Value! } : Array.Empty<T>();
    }

    public List<T> ToList()
    {
        return IsSome ? new List<T> { Value! } : new List<T>();
    }
}