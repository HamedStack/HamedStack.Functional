// ReSharper disable UnusedMember.Global
// ReSharper disable InvalidXmlDocComment

namespace HamedStack.Functional.Extensions;

/// <summary>
/// Provides extension methods for composing functions, allowing traditional and forward composition 
/// to combine multiple functions into one in a readable and concise manner.
/// </summary>
public static class ComposeExtensions
{
    /// <summary>
    ///     Composes two functions in a way that the output of the second function (<paramref name="g" />)
    ///     becomes the input to the first function (<paramref name="f" />). This is analogous to the mathematical composition
    ///     notation \(f \circ g\) (f after g).
    /// </summary>
    /// <typeparam name="TSource">The input type of the composed function.</typeparam>
    /// <typeparam name="TIntermediate">The output type of <paramref name="g" /> and the input type of <paramref name="f" />.</typeparam>
    /// <typeparam name="TResult">The output type of the composed function.</typeparam>
    /// <param name="f">The first function to compose.</param>
    /// <param name="g">The second function to compose.</param>
    /// <returns>A new function composed of the provided functions.</returns>
    public static Func<TSource, TResult> Compose<TSource, TIntermediate, TResult>(this Func<TIntermediate, TResult> f,
        Func<TSource, TIntermediate> g)
    {
        return source => f(g(source));
    }

    /// <summary>
    ///     Composes two functions in a forward manner, meaning the output of the first function (<paramref name="f" />)
    ///     becomes the input to the second function (<paramref name="g" />). This is analogous to the mathematical composition
    ///     notation \(g \circ f\) (g after f).
    /// </summary>
    /// <typeparam name="TSource">The input type of the composed function.</typeparam>
    /// <typeparam name="TIntermediate">The output type of <paramref name="f" /> and the input type of <paramref name="g" />.</typeparam>
    /// <typeparam name="TResult">The output type of the composed function.</typeparam>
    /// <param name="f">The first function to compose.</param>
    /// <param name="g">The second function to compose.</param>
    /// <returns>A new function composed of the provided functions in a forward manner.</returns>
    public static Func<TSource, TResult> ComposeForward<TSource, TIntermediate, TResult>(
        this Func<TSource, TIntermediate> f, Func<TIntermediate, TResult> g)
    {
        return source => g(f(source));
    }
}