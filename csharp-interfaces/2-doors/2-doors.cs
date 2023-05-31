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
/// <summary>
/// Interactive
/// </summary>
public interface IInteractive
{
    /// <summary>
    ///interact 
    /// </summary>
    void Interact();
}
/// <summary>
/// breakable
/// </summary>
public interface IBreakable
{
    /// <summary>
    /// durablity
    /// </summary>
    int durability { get; set; }
    /// <summary>
    /// break
    /// </summary>
    void Break();
}
/// <summary>
/// collect
/// </summary>
public interface ICollectable
{
    /// <summary>
    /// these actually clutter the code so much. Bad practice
    /// </summary>
    bool isCollected { get; set; }
    /// <summary>
    /// collect
    /// </summary>
    void Collect();
}
/// <summary>
///door class 
/// </summary>
public class Door : Base, IInteractive
{
    /// <summary>
    /// sets name of door and default
    /// </summary>
    public Door(string name = "Door")
    {
        this.name = name;
    }
    /// <summary>
    ///interact with door 
    /// </summary>
    public void Interact()
    {
        Console.WriteLine($"You try to open the {name}. It's locked.");
    }
}
