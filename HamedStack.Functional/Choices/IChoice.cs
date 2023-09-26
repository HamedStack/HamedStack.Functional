// ReSharper disable UnusedMember.Global

// ReSharper disable UnusedMemberInSuper.Global
namespace HamedStack.Functional.Choices;

public interface IChoice 
{ 
    object? Value { get ; }
    int Index { get; }
}