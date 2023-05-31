using System;

/// <summary>
/// Represents a player with a name, maximum health, current health, and health calculation methods.
/// </summary>
public class Player
{
    private string name;
    private float maxHp;
    private float hp;

    /// <summary>
    /// Initializes a new instance of the Player class with the specified name and maximum health.
    /// </summary>
    /// <param name="name">The name of the player.</param>
    /// <param name="maxHp">The maximum health of the player.</param>
    public Player(string name, float maxHp)
    {
        this.name = name;
        if (maxHp > 0)
        {
            this.maxHp = maxHp;
        }
        else
        {
            this.maxHp = 100f;
            Console.WriteLine("maxHp must be greater than 0. maxHp set to 100f by default.");
        }
        this.hp = this.maxHp;
    }

    /// <summary>
    /// Prints the current health of the player.
    /// </summary>
    public void PrintHealth()
    {
        Console.WriteLine($"{name} has {hp} / {maxHp} health");
    }

    /// <summary>
    /// Delegate for calculating health.
    /// </summary>
    /// <param name="amount">The amount to be calculated.</param>
    public delegate void CalculateHealth(float amount);

    /// <summary>
    /// Takes damage and reduces the player's health accordingly.
    /// </summary>
    /// <param name="damage">The amount of damage to be taken.</param>
    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            damage = 0;
        }

        Console.WriteLine($"{name} takes {damage} damage!");
        hp -= damage;

        if (hp < 0)
        {
            hp = 0;
        }
    }

    /// <summary>
    /// Heals the player and increases their health accordingly.
    /// </summary>
    /// <param name="heal">The amount of HP to be healed.</param>
    public void HealDamage(float heal)
    {
        if (heal < 0)
        {
            heal = 0;
        }

        Console.WriteLine($"{name} heals {heal} HP!");
        hp += heal;

        if (hp > maxHp)
        {
            hp = maxHp;
        }
    }
}
