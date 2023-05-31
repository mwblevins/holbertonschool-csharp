using System;

class Key : Base, ICollectable
{
    public bool isCollected { get; set; }

    public Key(string name = "Key", bool iscollected = false)
    {
        this.name = name;
        this.isCollected = isCollected;
    }

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