using System;
/// <summary>
/// Task 2
/// </summary>
public class Obj
{
    /// <summary>
    /// IsOnlyASubclass method
    /// </summary>
    public static bool IsOnlyASubclass(Type derivedType, Type baseType)
    {
        return derivedType.IsSubclassOf(baseType);
    }
}