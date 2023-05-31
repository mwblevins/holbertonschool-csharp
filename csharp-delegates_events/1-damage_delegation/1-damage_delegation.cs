using System;

/// <summary>
/// Player class represents a player in a game.
/// </summary>
public class Player
{
    /// <summary>
    /// Player name.
    /// </summary>
    protected string name;

    /// <summary>
    /// Player maximum health points (hp).
    /// </summary>
    protected float maxHp;

    /// <summary>
    /// Player current health points (hp).
    /// </summary>
    protected float hp;

    // Define the delegate
    public delegate void CalculateHealth(float amount);

    /// <summary>
    /// Constructs a new instance of the Player class with the specified name and maximum health points.
    /// </summary>
    /// <param name="name">Player name.</param>
    /// <param name="maxHp">Maximum health points.</param>
    public Player(string name = "Player", float maxHp = 100f)
    {
        this.name = name;
        if (maxHp <= 0f)
        {
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
            maxHp = 100f;
        }
        this.maxHp = maxHp;
        this.hp = this.maxHp;
    }

    /// <summary>
    /// Prints the player's current health information.
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine("{0} has {1} / {2} health", name, hp, maxHp);
    }

    /// <summary>
    /// Takes damage from the player.
    /// </summary>
    /// <param name="damage">Amount of damage to be taken.</param>
    public void TakeDamage(float damage)
    {
        if (damage < 0f)
            damage = 0f;

        Console.WriteLine("{0} takes {1} damage!", name, damage);
        hp -= damage;
        if (hp < 0f)
            hp = 0f;
    }

    /// <summary>
    /// Heals the player.
    /// </summary>
    /// <param name="heal">Amount of health to be healed.</param>
    public void HealDamage(float heal)
    {
        if (heal < 0f)
            heal = 0f;

        Console.WriteLine("{0} heals {1} HP!", name, heal);
        hp += heal;
        if (hp > maxHp)
            hp = maxHp;
    }
}
