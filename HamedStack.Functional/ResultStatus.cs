namespace HamedStack.Functional;

#pragma warning disable CS1591

/// <summary>
///     Represents the possible status outcomes for a result.
/// </summary>
public enum ResultStatus
{
    /// <summary>
    ///     Represents a successful operation.
    /// </summary>
    Success,

    /// <summary>
    ///     Represents a generic error outcome.
    /// </summary>
    Failure,

    /// <summary>
    ///     Indicates that the operation is forbidden.
    /// </summary>
    Forbidden,

    /// <summary>
    ///     Indicates that the operation is unauthorized.
    /// </summary>
    Unauthorized,

    /// <summary>
    ///     Indicates invalid input or state.
    /// </summary>
    Invalid,

    /// <summary>
    ///     Indicates that a resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    ///     Indicates that there's a conflict with the requested operation.
    /// </summary>
    Conflict,

    /// <summary>
    ///     Indicates that the operation is unsupported.
    /// </summary>
    Unsupported
}