// ReSharper disable UnusedMember.Global

namespace HamedStack.Functional.Extensions;

/// <summary>
/// Provides extension methods for applying the first parameter of multi-parameter functions.
/// </summary>
public static class ApplyExtensions
{

    /// <summary>
    /// Applies the first parameter to a two-parameter function, returning a function with one parameter.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameter and returns the result.</returns>
    public static Func<T2, TResult> Apply<T1, T2, TResult>(this Func<T1, T2, TResult> func, T1 t1)
    {
        return t2 => func(t1, t2);
    }

    /// <summary>
    /// Applies the first parameter to a three-parameter function, returning a function with two parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, TResult> Apply<T1, T2, T3, TResult>(this Func<T1, T2, T3, TResult> func, T1 t1)
    {
        return (t2, t3) => func(t1, t2, t3);
    }

    /// <summary>
    /// Applies the first parameter to a four-parameter function, returning a function with three parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, TResult> Apply<T1, T2, T3, T4, TResult>(this Func<T1, T2, T3, T4, TResult> func,
        T1 t1)
    {
        return (t2, t3, t4) => func(t1, t2, t3, t4);
    }

    /// <summary>
    /// Applies the first parameter to a five-parameter function, returning a function with four parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, TResult> Apply<T1, T2, T3, T4, T5, TResult>(
        this Func<T1, T2, T3, T4, T5, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5) => func(t1, t2, t3, t4, t5);
    }

    /// <summary>
    /// Applies the first parameter to a six-parameter function, returning a function with five parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, TResult> Apply<T1, T2, T3, T4, T5, T6, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6) => func(t1, t2, t3, t4, t5, t6);
    }

    /// <summary>
    /// Applies the first parameter to a seven-parameter function, returning a function with six parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7) => func(t1, t2, t3, t4, t5, t6, t7);
    }

    /// <summary>
    /// Applies the first parameter to an eight-parameter function, returning a function with seven parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8) => func(t1, t2, t3, t4, t5, t6, t7, t8);
    }

    /// <summary>
    /// Applies the first parameter to a nine-parameter function, returning a function with eight parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9);
    }

    /// <summary>
    /// Applies the first parameter to a ten-parameter function, returning a function with nine parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining nine parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,
        TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
    }

    /// <summary>
    /// Applies the first parameter to an eleven-parameter function, returning a function with ten parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining ten parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10,
        T11, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) => func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
    }

    /// <summary>
    /// Applies the first parameter to a twelve-parameter function, returning a function with eleven parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining eleven parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> Apply<T1, T2, T3, T4, T5, T6, T7, T8, T9,
        T10, T11, T12, TResult>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) =>
            func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
    }

    /// <summary>
    /// Applies the first parameter to a thirteen-parameter function, returning a function with twelve parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter of the original function.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining twelve parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> Apply<T1, T2, T3, T4, T5, T6, T7,
        T8, T9, T10, T11, T12, T13, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) =>
            func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
    }

    /// <summary>
    /// Applies the first parameter to a fourteen-parameter function, returning a function with thirteen parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter of the original function.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter of the original function.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining thirteen parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> Apply<T1, T2, T3, T4, T5, T6,
        T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) =>
            func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
    }

    /// <summary>
    /// Applies the first parameter to a fifteen-parameter function, returning a function with fourteen parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter of the original function.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter of the original function.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter of the original function.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining fourteen parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> Apply<T1, T2, T3, T4, T5,
        T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) =>
            func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
    }

    /// <summary>
    /// Applies the first parameter to a sixteen-parameter function, returning a function with fifteen parameters.
    /// </summary>
    /// <typeparam name="T1">The type of the first parameter of the original function.</typeparam>
    /// <typeparam name="T2">The type of the second parameter of the original function.</typeparam>
    /// <typeparam name="T3">The type of the third parameter of the original function.</typeparam>
    /// <typeparam name="T4">The type of the fourth parameter of the original function.</typeparam>
    /// <typeparam name="T5">The type of the fifth parameter of the original function.</typeparam>
    /// <typeparam name="T6">The type of the sixth parameter of the original function.</typeparam>
    /// <typeparam name="T7">The type of the seventh parameter of the original function.</typeparam>
    /// <typeparam name="T8">The type of the eighth parameter of the original function.</typeparam>
    /// <typeparam name="T9">The type of the ninth parameter of the original function.</typeparam>
    /// <typeparam name="T10">The type of the tenth parameter of the original function.</typeparam>
    /// <typeparam name="T11">The type of the eleventh parameter of the original function.</typeparam>
    /// <typeparam name="T12">The type of the twelfth parameter of the original function.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth parameter of the original function.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth parameter of the original function.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth parameter of the original function.</typeparam>
    /// <typeparam name="T16">The type of the sixteenth parameter of the original function.</typeparam>
    /// <typeparam name="TResult">The type of the return value of the function.</typeparam>
    /// <param name="func">The original function to apply the first parameter to.</param>
    /// <param name="t1">The value to apply to the first parameter of the function.</param>
    /// <returns>A function that accepts the remaining fifteen parameters and returns the result.</returns>
    public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> Apply<T1, T2, T3, T4,
        T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
        this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> func, T1 t1)
    {
        return (t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16) =>
            func(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16);
    }
}