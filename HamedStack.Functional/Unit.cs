// ReSharper disable RedundantDefaultMemberInitializer
// ReSharper disable UnusedParameter.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertToAutoPropertyWithPrivateSetter

using System.Collections;
using System.Linq.Expressions;
using System.Text.Json;

namespace HamedStack.Functional;

/// <summary>
///     Represents a unit type. This type is typically used to represent the absence of a value, similar to 'void' but
///     usable as a type parameter.
/// </summary>
[Serializable]
public readonly struct Unit : IEquatable<Unit>, IComparable<Unit>, IComparable, IFormattable
{
    /// <summary>
    ///     The default unit value.
    /// </summary>
    private static readonly Unit Default = new();

    /// <summary>
    ///     Gets the default equality comparer for the <see cref="Unit" /> type.
    /// </summary>
    public static IEqualityComparer<Unit> EqualityComparer => EqualityComparer<Unit>.Default;

    /// <summary>
    ///     Gets a completed task with a unit result.
    /// </summary>
    public static Task<Unit> Task { get; } = System.Threading.Tasks.Task.FromResult(Default);

    /// <summary>
    ///     Gets the unit value.
    /// </summary>
    public static Unit Value => Default;

    /// <summary>
    ///     Indicates whether this instance and another unit instance are equal.
    /// </summary>
    public static bool Equals(Unit other)
    {
        return true;
    }

    /// <summary>
    ///     Checks if two unit values are equal using a custom equality comparer.
    /// </summary>
    /// <param name="first">The first unit value.</param>
    /// <param name="second">The second unit value.</param>
    /// <param name="comparer">The custom equality comparer.</param>
    /// <returns>True if the unit values are considered equal; otherwise, false.</returns>
    public static bool Equals(Unit first, Unit second, IEqualityComparer<Unit> comparer)
    {
        return comparer.Equals(first, second);
    }

    /// <summary>
    ///     Converts a JSON string to a unit instance.
    /// </summary>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>A unit instance deserialized from the JSON string.</returns>
    public static Unit FromJson(string json)
    {
        return JsonSerializer.Deserialize<Unit>(json);
    }

    /// <summary>
    ///     Converts a nullable unit to a unit.
    /// </summary>
    /// <param name="nullableUnit">The nullable unit to convert.</param>
    /// <returns>The corresponding unit instance or the default unit if the input is null.</returns>
    public static Unit FromNullable(Unit? nullableUnit)
    {
        return nullableUnit ?? Value;
    }

    /// <summary>
    ///     Returns an enumerator that iterates through a collection with zero elements.
    /// </summary>
    /// <returns>An enumerator that can be used to iterate through the collection.</returns>
    public static IEnumerator GetEnumerator()
    {
        return Enumerable.Empty<object>().GetEnumerator();
    }

    /// <summary>
    ///     Implicitly converts a value tuple to a unit.
    /// </summary>
    public static implicit operator Unit(ValueTuple _)
    {
        return default;
    }

    /// <summary>
    ///     Implicitly converts a unit to a value tuple.
    /// </summary>
    public static implicit operator ValueTuple(Unit _)
    {
        return default;
    }

    /// <summary>
    ///     Subtract two unit values together, returning a unit.
    /// </summary>
    public static Unit operator -(Unit first, Unit second)
    {
        return Default;
    }

    /// <summary>
    ///     Always indicates that two unit values are not equal.
    /// </summary>
    public static bool operator !=(Unit first, Unit second)
    {
        return false;
    }

    /// <summary>
    ///     Multiplies two unit values, returning a unit.
    /// </summary>
    /// <param name="first">The first unit value.</param>
    /// <param name="second">The second unit value.</param>
    /// <returns>The result of the multiplication, which is always a unit.</returns>
    public static Unit operator *(Unit first, Unit second)
    {
        return Default;
    }

    /// <summary>
    ///     Divides two unit values, returning a unit.
    /// </summary>
    /// <param name="numerator">The numerator unit value.</param>
    /// <param name="denominator">The denominator unit value.</param>
    /// <returns>The result of the division, which is always a unit.</returns>
    public static Unit operator /(Unit numerator, Unit denominator)
    {
        return Default;
    }

    /// <summary>
    ///     Adds two unit values together, returning a unit.
    /// </summary>
    public static Unit operator +(Unit first, Unit second)
    {
        return Default;
    }

    /// <summary>
    ///     Always indicates that the first unit value is less than the second.
    /// </summary>
    public static bool operator <(Unit first, Unit second)
    {
        return false;
    }

    /// <summary>
    ///     Always indicates that the first unit value is less than or equal to the second.
    /// </summary>
    public static bool operator <=(Unit first, Unit second)
    {
        return true;
    }

    /// <summary>
    ///     Always indicates that two unit values are equal.
    /// </summary>
    public static bool operator ==(Unit first, Unit second)
    {
        return true;
    }

    /// <summary>
    ///     Always indicates that the first unit value is greater than the second.
    /// </summary>
    public static bool operator >(Unit first, Unit second)
    {
        return false;
    }

    /// <summary>
    ///     Always indicates that the first unit value is greater than or equal to the second.
    /// </summary>
    public static bool operator >=(Unit first, Unit second)
    {
        return true;
    }

    /// <summary>
    ///     Returns the given value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="anything">The value to return.</param>
    public static T Return<T>(T anything)
    {
        return anything;
    }

    /// <summary>
    ///     Invokes a function and returns its result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="anything">The function to invoke.</param>
    public static T Return<T>(Func<T> anything)
    {
        return anything();
    }

    /// <summary>
    ///     Compiles and invokes an expression and returns its result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="anything">The expression to compile and invoke.</param>
    public static T Return<T>(Expression<Func<T>> anything)
    {
        return anything.Compile()();
    }

    /// <summary>
    ///     Compares this instance to another unit instance.
    /// </summary>
    public int CompareTo(Unit other)
    {
        return 0;
    }

    /// <summary>
    ///     Compares this instance to another object.
    /// </summary>
    int IComparable.CompareTo(object? obj)
    {
        return 0;
    }
    /// <summary>
    ///     Determines whether the specified <see cref="Unit" /> is equal to the current unit.
    /// </summary>
    /// <param name="other">The <see cref="Unit" /> to compare with the current unit.</param>
    /// <returns>
    ///     true if the specified <see cref="Unit" /> is equal to the current unit; otherwise, false.
    /// </returns>
    bool IEquatable<Unit>.Equals(Unit other)
    {
        return true;
    }

    /// <summary>
    ///     Indicates whether this instance and an object are equal.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return obj is Unit;
    }

    /// <summary>
    ///     Returns a hash code for this instance.
    /// </summary>
    public override int GetHashCode()
    {
        return 0;
    }

    /// <summary>
    /// Selects a value from the current unit using the specified selector function.
    /// </summary>
    /// <param name="selector">The selector function to apply to the unit.</param>
    /// <returns>The result of applying the selector function to the unit.</returns>
    public Unit Select(Func<Unit, Unit> selector)
    {
        return selector(this);
    }

    /// <summary>
    ///     Converts the current unit to its JSON representation.
    /// </summary>
    /// <returns>A JSON string representing the current unit.</returns>
    public string ToJson()
    {
        return JsonSerializer.Serialize(this);
    }

    /// <summary>
    ///     Converts the current unit to a nullable unit.
    /// </summary>
    /// <returns>A nullable unit representing the current unit.</returns>
    public Unit? ToNullable()
    {
        return this;
    }

    /// <summary>
    ///     Returns a string representation of the unit value.
    /// </summary>
    public override string ToString()
    {
        return "()";
    }

    /// <summary>
    ///     Returns a string representation of the unit value with custom formatting options.
    /// </summary>
    /// <param name="format">A format string.</param>
    /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
    /// <returns>A formatted string representing the unit value.</returns>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return format switch
        {
            "U" => "()",
            _ => throw new FormatException("Invalid format.")
        };
    }
}