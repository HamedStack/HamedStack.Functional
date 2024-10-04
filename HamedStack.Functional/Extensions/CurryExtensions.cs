// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace HamedStack.Functional.Extensions;

/// <summary>
/// Provides extension methods to curry functions with multiple parameters.
/// </summary>
public static class CurryExtensions
{
    /// <summary>
    /// Curries a function with 2 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, TResult>> Curry<T1, T2, TResult>(this Func<T1, T2, TResult> func)
    {
        return x1 => x2 => func(x1, x2);
    }

    /// <summary>
    /// Curries a function with 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, TResult>>> Curry<T1, T2, T3, TResult>(
        this Func<T1, T2, T3, TResult> func)
    {
        return x1 => x2 => x3 => func(x1, x2, x3);
    }

    /// <summary>
    /// Curries a function with 4 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> Curry<T1, T2, T3, T4, TResult>(
        this Func<T1, T2, T3, T4, TResult> func)
    {
        return x1 => x2 => x3 => x4 => func(x1, x2, x3, x4);
    }

    /// <summary>
    /// Curries a function with 5 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> Curry<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => func(x1, x2, x3, x4, x5);
    }

    /// <summary>
    /// Curries a function with 6 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> Curry<T1, T2, T3, T4, T5, T6,
        TResult>(this Func<T1, T2, T3, T4, T5, T6, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => func(x1, x2, x3, x4, x5, x6);
    }

    /// <summary>
    /// Curries a function with 7 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> Curry<T1, T2, T3, T4,
        T5, T6, T7, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => func(x1, x2, x3, x4, x5, x6, x7);
    }

    /// <summary>
    /// Curries a function with 8 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> Curry<T1, T2,
        T3, T4, T5, T6, T7, T8, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 => func(x1, x2, x3, x4, x5, x6, x7, x8);
    }

    /// <summary>
    /// Curries a function with 9 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>>
        Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 => x9 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9);
    }

    /// <summary>
    /// Curries a function with 10 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, TResult>>>>>>>>>>
        Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func)
    {
        return x1 => x2 =>
            x3 => x4 => x5 => x6 => x7 => x8 => x9 => x10 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10);
    }

    /// <summary>
    /// Curries a function with 11 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3,
            Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, TResult>>>>>>>>>>> Curry<T1, T2,
            T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func)
    {
        return x1 => x2 => x3 => x4 =>
            x5 => x6 => x7 => x8 => x9 => x10 => x11 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11);
    }

    /// <summary>
    /// Curries a function with 12 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4,
            Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, TResult>>>>>>>>>>>> Curry<T1, T2,
            T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 =>
            x7 => x8 => x9 => x10 => x11 => x12 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12);
    }

    /// <summary>
    /// Curries a function with 13 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4,
        Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, TResult>>>>>>>>>>>>> Curry<
        T1,
        T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 =>
            x9 => x10 => x11 => x12 => x13 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13);
    }

    /// <summary>
    /// Curries a function with 14 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5,
            Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, TResult>>>>>>>>>>>>>>
        Curry<T1,
            T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 => x9 => x10 =>
            x11 => x12 => x13 => x14 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14);
    }

    /// <summary>
    /// Curries a function with 15 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7,
        Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, TResult>>>>>>>>>>>>>>> Curry<
        T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 => x9 => x10 => x11 => x12 =>
            x13 => x14 => x15 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15);
    }

    /// <summary>
    /// Curries a function with 16 parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter.</typeparam>
    /// <typeparam name="T2">The type of the second parameter.</typeparam>
    /// <typeparam name="T3">The type of the third parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth parameter.</typeparam>
    /// <typeparam name="T16">The type of the sixteenth parameter.</typeparam>
    /// <typeparam name="TResult">The return type of the function.</typeparam>
    /// <param name="func">The function to be curried.</param>
    /// <returns>A curried version of the input function.</returns>
    public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8,
            Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, Func<T16, TResult>>>>>>>>>>>>>>>>
        Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
            this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func)
    {
        return x1 => x2 => x3 => x4 => x5 => x6 => x7 => x8 => x9 => x10 => x11 => x12 =>
            x13 => x14 => x15 => x16 => func(x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16);
    }
}