using System;
/// <summary>
/// public class base
/// </summary>
public abstract class Base
{
    /// <summary>
    /// public name
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// ToString override
    /// </summary>
    public override string ToString()
    {
        return $"{name} is a {GetType().Name}";
    }
}
