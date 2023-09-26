// ReSharper disable UnusedMember.Global

using System.Collections.Concurrent;
using System.Collections.Specialized;

namespace HamedStack.Functional.Extensions;

public static class OptionExtensions
{
    public static Option<T> FirstOrNone<T>(this IEnumerable<T> source) where T : notnull
    {
        foreach (var item in source)
        {
            return Option<T>.Some(item);
        }
        return Option<T>.None;
    }

    public static Option<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : notnull
    {
        return source.Where(predicate).FirstOrNone();
    }
    public static Option<List<T>> Collapse<T>(this List<Option<T>> options) where T : notnull
    {
        var resultList = new List<T>();
        foreach (var option in options)
        {
            if (option.IsNone) return new Option<List<T>>();
            resultList.Add(option.Value!);
        }
        return new Option<List<T>>(resultList);
    }

    public static Option<(T, TOther)> CombineWith<T, TOther>(this Option<T> option, Option<TOther> other) where TOther : notnull where T : notnull
    {
        if (option.IsSome && other.IsSome)
        {
            return new Option<(T, TOther)>((option.Value!, other.Value!));
        }
        return Option<(T, TOther)>.None;
    }

    public static Option<T> Flatten<T>(this Option<Option<T>> option) where T : notnull
    {
        return option.IsSome ? option.Value : Option<T>.None;
    }

    public static Option<T> Or<T>(this Option<T> option, Option<T> fallbackOption) where T : notnull
    {
        return option.IsSome ? option : fallbackOption;
    }

    public static async Task<T> OrElseAsync<T>(this Option<T> option, Func<Task<T>> taskFunc) where T : notnull
    {
        if (option.IsSome) return option.Value!;
        return await taskFunc();
    }

    public static bool Satisfies<T>(this Option<T> option, Func<T, bool> condition) where T : notnull
    {
        return option.IsSome && condition(option.Value!);
    }

    public static Option<TResult> SelectMany<T, TMiddle, TResult>(
        this Option<T> option,
        Func<T, Option<TMiddle>> binder,
        Func<T, TMiddle, TResult> projector) where TResult : notnull where TMiddle : notnull where T : notnull
    {
        if (option.IsNone) return Option<TResult>.None;
        var middle = binder(option.Value!);
        return middle.IsNone ? Option<TResult>.None : new Option<TResult>(projector(option.Value!, middle.Value!));
    }

    public static Either<Option<T>, T> ToEither<T>(this Option<T> option) where T : notnull
    {
        return option.IsSome
            ? (Either<Option<T>, T>)option.Unwrap()
            : (Either<Option<T>, T>)option;
    }

    public static Either<TLeft, Option<TRight>> ToEither<TLeft, TRight>(this Either<TLeft, TRight> either) where TRight : notnull
    {
        return either.IsRight
            ? new Either<TLeft, Option<TRight>>(default, new Option<TRight>(either.Right))
            : new Either<TLeft, Option<TRight>>(either.Left, Option<TRight>.None);
    }

    public static Exceptional<T> ToExceptional<T>(this Option<T> option, Exception fallbackException) where T : notnull
    {
        return option.IsSome ? new Exceptional<T>(option.Value, null) : new Exceptional<T>(default, fallbackException);
    }

    public static List<T> ToList<T>(this Option<T> option) where T : notnull
    {
        return option.IsSome ? new List<T> { option.Value! } : new List<T>();
    }

    public static Option<string> ToOption(this NameValueCollection collection, string key)
    {
        var value = collection[key];
        return value != null ? new Option<string>(value) : Option<string>.None;
    }
    public static Option<string> ToOption(this NameValueCollection collection, int key)
    {
        var value = collection[key];
        return value != null ? new Option<string>(value) : Option<string>.None;
    }
    public static Option<TValue> ToOption<TKey, TValue>(this Dictionary<TKey, TValue> @this, TKey key) where TKey : notnull where TValue : notnull
    {
        return @this.TryGetValue(key, out var value)
            ? Option<TValue>.Some(value)
            : Option<TValue>.None;
    }

    public static Option<TValue> ToOption<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> @this, TKey key) where TKey : notnull where TValue : notnull
    {
        return @this.TryGetValue(key, out var value)
            ? Option<TValue>.Some(value)
            : Option<TValue>.None;
    }
    public static Option<T> ToOption<T>(this T? value) where T : struct
    {
        return value.HasValue ? new Option<T>(value.Value) : Option<T>.None;
    }

    public static Option<T> ToOption<T>(this T? value) where T : class
    {
        return value is not null ? new Option<T>(value) : Option<T>.None;
    }
}