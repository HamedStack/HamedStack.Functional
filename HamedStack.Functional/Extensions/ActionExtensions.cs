// ReSharper disable UnusedMember.Global

namespace HamedStack.Functional.Extensions;

/// <summary>
/// Provides extension methods for converting <see cref="Action"/> and <see cref="Action{T}"/> 
/// delegates into <see cref="Func{TResult}"/> returning <see cref="Unit"/>.
/// </summary>
public static class ActionExtensions
{
    /// <summary>
    /// Converts an <see cref="Action"/> delegate to a <see cref="Func{TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<Unit> ToUnitFunc(this Action @this)
    {
        return () =>
        {
            @this();
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T}"/> delegate to a <see cref="Func{T, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T">The type of the input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T, Unit> ToUnitFunc<T>(this Action<T> @this)
    {
        return t =>
        {
            @this(t);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2}"/> delegate to a <see cref="Func{T1, T2, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, Unit> ToUnitFunc<T1, T2>(this Action<T1, T2> @this)
    {
        return (t1, t2) =>
        {
            @this(t1, t2);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3}"/> delegate to a <see cref="Func{T1, T2, T3, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, Unit> ToUnitFunc<T1, T2, T3>(this Action<T1, T2, T3> @this)
    {
        return (t1, t2, t3) =>
        {
            @this(t1, t2, t3);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4}"/> delegate to a <see cref="Func{T1, T2, T3, T4, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, Unit> ToUnitFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> @this)
    {
        return (t1, t2, t3, t4) =>
        {
            @this(t1, t2, t3, t4);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, Unit> ToUnitFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> @this)
    {
        return (t1, t2, t3, t4, t5) =>
        {
            @this(t1, t2, t3, t4, t5);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6>(
        this Action<T1, T2, T3, T4, T5, T6> @this)
    {
        return (t1, t2, t3, t4, t5, t6) =>
        {
            @this(t1, t2, t3, t4, t5, t6);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7>(
        this Action<T1, T2, T3, T4, T5, T6, T7> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7, T8>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9,
        T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7, T8,
        T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh input parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6, T7,
        T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh input parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth input parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> ToUnitFunc<T1, T2, T3, T4, T5, T6,
        T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh input parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth input parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth input parameter.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> ToUnitFunc<T1, T2, T3, T4, T5,
        T6, T7, T8, T9, T10, T11, T12, T13, T14>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            return new Unit();
        };
    }

    /// <summary>
    /// Converts an <see cref="Action{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15}"/> delegate to a <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/> that returns <see cref="Unit"/>.
    /// </summary>
    /// <typeparam name="T1">The type of the first input parameter.</typeparam>
    /// <typeparam name="T2">The type of the second input parameter.</typeparam>
    /// <typeparam name="T3">The type of the third input parameter.</typeparam>
    /// <typeparam name="T4">The type of the fourth input parameter.</typeparam>
    /// <typeparam name="T5">The type of the fifth input parameter.</typeparam>
    /// <typeparam name="T6">The type of the sixth input parameter.</typeparam>
    /// <typeparam name="T7">The type of the seventh input parameter.</typeparam>
    /// <typeparam name="T8">The type of the eighth input parameter.</typeparam>
    /// <typeparam name="T9">The type of the ninth input parameter.</typeparam>
    /// <typeparam name="T10">The type of the tenth input parameter.</typeparam>
    /// <typeparam name="T11">The type of the eleventh input parameter.</typeparam>
    /// <typeparam name="T12">The type of the twelfth input parameter.</typeparam>
    /// <typeparam name="T13">The type of the thirteenth input parameter.</typeparam>
    /// <typeparam name="T14">The type of the fourteenth input parameter.</typeparam>
    /// <typeparam name="T15">The type of the fifteenth input parameter.</typeparam>
    /// <param name="this">The action to convert.</param>
    /// <returns>A <see cref="Func{T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult}"/> returning <see cref="Unit"/>.</returns>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> ToUnitFunc<T1, T2, T3,
        T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(
        this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> @this)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) =>
        {
            @this(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            return new Unit();
        };
    }
}