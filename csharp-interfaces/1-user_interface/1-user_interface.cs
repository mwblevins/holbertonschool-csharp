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
///Test class 
/// </summary>
public class TestObject : Base, IInteractive, IBreakable, ICollectable
{
    /// <summary>
    /// durable
    /// </summary>
    public int durability { get; set; }
    /// <summary>
    /// collect
    /// </summary>
    public bool isCollected { get; set; }

    /// <summary>
    /// interact
    /// </summary>
    public void Interact()
    {
        throw new NotImplementedException();

    }
    /// <summary>
    /// break
    /// </summary>
    public void Break()
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// collect
    /// </summary>
    public void Collect()
    {
        throw new NotImplementedException();
    }
}