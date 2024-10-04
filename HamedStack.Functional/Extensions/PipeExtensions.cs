// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace HamedStack.Functional.Extensions;

/// <summary>
///     Contains extension methods for piping operations on objects, enabling a more functional style of programming.
/// </summary>
public static class PipeExtensions
{
    /// <summary>
    ///     Pipes the given object into the provided function and returns the result.
    ///     This is useful for applying transformations to an object in a readable and functional manner.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <typeparam name="TU">The return type of the function.</typeparam>
    /// <param name="obj">The object to pipe into the function.</param>
    /// <param name="f">The function to apply on the piped object.</param>
    /// <returns>The result of applying the function on the object.</returns>
    public static TU Pipe<T, TU>(this T obj, Func<T, TU> f)
    {
        return f(obj);
    }

    /// <summary>
    ///     Pipes the given object into the provided action and returns the original object.
    ///     This is useful for performing side effects on the object without changing its state.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the action.</param>
    /// <param name="f">The action to apply on the piped object.</param>
    /// <returns>The original object after applying the action.</returns>
    public static T Pipe<T>(this T obj, Action<T> f)
    {
        f(obj);
        return obj;
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function and returns the result.
    ///     This method is useful for applying asynchronous transformations to the object.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <typeparam name="TU">The return type of the function.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>The result of applying the function on the object.</returns>
    public static async Task<TU> PipeAsync<T, TU>(this T obj, Func<T, Task<TU>> f)
    {
        return await f(obj);
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function using a <see cref="ValueTask{TU}"/> and returns the result.
    ///     This overload is suitable for performance-sensitive scenarios where a <see cref="ValueTask"/> is more appropriate.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <typeparam name="TU">The return type of the function.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>The result of applying the function on the object.</returns>
    public static async ValueTask<TU> PipeAsync<T, TU>(this T obj, Func<T, ValueTask<TU>> f)
    {
        return await f(obj);
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function and returns the original object.
    ///     This is useful for performing side effects in an asynchronous manner.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>The original object after applying the function asynchronously.</returns>
    public static async Task<T> PipeAsync<T>(this T obj, Func<T, Task> f)
    {
        await f(obj);
        return obj;
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function using a <see cref="ValueTask"/> and returns the original object.
    ///     Useful for performance-sensitive asynchronous operations.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>The original object after applying the function asynchronously.</returns>
    public static async ValueTask<T> PipeAsync<T>(this T obj, Func<T, ValueTask> f)
    {
        await f(obj);
        return obj;
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function without returning a result.
    ///     Suitable for executing asynchronous operations that do not return a value.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    public static async Task PipeTaskAsync<T>(this T obj, Func<T, Task> f)
    {
        await f(obj);
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function using a <see cref="ValueTask"/> without returning a result.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    public static async ValueTask PipeTaskAsync<T>(this T obj, Func<T, ValueTask> f)
    {
        await f(obj);
    }

    /// <summary>
    ///     Pipes the given object into the provided action and returns a unit type, indicating that a side effect has occurred.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the action.</param>
    /// <param name="f">The action to apply on the piped object.</param>
    /// <returns>A unit type indicating completion.</returns>
    public static Unit PipeUnit<T>(this T obj, Action<T> f)
    {
        f(obj);
        return Unit.Value;
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function and returns a unit type.
    ///     Useful for performing asynchronous side effects that should signal completion.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>A unit type indicating completion.</returns>
    public static async Task<Unit> PipeUnitAsync<T>(this T obj, Func<T, Task> f)
    {
        await f(obj);
        return Unit.Value;
    }

    /// <summary>
    ///     Asynchronously pipes the given object into the provided function using a <see cref="ValueTask"/> and returns a unit type.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the asynchronous function.</param>
    /// <param name="f">The asynchronous function to apply on the piped object.</param>
    /// <returns>A unit type indicating completion.</returns>
    public static async ValueTask<Unit> PipeUnitAsync<T>(this T obj, Func<T, ValueTask> f)
    {
        await f(obj);
        return Unit.Value;
    }

    /// <summary>
    ///     Pipes the given object into the provided action without returning a result.
    ///     This method is primarily used for executing actions that perform side effects.
    /// </summary>
    /// <typeparam name="T">The type of the object being piped.</typeparam>
    /// <param name="obj">The object to pipe into the action.</param>
    /// <param name="f">The action to apply on the piped object.</param>
    public static void PipeVoid<T>(this T obj, Action<T> f)
    {
        f(obj);
    }
}