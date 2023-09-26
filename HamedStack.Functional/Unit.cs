// ReSharper disable UnusedMember.Global
// ReSharper disable StringLiteralTypo
// ReSharper disable InconsistentNaming

using System.Linq.Expressions;

namespace HamedStack.Functional;

/// <summary>
/// Represents a unit type. This type is typically used to represent the absence of a value, similar to 'void' but usable as a type parameter.
/// </summary>
public readonly struct Unit : IEquatable<Unit>, IComparable<Unit>, IComparable
{
    /// <summary>
    /// The default unit value.
    /// </summary>
    private static readonly Unit Default = new();

    /// <summary>
    /// Gets a completed task with a unit result.
    /// </summary>
    public static Task<Unit> Task { get; } = System.Threading.Tasks.Task.FromResult(Default);

    /// <summary>
    /// Gets the unit value.
    /// </summary>
    public static ref readonly Unit Value => ref Default;

    /// <summary>
    /// Implicitly converts a value tuple to a unit.
    /// </summary>
    public static implicit operator Unit(ValueTuple _) => default;

    /// <summary>
    /// Implicitly converts a unit to a value tuple.
    /// </summary>
    public static implicit operator ValueTuple(Unit _) => default;

    /// <summary>
    /// Always indicates that two unit values are not equal.
    /// </summary>
    public static bool operator !=(Unit first, Unit second) => false;

    /// <summary>
    /// Adds two unit values together, returning a unit.
    /// </summary>
    
    public static Unit operator +(Unit first, Unit second) => Default;

    /// <summary>
    /// Always indicates that the first unit value is less than the second.
    /// </summary>
    public static bool operator <(Unit first, Unit second) => false;

    /// <summary>
    /// Always indicates that the first unit value is less than or equal to the second.
    /// </summary>
    public static bool operator <=(Unit first, Unit second) => true;

    /// <summary>
    /// Always indicates that two unit values are equal.
    /// </summary>
    public static bool operator ==(Unit first, Unit second) => true;

    /// <summary>
    /// Always indicates that the first unit value is greater than the second.
    /// </summary>
    public static bool operator >(Unit first, Unit second) => false;

    /// <summary>
    /// Always indicates that the first unit value is greater than or equal to the second.
    /// </summary>
    public static bool operator >=(Unit first, Unit second) => true;

    /// <summary>
    /// Compares this instance to another unit instance.
    /// </summary>
    public int CompareTo(Unit other) => 0;

    /// <summary>
    /// Compares this instance to another object.
    /// </summary>
    int IComparable.CompareTo(object? obj) => 0;

    /// <summary>
    /// Indicates whether this instance and another unit instance are equal.
    /// </summary>
    public bool Equals(Unit other) => true;

    /// <summary>
    /// Indicates whether this instance and an object are equal.
    /// </summary>
    public override bool Equals(object? obj) => obj is Unit;

    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    public override int GetHashCode() => 0;

    /// <summary>
    /// Returns the given value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="anything">The value to return.</param>
    public static T Return<T>(T anything) => anything;

    /// <summary>
    /// Invokes a function and returns its result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="anything">The function to invoke.</param>
    public static T Return<T>(Func<T> anything) => anything();

    /// <summary>
    /// Compiles and invokes an expression and returns its result.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="anything">The expression to compile and invoke.</param>
    public static T Return<T>(Expression<Func<T>> anything) => anything.Compile()();

    /// <summary>
    /// Returns a string representation of the unit value.
    /// </summary>
    public override string ToString() => "()";
}
