using System;

namespace Enemies
{
    /// <summary>
    /// Second namespace in C# named Enemies which includes
    /// a class of Zombie and its definition
    /// </summary>
    public class Zombie
    {
        /// <summary>
        /// First class Zombie with int health 
        /// </summary>
        public int health;
            /// <summary>
            /// Constructor that sets health to 0 
            /// </summary>

        public Zombie()
        {
            health = 0;
        }
            /// <summary>
            /// Health must be greater than 0 or dead
            /// </summary>
        public Zombie(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Health must be greater than or equal to 0");
            }
        }

    }
}