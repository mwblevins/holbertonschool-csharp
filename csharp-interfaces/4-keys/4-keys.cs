using System;
/// <summary>
/// class Key
/// </summary>
class Key : Base, ICollectable
{
    /// <summary>
    /// Collected
    /// </summary>
    public bool isCollected { get; set; }
    /// <summary>
    /// key constructor
    /// </summary>
    public Key(string name = "Key", bool iscollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }
    /// <summary>
    /// collect method
    /// </summary>
    public void Collect()
    {
        if (this.isCollected == false)
        {
            this.isCollected = true;
            Console.WriteLine("You pick up the {0}.", this.name);
        }
        else
            Console.WriteLine("You have already picked up the {0}.", this.name);
    }
}