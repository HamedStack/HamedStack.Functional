// ReSharper disable CommentTypo
// ReSharper disable UnusedMember.Global

namespace HamedStack.Functional.Extensions;

/// <summary>
/// Extension methods for uncurrying curried functions up to 16 parameters.
/// </summary>
public static class UncurryExtensions
{
    /// <summary>
    /// Uncurries a function with two parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts two parameters and returns a result.</returns>
    public static Func<T1, T2, TResult> Uncurry<T1, T2, TResult>(this Func<T1, Func<T2, TResult>> func)
    {
        return (x1, x2) => func(x1)(x2);
    }

    /// <summary>
    /// Uncurries a function with three parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts three parameters and returns a result.</returns>
    public static Func<T1, T2, T3, TResult> Uncurry<T1, T2, T3, TResult>(
        this Func<T1, Func<T2, Func<T3, TResult>>> func)
    {
        return (x1, x2, x3) => func(x1)(x2)(x3);
    }

    /// <summary>
    /// Uncurries a function with four parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts four parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, TResult> Uncurry<T1, T2, T3, T4, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, TResult>>>> func)
    {
        return (x1, x2, x3, x4) => func(x1)(x2)(x3)(x4);
    }

    /// <summary>
    /// Uncurries a function with five parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts five parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, TResult> Uncurry<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, TResult>>>>> func)
    {
        return (x1, x2, x3, x4, x5) => func(x1)(x2)(x3)(x4)(x5);
    }

    /// <summary>
    /// Uncurries a function with six parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts six parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, TResult> Uncurry<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, TResult>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6) => func(x1)(x2)(x3)(x4)(x5)(x6);
    }

    /// <summary>
    /// Uncurries a function with seven parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts seven parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, TResult>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7);
    }

    /// <summary>
    /// Uncurries a function with eight parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts eight parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, TResult>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8);
    }

    /// <summary>
    /// Uncurries a function with nine parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts nine parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, TResult>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9);
    }

    /// <summary>
    /// Uncurries a function with ten parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts ten parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, TResult>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10);
    }

    /// <summary>
    /// Uncurries a function with eleven parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts eleven parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, TResult>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11);
    }

    /// <summary>
    /// Uncurries a function with twelve parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">Type of the twelfth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts twelve parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, TResult>>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11)(x12);
    }

    /// <summary>
    /// Uncurries a function with thirteen parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">Type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">Type of the thirteenth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts thirteen parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, TResult>>>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11)(x12)(x13);
    }

    /// <summary>
    /// Uncurries a function with fourteen parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">Type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">Type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">Type of the fourteenth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts fourteen parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, TResult>>>>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11)(x12)(x13)(x14);
    }

    /// <summary>
    /// Uncurries a function with fifteen parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">Type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">Type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">Type of the fourteenth parameter.</typeparam>
    /// <typeparam name="T15">Type of the fifteenth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts fifteen parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, TResult>>>>>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11)(x12)(x13)(x14)(x15);
    }

    /// <summary>
    /// Uncurries a function with sixteen parameters.
    /// </summary>
    /// <typeparam name="T1">Type of the first parameter.</typeparam>
    /// <typeparam name="T2">Type of the second parameter.</typeparam>
    /// <typeparam name="T3">Type of the third parameter.</typeparam>
    /// <typeparam name="T4">Type of the fourth parameter.</typeparam>
    /// <typeparam name="T5">Type of the fifth parameter.</typeparam>
    /// <typeparam name="T6">Type of the sixth parameter.</typeparam>
    /// <typeparam name="T7">Type of the seventh parameter.</typeparam>
    /// <typeparam name="T8">Type of the eighth parameter.</typeparam>
    /// <typeparam name="T9">Type of the ninth parameter.</typeparam>
    /// <typeparam name="T10">Type of the tenth parameter.</typeparam>
    /// <typeparam name="T11">Type of the eleventh parameter.</typeparam>
    /// <typeparam name="T12">Type of the twelfth parameter.</typeparam>
    /// <typeparam name="T13">Type of the thirteenth parameter.</typeparam>
    /// <typeparam name="T14">Type of the fourteenth parameter.</typeparam>
    /// <typeparam name="T15">Type of the fifteenth parameter.</typeparam>
    /// <typeparam name="T16">Type of the sixteenth parameter.</typeparam>
    /// <typeparam name="TResult">Type of the return value.</typeparam>
    /// <param name="func">The curried function to uncurry.</param>
    /// <returns>A function that accepts sixteen parameters and returns a result.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Uncurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
        this Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, Func<T11, Func<T12, Func<T13, Func<T14, Func<T15, Func<T16, TResult>>>>>>>>>>>>>>>> func)
    {
        return (x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, x11, x12, x13, x14, x15, x16) => func(x1)(x2)(x3)(x4)(x5)(x6)(x7)(x8)(x9)(x10)(x11)(x12)(x13)(x14)(x15)(x16);
    }

}