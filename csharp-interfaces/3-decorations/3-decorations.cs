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

/// <summary> Decoration </summary>
public class Decoration : Base, IInteractive, IBreakable
{
    ///<summary> isQuestItem Property </summary>
    public bool isQuestItem = false;
    ///<summary> durability Property </summary>
    public int durability { get; set; }

    ///<summary> Decoration Constructor </summary>
    public Decoration(string name = "Decoration", int durability = 1, bool isQuestItem = false)
    {
        if (durability <= 0)
            throw new Exception("Durability must be greater than 0");
        this.name = name;
        this.durability = durability;
        this.isQuestItem = isQuestItem;
    }

    ///<summary> Interact Method </summary>
    public void Interact()
    {
        if (durability <= 0)
        {
            Console.WriteLine("The {0} has been broken.", this.name);
            return;
        }
        if (isQuestItem)
            Console.WriteLine("You look at the {0}. There's a key inside.", this.name);
        else
            Console.WriteLine("You look at the {0}. Not much to see here.", this.name);
    }

    ///<summary> Break Method </summary>
    public void Break()
    {
        durability--;
        if (durability < 0)
            Console.WriteLine("The {0} is already broken.", this.name);
        else if (durability == 0)
            Console.WriteLine("You smash the {0}. What a mess.", this.name);
        else
            Console.WriteLine("You hit the {0}. It cracks.", this.name);
    }

}