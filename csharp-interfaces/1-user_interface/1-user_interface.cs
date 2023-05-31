﻿using System;
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
/// <summary>
/// Interactive
/// </summary>
public interface IInteractive
{
    void Interface();
}
/// <summary>
/// breakable
/// </summary>
public interface IBreakable
{
    int durability { get; set; }
    void Break();
}
/// <summary>
/// collect
/// </summary>
public interface ICollectable
{
    bool isCollected { get; set; }
    void Collect();
}